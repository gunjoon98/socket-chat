namespace Client
{
    partial class ChatRoomFrom
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
            this.ChatRoom = new System.Windows.Forms.TextBox();
            this.UserList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NickNameLable = new System.Windows.Forms.Label();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.DownLoadButten = new System.Windows.Forms.PictureBox();
            this.UpLoadButten = new System.Windows.Forms.PictureBox();
            this.EnterButten = new System.Windows.Forms.PictureBox();
            this.FontButteb = new System.Windows.Forms.PictureBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DownLoadButten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpLoadButten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterButten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontButteb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatRoom
            // 
            this.ChatRoom.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ChatRoom.Location = new System.Drawing.Point(21, 94);
            this.ChatRoom.Multiline = true;
            this.ChatRoom.Name = "ChatRoom";
            this.ChatRoom.ReadOnly = true;
            this.ChatRoom.Size = new System.Drawing.Size(641, 392);
            this.ChatRoom.TabIndex = 1;
            this.ChatRoom.TabStop = false;
            // 
            // UserList
            // 
            this.UserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.UserList.GridLines = true;
            this.UserList.Location = new System.Drawing.Point(672, 94);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(119, 392);
            this.UserList.TabIndex = 2;
            this.UserList.TabStop = false;
            this.UserList.UseCompatibleStateImageBehavior = false;
            this.UserList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "     -대화 상대-";
            this.columnHeader1.Width = 118;
            // 
            // NickNameLable
            // 
            this.NickNameLable.AutoSize = true;
            this.NickNameLable.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NickNameLable.Location = new System.Drawing.Point(117, 39);
            this.NickNameLable.Name = "NickNameLable";
            this.NickNameLable.Size = new System.Drawing.Size(50, 25);
            this.NickNameLable.TabIndex = 4;
            this.NickNameLable.Text = "User";
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ChatTextBox.Location = new System.Drawing.Point(21, 496);
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(569, 23);
            this.ChatTextBox.TabIndex = 1;
            this.ChatTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChatTextBox_KeyUp);
            // 
            // DownLoadButten
            // 
            this.DownLoadButten.Image = global::Client.Properties.Resources.download;
            this.DownLoadButten.Location = new System.Drawing.Point(679, 14);
            this.DownLoadButten.Name = "DownLoadButten";
            this.DownLoadButten.Size = new System.Drawing.Size(104, 61);
            this.DownLoadButten.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DownLoadButten.TabIndex = 11;
            this.DownLoadButten.TabStop = false;
            this.DownLoadButten.Click += new System.EventHandler(this.DownLoadButten_Click);
            // 
            // UpLoadButten
            // 
            this.UpLoadButten.Image = global::Client.Properties.Resources.Upload_PNG_Pic;
            this.UpLoadButten.Location = new System.Drawing.Point(559, 12);
            this.UpLoadButten.Name = "UpLoadButten";
            this.UpLoadButten.Size = new System.Drawing.Size(104, 63);
            this.UpLoadButten.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UpLoadButten.TabIndex = 10;
            this.UpLoadButten.TabStop = false;
            this.UpLoadButten.Click += new System.EventHandler(this.UpLoadButten_Click);
            // 
            // EnterButten
            // 
            this.EnterButten.BackColor = System.Drawing.SystemColors.Highlight;
            this.EnterButten.Image = global::Client.Properties.Resources.enter_key;
            this.EnterButten.Location = new System.Drawing.Point(587, 490);
            this.EnterButten.Name = "EnterButten";
            this.EnterButten.Size = new System.Drawing.Size(76, 61);
            this.EnterButten.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnterButten.TabIndex = 8;
            this.EnterButten.TabStop = false;
            this.EnterButten.Click += new System.EventHandler(this.EnterButten_Click);
            // 
            // FontButteb
            // 
            this.FontButteb.Image = global::Client.Properties.Resources.font_icon__icon_search_engine__iconfinder_1;
            this.FontButteb.Location = new System.Drawing.Point(679, 490);
            this.FontButteb.Name = "FontButteb";
            this.FontButteb.Size = new System.Drawing.Size(104, 61);
            this.FontButteb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FontButteb.TabIndex = 9;
            this.FontButteb.TabStop = false;
            this.FontButteb.Click += new System.EventHandler(this.FontButteb_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.Image = global::Client.Properties.Resources.Circle_icons_chat_svg;
            this.PictureBox.Location = new System.Drawing.Point(21, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(79, 76);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 3;
            this.PictureBox.TabStop = false;
            // 
            // ChatRoomFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(813, 557);
            this.Controls.Add(this.DownLoadButten);
            this.Controls.Add(this.UpLoadButten);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.EnterButten);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.FontButteb);
            this.Controls.Add(this.NickNameLable);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.ChatRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatRoomFrom";
            this.Text = "채팅방";
            this.Load += new System.EventHandler(this.ChatRoomFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DownLoadButten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpLoadButten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnterButten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontButteb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChatRoom;
        private System.Windows.Forms.ListView UserList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label NickNameLable;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.PictureBox EnterButten;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.PictureBox FontButteb;
        private System.Windows.Forms.PictureBox UpLoadButten;
        private System.Windows.Forms.PictureBox DownLoadButten;
    }
}