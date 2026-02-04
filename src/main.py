
# =================================================================================================
# BUNDLED APPLICATION - Windows Scaler
# Consolidating gui.py, capturer.py, and main.py into a single file to solve PyInstaller issues.
# =================================================================================================

import tkinter as tk
from tkinter import ttk, messagebox
from PIL import Image, ImageTk
import json
import os
import sys
import time
import threading
import mss

# ====================
# CAPTURER.PY CONTENT
# ====================

class ScreenCapturer:
    def __init__(self):
        self.sct = mss.mss()
        self.last_frame = None
        self.lock = threading.Lock()
        
    def capture_frame(self, x, y, width, height):
        """
        Captures a region of the screen.
        Returns a PIL Image.
        """
        monitor = {"top": y, "left": x, "width": width, "height": height}
        
        try:
            # mss returns a numpy-compatible array, we verify if it works
            # grab returns a MSSImage which can be converted to PIL
            sct_img = self.sct.grab(monitor)
            
            # Convert to PIL Image
            img = Image.frombytes("RGB", sct_img.size, sct_img.bgra, "raw", "BGRX")
            return img
        except Exception as e:
            # In case of error (e.g. coordinates out of screen), return None
            # print(f"Capture error: {e}")
            return None

    def close(self):
        self.sct.close()

# ====================
# GUI.PY CONTENT
# ====================

# Safe Settings Path in %LOCALAPPDATA%
APPDATA = os.getenv('LOCALAPPDATA')
SETTINGS_DIR = os.path.join(APPDATA, "WindowsScaler")
if not os.path.exists(SETTINGS_DIR):
    os.makedirs(SETTINGS_DIR)
SETTINGS_FILE = os.path.join(SETTINGS_DIR, "settings.json")

class OutputWindow(tk.Toplevel):
    def __init__(self, master, x, y, width, height):
        super().__init__(master)
        self.geometry(f"{width}x{height}+{x}+{y}")
        self.overrideredirect(True)  # Borderless
        self.attributes("-topmost", True)
        self.configure(bg='black')
        
        self.canvas = tk.Canvas(self, width=width, height=height, bg='black', highlightthickness=0)
        self.canvas.pack(fill=tk.BOTH, expand=True)
        self.image_id = None
        self.photo = None  # Keep reference to avoid GC

    def update_image(self, img):
        self.photo = ImageTk.PhotoImage(img)
        if self.image_id is None:
            self.image_id = self.canvas.create_image(0, 0, image=self.photo, anchor=tk.NW)
        else:
            self.canvas.itemconfig(self.image_id, image=self.photo)

class OverlayWindow(tk.Toplevel):
    def __init__(self, master, color, label_text):
        super().__init__(master)
        self.overrideredirect(True)
        self.attributes("-topmost", True)
        self.attributes("-alpha", 0.5)  # Semi-transparent
        
        self.configure(bg=color)
        
        # Border frame
        self.frame = tk.Frame(self, bg=color, bd=5, relief="flat")
        self.frame.pack(fill=tk.BOTH, expand=True)
        
        # Inner transparent-ish part
        self.label = tk.Label(self.frame, text=label_text, fg="white", bg=color, font=("Arial", 12, "bold"))
        self.label.place(relx=0.5, rely=0.5, anchor="center")

    def update_position(self, x, y, width, height):
        self.geometry(f"{width}x{height}+{x}+{y}")

class MainWindow:
    def __init__(self, root, start_callback, stop_callback):
        self.root = root
        self.root.title("Window Scaler")
        
        # Center the window
        w = 600
        h = 300
        sw = self.root.winfo_screenwidth()
        sh = self.root.winfo_screenheight()
        x = (sw - w) // 2
        y = (sh - h) // 2
        self.root.geometry(f"{w}x{h}+{x}+{y}")
        
        # Set Icon
        try:
            icon_path = "app_icon.png"
            if hasattr(sys, '_MEIPASS'):
                icon_path = os.path.join(sys._MEIPASS, "app_icon.png")
            
            if os.path.exists(icon_path):
                icon = tk.PhotoImage(file=icon_path)
                self.root.iconphoto(True, icon)
        except Exception:
            pass

        self.start_callback = start_callback
        self.stop_callback = stop_callback
        self.is_running = False
        
        self.input_overlay = None
        self.output_overlay = None

        self.settings = self.load_settings()
        self.window_state = self.settings.get("window_state", "normal")

        self.create_widgets()
        
    def load_settings(self):
        default_settings = {
            "input_x": 0, "input_y": 0, "input_w": 800, "input_h": 600,
            "output_x": 800, "output_y": 0, "output_w": 800, "output_h": 600,
            "fps": 30,
            "window_state": "normal"
        }
        
        # 1. Try Python settings
        if os.path.exists(SETTINGS_FILE):
            try:
                with open(SETTINGS_FILE, "r") as f:
                    return {**default_settings, **json.load(f)}
            except:
                pass # Fall through to C# settings or default

        # 2. Try C# settings
        try:
            program_data = os.environ.get("ProgramData", "C:\\ProgramData")
            csharp_path = os.path.join(program_data, "Samsung", "theApp", "SystemConfiguration", "theApp-003.json")
            
            if os.path.exists(csharp_path):
                with open(csharp_path, "r") as f:
                    c_settings = json.load(f)
                    
                return {
                    "input_x": c_settings.get("InputX", default_settings["input_x"]),
                    "input_y": c_settings.get("InputY", default_settings["input_y"]),
                    "input_w": c_settings.get("InputWidth", default_settings["input_w"]),
                    "input_h": c_settings.get("InputHeight", default_settings["input_h"]),
                    "output_x": c_settings.get("OutputX", default_settings["output_x"]),
                    "output_y": c_settings.get("OutputY", default_settings["output_y"]),
                    "output_w": c_settings.get("OutputWidth", default_settings["output_w"]),
                    "output_h": c_settings.get("OutputHeight", default_settings["output_h"]),
                    "fps": c_settings.get("MaxFPS", default_settings["fps"]),
                    "window_state": "normal"
                }
        except Exception as e:
            print(f"Failed to import C# settings: {e}")

        return default_settings

    def get_settings_from_ui(self):
        # Prevent crash if called before init is complete
        if not hasattr(self, 'fps_var'):
            raise RuntimeError("GUI not fully initialized")

        def safe_int(var, default=0):
            try:
                val = var.get()
                if not val: return default
                return int(float(val)) # Handling float strings just in case
            except (ValueError, tk.TclError):
                return default

        # Capture window state (normal, iconic, withdrawn)
        current_state = "normal"
        try:
            current_state = self.root.state()
        except:
            pass

        return {
            "input_x": safe_int(self.input_x),
            "input_y": safe_int(self.input_y),
            "input_w": safe_int(self.input_w),
            "input_h": safe_int(self.input_h),
            "output_x": safe_int(self.output_x),
            "output_y": safe_int(self.output_y),
            "output_w": safe_int(self.output_w),
            "output_h": safe_int(self.output_h),
            "fps": safe_int(self.fps_var, 30),
            "is_running": self.is_running_var.get(),
            "window_state": current_state
        }

    def save_settings(self):
        try:
            settings = self.get_settings_from_ui()
        except RuntimeError:
            return # Skip saving during init
            
        with open(SETTINGS_FILE, "w") as f:
            json.dump(settings, f)
        
        # Update overlays if they exist
        if self.input_overlay:
            self.input_overlay.update_position(
                settings["input_x"], settings["input_y"], 
                settings["input_w"], settings["input_h"]
            )
        if self.output_overlay:
            self.output_overlay.update_position(
                settings["output_x"], settings["output_y"], 
                settings["output_w"], settings["output_h"]
            )
            
        return settings

    def set_window_visible(self, visible):
        if visible:
            self.window_state = "normal"
            self.root.deiconify()
        else:
            self.window_state = "withdrawn"
            self.root.withdraw()
        self.save_settings()

    def create_widgets(self):
        # Container for Input/Output to be side-by-side
        io_container = ttk.Frame(self.root)
        io_container.pack(padx=10, pady=5, fill="x")

        # Input Frame
        input_frame = ttk.LabelFrame(io_container, text="Input Region")
        input_frame.pack(side=tk.LEFT, padx=5, fill="both", expand=True)
        
        self.input_x = self.create_spinbox(input_frame, "X:", 0, 0, 10000)
        self.input_y = self.create_spinbox(input_frame, "Y:", 1, 0, 10000)
        self.input_w = self.create_spinbox(input_frame, "W:", 2, 1, 10000)
        self.input_h = self.create_spinbox(input_frame, "H:", 3, 1, 10000)
        
        # Output Frame
        output_frame = ttk.LabelFrame(io_container, text="Output Region")
        output_frame.pack(side=tk.LEFT, padx=5, fill="both", expand=True)
        
        self.output_x = self.create_spinbox(output_frame, "X:", 0, 0, 10000)
        self.output_y = self.create_spinbox(output_frame, "Y:", 1, 0, 10000)
        self.output_w = self.create_spinbox(output_frame, "W:", 2, 1, 10000)
        self.output_h = self.create_spinbox(output_frame, "H:", 3, 1, 10000)
        
        # Set values
        self.input_x.set(self.settings["input_x"])
        self.input_y.set(self.settings["input_y"])
        self.input_w.set(self.settings["input_w"])
        self.input_h.set(self.settings["input_h"])
        
        self.output_x.set(self.settings["output_x"])
        self.output_y.set(self.settings["output_y"])
        self.output_w.set(self.settings["output_w"])
        self.output_h.set(self.settings["output_h"])
        
        # Controls Frame
        ctrl_frame = ttk.Frame(self.root)
        ctrl_frame.pack(padx=10, pady=5, fill="x")
        
        ttk.Label(ctrl_frame, text="FPS:").pack(side=tk.LEFT)
        self.fps_var = tk.IntVar(value=self.settings["fps"])
        ttk.Spinbox(ctrl_frame, from_=5, to=60, textvariable=self.fps_var, width=5).pack(side=tk.LEFT, padx=5)
        
        # Capture Toggle
        self.is_running_var = tk.BooleanVar(value=self.settings.get("is_running", False))
        self.chk_running = ttk.Checkbutton(
            ctrl_frame, 
            text="Capture Active", 
            variable=self.is_running_var, 
            command=self.toggle_capture
        )
        self.chk_running.pack(side=tk.LEFT, padx=5)
        
        # Tools Frame
        tools_frame = ttk.LabelFrame(self.root, text="Tools")
        tools_frame.pack(padx=10, pady=5, fill="x")
        
        self.btn_overlays = ttk.Button(tools_frame, text="Show Overlays", command=self.toggle_overlays)
        self.btn_overlays.pack(side=tk.LEFT, padx=5, pady=5)
        
        ttk.Button(tools_frame, text="Offset Output on Right", command=self.set_output_right).pack(side=tk.LEFT, padx=5, pady=5)
        ttk.Button(tools_frame, text="2x Size", command=self.set_2x_size).pack(side=tk.LEFT, padx=5, pady=5)
        ttk.Button(tools_frame, text="1/2 Size", command=self.set_half_size).pack(side=tk.LEFT, padx=5, pady=5)

        # Auto-start if saved as running
        if self.is_running_var.get():
             self.root.after(100, lambda: self.start_callback(self.save_settings()))

    def create_spinbox(self, parent, label, row, min_val, max_val):
        ttk.Label(parent, text=label).grid(row=row, column=0, padx=5, pady=2, sticky="e")
        var = tk.StringVar()
        sp = ttk.Spinbox(parent, from_=min_val, to=max_val, textvariable=var, width=10)
        sp.grid(row=row, column=1, padx=5, pady=2)
        var.trace_add("write", lambda *args: self.save_settings())
        return var

    def toggle_capture(self):
        is_active = self.is_running_var.get()
        if is_active:
            settings = self.save_settings()
            self.start_callback(settings)
        else:
            self.stop_callback()
            self.save_settings()

    def toggle_overlays(self):
        if self.input_overlay:
            self.input_overlay.destroy()
            self.input_overlay = None
            self.output_overlay.destroy()
            self.output_overlay = None
            self.btn_overlays.config(text="Show Overlays")
        else:
            self.input_overlay = OverlayWindow(self.root, "green", "INPUT")
            self.output_overlay = OverlayWindow(self.root, "red", "OUTPUT")
            s = self.get_settings_from_ui()
            self.input_overlay.update_position(s["input_x"], s["input_y"], s["input_w"], s["input_h"])
            self.output_overlay.update_position(s["output_x"], s["output_y"], s["output_w"], s["output_h"])
            self.btn_overlays.config(text="Hide Overlays")

    def set_output_right(self):
        ix = int(self.input_x.get())
        iw = int(self.input_w.get())
        self.output_x.set(ix + iw)
        self.output_y.set(self.input_y.get())
        self.save_settings()

    def set_2x_size(self):
        iw = int(self.input_w.get())
        ih = int(self.input_h.get())
        self.output_w.set(iw * 2)
        self.output_h.set(ih * 2)
        self.save_settings()

    def set_half_size(self):
        iw = int(self.input_w.get())
        ih = int(self.input_h.get())
        new_w = max(1, iw // 2)
        new_h = max(1, ih // 2)
        self.output_w.set(new_w)
        self.output_h.set(new_h)
        self.save_settings()
        
    def on_close(self):
        self.save_settings()
        self.root.destroy()

# ====================
# MAIN.PY LOGIC
# ====================

def resource_path(relative_path):
    """ Get absolute path to resource, works for dev and for PyInstaller """
    try:
        base_path = sys._MEIPASS
    except Exception:
        base_path = os.path.dirname(__file__)
        
    # Check if file exists at base path
    full_path = os.path.join(base_path, relative_path)
    if os.path.exists(full_path):
        return full_path
        
    # If not, and we are in dev mode (not frozen), check ../assets
    if not hasattr(sys, '_MEIPASS'):
        assets_path = os.path.join(os.path.dirname(base_path), "assets", relative_path)
        if os.path.exists(assets_path):
            return assets_path
            
    return full_path

def show_splash(root):
    splash_path = resource_path("splash.png")
    if not os.path.exists(splash_path):
        return None

    try:
        img = Image.open(splash_path)
    except Exception:
        return None
    
    splash = tk.Toplevel(root)
    splash.overrideredirect(True)
    splash.attributes("-topmost", True)
    
    w, h = img.size
    ws = root.winfo_screenwidth()
    hs = root.winfo_screenheight()
    x = int((ws/2) - (w/2))
    y = int((hs/2) - (h/2))
    splash.geometry(f'{w}x{h}+{x}+{y}')
    
    photo = ImageTk.PhotoImage(img)
    label = tk.Label(splash, image=photo, borderwidth=0)
    label.image = photo 
    label.pack()
    
    return splash

class AppController:
    def __init__(self, root):
        self.root_tk = root
        
        # Direct reference to local classes
        self.MainWindow = MainWindow
        self.OutputWindow = OutputWindow
        self.ScreenCapturer = ScreenCapturer
        
        self.capturer = None
        self.output_window = None
        self.settings = None
        
        self.gui = self.MainWindow(self.root_tk, self.start_capture, self.stop_capture)
        self.root_tk.protocol("WM_DELETE_WINDOW", self.on_close)
        
        self.is_running = False
        self.tray_icon = None

    def start_capture(self, settings):
        self.settings = settings
        self.capturer = self.ScreenCapturer()
        
        self.output_window = self.OutputWindow(
            self.root_tk, 
            settings["output_x"], 
            settings["output_y"], 
            settings["output_w"], 
            settings["output_h"]
        )
        
        self.is_running = True
        self.capture_loop()

    def stop_capture(self):
        self.is_running = False
        if self.output_window:
            self.output_window.destroy()
            self.output_window = None
        if self.capturer:
            self.capturer.close()
            self.capturer = None
            
    def capture_loop(self):
        if not self.is_running:
            return

        try:
            current_settings = self.gui.get_settings_from_ui()
            self.settings = current_settings
        except Exception:
            pass 

        if self.output_window:
             pass

        img = self.capturer.capture_frame(
            self.settings["input_x"],
            self.settings["input_y"],
            self.settings["input_w"],
            self.settings["input_h"]
        )

        if img:
            if (self.settings["input_w"] != self.settings["output_w"] or 
                self.settings["input_h"] != self.settings["output_h"]):
                img = img.resize((self.settings["output_w"], self.settings["output_h"]), Image.Resampling.LANCZOS)
            
            if self.output_window:
                self.output_window.update_image(img)

        if self.is_running:
            interval = int(1000 / self.settings["fps"])
            self.root_tk.after(interval, self.capture_loop)

    def on_close(self):
        try:
            if self.tray_icon:
                self.tray_icon.stop()
        except:
            pass
            
        try:
            self.stop_capture()
            self.gui.save_settings()
        except:
            pass
            
        try:
            self.root_tk.destroy()
        except:
            pass
            
        sys.exit(0)

def main():
    import win32event
    import win32api
    import winerror
    
    mutex_name = "Global\\Window_Scaler_Python_Instance_Mutex"
    mutex = win32event.CreateMutex(None, False, mutex_name)
    last_error = win32api.GetLastError()
    
    if last_error == winerror.ERROR_ALREADY_EXISTS:
        return

    root = tk.Tk()
    root.withdraw() 
    
    start_time = time.time()
    splash = show_splash(root)
    root.update() 
    
    def load_app():
        try:
            elapsed = time.time() - start_time
            if elapsed < 2.0:
                root.after(int((2.0 - elapsed) * 1000), load_app)
                return
            
            if splash:
                splash.destroy()
                
            global app
            app = AppController(root)
            
            w_state = app.gui.window_state
            if w_state == "withdrawn":
                root.withdraw()
            elif w_state == "iconic":
                root.iconify()
            else:
                root.deiconify()
                
            setup_tray(app, root)
            
        except Exception as e:
            import traceback
            import tkinter.messagebox
            err = traceback.format_exc()
            tkinter.messagebox.showerror("Startup Error", f"An error occurred during startup:\n\n{err}")
            root.destroy()

    def setup_tray(app, root):
        import pystray
        from pystray import Icon, Menu, MenuItem
        from PIL import Image
        import threading
        
        def on_show(icon, item):
            root.after(0, lambda: app.gui.set_window_visible(True))

        def on_hide(icon, item):
            root.after(0, lambda: app.gui.set_window_visible(False))

        def on_quit(icon, item):
            icon.stop()
            root.after(0, app.on_close)

        try:
            if hasattr(sys, '_MEIPASS'):
                icon_path = os.path.join(sys._MEIPASS, "app_icon.png")
            else:
                icon_path = "app_icon.png"
            
            image = Image.open(icon_path)
        except Exception:
            try:
                if hasattr(sys, '_MEIPASS'):
                    icon_path = os.path.join(sys._MEIPASS, "splash.png")
                else:
                    icon_path = "splash.png"
                image = Image.open(icon_path)
                image.thumbnail((64, 64))
            except:
                 image = Image.new('RGB', (64, 64), color = 'blue')

        menu = Menu(
            MenuItem('Show', on_show),
            MenuItem('Hide', on_hide),
            MenuItem('Exit', on_quit)
        )
        
        try:
            icon = Icon("WindowScaler", image, "Window Scaler", menu)
            t = threading.Thread(target=icon.run, daemon=True)
            t.start()
            app.tray_icon = icon
        except Exception:
            pass

    root.after(100, load_app)
    root.mainloop()

if __name__ == "__main__":
    main()
