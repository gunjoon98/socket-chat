namespace Client
{
    partial class DropOutForm
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.PwTextBox = new System.Windows.Forms.TextBox();
            this.DropOutButten = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Image = global::Client.Properties.Resources.Circle_icons_chat_svg;
            this.PictureBox.Location = new System.Drawing.Point(118, 47);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(109, 100);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 2;
            this.PictureBox.TabStop = false;
            // 
            // IdTextBox
            // 
            this.IdTextBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IdTextBox.ForeColor = System.Drawing.Color.Gray;
            this.IdTextBox.Location = new System.Drawing.Point(71, 192);
            this.IdTextBox.MaxLength = 20;
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(208, 23);
            this.IdTextBox.TabIndex = 1;
            this.IdTextBox.Text = "계정 (6~20자)";
            this.IdTextBox.Enter += new System.EventHandler(this.IdTextBox_Enter);
            this.IdTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IdTextBox_KeyUp);
            this.IdTextBox.Leave += new System.EventHandler(this.IdTextBox_Leave);
            // 
            // PwTextBox
            // 
            this.PwTextBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PwTextBox.ForeColor = System.Drawing.Color.Gray;
            this.PwTextBox.Location = new System.Drawing.Point(71, 224);
            this.PwTextBox.MaxLength = 20;
            this.PwTextBox.Name = "PwTextBox";
            this.PwTextBox.Size = new System.Drawing.Size(208, 23);
            this.PwTextBox.TabIndex = 2;
            this.PwTextBox.Text = "비밀번호 (6~20자)";
            this.PwTextBox.Enter += new System.EventHandler(this.PwTextBox_Enter);
            this.PwTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PwTextBox_KeyUp);
            this.PwTextBox.Leave += new System.EventHandler(this.PwTextBox_Leave);
            // 
            // DropOutButten
            // 
            this.DropOutButten.BackColor = System.Drawing.Color.Gray;
            this.DropOutButten.FlatAppearance.BorderSize = 0;
            this.DropOutButten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DropOutButten.Location = new System.Drawing.Point(71, 336);
            this.DropOutButten.Name = "DropOutButten";
            this.DropOutButten.Size = new System.Drawing.Size(208, 42);
            this.DropOutButten.TabIndex = 3;
            this.DropOutButten.Text = "회원탈퇴";
            this.DropOutButten.UseVisualStyleBackColor = false;
            this.DropOutButten.Click += new System.EventHandler(this.DropOutButten_Click);
            // 
            // DropOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(346, 406);
            this.Controls.Add(this.DropOutButten);
            this.Controls.Add(this.PwTextBox);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.PictureBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DropOutForm";
            this.Text = "회원탈퇴";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.TextBox PwTextBox;
        private System.Windows.Forms.Button DropOutButten;
    }
}