# 📋 Lite Screen Recorder — Official Changelog

All notable changes to **Lite Screen Recorder** by **ㅤᏞᴀᴢʏㅤᎷꫝʏᴀɴк まやんく (`@xboyrex` / Mayank Droid)** are documented in this file.

## [v2.0.0] — Pro Edition (2026-11-04)

### 🚀 New Pro Features Added
- **Complete Rebranding**: Official **Lite Screen Recorder** branding by **ㅤᏞᴀᴢʏㅤᎷꫝʏᴀɴк まやんく (`@xboyrex`)** across all windows, metadata, watermarks, and About dialog.
- **Selectable Frame Rate (FPS)**: Choose between `10 FPS`, `15 FPS`, `24 FPS`, `30 FPS`, and `60 FPS` recording modes, plus `90% - Ultra (MJPEG)` quality tier.
- **Pause & Resume Recording (`Alt+P`)**: Pause and resume active screen recordings seamlessly from the recording bar or via `Alt+P` global hotkey with automatic audio/video sync.
- **Mouse Click Highlight Effects**: Real-time visual click rings (`Red` for Left-Click, `Cyan` for Right-Click) rendered around the cursor during recording and live preview.
- **Live Brand Watermark & Timestamp Overlay**: Stamp custom watermark text (`Lite Screen Recorder • @xboyrex`) and/or a live `YYYY-MM-DD HH:mm:ss` clock badge onto recorded video frames.
- **Instant High-Res Screenshot (`Alt+S` / `📸 Shot`)**: Capture lossless `.png` screenshots of the selected capture area anytime (before or during recording).
- **Pre-Recording Countdown & Auto-Stop Timer**: Optional `3s`, `5s`, or `10s` countdown before recording starts, plus configurable Auto-Stop duration (`1m`, `5m`, `10m`, `15m`, `30m`, `60m`).
- **System Tray Minimize Mode**: Hide the recording controller to the Windows System Tray during recording and double-click the tray icon to restore.
- **Auto-Updater & Live Changelog Viewer (`F2`)**: Built-in GitHub Releases (`xboyrex/Lite-Screen-Recorder`) update checker with live Markdown changelog viewer, download progress bar, and automatic self-installation.
- **Circular SVG & Multi-DPI Desktop Icon**: High-visibility circular launcher icon (`icon.svg` & `rec.ico`) + one-click `build.bat`, `run.bat`, and `create_desktop_shortcut.bat`.

### 🐛 Bug Fixes
- Fixed cursor position offset when capturing a custom screen area (`X > 0, Y > 0`) or secondary monitor.
- Fixed `QuickLibrary.dll` MSBuild hint path so the project builds out-of-the-box on any Windows PC and GitHub Actions.

## [Unreleased] — CI Packaging

- Added a GitHub Actions Windows pipeline that builds the application EXE, WiX MSI installer, and portable ZIP.
- Added validation for required build inputs and runtime dependencies before packaging.
- MSI packaging uses pinned WiX Toolset 5.0.2 and includes the complete Release output plus a Start Menu shortcut.
- The legacy Visual Studio `.vdproj` remains in the repository but is not invoked by CI.
