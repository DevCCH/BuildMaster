namespace BuildMaster
{
    partial class ProjectSettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.prjPathInputField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.editorPathInputField = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.aosBuildMethodInputField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iosBuildMethodInputField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.aosBuildCommandFormatInputField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "프로젝트 경로";
            // 
            // prjPathInputField
            // 
            this.prjPathInputField.Location = new System.Drawing.Point(117, 71);
            this.prjPathInputField.Name = "prjPathInputField";
            this.prjPathInputField.Size = new System.Drawing.Size(262, 21);
            this.prjPathInputField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "유니티 에디터 경로";
            // 
            // editorPathInputField
            // 
            this.editorPathInputField.Location = new System.Drawing.Point(117, 110);
            this.editorPathInputField.Name = "editorPathInputField";
            this.editorPathInputField.Size = new System.Drawing.Size(262, 21);
            this.editorPathInputField.TabIndex = 3;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(100, 282);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "확인";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.OnConfirmButtonClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(225, 282);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "취소";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "프로젝트명";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 21);
            this.textBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "AOS빌드 메소드";
            // 
            // aosBuildMethodInputField
            // 
            this.aosBuildMethodInputField.Location = new System.Drawing.Point(117, 179);
            this.aosBuildMethodInputField.Name = "aosBuildMethodInputField";
            this.aosBuildMethodInputField.Size = new System.Drawing.Size(262, 21);
            this.aosBuildMethodInputField.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "IOS빌드 메소드";
            // 
            // iosBuildMethodInputField
            // 
            this.iosBuildMethodInputField.Location = new System.Drawing.Point(117, 215);
            this.iosBuildMethodInputField.Name = "iosBuildMethodInputField";
            this.iosBuildMethodInputField.Size = new System.Drawing.Size(262, 21);
            this.iosBuildMethodInputField.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "AOS빌드명령어포맷";
            // 
            // aosBuildCommandFormatInputField
            // 
            this.aosBuildCommandFormatInputField.Location = new System.Drawing.Point(117, 144);
            this.aosBuildCommandFormatInputField.Name = "aosBuildCommandFormatInputField";
            this.aosBuildCommandFormatInputField.Size = new System.Drawing.Size(262, 21);
            this.aosBuildCommandFormatInputField.TabIndex = 13;
            // 
            // ProjectSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 341);
            this.Controls.Add(this.aosBuildCommandFormatInputField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.iosBuildMethodInputField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.aosBuildMethodInputField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.editorPathInputField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prjPathInputField);
            this.Controls.Add(this.label1);
            this.Name = "ProjectSettingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prjPathInputField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox editorPathInputField;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox aosBuildMethodInputField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox iosBuildMethodInputField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox aosBuildCommandFormatInputField;
    }
}
