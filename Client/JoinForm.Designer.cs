namespace Client
{
    partial class JoinForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.PwTextBox = new System.Windows.Forms.TextBox();
            this.NickNameTextBox = new System.Windows.Forms.TextBox();
            this.JoinButten = new System.Windows.Forms.Button();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdTextBox.ForeColor = System.Drawing.Color.Gray;
            this.IdTextBox.Location = new System.Drawing.Point(71, 192);
            this.IdTextBox.MaxLength = 20;
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(208, 21);
            this.IdTextBox.TabIndex = 1;
            this.IdTextBox.Text = "계정 (6~20자)";
            this.IdTextBox.Enter += new System.EventHandler(this.IdTextBox_Enter);
            this.IdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IdTextBox_KeyUp);
            this.IdTextBox.Leave += new System.EventHandler(this.IdTextBox_Leave);
            // 
            // PwTextBox
            // 
            this.PwTextBox.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PwTextBox.Location = new System.Drawing.Point(71, 224);
            this.PwTextBox.MaxLength = 20;
            this.PwTextBox.Name = "PwTextBox";
            this.PwTextBox.Size = new System.Drawing.Size(208, 21);
            this.PwTextBox.TabIndex = 2;
            this.PwTextBox.Text = "비밀번호 (6~20자)";
            this.PwTextBox.Enter += new System.EventHandler(this.PwTextBox_Enter);
            this.PwTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PwTextBox_KeyUp);
            this.PwTextBox.Leave += new System.EventHandler(this.PwTextBox_Leave);
            // 
            // NickNameTextBox
            // 
            this.NickNameTextBox.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NickNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.NickNameTextBox.Location = new System.Drawing.Point(71, 256);
            this.NickNameTextBox.MaxLength = 7;
            this.NickNameTextBox.Name = "NickNameTextBox";
            this.NickNameTextBox.Size = new System.Drawing.Size(208, 21);
            this.NickNameTextBox.TabIndex = 3;
            this.NickNameTextBox.Text = "닉네임 (2~7자)";
            this.NickNameTextBox.Enter += new System.EventHandler(this.NickNameTextBox_Enter);
            this.NickNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NickNameTextBox_KeyUp);
            this.NickNameTextBox.Leave += new System.EventHandler(this.NickNameTextBox_Leave);
            // 
            // JoinButten
            // 
            this.JoinButten.BackColor = System.Drawing.Color.Gray;
            this.JoinButten.FlatAppearance.BorderSize = 0;
            this.JoinButten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinButten.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.JoinButten.Location = new System.Drawing.Point(71, 336);
            this.JoinButten.Name = "JoinButten";
            this.JoinButten.Size = new System.Drawing.Size(208, 42);
            this.JoinButten.TabIndex = 4;
            this.JoinButten.Text = "회원가입";
            this.JoinButten.UseVisualStyleBackColor = false;
            this.JoinButten.Click += new System.EventHandler(this.JoinButten_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.Image = global::Client.Properties.Resources.Circle_icons_chat_svg;
            this.PictureBox.Location = new System.Drawing.Point(118, 47);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(109, 100);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            // 
            // JoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(346, 406);
            this.Controls.Add(this.JoinButten);
            this.Controls.Add(this.NickNameTextBox);
            this.Controls.Add(this.PwTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.PictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "JoinForm";
            this.Text = "회원가입";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox PwTextBox;
        private System.Windows.Forms.TextBox NickNameTextBox;
        private System.Windows.Forms.Button JoinButten;
    }
}