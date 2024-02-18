using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildMaster
{
    public partial class Form1 : Form
    {
        public List<ProjectInfo> projectInfoList = new List<ProjectInfo>();

        ProjectInfo curProjectInfo;

        public class ProjectInfo
        {
            public string projectName = "";

            public string lastClientVersion = "";
            public string lastTableVersion = "";
            public string lastServerSlot = "";

            public string clientVersion = "";
        }

        const string checkInput = "ClientVersion, ServerSlot, TableVersion 입력을 확인해 주십시오.";
        const string checkUnityInstance = "Multiple Unity instances cannot open the same project.";
        const string checkUnityInstanceMsg = "해당 프로젝트에서 사용하는 버전의 유니티 에디터가 하나 이상 켜져있습니다. 모든 에디터를 종료 후 실행 해 주세요";

        public static string jFrameworkConfigPath = @"\Assets\JFrameworkData\Resources\JFrameworkConfig.asset";
        public static string projectSettingPath = @"\ProjectSettings\ProjectSettings.asset";

        public static string runtimeConfigFilePath = "runtimeConfig.txt";
        public static string lastBuildInfoTextFileName = "lastBuildInfo.txt";

        public string ConfigPath => $"{GetBMProjectPath(curProjectInfo.projectName)}/config.txt";

        public enum ConfigType
        {
            ProjectName,
            ProjectPath,
            EditorPath,
            AOSBuildMethod,
            IOSBuildMethod
        }

        public string GetConfigString(ConfigType configType)
        {
            var __configPath = ConfigPath;

            var __lineList = File.ReadLines(__configPath).ToList();
            return __lineList[(int)configType];
        }

        public string ProjectName => GetConfigString(ConfigType.ProjectName);
        public string ProjectPath => GetConfigString(ConfigType.ProjectPath);
        public string EditorPath => GetConfigString(ConfigType.EditorPath);
        public string AOSBuildMethod => GetConfigString(ConfigType.AOSBuildMethod);
        public string IOSBuildMethod => GetConfigString(ConfigType.IOSBuildMethod);

        public string GetBMProjectPath(string projectName)
        {
            return $"./Projects/{projectName}";
        }

        public Form1()
        {
            InitializeComponent();

            curProjectInfo = default(ProjectInfo);

            if (File.Exists(runtimeConfigFilePath))
            {
                var __configStrList = File.ReadLines(runtimeConfigFilePath).ToList();
                SetCurProjectInfo(__configStrList[0], true);
            }
            else
            {
                curProjectInfo = new ProjectInfo();
            }

            var __isSuccess = HasValidProject();
            if (__isSuccess == false)
            {
                var __settingForm = new ProjectSettingForm();
                __settingForm.ShowDialog();
                curProjectInfo.projectName = __settingForm.resultProjectName;
            }

            useCommitCheckBox.Checked = true;

            SetProjectComboBox();
        }

        void CurStatusTextUpdate(string p_Msg)
        {
            curStatusText.Text = p_Msg;
            curStatusText.Update();
        }

        bool HasValidProject()
        {
            var __configPath = ConfigPath;
            if (!File.Exists(__configPath))
                return false;

            var __lines = File.ReadLines(__configPath).ToList();
            if (__lines.Count < 5)
                return false;

            return true;
        }

        public void SVNDiff(string p_FilePath)
        {
            if (!useCommitCheckBox.Checked)
                return;

            CurStatusTextUpdate("SVN diff..");

            // 잘 바뀌었는지 비교
            var __projectPath = ProjectPath;
            var __workingDir = __projectPath;
            var __executeCommand = $"svn diff {__projectPath}{p_FilePath}";
            var __resultStr = ExecuteCommand(__workingDir, __executeCommand);
            MessageBox.Show(__resultStr);

            CurStatusTextUpdate("Diff done!");
        }

        private void OnOneClickBuildButtonClicked(object sender, EventArgs e)
        {
            CurStatusTextUpdate("BuildProcess Begin");

            curStatusText.ForeColor = Color.Black;

            SVNUpdate();

            var __isSuccess = ClientVersionUp();
            if (__isSuccess == false)
            {
                MessageBox.Show(checkUnityInstanceMsg);
                return;
            }

            __isSuccess = SVNCommit();
            if (__isSuccess == false)
            {
                MessageBox.Show("커밋에 실패하였습니다. 커밋 목록을 확인 해 주세요");
                return;
            }

            CurStatusTextUpdate("BuildStart!");

            curStatusText.ForeColor = Color.Green;

            RunBuild();
        }

        void RunBuild()
        {
            BuildAndroid();

            BuildIOS();
        }

        string ExecuteCommand(string p_WorkingDir, string p_Command, string p_DoneMsg = "")
        {
            var __pri = new ProcessStartInfo();
            var __pro = new Process();

            __pri.FileName = @"cmd.exe";
            __pri.CreateNoWindow = false;
            __pri.UseShellExecute = false;

            __pri.RedirectStandardInput = true;
            __pri.RedirectStandardOutput = true;
            __pri.RedirectStandardError = true;

            __pri.WorkingDirectory = p_WorkingDir;

            __pro.StartInfo = __pri;
            __pro.Start();

            __pro.StandardInput.Write(p_Command + Environment.NewLine);
            __pro.StandardInput.Close();

            var __streamReader = __pro.StandardOutput;

            var __resultStr = __streamReader.ReadToEnd();
            __pro.WaitForExit();
            __pro.Close();

            if (string.IsNullOrEmpty(p_DoneMsg) == false)
                MessageBox.Show(p_DoneMsg);

            return __resultStr;
        }

        bool InputCheck()
        {
            var __clientVersionStr = clientVersionInputField.Text;
            var __serverSlotStr = serverSlotInputField.Text;
            var __tableVersionStr = tableVersionInputField.Text;

            if (string.IsNullOrEmpty(__clientVersionStr))
                return false;

            if (string.IsNullOrEmpty(__serverSlotStr))
                return false;

            if (string.IsNullOrEmpty(__tableVersionStr))
                return false;

            var __tableVersionSplitted = __tableVersionStr.Split('.');
            if (__tableVersionSplitted.Length != 2 || __tableVersionSplitted[0] != "0")
                return false;

            var __versionSplitted = __clientVersionStr.Split('.');
            if (__versionSplitted.Length != 3)
                return false;

            for (int i = 0; i < __versionSplitted.Length; i++)
            {
                var __str = __versionSplitted[i];

                if (int.TryParse(__str, out var __num) == false)
                    return false;
            }

            if (int.TryParse(__serverSlotStr, out var __slot) == false)
                return false;

            if (__slot < 1 || __slot > 4)
                return false;

            return true;
        }

        private void jenkinsAosButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://121.131.71.175:9090/");
        }

        private void jenkinsIosButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://121.131.71.175:8080/");
        }

        bool ClientVersionUp(string p_DoneMsg = "")
        {
            if (InputCheck() == false)
            {
                MessageBox.Show(checkInput);
                return false;
            }

            CurStatusTextUpdate("Set client version up..");

            curProjectInfo.clientVersion = clientVersionInputField.Text;

            curStatusText.Update();

            var __serverSlotStr = serverSlotInputField.Text;

            var __projectPath = ProjectPath;

            // 클라이언트 및 번들 버전, 서버슬롯 변경
            var __executeCommand = $"Unity.exe " +
                $"-quit " +
                $"-batchmode " +
                $"-buildTarget Android " +
                $"-logFile {__projectPath}{@"\BuildLog.txt"} " +
                $"-projectPath {__projectPath} " +
                $"-executeMethod BatchModeUtil.SetClientVersion " +
                $"-clientVersion {curProjectInfo.clientVersion} " +
                $"-serverSlot {__serverSlotStr}";

            var __workingDir = EditorPath;

            var __resultStr = ExecuteCommand(__workingDir, __executeCommand, p_DoneMsg);

            if (__resultStr.Contains(checkUnityInstance))
            {
                CurStatusTextUpdate("version up fail");
                return false;
            }

            CurStatusTextUpdate("version up done!");

            return true;
        }

        void SVNUpdate(string p_DoneMsg = "")
        {
            CurStatusTextUpdate("SVN update..");

            // 업데이트
            var __workingDir = ProjectPath;
            var __executeCommand = "svn update";

            ExecuteCommand(__workingDir, __executeCommand, p_DoneMsg);

            CurStatusTextUpdate("Update Done!");
        }

        bool SVNCommit(string p_DoneMsg = "")
        {
            if (!useCommitCheckBox.Checked)
                return true;

            if (InputCheck() == false)
            {
                MessageBox.Show(checkInput);
                return false;
            }

            var __diffCheck = new DiffCheck();
            __diffCheck.mainForm = this;
            __diffCheck.ShowDialog();

            if (__diffCheck.isConfirm == false)
            {
                MessageBox.Show("커밋이 취소되었습니다.");
                return false;
            }

            CurStatusTextUpdate("SVN commit..");

            var __clientVersionStr = clientVersionInputField.Text;
            var __serverSlotStr = serverSlotInputField.Text;
            var __tableVersionStr = tableVersionInputField.Text;
            var __serverSlot = Convert.ToInt32(__serverSlotStr);

            var __commitMsg = $"\"{curProjectInfo.projectName} Client {__clientVersionStr} {__tableVersionStr} s{__serverSlot}\"";

            // 커밋
            var __projectPath = ProjectPath;
            var __workingDir = __projectPath;
            var __executeCommand = $"svn commit " +
                               $"{__projectPath}{@"\ProjectSettings\ProjectSettings.asset"} " +
                               $"{__projectPath}{@"\Assets\JFrameworkData\Resources\JFrameworkConfig.asset"} -m " + __commitMsg;

            var __resultStr = ExecuteCommand(__workingDir, __executeCommand, p_DoneMsg);

            if (__resultStr.Contains("커밋된 리비전") == false)
            {
                CurStatusTextUpdate("Commit Failed!");
                return false;
            }

            CurStatusTextUpdate("Commit Done!");

            var __lastClientVersion = clientVersionInputField.Text;
            var __lastServerSlot = serverSlotInputField.Text;
            var __lastTableVersion = tableVersionInputField.Text;
            var __strs = new string[3];
            __strs[0] = __lastClientVersion;
            __strs[1] = __lastServerSlot;
            __strs[2] = __lastTableVersion;
            File.WriteAllLines($"{GetBMProjectPath(curProjectInfo.projectName)}/{lastBuildInfoTextFileName}", __strs, Encoding.UTF8);

            MessageBox.Show(__resultStr);

            return true;
        }

        private void HelpLinkButtonClicked(object sender, EventArgs e)
        {
            Process.Start("https://www.notion.so/novacore-dragonsky/859f0413eecc4a4fb352796fc2522744");
        }

        private void ShowPathButton_Click(object sender, EventArgs e)
        {
            Process.Start($"{AppDomain.CurrentDomain.BaseDirectory}/Projects/{curProjectInfo.projectName}/config.txt");
        }

        private void EditPathButton_Click(object sender, EventArgs e)
        {
            var __settingForm = new ProjectSettingForm();
            __settingForm.ShowDialog();
        }

        private void AndroidBuildButton_Click(object sender, EventArgs e)
        {
            BuildAndroid();
        }

        private void BuildIosButton_Click(object sender, EventArgs e)
        {
            BuildIOS();
        }

        void BuildIOS()
        {
            var __workingDir = @"C:\";

            var __buildCommandFormatStr = "curl -X post {0}";

            var __command = string.Format(__buildCommandFormatStr, IOSBuildMethod);

            ExecuteCommand(__workingDir, __command);
        }

        void BuildAndroid()
        {
            var __workingDir = @"C:\";

            curProjectInfo.clientVersion = clientVersionInputField.Text;

            var __buildCommandFormatStr = "curl -X post {0} -F clientVersion={1}";

            var __command = string.Format(__buildCommandFormatStr, AOSBuildMethod, curProjectInfo.clientVersion);

            ExecuteCommand(__workingDir, __command);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            curProjectInfo.projectName = comboBox1.Text;
            SetCurProjectInfo(curProjectInfo.projectName, false);
        }

        void SetCurProjectInfo(string projectName, bool setComboBox)
        {
            curProjectInfo = new ProjectInfo();

            curProjectInfo.projectName = projectName;
            var __lastBuildInfoPath = $"{GetBMProjectPath(projectName)}/{lastBuildInfoTextFileName}";

            if (File.Exists(__lastBuildInfoPath))
            {
                var __infoLines = File.ReadLines(__lastBuildInfoPath).ToList();
                if (__infoLines.Count >= 3)
                {
                    curProjectInfo.lastClientVersion = __infoLines[0];
                    curProjectInfo.lastServerSlot = __infoLines[1];
                    curProjectInfo.lastTableVersion = __infoLines[2];
                }
                else
                {
                    curProjectInfo.lastClientVersion = string.Empty;
                    curProjectInfo.lastServerSlot = string.Empty;
                    curProjectInfo.lastTableVersion = string.Empty;
                }

                clientVersionInputField.Text = curProjectInfo.lastClientVersion;
                serverSlotInputField.Text = curProjectInfo.lastServerSlot;
                tableVersionInputField.Text = curProjectInfo.lastTableVersion;
            }

            if (File.Exists(runtimeConfigFilePath))
            {
                var __strs = new string[1];
                __strs[0] = projectName;
                File.WriteAllLines(runtimeConfigFilePath, __strs, Encoding.UTF8);
            }

            if (setComboBox)
            {
                SetProjectComboBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var __form = new ProjectSettingForm();
            __form.ShowDialog();

            var __newProjectName = __form.resultProjectName;
            SetCurProjectInfo(__newProjectName, true);
        }

        void SetProjectComboBox()
        {
            comboBox1.Items.Clear();
            var __directories = Directory.GetDirectories("Projects");
            for (int i = 0; i < __directories.Length; i++)
            {
                var __directory = __directories[i];
                var __directoryName = __directory.Substring(9, __directory.Length - 9);
                comboBox1.Items.Add(__directoryName);

                if (curProjectInfo.projectName == __directoryName)
                {
                    comboBox1.SelectedIndex = i;
                    comboBox1.Text = curProjectInfo.projectName;
                }
            }
        }
    }
}
