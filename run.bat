@echo off
setlocal EnableExtensions
title Lite Screen Recorder v2.0 - Build ^& Run
color 0B
cd /d "%~dp0"

echo ============================================================
echo LITE SCREEN RECORDER v2.0 - BUILD ^& RUN
echo ============================================================
echo.

call "%~dp0build.bat" --nopause

if %ERRORLEVEL% NEQ 0 (
    color 0C
    echo.
    echo [ERROR] Build fail ho gaya, app run nahi ho sakti.
    pause
    exit /b 1
)

set "EXE_PATH=quick-screen-recorder\bin\Release\Lite-Screen-Recorder.exe"

if not exist "%EXE_PATH%" (
    color 0C
    echo.
    echo [ERROR] EXE file nahi mili: %EXE_PATH%
    pause
    exit /b 1
)

echo.
echo [INFO] Launching Lite Screen Recorder...
start "" "%EXE_PATH%"
exit /b 0
