rem this is check Administrator 
@Echo OFF
net session >nul 2>&1
IF NOT %ERRORLEVEL% EQU 0 (
	   ECHO ERROR: Please run Bat as Administrator.
	   PAUSE
	   EXIT /B 1
	)
@SETLOCAL enableextensions
@CD /d "%~dp0"


REM The following directory is for .NET 4
SET DOTNETFX4=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
SET PATH=%PATH%;%DOTNETFX4%
ECHO UnInstalling Windows Service...
ECHO ---------------------------------------------------
InstallUtil /u .\Ex-WindowsService.exe
ECHO ---------------------------------------------------
ECHO Done.
PAUSE