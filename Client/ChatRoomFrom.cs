using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Client
{
    public partial class ChatRoomFrom : Form
    {
        UpLoadForm upLoadForm = null;
        DownLoadForm downLoadForm = null;
        User user = null;
        List<string> FileName = new List<string>();
        List<string> FileSize = new List<string>();
        
        //UI 쓰레드에게 작업 지시를 내리기 위한 델리게이트와 델리게이트 객체
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate ChatRoomTextAppender;    //채팅창에 텍스트 추가
        AppendTextDelegate UserListTextAppender;    //사용자 목록에 사용자 추가
        AppendTextDelegate UserListTextDeleter;     //사용자 목록에 사용자 제거

        //생성자
        public ChatRoomFrom(User user)
        {
            InitializeComponent();

            this.user = user;
            ChatRoomTextAppender = new AppendTextDelegate(ChatRoomTextAppend);
            UserListTextAppender = new AppendTextDelegate(UserListTextAppend);
            UserListTextDeleter = new AppendTextDelegate(UserListTextDelete);
        }

        void ChatRoomTextAppend(Control ctrl, string str)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(ChatRoomTextAppender, ctrl, str);
            }
            //UI 쓰레드가 채팅룸(텍스트 박스)에 텍스트 추가함
            else
            {
                ((TextBox)ctrl).AppendText(str);
            }
        }

        void UserListTextAppend(Control ctrl, string str)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(UserListTextAppender, ctrl, str);
            }
            //Ul 쓰레드가 유저 리스트(ListView)에 텍스트 추가함
            else
            {
                ((ListView)ctrl).Items.Add(str);
            }
        }

        void UserListTextDelete(Control ctrl, string str)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(UserListTextDeleter, ctrl, str);
            }
            //UI 쓰레드가 유저 리스트(ListView)에 텍스트 삭제
            else
            {
                ((ListView)ctrl).Items.Remove(((ListView)ctrl).FindItemWithText(str));
            }
        }

        private void ChatRoomFrom_Load(object sender, EventArgs e)
        {
            NickNameLable.Text = user.nickname;

            //서버의 데이터를 받는다.
            user.message = new byte[8];
            user.clnt_sock.BeginReceive(user.message,0,8,0,ReciveCalback, null);
        }

        //소켓 수신 콜백 함수
        void ReciveCalback(IAsyncResult result)
        {
            int recv_cnt = 0;
            Message packet = new Message();

            try
            {
                //고정 길이 메세지 부분을 받는다.
                recv_cnt = user.clnt_sock.EndReceive(result);
                //recv_cnt가 0이면 연결 끊는다.
                if (recv_cnt == 0)
                    throw new SocketException();
                Message.MessageResive(user.message, recv_cnt, 8, user.clnt_sock);
                packet.MessageTranslate(user.message, false);

                //가변 길이 메세지 부분을 받는다.
                user.message = new byte[packet.MessageLength];
                Message.MessageResive(user.message, 0, packet.MessageLength, user.clnt_sock);
                packet.MessageTranslate(user.message, true);

                //메세지 유형에 따라 각기 다른 처리를 해준다.     
                //서버 4번 메세지
                if (packet.MessageType == 4)
                {
                    //사용자 목록에 추가
                    UserListTextAppender(UserList, packet.Str);
                }

                //서버 5번 메세지
                else if (packet.MessageType == 5)
                {
                    //사용자 목록에서 삭제
                    UserListTextDeleter(UserList, packet.Str);
                }

                //서버 7번 메세지
                else if (packet.MessageType == 7)
                {
                    //채팅창에 추가
                    ChatRoomTextAppender(ChatRoom, packet.Str);
                }
                
                //서버 8번 메세지
                else if(packet.MessageType == 8)
                {
                    //파일 이름, 파일 크기 리스트에 추가한다.
                    string[] str = packet.Str.Split('/');
                    FileName.Add(str[0]);
                    FileSize.Add(str[1]);
                }

                //수신 대기
                user.message = new byte[8];
                user.clnt_sock.BeginReceive(user.message, 0, 8, 0, ReciveCalback, null);
            }
            //서버 닫힘
            catch (SocketException)
            {
                //프로그램을 종료한다.
                MessageBox.Show("서버가 닫혔습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void EnterButten_Click(object sender, EventArgs e)
        {
            if (ChatTextBox.Text == "")
            {
                return;
            }

            //채팅 메세지 채팅창에 추가
            string chatstr = "나 : " + ChatTextBox.Text + Environment.NewLine;
            ChatRoomTextAppender(ChatRoom, chatstr);

            //채팅 메세지(6번 메세지) 전송
            chatstr = user.nickname + " : " + ChatTextBox.Text + Environment.NewLine;
            user.clnt_sock.Send(Message.MessageMake(6, Message.GetStrEncodingLength(chatstr), chatstr));

            //채팅 텍스트 박스 비움
            ChatTextBox.Clear();
        }

        private void ChatTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //엔터 누르면 엔터 버튼 클릭
            if(e.KeyCode == Keys.Enter)
            {
                EnterButten_Click(sender, e);
            }
        }

        private void FontButteb_Click(object sender, EventArgs e)
        {
            //폰트, 색상 선택
            fontDialog.ShowDialog();
            ChatRoom.ReadOnly = false;
            ChatRoom.Font = fontDialog.Font;
            ChatRoom.ForeColor = fontDialog.Color;
            ChatRoom.ReadOnly = true;
        }

        private void DownLoadButten_Click(object sender, EventArgs e)
        {
            //다운로드 폼을 띄운다.
            if (downLoadForm == null || downLoadForm.IsDisposed)
            {
                downLoadForm = new DownLoadForm();
                for (int i = 0; i < FileName.Count; i++)
                {
                    downLoadForm.ListViewAdd(FileName[i], FileSize[i]);
                }
                downLoadForm.Show();
            }
        }

        private void UpLoadButten_Click(object sender, EventArgs e)
        {
            //업로드 폼을 띄운다.
            if (upLoadForm == null || upLoadForm.IsDisposed)
            {
                upLoadForm = new UpLoadForm();
                upLoadForm.Show();
            }
        }
    }
}
