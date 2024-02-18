namespace BuildMaster
{
    partial class DiffCheck
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.diffPrjSettings = new System.Windows.Forms.Button();
            this.diffJFrameworkConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ConfirmButtonClicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(187, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CancelButtonClicked);
            // 
            // diffPrjSettings
            // 
            this.diffPrjSettings.Location = new System.Drawing.Point(59, 81);
            this.diffPrjSettings.Name = "diffPrjSettings";
            this.diffPrjSettings.Size = new System.Drawing.Size(75, 23);
            this.diffPrjSettings.TabIndex = 2;
            this.diffPrjSettings.Text = "Diff";
            this.diffPrjSettings.UseVisualStyleBackColor = true;
            this.diffPrjSettings.Click += new System.EventHandler(this.diffPrjSettings_Click);
            // 
            // diffJFrameworkConfig
            // 
            this.diffJFrameworkConfig.Location = new System.Drawing.Point(187, 81);
            this.diffJFrameworkConfig.Name = "diffJFrameworkConfig";
            this.diffJFrameworkConfig.Size = new System.Drawing.Size(75, 23);
            this.diffJFrameworkConfig.TabIndex = 3;
            this.diffJFrameworkConfig.Text = "Diff ";
            this.diffJFrameworkConfig.UseVisualStyleBackColor = true;
            this.diffJFrameworkConfig.Click += new System.EventHandler(this.diffJFrameworkConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "ProjectSettings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "JFrameworkConfig";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "클라이언트 버전업이 잘 되었는지 확인합니다.\r\n확인을 누르면 커밋됩니다.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DiffCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 187);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diffJFrameworkConfig);
            this.Controls.Add(this.diffPrjSettings);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DiffCheck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button diffPrjSettings;
        private System.Windows.Forms.Button diffJFrameworkConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
