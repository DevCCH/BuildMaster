namespace BuildMaster
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.clientVersionInputField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serverSlotInputField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tableVersionInputField = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.jenkinsIosButton = new System.Windows.Forms.Button();
            this.jenkinsAosButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.curStatusText = new System.Windows.Forms.Label();
            this.helpLinkButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.showPathButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.editPathButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AndroidBuildButton = new System.Windows.Forms.Button();
            this.buildIosButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ClientVersion : ";
            // 
            // clientVersionInputField
            // 
            this.clientVersionInputField.Location = new System.Drawing.Point(103, 119);
            this.clientVersionInputField.Name = "clientVersionInputField";
            this.clientVersionInputField.Size = new System.Drawing.Size(100, 21);
            this.clientVersionInputField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ServerSlot : ";
            // 
            // serverSlotInputField
            // 
            this.serverSlotInputField.Location = new System.Drawing.Point(103, 148);
            this.serverSlotInputField.Name = "serverSlotInputField";
            this.serverSlotInputField.Size = new System.Drawing.Size(100, 21);
            this.serverSlotInputField.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "ClientVersion과 ServerSlot을 입력 후 커밋 버튼을 누릅니다.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, -103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "svn업데이트를 먼저 진행합니다.";
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Coral;
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(69, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "버전업과 동시에 커밋 후 빌드 시작";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "OneClickBuild";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnOneClickBuildButtonClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "x.x.x 형식";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(209, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "ServerSlot은 1~4";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "TableVersion : ";
            // 
            // tableVersionInputField
            // 
            this.tableVersionInputField.Location = new System.Drawing.Point(103, 181);
            this.tableVersionInputField.Name = "tableVersionInputField";
            this.tableVersionInputField.Size = new System.Drawing.Size(100, 21);
            this.tableVersionInputField.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(209, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "0.x 형식 (svn 커밋 로그 남기기용)";
            // 
            // jenkinsIosButton
            // 
            this.jenkinsIosButton.Location = new System.Drawing.Point(366, 397);
            this.jenkinsIosButton.Name = "jenkinsIosButton";
            this.jenkinsIosButton.Size = new System.Drawing.Size(70, 23);
            this.jenkinsIosButton.TabIndex = 20;
            this.jenkinsIosButton.Text = "IOS";
            this.jenkinsIosButton.UseVisualStyleBackColor = true;
            this.jenkinsIosButton.Click += new System.EventHandler(this.jenkinsIosButton_Click);
            // 
            // jenkinsAosButton
            // 
            this.jenkinsAosButton.Location = new System.Drawing.Point(290, 397);
            this.jenkinsAosButton.Name = "jenkinsAosButton";
            this.jenkinsAosButton.Size = new System.Drawing.Size(70, 23);
            this.jenkinsAosButton.TabIndex = 21;
            this.jenkinsAosButton.Text = "Android";
            this.jenkinsAosButton.UseVisualStyleBackColor = true;
            this.jenkinsAosButton.Click += new System.EventHandler(this.jenkinsAosButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(326, 370);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "젠킨스 웹 접속";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(326, 230);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "현재 상태";
            // 
            // curStatusText
            // 
            this.curStatusText.AutoSize = true;
            this.curStatusText.Location = new System.Drawing.Point(336, 254);
            this.curStatusText.Name = "curStatusText";
            this.curStatusText.Size = new System.Drawing.Size(25, 12);
            this.curStatusText.TabIndex = 24;
            this.curStatusText.Text = "Idle";
            // 
            // helpLinkButton
            // 
            this.helpLinkButton.Location = new System.Drawing.Point(188, 509);
            this.helpLinkButton.Name = "helpLinkButton";
            this.helpLinkButton.Size = new System.Drawing.Size(83, 23);
            this.helpLinkButton.TabIndex = 25;
            this.helpLinkButton.Text = "도움말 링크";
            this.helpLinkButton.UseVisualStyleBackColor = true;
            this.helpLinkButton.Click += new System.EventHandler(this.HelpLinkButtonClicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(169, 483);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 12);
            this.label15.TabIndex = 26;
            this.label15.Text = "빌드마스터 도움말";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(92, 345);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 12);
            this.label16.TabIndex = 27;
            this.label16.Text = "설정된 경로 확인";
            // 
            // showPathButton
            // 
            this.showPathButton.Location = new System.Drawing.Point(53, 395);
            this.showPathButton.Name = "showPathButton";
            this.showPathButton.Size = new System.Drawing.Size(75, 23);
            this.showPathButton.TabIndex = 28;
            this.showPathButton.Text = "경로 확인";
            this.showPathButton.UseVisualStyleBackColor = true;
            this.showPathButton.Click += new System.EventHandler(this.ShowPathButton_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Location = new System.Drawing.Point(5, 370);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(269, 12);
            this.label17.TabIndex = 29;
            this.label17.Text = "메모장에서 경로 변경 시 재시작해야 적용됩니다.";
            // 
            // editPathButton
            // 
            this.editPathButton.Location = new System.Drawing.Point(175, 395);
            this.editPathButton.Name = "editPathButton";
            this.editPathButton.Size = new System.Drawing.Size(75, 23);
            this.editPathButton.TabIndex = 30;
            this.editPathButton.Text = "경로 변경";
            this.editPathButton.UseVisualStyleBackColor = true;
            this.editPathButton.Click += new System.EventHandler(this.EditPathButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(429, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "해당 프로젝트 버전의 유니티 에디터가 모두 꺼져있는 상태로 진행해야 합니다.";
            // 
            // AndroidBuildButton
            // 
            this.AndroidBuildButton.Location = new System.Drawing.Point(36, 291);
            this.AndroidBuildButton.Margin = new System.Windows.Forms.Padding(2);
            this.AndroidBuildButton.Name = "AndroidBuildButton";
            this.AndroidBuildButton.Size = new System.Drawing.Size(109, 19);
            this.AndroidBuildButton.TabIndex = 32;
            this.AndroidBuildButton.Text = "안드로이드 빌드";
            this.AndroidBuildButton.UseVisualStyleBackColor = true;
            this.AndroidBuildButton.Click += new System.EventHandler(this.AndroidBuildButton_Click);
            // 
            // buildIosButton
            // 
            this.buildIosButton.Location = new System.Drawing.Point(188, 291);
            this.buildIosButton.Margin = new System.Windows.Forms.Padding(2);
            this.buildIosButton.Name = "buildIosButton";
            this.buildIosButton.Size = new System.Drawing.Size(109, 19);
            this.buildIosButton.TabIndex = 33;
            this.buildIosButton.Text = "IOS빌드";
            this.buildIosButton.UseVisualStyleBackColor = true;
            this.buildIosButton.Click += new System.EventHandler(this.BuildIosButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 587);
            this.Controls.Add(this.buildIosButton);
            this.Controls.Add(this.AndroidBuildButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.editPathButton);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.showPathButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.helpLinkButton);
            this.Controls.Add(this.curStatusText);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.jenkinsAosButton);
            this.Controls.Add(this.jenkinsIosButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tableVersionInputField);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serverSlotInputField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clientVersionInputField);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "빌드마스터";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clientVersionInputField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverSlotInputField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tableVersionInputField;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button jenkinsIosButton;
        private System.Windows.Forms.Button jenkinsAosButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label curStatusText;
        private System.Windows.Forms.Button helpLinkButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button showPathButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button editPathButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AndroidBuildButton;
        private System.Windows.Forms.Button buildIosButton;
    }
}

