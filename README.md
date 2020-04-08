# .NET-ClickOnce-Publish-with-Winrar.exe

```doskey
"C:\Program Files\WinRAR\RAR.exe"  a -r -sfx -z"config.conf" 
                                   LogicHealth_Devops_PrintSetup 
                                   LogicHealth_Devops_PrintSetup.vbs
```


```csharp
Set objShell = WScript.CreateObject("WScript.Shell" )
u = "http://192.168.0.123/ljk/CSSD.Packpress.PrintAssistant.application"
objShell.Run("""C:\Windows\System32\rundll32.exe"" ""C:\Windows\System32\dfshim.dll"",ShOpenVerbApplication " & u)
Set objShell = Nothing
```

```regedit
Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                                  @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
```
