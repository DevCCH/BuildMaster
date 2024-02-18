using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildMaster
{
    public partial class DiffCheck : Form
    {
        public Form1 mainForm;

        public bool isConfirm = false;

        public DiffCheck()
        {
            InitializeComponent();
        }

        private void diffPrjSettings_Click(object sender, EventArgs e)
        {
            mainForm.SVNDiff(Form1.projectSettingPath);
        }

        private void diffJFrameworkConfig_Click(object sender, EventArgs e)
        {
            mainForm.SVNDiff(Form1.jFrameworkConfigPath);
        }

        private void ConfirmButtonClicked(object sender, EventArgs e)
        {
            isConfirm = true;
            Close();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
