#define MyAppName "ContactsApp"
#define MyAppExeName "ContactsAppUI.exe"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Rozhdestvenskiy Mikhail"

[Setup]
AppId={{A24AACB9-D068-4E5F-8D8E-3533865397B2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}

DefaultDirName={pf}\{#MyAppExeName}


OutputDir="Installers"
OutputBaseFileName=ContactsAppSetup

Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl";
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\WindowsFormsApp1Variant2\ContactsAppUI\bin\Release\ContactsAppUI.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\WindowsFormsApp1Variant2\ContactsAppUI\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

