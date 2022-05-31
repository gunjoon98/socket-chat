namespace Client
{
    partial class LoginForm
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
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.PwTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.JoinLable = new System.Windows.Forms.Label();
            this.DropOutLable = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.IdTextBox.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdTextBox.ForeColor = System.Drawing.Color.Gray;
            this.IdTextBox.Location = new System.Drawing.Point(71, 217);
            this.IdTextBox.MaxLength = 20;
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(208, 22);
            this.IdTextBox.TabIndex = 1;
            this.IdTextBox.Text = "계정 (6~20자)";
            this.IdTextBox.Enter += new System.EventHandler(this.IdTextBox_Enter);
            this.IdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IdTextBox_KeyUp);
            this.IdTextBox.Leave += new System.EventHandler(this.IdTextBox_Leave);
            // 
            // PwTextBox
            // 
            this.PwTextBox.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PwTextBox.Location = new System.Drawing.Point(71, 246);
            this.PwTextBox.MaxLength = 20;
            this.PwTextBox.Name = "PwTextBox";
            this.PwTextBox.Size = new System.Drawing.Size(208, 22);
            this.PwTextBox.TabIndex = 2;
            this.PwTextBox.Text = "비밀번호 (6~20자)";
            this.PwTextBox.Enter += new System.EventHandler(this.PwTextBox_Enter);
            this.PwTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PwTextBox_KeyUp);
            this.PwTextBox.Leave += new System.EventHandler(this.PwTextBox_Leave);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.Gray;
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoginButton.Location = new System.Drawing.Point(71, 277);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(208, 42);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "로그인";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // JoinLable
            // 
            this.JoinLable.AutoSize = true;
            this.JoinLable.BackColor = System.Drawing.SystemColors.Highlight;
            this.JoinLable.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.JoinLable.ForeColor = System.Drawing.SystemColors.Window;
            this.JoinLable.Location = new System.Drawing.Point(69, 502);
            this.JoinLable.Name = "JoinLable";
            this.JoinLable.Size = new System.Drawing.Size(59, 13);
            this.JoinLable.TabIndex = 4;
            this.JoinLable.Text = "회원가입";
            this.JoinLable.Click += new System.EventHandler(this.JoinLable_Click);
            // 
            // DropOutLable
            // 
            this.DropOutLable.AutoSize = true;
            this.DropOutLable.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DropOutLable.ForeColor = System.Drawing.SystemColors.Window;
            this.DropOutLable.Location = new System.Drawing.Point(226, 502);
            this.DropOutLable.Name = "DropOutLable";
            this.DropOutLable.Size = new System.Drawing.Size(59, 13);
            this.DropOutLable.TabIndex = 5;
            this.DropOutLable.Text = "회원탈퇴";
            this.DropOutLable.Click += new System.EventHandler(this.DropOutLable_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.Image = global::Client.Properties.Resources.Circle_icons_chat_svg;
            this.PictureBox.Location = new System.Drawing.Point(118, 80);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(109, 100);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(346, 553);
            this.Controls.Add(this.DropOutLable);
            this.Controls.Add(this.JoinLable);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PwTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.Text = "로그인";
            this.TransparencyKey = System.Drawing.SystemColors.ScrollBar;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox PwTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label JoinLable;
        private System.Windows.Forms.Label DropOutLable;
    }
}

