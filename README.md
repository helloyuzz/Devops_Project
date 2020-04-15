# Devops_Project

```doskey
"C:\Program Files\WinRAR\RAR.exe"  a -r -sfx -z"config.conf" 
                                   Devops_Setup 
                                   Devops_Setup.vbs
```


```csharp
Set objShell = WScript.CreateObject("WScript.Shell" )
url = "http://192.168.0.123/ljk/CSSD.Packpress.PrintAssistant.application"
objShell.Run("""C:\Windows\System32\rundll32.exe"" ""C:\Windows\System32\dfshim.dll"",ShOpenVerbApplication " & url)
Set objShell = Nothing
```

```regedit
Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                                  @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
```

```vs2017 cmd 
msbuild Devops_Project.sln 
              /t:publish 
              /p:PublishDir="D:/GitHub/Devops_Project/MsBuild/" 
              /p:MapFileExtensions=true 
              /p:TrustUrlParameters=true 
              /p:UseApplicationTrust=true 
              /p:CreateDesktopShortcut=true 
              /p:BootstrapperEnabled=true 
              /p:IsWebBootstrapper=true 
              /p:InstallFrom=Web 
              /p:UpdateEnabled=false 
              /p:ProductName="Com.Yuzz.Devops.App" 
              /p:PublisherName="1tyu.com" 
              /p:Configuration=Release 
              /p:IISApplicationUrl="http://192.168.0.123/devops/com.yuzz.Devops.App.application" 
              /p:ApplicationVersion="1.0.0.26"
```
