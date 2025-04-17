[Setup]
AppName=DBD Reshade Launcher
AppVersion=1.0.0
AppPublisher=Joolace
AppPublisherURL=https://github.com/Joolace
DefaultDirName={autopf}\DBD Reshade Launcher
DefaultGroupName=DBD Reshade Launcher
OutputDir=Output
OutputBaseFilename=DBDReshade_Launcher_Setup_v1.0.0
Compression=lzma2/max
SolidCompression=yes
DisableProgramGroupPage=no
UninstallDisplayIcon={app}\Resources\favicon.ico


[Files]
Source: "DBDReshadeLauncherInstaller\DBDReshadeLauncher.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "DBDReshadeLauncherInstaller\Resources\*"; DestDir: "{app}\Resources"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "DBDReshadeLauncherInstaller\ScriptFolder\*"; DestDir: "{app}\ScriptFolder"; Flags: ignoreversion recursesubdirs createallsubdirs

[Tasks]
Name: "desktopicon"; Description: "Create a desktop icon"; GroupDescription: "Additional icons:"; Flags: unchecked

[Icons]
Name: "{group}\DBD Reshade Launcher"; Filename: "{app}\DBDReshadeLauncher.exe"
Name: "{group}\Uninstall DBD Reshade Launcher"; Filename: "{uninstallexe}"
Name: "{commondesktop}\DBD Reshade Launcher"; Filename: "{app}\DBDReshadeLauncher.exe"; Tasks: desktopicon

[Run]
Filename: "{app}\DBDReshadeLauncher.exe"; Description: "Open DBD Reshade Launcher"; Flags: nowait postinstall skipifsilent
