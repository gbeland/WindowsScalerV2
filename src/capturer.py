import mss
from PIL import Image
import threading
import time

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
