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
        string projectPath = "";
        string editorPath = "";

        string lastClientVersion = "";
        string lastTableVersion = "";
        string lastServerSlot = "";

        string clientVersion = "";

        const string checkInput = "ClientVersion, ServerSlot, TableVersion 입력을 확인해 주십시오.";
        const string checkUnityInstance = "Multiple Unity instances cannot open the same project.";
        const string checkUnityInstanceMsg = "해당 프로젝트에서 사용하는 버전의 유니티 에디터가 하나 이상 켜져있습니다. 모든 에디터를 종료 후 실행 해 주세요";

        public static string jFrameworkConfigPath = @"\Assets\JFrameworkData\Resources\JFrameworkConfig.asset";
        public static string projectSettingPath = @"\ProjectSettings\ProjectSettings.asset";

        public Form1()
        {
            InitializeComponent();
            if (File.Exists("lastBuildInfo.txt"))
            {
                var __infoLines = File.ReadLines("lastBuildInfo.txt").ToList();
                if (__infoLines.Count >= 3)
                {
                    lastClientVersion = __infoLines[0];
                    lastServerSlot = __infoLines[1];
                    lastTableVersion = __infoLines[2];

                    clientVersionInputField.Text = lastClientVersion;
                    serverSlotInputField.Text = lastServerSlot;
                    tableVersionInputField.Text = lastTableVersion;
                }
            }

            var __isSuccess = SetPath();
            if(__isSuccess == false)
            {
                var __settingForm = new PathSettingForm();
                __settingForm.ShowDialog();
                SetPath();
            }
        }

        void CurStatusTextUpdate(string p_Msg)
        {
            curStatusText.Text = p_Msg;
            curStatusText.Update();
        }

        bool SetPath()
        {
            var __lines = File.ReadLines("config.txt").ToList();
            if (__lines.Count < 2)
                return false;
            
            var __prjPath = __lines[0];
            var __editorPath = __lines[1];

            if (__prjPath.Length <= 14 || __editorPath.Length <= 13)
                return false;

            projectPath = __lines[0].Substring(14);
            editorPath = __lines[1].Substring(13);

            if (projectPath.Length == 0 || editorPath.Length == 0)
                return false;

            return true;
        }

        public void SVNDiff(string p_FilePath)
        {
            CurStatusTextUpdate("SVN diff..");

            // 잘 바뀌었는지 비교
            var __workingDir = projectPath;
            var __executeCommand = $"svn diff {projectPath}{p_FilePath}";
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
            Process.Start("http://192.168.50.85:9090/");
        }

        private void jenkinsIosButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://192.168.50.183:8080/");
        }

        bool ClientVersionUp(string p_DoneMsg = "")
        {
            if (InputCheck() == false)
            {
                MessageBox.Show(checkInput);
                return false;
            }

            CurStatusTextUpdate("Set client version up..");

            clientVersion = clientVersionInputField.Text;

            curStatusText.Update();

            var __serverSlotStr = serverSlotInputField.Text;

            // 클라이언트 및 번들 버전, 서버슬롯 변경
            var __executeCommand = $"Unity.exe " +
                $"-quit " +
                $"-batchmode " +
                $"-buildTarget Android " +
                $"-logFile {projectPath}{@"\Yong_Unity\Build\Log.txt"} " +
                $"-projectPath {projectPath} " +
                $"-executeMethod BatchModeUtil.SetClientVersion " +
                $"-clientVersion {clientVersion} " +
                $"-serverSlot {__serverSlotStr}";

            var __workingDir = editorPath;

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
            var __workingDir = projectPath;
            var __executeCommand = "svn update";

            ExecuteCommand(__workingDir, __executeCommand, p_DoneMsg);

            CurStatusTextUpdate("Update Done!");
        }

        bool SVNCommit(string p_DoneMsg = "")
        {
            if (InputCheck() == false)
            {
                MessageBox.Show(checkInput);
                return false;
            }

            var __diffCheck = new DiffCheck();
            __diffCheck.mainForm = this;
            __diffCheck.ShowDialog();

            if(__diffCheck.isConfirm == false)
            {
                MessageBox.Show("커밋이 취소되었습니다.");
                return false;
            }

            CurStatusTextUpdate("SVN commit..");

            var __clientVersionStr = clientVersionInputField.Text;
            var __serverSlotStr = serverSlotInputField.Text;
            var __tableVersionStr = tableVersionInputField.Text;
            var __serverSlot = Convert.ToInt32(__serverSlotStr);

            var __commitMsg = $"\"DS Client {__clientVersionStr} {__tableVersionStr} s{__serverSlot}\"";

            // 커밋
            var __workingDir = projectPath;
            var __executeCommand = $"svn commit " +
                               $"{projectPath}{@"\ProjectSettings\ProjectSettings.asset"} " +
                               $"{projectPath}{@"\Assets\JFrameworkData\Resources\JFrameworkConfig.asset"} -m " + __commitMsg;

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
            File.WriteAllLines("lastBuildInfo.txt", __strs, Encoding.UTF8);

            MessageBox.Show(__resultStr);

            return true;
        }

        private void HelpLinkButtonClicked(object sender, EventArgs e)
        {
            Process.Start("https://www.notion.so/novacore-dragonsky/859f0413eecc4a4fb352796fc2522744");
        }

        private void ShowPathButton_Click(object sender, EventArgs e)
        {
            Process.Start("config.txt");
        }

        private void EditPathButton_Click(object sender, EventArgs e)
        {
            var __settingForm = new PathSettingForm();
            __settingForm.ShowDialog();
            SetPath();
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
            var __command = @"curl -X post http://novacore:11600e9374411596ce798672372d919152@121.131.71.175:8080/job/DS_Release/build?token=IOSBuildQA";

            ExecuteCommand(__workingDir, __command);
        }

        void BuildAndroid()
        {
            var __workingDir = @"C:\";

            clientVersion = clientVersionInputField.Text;

            var __command = $"curl -X post {@"http://novacore:119d76aaa8418a560da82377b2936ef0c1@121.131.71.175:9090/job/DS_AAB/buildWithParameters?token=DS_AAB"} -F clientVersion={clientVersion}";

            ExecuteCommand(__workingDir, __command);
        }
    }
}
