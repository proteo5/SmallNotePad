; SmallNotePad Installer Script for Inno Setup
; This script creates a professional installer with all features

#define MyAppName "SmallNotePad"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "proteo5"
#define MyAppURL "https://github.com/proteo5/SmallNotePad"
#define MyAppExeName "SmallNotePad.exe"
#define MyAppDescription "A lightweight, feature-rich text editor"
#define SourceDir "C:\Des\5-Fx\SmallNotePad\SmallNotePad\bin\Release\net10.0-windows\publish\win-x64"

[Setup]
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=C:\Des\5-Fx\SmallNotePad\LICENSE
OutputDir=C:\Des\5-Fx\SmallNotePad\Installers
OutputBaseFilename=SmallNotePad-Setup
SetupIconFile=C:\Des\5-Fx\SmallNotePad\SmallNotePad\App.ico
Compression=lzma
SolidCompression=yes
PrivilegesRequired=lowest
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
WizardStyle=modern
ShowLanguageDialog=no
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName={#MyAppName}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "contextmenu"; Description: "Add 'Open with {#MyAppName}' to context menu"; GroupDescription: "Windows Explorer Integration"
Name: "defaulttxt"; Description: "Make {#MyAppName} the default application for .txt files"; GroupDescription: "File Association"

[Files]
Source: "{#SourceDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Dirs]
Name: "{app}"; Permissions: users-modify

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Registry]
; Make SmallNotePad the default application for .txt files
Root: HKA; Subkey: "Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.txt\UserChoice"; Flags: dontcreatekey deletevalue; Tasks: defaulttxt
Root: HKA; Subkey: "Software\Classes\.txt"; ValueType: string; ValueName: ""; ValueData: "txtfile"; Flags: uninsdeletevalue; Tasks: defaulttxt
Root: HKA; Subkey: "Software\Classes\txtfile"; ValueType: string; ValueName: ""; ValueData: "Text Document"; Flags: uninsdeletekey; Tasks: defaulttxt
Root: HKA; Subkey: "Software\Classes\txtfile\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"; Tasks: defaulttxt
Root: HKA; Subkey: "Software\Classes\txtfile\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""; Tasks: defaulttxt

; Add context menu entry
Root: HKA; Subkey: "Software\Classes\*\shell\SmallNotePad"; ValueType: string; ValueName: ""; ValueData: "Open with SmallNotePad"; Tasks: contextmenu
Root: HKA; Subkey: "Software\Classes\*\shell\SmallNotePad"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#MyAppExeName}"; Tasks: contextmenu
Root: HKA; Subkey: "Software\Classes\*\shell\SmallNotePad\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""; Tasks: contextmenu

; Add context menu for folders (send to)
Root: HKA; Subkey: "Software\Classes\Folder\shell\SmallNotePad"; ValueType: string; ValueName: ""; ValueData: "Open with SmallNotePad"; Tasks: contextmenu
Root: HKA; Subkey: "Software\Classes\Folder\shell\SmallNotePad\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""; Tasks: contextmenu

[Code]
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usUninstall then
  begin
    // Clean up registry entries if needed
    RegDeleteKeyIncludingSubkeys(HKEY_CURRENT_USER, 'Software\Classes\txtfile');
  end;
end;
