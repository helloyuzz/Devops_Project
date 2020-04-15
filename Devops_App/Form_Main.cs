using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicHealth_Devops_App {
    public partial class Form_Main:Form {
        public Form_Main() {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender,EventArgs e) {
            if(ApplicationDeployment.IsNetworkDeployed) {
                this.Text = "Form_Main - " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
        }
    }
}
