namespace Client
{
    partial class UpLoadForm
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
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileSizeLabel = new System.Windows.Forms.Label();
            this.UpLoadButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Image = global::Client.Properties.Resources.System_pictures_icon;
            this.PictureBox.Location = new System.Drawing.Point(41, 32);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(158, 122);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(227, 32);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(53, 12);
            this.FileNameLabel.TabIndex = 3;
            this.FileNameLabel.Text = "파일명 : ";
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.AutoSize = true;
            this.FileSizeLabel.Location = new System.Drawing.Point(227, 131);
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(65, 12);
            this.FileSizeLabel.TabIndex = 4;
            this.FileSizeLabel.Text = "파일 크기 :";
            // 
            // UpLoadButton
            // 
            this.UpLoadButton.BackColor = System.Drawing.Color.Gray;
            this.UpLoadButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.UpLoadButton.Location = new System.Drawing.Point(1, 401);
            this.UpLoadButton.Name = "UpLoadButton";
            this.UpLoadButton.Size = new System.Drawing.Size(569, 49);
            this.UpLoadButton.TabIndex = 5;
            this.UpLoadButton.Text = "업로드";
            this.UpLoadButton.UseVisualStyleBackColor = false;
            this.UpLoadButton.Click += new System.EventHandler(this.UpLoadButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(1, 401);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(569, 49);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 6;
            this.ProgressBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(71, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "업로드 파일 선택";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // UpLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpLoadButton);
            this.Controls.Add(this.FileSizeLabel);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.ProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpLoadForm";
            this.Text = "업로드 창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpLoadForm_FormClosing);
            this.Load += new System.EventHandler(this.UpLoadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label FileSizeLabel;
        private System.Windows.Forms.Button UpLoadButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}