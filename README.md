<p align="center">
  <img src="icon.svg" width="128" height="128" alt="Lite Screen Recorder Circular Icon">
</p>

<h1 align="center">Lite Screen Recorder v2.0 (Pro Edition)</h1>

<p align="center">
  <b>Ultra-Lightweight, Feature-Packed Desktop Screen & Audio Recorder for Windows (C# / WinForms .NET 4.7.2)</b><br>
  Developed & Branded by <b>ㅤᏞᴀᴢʏㅤᎷꫝʏᴀɴк まやんく (<a href="https://github.com/xboyrex">@xboyrex</a> / Mayank Droid)</b>
</p>

<p align="center">
  <a href="https://github.com/xboyrex/Lite-Screen-Recorder/actions">
    <img alt="GitHub Actions Build" src="https://img.shields.io/github/actions/workflow/status/xboyrex/Lite-Screen-Recorder/build.yml?label=Windows%20Build&logo=github">
  </a>
  <a href="https://github.com/xboyrex/Lite-Screen-Recorder/releases">
    <img alt="GitHub Release" src="https://img.shields.io/github/v/release/xboyrex/Lite-Screen-Recorder?include_prereleases&color=00E676">
    <img alt="GitHub Downloads" src="https://img.shields.io/github/downloads/xboyrex/Lite-Screen-Recorder/total?color=00F2FE">
  </a>
  <a href="LICENSE">
    <img alt="License: GPL-3.0" src="https://img.shields.io/badge/License-GPL%20v3.0-FF1744.svg">
  </a>
</p>

---

## Admin

| Field | Details |
| :--- | :--- |
| **Developer / Brand** | **ㅤᏞᴀᴢʏㅤᎷꫝʏᴀɴк まやんく** (`Mayank Droid` / `@xboyrex` · `he/him`) |
| **Tagline** | `Android modding - Web/ App ( developer - etc..` |
| **Email** | [xboyrex496@gmail.com](mailto:xboyrex496@gmail.com) |
| **GitHub** | [https://github.com/xboyrex](https://github.com/xboyrex) |
| **Instagram** | [@mayank.zx7](https://www.instagram.com/mayank.zx7) |
| **YouTube Channels** | [@mayankdroid](https://youtube.com/@mayankdroid?si=slX8DDU0dpLSIYyY) • [@onyxdroid89](https://youtube.com/@onyxdroid89?si=9gxpZfa3bpI9PKku) |
| **Telegram** | [@MayankDroid7](https://t.me/MayankDroid7) • [@OnyxHub7](https://t.me/OnyxHub7) |

---

## ✨ Complete Pro Features

- 🎥 **High-Speed AVI Screen Recording**: Motion JPEG (`25%`, `50%`, `75%`, `90% Ultra`, `100% Original`) & Uncompressed RGB recording.
- ⚡ **Configurable Frame Rate (FPS)**: Record at `10 FPS`, `15 FPS`, `24 FPS`, `30 FPS`, or `60 FPS`.
- ⏸️ **Pause & Resume Recording (`Alt+P`)**: Pause and resume anytime without splitting your video file or losing audio sync.
- 🖱️ **Cursor Capture & Click Highlight Effects**: Captures the mouse cursor accurately across all monitors and draws glowing highlight rings on Left-Click (`Red`) and Right-Click (`Cyan`).
- 🏷️ **Live Brand Watermark & Timestamp Overlay**: Automatically stamp customizable watermark text (`Lite Screen Recorder • @xboyrex`) and/or a live `YYYY-MM-DD HH:mm:ss` timestamp onto recorded video frames.
- 📸 **Instant Full-Res Screenshot (`Alt+S`)**: Snap a lossless `.png` screenshot of the selected capture region at any time (even during active video recording).
- ⏱️ **Countdown Delay & Auto-Stop Timer**: Choose a `3s`, `5s`, or `10s` pre-recording countdown and set an optional Auto-Stop duration (`1 min` to `60 min`).
- 🖥️ **Multi-Monitor, FHD/HD Presets & Custom Area**: Record your Primary Screen, Secondary Monitors, Everything, `1920x1080 (FHD)`, `1280x720 (HD)`, or a draggable/resizable Custom Area with `Hide Taskbar` support.
- 🔊 **System Audio + Microphone Recording**: Record system loopback soundcard audio (`WASAPI`) or any microphone (`WaveIn`) with live volume meter, `Mute (Alt+M)`, and optional separate `.wav` track export.
- 🔄 **Working Auto-Updater & Changelog Viewer (`F2`)**: Automatically checks `xboyrex/Lite-Screen-Recorder` GitHub Releases, displays the full Markdown release changelog, downloads updates with a live progress bar, and self-installs updates automatically.
- 🟢 **Circular High-Visibility Icon**: Includes vector `icon.svg` and multi-resolution `rec.ico` / `LiteScreenRecorder.ico` + `create_desktop_shortcut.bat`.

---

## ⌨️ Global Hotkeys & Shortcuts

| Shortcut | Action |
| :--- | :--- |
| `Alt + R` | **Start / Stop** Screen Recording |
| `Alt + P` | **Pause / Resume** Active Recording |
| `Alt + M` | **Mute / Unmute** Audio Recording |
| `Alt + S` | **Take Instant PNG Screenshot** of Selected Region |
| `Ctrl + P` | Toggle **Live Screen Preview** Panel |
| `Ctrl + T` | Toggle **Always on Top** Mode |
| `Ctrl + ,` | Open **Settings** Dialog |
| `F2` | Open **Auto-Updater & Changelog Viewer** |
| `F1` | Open **About & Developer Links (`@xboyrex`)** |

---

## 🛠️ One-Click Local Build & Run (Windows)

This repository includes pre-bundled dependencies in `packages/` so you can build and test immediately on Windows:

1. **Build the Release Binary**:
   Double-click **`build.bat`** (or run `.\build.bat` in Command Prompt / PowerShell).
   - Automatically detects Visual Studio `MSBuild.exe` or Windows built-in `.NET Framework v4.0.30319\MSBuild.exe`.
   - Outputs `quick-screen-recorder\bin\Release\Lite-Screen-Recorder.exe`.
2. **Run & Test Immediately**:
   Double-click **`run.bat`** (automatically builds if needed and launches `Lite-Screen-Recorder.exe`).
3. **Create Circular Desktop Icon**:
   Double-click **`create_desktop_shortcut.bat`** to place the circular **Lite Screen Recorder** launcher on your Windows Desktop.

---

## Termux — Create & Push the GitHub Repository

The project includes a guarded Termux deployment script. It authenticates through GitHub CLI, creates the public repository under the authenticated account, stages the source, pushes `main`, and pushes the `v2.0.0` release tag when that tag does not already exist.

```bash
chmod +x termux_push.sh
./termux_push.sh
```

Run this script from the extracted `Lite-Screen-Recorder` project directory. On first run, provide a GitHub token with repository creation and repository contents write permissions when prompted. The token is passed to GitHub CLI and is never written into the Git remote URL.

**Safety:** the script does not force-push, does not overwrite an existing remote origin, and does not replace an existing release tag. If the GitHub repository already contains unrelated commits, the normal push will stop with a non-fast-forward error rather than destroying remote history. Resolve that repository state manually before retrying.

The `v2.0.0` tag triggers `.github/workflows/build.yml`. Check the Actions page for the actual Windows build result; pushing a tag does not guarantee that compilation or release publication succeeds.

## GitHub Actions — EXE + MSI + Portable ZIP

Every push to `main`/`master` and every pull request runs a Windows build on `windows-latest`.

The workflow:
1. Compiles the WinForms application in Release mode with MSBuild.
2. Verifies the executable and all required runtime DLLs.
3. Builds `LiteScreenRecorder-Setup.msi` using pinned WiX Toolset 5.0.2.
4. Creates `Lite-Screen-Recorder-Portable.zip` from the complete runtime output.
5. Uploads all three artifacts to the Actions run.
6. Publishes all three files to GitHub Releases when a `v*` tag is pushed.

**Artifacts**
- `Lite-Screen-Recorder.exe` — application executable (requires the companion DLLs to be alongside it; use the portable ZIP for a ready-to-run folder).
- `LiteScreenRecorder-Setup.msi` — Windows Installer package with a Start Menu shortcut.
- `Lite-Screen-Recorder-Portable.zip` — executable and its runtime dependencies.

The MSI is built with WiX rather than the legacy Visual Studio `.vdproj`, so the GitHub runner does not need the Visual Studio Installer Projects extension. The legacy `.vdproj` is retained as source/reference but is not used by CI.

To publish a release after the workflow changes have been pushed, create and push a new, unused tag (for example `v2.0.1`). Do not force-update an existing release tag. Alternatively, run the workflow manually and provide a new `release_tag`.

## 📄 License

Licensed under the **GNU General Public License v3.0 (GPL-3.0)** — Copyright © 2026 **ㅤᏞᴀᴢʏㅤᎷꫝʏᴀɴк まやんく (`@xboyrex`)**.
