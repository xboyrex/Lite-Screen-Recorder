@echo off
setlocal
title Create Desktop Shortcut - Lite Screen Recorder (@xboyrex)
cd /d "%~dp0"

set "TARGET_EXE=%~dp0quick-screen-recorder\bin\Release\Lite-Screen-Recorder.exe"
if not exist "%TARGET_EXE%" (
    call "%~dp0build.bat" --nopause
)
set "ICON_FILE=%~dp0quick-screen-recorder\rec.ico"

echo Creating Desktop Shortcut for Lite Screen Recorder...
powershell -NoProfile -ExecutionPolicy Bypass -Command "$ws = New-Object -ComObject WScript.Shell; $s = $ws.CreateShortcut([Environment]::GetFolderPath('Desktop') + '\Lite Screen Recorder.lnk'); $s.TargetPath = '%TARGET_EXE%'; $s.WorkingDirectory = '%~dp0quick-screen-recorder\bin\Release'; $s.IconLocation = '%ICON_FILE%'; $s.Description = 'Lite Screen Recorder v2.0 by Mayank Droid (@xboyrex)'; $s.Save()"

echo [SUCCESS] Desktop shortcut "Lite Screen Recorder" created with circular icon!
pause
