!define OUTDIR "bin\Release"

OutFile "WAP Installer.exe"
InstallDir "$PROGRAMFILES\Fusky Labs Software\WinAutoprefs"

Section
  SetOutPath "$INSTDIR"
SectionEnd