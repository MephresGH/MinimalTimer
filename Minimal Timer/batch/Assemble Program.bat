@echo off
cd /d "%~dp0.."
IF EXIST "%~dp0..\bin" echo WARNING: directory found. Starting assembly... && GOTO :ASSEMBLY (
) ELSE (
GOTO :FIRSTASSEMBLY
)

:FIRSTASSEMBLY
mkdir "%~dp0..\bin"
"C:\Windows\Microsoft.NET\Framework\v2.0.50727\csc.exe" /t:winexe /out:"Minimal Timer.exe" "Program.cs" "MainForm.cs" "AssemblyInfo.cs" /platform:x86 /win32icon:"Timer.ico"
move "Minimal Timer.exe" "bin"
explorer "%~dp0..\bin"
pause
taskkill /f /im cmd.exe

:ASSEMBLY
echo.
rmdir /s /q "%~dp0..\bin" >NUL 2>&1
"C:\Windows\Microsoft.NET\Framework\v2.0.50727\csc.exe" /t:winexe /out:"Minimal Timer.exe" "Program.cs" "MainForm.cs" "AssemblyInfo.cs" /platform:x86 /win32icon:"Timer.ico"
mkdir "%~dp0..\bin"
move "Minimal Timer.exe" "bin"
explorer "%~dp0..\bin"
pause
taskkill /f /im cmd.exe