using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Devops_Prebuild {
    public class PreBuild:Task {
        public override bool Execute() {
            MessageBox.Show("aa");
            return true;
        }
    }
}
