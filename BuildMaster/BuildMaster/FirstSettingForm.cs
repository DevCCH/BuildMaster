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
    public partial class ProjectSettingForm : Form
    {
        public string resultProjectName;

        public ProjectSettingForm()
        {
            InitializeComponent();
        }

        private void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            var __prjName = textBox1.Text;
            var __prjPath = prjPathInputField.Text;
            var __editorPath = editorPathInputField.Text;
            var __aosBuildCommandFormatStr = aosBuildCommandFormatInputField.Text;
            var __aosBuildMethod = aosBuildMethodInputField.Text;
            var __iosBuildMethod = iosBuildMethodInputField.Text;
            var __strs = new string[5];
            __strs[0] = __prjName;
            __strs[1] = __prjPath;
            __strs[2] = __editorPath;
            __strs[3] = __aosBuildCommandFormatStr;
            __strs[4] = __aosBuildMethod;
            __strs[5] = __iosBuildMethod;

            var __dirPath = $"./Projects/{textBox1.Text}";
            Directory.CreateDirectory(__dirPath);

            File.WriteAllLines($"{__dirPath}/config.txt", __strs, Encoding.UTF8);

            var __strs2 = new string[1];
            __strs2[0] = __prjName;

            File.WriteAllLines(Form1.runtimeConfigFilePath, __strs2, Encoding.UTF8);

            resultProjectName = __prjName;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
