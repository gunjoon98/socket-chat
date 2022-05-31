namespace Client
{
    partial class DownLoadForm
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
            this.FileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownLoadButten = new System.Windows.Forms.Button();
            this.FileNameLable = new System.Windows.Forms.Label();
            this.FileSizeLable = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // FileList
            // 
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.FileList.Location = new System.Drawing.Point(24, 32);
            this.FileList.MultiSelect = false;
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(197, 336);
            this.FileList.TabIndex = 0;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            this.FileList.ItemActivate += new System.EventHandler(this.FileList_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "파일명";
            this.columnHeader1.Width = 123;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "용량";
            this.columnHeader2.Width = 73;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "바이트";
            // 
            // DownLoadButten
            // 
            this.DownLoadButten.BackColor = System.Drawing.Color.Gray;
            this.DownLoadButten.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DownLoadButten.Location = new System.Drawing.Point(0, 401);
            this.DownLoadButten.Name = "DownLoadButten";
            this.DownLoadButten.Size = new System.Drawing.Size(569, 49);
            this.DownLoadButten.TabIndex = 1;
            this.DownLoadButten.Text = "다운로드";
            this.DownLoadButten.UseVisualStyleBackColor = false;
            this.DownLoadButten.Click += new System.EventHandler(this.DownLoadButten_Click);
            // 
            // FileNameLable
            // 
            this.FileNameLable.AutoSize = true;
            this.FileNameLable.Location = new System.Drawing.Point(227, 32);
            this.FileNameLable.Name = "FileNameLable";
            this.FileNameLable.Size = new System.Drawing.Size(53, 12);
            this.FileNameLable.TabIndex = 2;
            this.FileNameLable.Text = "파일명 : ";
            // 
            // FileSizeLable
            // 
            this.FileSizeLable.AutoSize = true;
            this.FileSizeLable.Location = new System.Drawing.Point(227, 131);
            this.FileSizeLable.Name = "FileSizeLable";
            this.FileSizeLable.Size = new System.Drawing.Size(65, 12);
            this.FileSizeLable.TabIndex = 3;
            this.FileSizeLable.Text = "파일 크기 :";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 401);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(569, 49);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // DownLoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(569, 450);
            this.Controls.Add(this.FileSizeLable);
            this.Controls.Add(this.FileNameLable);
            this.Controls.Add(this.DownLoadButten);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DownLoadForm";
            this.Text = "다운로드 창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownLoadForm_FormClosing);
            this.Load += new System.EventHandler(this.DownLoadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView FileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button DownLoadButten;
        private System.Windows.Forms.Label FileNameLable;
        private System.Windows.Forms.Label FileSizeLable;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}