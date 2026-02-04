# Window Scaler v2.0

**Window Scaler** is a lightweight, high-performance Windows utility that allows you to capture a specific region of your screen and clone it to a borderless, always-on-top window. It is perfect for monitoring specific areas, scaling up small UI elements, or creating stream overlays.

![Window Scaler Icon](assets/app_icon.png)

## Features

-   **Region Cloning**: Select any area of your screen (X, Y, Width, Height) to capture.
-   **Live Scaling**: Resize the output window to zoom in (2x) or shrink (1/2) the captured content in real-time.
-   **Picture-in-Picture**: The output window is borderless and stays on top of other windows.
-   **Low Latency**: Built with `mss` for ultra-fast screen capture (up to 60 FPS).
-   **Persistent State**: Remembers your window position, capture region, and running state between restarts.
-   **System Tray Integration**: Minimizes to the system tray to run quietly in the background.
-   **Startup Support**: Can automatically start with Windows (configurable via installer).

## Installation

### Option A: Installer (Recommended)
[Download Installer (WindowScalerSetup.exe)](dist/WindowScalerSetup.exe?raw=true)  
*(Location: `dist/WindowScalerSetup.exe`)*

This will:
- Install Window Scaler to your local AppData folder.
- Create a Desktop shortcut.
- (Optional) Add Window Scaler to your Windows Startup apps.

### Option B: Standalone Application
[Download Portable App (Window Scaler.exe)](dist/Window%20Scaler.exe?raw=true)  
*(Location: `dist/Window Scaler.exe`)*

You can place this file anywhere and run it directly.

## Development

### Prerequisites
-   Python 3.8+
-   Inno Setup 6 (for building the installer)

### Setup
1.  Clone the repository:
    ```bash
    git clone https://github.com/YOUR_USERNAME/WindowsScalerV2.git
    cd WindowsScalerV2
    ```
2.  Install dependencies:
    ```bash
    pip install -r requirements.txt
    ```

### Running from Source
```bash
python src/main.py
```

### Building the Executable
This project uses **PyInstaller** to create the standalone EXE.
run:
```bash
pyinstaller --noconfirm --onefile --windowed --paths src --add-data "assets/splash.png;." --add-data "assets/app_icon.png;." --name "Window Scaler" --icon "assets/app_icon.ico" --distpath dist --workpath build --specpath . src/main.py
```

### Building the Installer
This project uses **Inno Setup**.
1.  Ensure Inno Setup 6 is installed.
2.  Compile the script:
    ```bash
    ISCC setup.iss
    ```
    *(Or right-click `setup.iss` and select "Compile")*

## License
MIT License.
