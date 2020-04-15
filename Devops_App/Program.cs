using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicHealth_Devops_App {
    static class Program {
        static string appName = Application.ProductName;
        static long sizeOfUpdate = 0;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread thread = new Thread(new ThreadStart(CheckUpdate));
            thread.IsBackground = true;
            thread.Start();

            Application.Run(new Form_Main());
        }

        private static void CheckUpdate() {
            Thread.Sleep(1000);
            Application.DoEvents();
            if(ApplicationDeployment.IsNetworkDeployed) {
                bool hasApplication = ApplicationDeployment.CurrentDeployment.CheckForUpdate(false);
                if(hasApplication == true) {
                    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                    ad.CheckForUpdateCompleted += new CheckForUpdateCompletedEventHandler(ad_CheckForUpdateCompleted);
                    ad.CheckForUpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_CheckForUpdateProgressChanged);

                    ad.CheckForUpdateAsync();
                }
            }
        }

        static void ad_CheckForUpdateProgressChanged(object sender,DeploymentProgressChangedEventArgs e) {
            //toolStripStatusLabel1.Text = String.Format("正在下载: {0}. 进度：{1:D}K of {2:D}K downloaded.",GetProgressString(e.State),e.BytesCompleted / 1024,e.BytesTotal / 1024);
        }

        static string GetProgressString(DeploymentProgressState state) {
            if(state == DeploymentProgressState.DownloadingApplicationFiles) {
                return "程序文件";
            } else if(state == DeploymentProgressState.DownloadingApplicationInformation) {
                return "文件清单";
            } else {
                return "文件部署清单";
            }
        }

        static void ad_CheckForUpdateCompleted(object sender,CheckForUpdateCompletedEventArgs e) {
            if(e.Error != null) {
                MessageBox.Show("错误:未能更新" + appName + "到最新版本，原因: \n" + e.Error.Message + "\n重试操作或联系系统管理员.");
                return;
            } else if(e.Cancelled == true) {
                MessageBox.Show("The update was cancelled.");
            }

            // Ask the user if they would like to update the application now.
            if(e.UpdateAvailable) {
                sizeOfUpdate = e.UpdateSizeBytes;

                if(!e.IsUpdateRequired) {
                    DialogResult dr = MessageBox.Show("检测到" + appName + "有最新的版本更新(版本号:" + e.AvailableVersion + ")，是否现在更新？\n\n升级预计需要: " + sizeOfUpdate / 1024 + "KB","有可用的新版本",MessageBoxButtons.OKCancel);
                    if(DialogResult.OK == dr) {
                        BeginUpdate();
                    }
                } else {
                    MessageBox.Show("您的" + appName + "需要更新。我们将立即安装更新，然后保存所有正在进行的数据，并重新启动" + appName + "。");
                    BeginUpdate();
                }
            }
        }

        private static void BeginUpdate() {
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
            ad.UpdateCompleted += new AsyncCompletedEventHandler(ad_UpdateCompleted);

            // Indicate progress in the application's status bar.
            ad.UpdateProgressChanged += new DeploymentProgressChangedEventHandler(ad_UpdateProgressChanged);
            ad.UpdateAsync();
        }

        static void ad_UpdateProgressChanged(object sender,DeploymentProgressChangedEventArgs e) {
            String progressText = String.Format("下载进度：{0:D}K / {1:D}K downloaded - 完成百分比：{2:D}% ",e.BytesCompleted / 1024,e.BytesTotal / 1024,e.ProgressPercentage);
            //toolStripStatusLabel1.Text = progressText;
        }

        static void ad_UpdateCompleted(object sender,AsyncCompletedEventArgs e) {
            if(e.Cancelled) {
                MessageBox.Show(appName + "更新操作被取消。");
                return;
            } else if(e.Error != null) {
                MessageBox.Show("错误:未能更新" + appName + "到最新版本，原因: \n" + e.Error.Message + "\n重试操作或联系系统管理员.");
                return;
            }

            DialogResult dr = MessageBox.Show(appName + "已更新，点击\"确定\"按钮重启。","更新完毕!",MessageBoxButtons.OK);
            if(DialogResult.OK == dr) {
                Application.Restart();
            }
        }
    }
}
