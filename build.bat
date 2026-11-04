@echo off
setlocal EnableExtensions
title Lite Screen Recorder v2.0 - Build
color 0B
cd /d "%~dp0"

set "MSBUILD_PATH="

echo ============================================================
echo LITE SCREEN RECORDER v2.0 - BUILD
echo ============================================================
echo.

REM MSBuild dhundh rahe hain
set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
if exist "%VSWHERE%" (
    for /f "usebackq tokens=*" %%i in (`"%VSWHERE%" -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe 2^>nul`) do (
        if not defined MSBUILD_PATH set "MSBUILD_PATH=%%i"
    )
)

if not defined MSBUILD_PATH (
    if exist "%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" set "MSBUILD_PATH=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
)

if not defined MSBUILD_PATH (
    if exist "%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" set "MSBUILD_PATH=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"
)

if not defined MSBUILD_PATH (
    color 0C
    echo [ERROR] MSBuild nahi mila!
    pause
    exit /b 1
)

if not exist "packages\QuickLibrary" mkdir "packages\QuickLibrary"
if exist "quick-screen-recorder\bin\Release\QuickLibrary.dll" (
    copy /Y "quick-screen-recorder\bin\Release\QuickLibrary.dll" "packages\QuickLibrary\QuickLibrary.dll" >nul 2>&1
)

echo [INFO] Compiling EXE...
"%MSBUILD_PATH%" "quick-screen-recorder\quick-screen-recorder.csproj" /p:Configuration=Release /p:Platform=AnyCPU /nologo

if %ERRORLEVEL% NEQ 0 (
    color 0C
    echo.
    echo [ERROR] Build FAIL ho gaya. Upar error check karo.
    pause
    exit /b 1
)

set "OUT_BIN=quick-screen-recorder\bin\Release"
echo [INFO] Copying DLLs...
copy /Y "packages\NAudio.1.10.0\lib\net35\NAudio.dll" "%OUT_BIN%\" >nul 2>&1
copy /Y "packages\Octokit.0.3.4\lib\net45\Octokit.dll" "%OUT_BIN%\" >nul 2>&1
copy /Y "packages\SharpAvi.2.1.2\lib\net45\SharpAvi.dll" "%OUT_BIN%\" >nul 2>&1
copy /Y "packages\QuickLibrary\QuickLibrary.dll" "%OUT_BIN%\" >nul 2>&1
copy /Y "quick-screen-recorder\rec.ico" "%OUT_BIN%\rec.ico" >nul 2>&1

if exist "%OUT_BIN%\Lite-Screen-Recorder.exe" (
    copy /Y "%OUT_BIN%\Lite-Screen-Recorder.exe" "%OUT_BIN%\quick-screen-recorder.exe" >nul 2>&1
    copy /Y "%OUT_BIN%\Lite-Screen-Recorder.exe.config" "%OUT_BIN%\quick-screen-recorder.exe.config" >nul 2>&1
)

color 0A
echo.
echo ============================================================
echo BUILD SUCCESSFUL! EXE ready hai:
echo %OUT_BIN%\Lite-Screen-Recorder.exe
echo ============================================================
echo.
if /I "%1"=="--nopause" exit /b 0
pause
exit /b 0
