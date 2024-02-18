using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BuildMaster
{
    public partial class PathSettingForm : Form
    {
        public PathSettingForm()
        {
            InitializeComponent();
        }

        private void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            var __prjPath = "projectPath : " + prjPathInputField.Text;
            var __editorPath = "editorPath : " + editorPathInputField.Text;
            var __strs = new string[2];
            __strs[0] = __prjPath;
            __strs[1] = __editorPath;
            File.WriteAllLines("config.txt", __strs, Encoding.UTF8);
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
