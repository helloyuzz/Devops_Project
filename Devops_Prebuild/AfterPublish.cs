using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Devops_Prebuild {
    public class AfterPublish:Task {
        [Required]
        public string ApplicationVersion { get; set; }
        [Required]
        public string ExecPath { get; set; }
        [Required]
        public string IISApplicationUrl { get; set; }
        [Required]
        public string PublisherName { get; set; }
        [Required]
        public string ProductName { get; set; }
        public override bool Execute() {
            //MessageBox.Show("OK" + PublishUrl);
            //MessageBox.Show(ExecPath + " " + PublishUrl);//Application.StartupPath

            Console.WriteLine("--------------------------------------------------------------------------PreBuild--------------------------------------------------------------------------");
            Console.WriteLine("\r\nExecPath:" + ExecPath);
            Console.WriteLine("\r\nPublishUrl:" + IISApplicationUrl);
            if(string.IsNullOrEmpty(IISApplicationUrl)) {
                MessageBox.Show("\r\nIIS实际发布地址不能为空。");
                return false;
            }

            //Console.WriteLine("Building LogicHealth_Devops_PrintSetup.exe");
            //Process.Start(ExecPath + "\\LogicHealth_Devops_Cmd.exe",PublishUrl + " " + ExecPath);
            //Console.WriteLine(ExecPath + "\\LogicHealth_Devops_PrintSetup.exe");

            //string appName = "com.yuzz.Devops.App";
            string exeName = ProductName + ".exe";

            string indexName = "index.html";
            string vbsName = ProductName + ".Setup.vbs";
            string rarName = ProductName + ".Setup.exe";

            string htmlFile = ExecPath + indexName;
            string vbsFile = ExecPath + vbsName;
            string rarFile = ExecPath + rarName;
            string cfgFile = ExecPath + "config.conf";

            Console.WriteLine("\r\nRun Building...");

            // Setup.vbs
            if(File.Exists(vbsFile)) {
                File.Delete(vbsFile);
            }
            string winRoot = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            StreamWriter writer = File.CreateText(vbsFile);
            writer.Write(Html.CreateVbsFile(IISApplicationUrl,winRoot));
            writer.Flush();
            writer.Close();
            writer = null;

            Console.WriteLine("\r\nBuilding " + vbsFile + " - OK!");

            // index.html
            string html = Html.CreateHtml(ApplicationVersion,ProductName,PublisherName,rarName);
            if(File.Exists(htmlFile)) {
                File.Delete(htmlFile);
            }
            writer = File.CreateText(htmlFile);
            writer.Write(html);
            writer.Flush();
            writer.Close();
            Console.WriteLine("\r\nBuilding " + htmlFile + " - OK!");

            // config.conf
            //string conf = Html.CreateConfig(vbsName);
            //if(File.Exists(cfgFile)) {
            //    File.Decrypt(cfgFile);
            //}
            //writer = File.CreateText(cfgFile);
            //writer.Write(conf);
            //writer.Flush();
            //writer.Close();

            //Console.WriteLine("\r\nBuilding " + cfgFile + " - OK!");

            // build exe
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
            string winRarPath = key.GetValue("").ToString();
            if(string.IsNullOrEmpty(winRarPath) == false) {
                Console.WriteLine();
                Console.WriteLine(winRarPath);
                string arguments = " a -r -sfx -ep1 -z\"" + cfgFile + "\" " + rarFile + " " + vbsFile;
                Console.WriteLine(arguments);

                Process process = Process.Start(winRarPath,arguments);
                process.WaitForExit();
                Console.WriteLine("");
                Console.WriteLine("Building " + rarFile + " - OK!");


                //Console.WriteLine("");
                //Console.WriteLine("操作完成。\"exit\"退出。");
            } else {
                Console.WriteLine("");
                Console.WriteLine("编译错误，未检测到winrar，请先安装winrar");
            }

            Console.WriteLine("");
            return true;
        }
    }
}