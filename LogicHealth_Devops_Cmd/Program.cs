using LogicHealth_Devops;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace LogicHealth_Devops_Cmd {
    class Program {
        static string appName = "CSSD.Packpress.PrintAssistant";
        static string indexFile = Environment.CurrentDirectory + "\\index.html";
        static string vbsFile = Environment.CurrentDirectory + "\\LogicHealth_Devops_PrintSetup.vbs";
        static void Main(string[] args) {
            bool ok = false;
            Console.WriteLine("CSSD.Packpress.PrintAssistant-LogicHealth_Devops_Cmd");
            while(true) {
                if(ok == false) {
                    Console.WriteLine("");
                    Console.WriteLine("请输入IIS服务器完整地址：（格式：http://xxx.xxx.xxx.xxx/path/app.application）");
                }
                string url = Console.ReadLine();
                if(url.Equals("exit")) {
                    break;
                }

                string path = Environment.CurrentDirectory + "\\Application Files";
                if(Directory.Exists(path) == false) {
                    Console.WriteLine("Application Files文件夹不存在。");
                } else {

                    string temp1 = "";
                    List<string> list = Directory.GetDirectories(path).ToList<string>();

                    if(list.Count <= 0) {
                        Console.WriteLine("Application Files文件夹中不存在任何发布文件。");
                    } else {
                        Console.WriteLine("");
                        Console.WriteLine("Run Building...");
                        list.Sort();
                        temp1 = list[list.Count - 1].Replace(appName + "_","");

                        DirectoryInfo directoryInfo = new DirectoryInfo(temp1);
                        temp1 = directoryInfo.Name;


                        // Setup.vbs
                        if(File.Exists(vbsFile)) {
                            File.Delete(vbsFile);
                        }
                        string winDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                        StreamWriter writer = File.CreateText(vbsFile);
                        writer.Write(Html.CreateVbsFile(url.Trim(),winDirectory));
                        writer.Flush();
                        writer.Close();
                        writer = null;
                        Console.WriteLine("");
                        Console.WriteLine("Building index.html - OK!");

                        // index.html
                        string html = Html.CreateHtml(url.Trim(),temp1);
                        if(File.Exists(indexFile)) {
                            File.Delete(indexFile);
                        }
                        writer = File.CreateText(indexFile);
                        writer.Write(html);
                        writer.Flush();
                        writer.Close();
                        Console.WriteLine("");
                        Console.WriteLine("Building LogicHealth_Devops_PrintSetup.vbs - OK!");

                        // build exe
                        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
                        string winRarPath = key.GetValue("").ToString();
                        if(string.IsNullOrEmpty(winRarPath) == false) {                            
                            Process process= Process.Start(winRarPath,"a -r -sfx -z\"config.conf\" LogicHealth_Devops_PrintSetup LogicHealth_Devops_PrintSetup.vbs");
                            process.WaitForExit();
                            Console.WriteLine("");
                            Console.WriteLine("Building LogicHealth_Devops_PrintSetup.exe - OK!");

                            ok = true;
                            Console.WriteLine("");
                            Console.WriteLine("操作完成。\"exit\"退出。");
                        } else {
                            Console.WriteLine("");
                            Console.WriteLine("编译错误，未检测到winrar，请先安装winrar");
                        }
                    }
                }
            }
        }
    }
}
