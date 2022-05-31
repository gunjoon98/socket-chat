using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class LoginForm : Form
    {
        User user = null;

        //생성자
        public LoginForm(User user)
        { 
            InitializeComponent();
            //ChatRoomFrom에 사용자 정보를 넘기기 위함
            this.user = user;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //소켓 생성 및 서버와 연결
            user.clnt_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint iP = new IPEndPoint(IPAddress.Parse(ServAddress.ip), ServAddress.port);
            try
            {
                user.clnt_sock.Connect(iP);
            }
            //서버가 아직 열리지 않음
            catch(SocketException)
            {
                //오류 메세지 출력하고 프로그램을 종료한다.
                MessageBox.Show("서버가 닫혔습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void IdTextBox_Enter(object sender, EventArgs e)
        {
            if (IdTextBox.ForeColor == Color.Gray)
            {
                IdTextBox.Clear();
                IdTextBox.ForeColor = Color.Black;
            }
        }

        private void IdTextBox_Leave(object sender, EventArgs e)
        {
            if(IdTextBox.Text == "")
            {
                IdTextBox.ForeColor = Color.Gray;
                IdTextBox.Text = "계정 (6~20자)";
            }
        }

        private void PwTextBox_Enter(object sender, EventArgs e)
        {
            if (PwTextBox.ForeColor == Color.Gray)
            {
                PwTextBox.Clear();
                PwTextBox.ForeColor = Color.Black;
                PwTextBox.PasswordChar = '●';
            }
        }

        private void PwTextBox_Leave(object sender, EventArgs e)
        {
            if(PwTextBox.Text == "")
            {
                PwTextBox.ForeColor = Color.Gray;
                PwTextBox.PasswordChar = '\0';
                PwTextBox.Text = "비밀번호 (6~20자)";
            }
        }

        private void IdTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //엔터 치면 로그인 버튼 클릭
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
                return;
            }

            //아이디와 비밀번호 6글자 이상 치면 로그인 버튼 색깔 바뀜
            if (IdTextBox.Text.Length >= 6 && PwTextBox.Text.Length  >= 6 && PwTextBox.ForeColor == Color.Black)
            {
                LoginButton.BackColor = Color.White;
            }
            else
            {
                LoginButton.BackColor = Color.Gray;
            }
        }

        private void PwTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //엔터 치면 로그인 버튼 클릭
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
                return;
            }

            //아이디와 비밀번호 6글자 이상 치면 로그인 버튼 색깔 바뀜
            if (IdTextBox.Text.Length >= 6 && PwTextBox.Text.Length >= 6 && IdTextBox.ForeColor == Color.Black)
            {
                LoginButton.BackColor = Color.White;
            }
            else
            {
                LoginButton.BackColor = Color.Gray;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //버튼 White 색일때만 클릭했을 때 작동됨
            if (LoginButton.BackColor == Color.Gray)
            {
                return;
            }

            //아이디 또는 비밀번호에 영문자나 숫자가 아닌 문자가 포함되어 있는지 확인
            Regex regex = new Regex(@"[0-9a-zA-Z]");
            for(int i=0; i<IdTextBox.Text.Length; i++)
            {
                bool ismatch = regex.IsMatch(IdTextBox.Text[i].ToString());
                if(ismatch == false)
                {
                    MessageBox.Show("계정에는 한글, 특수 문자가 포함될 수 없습니다.", "오류", MessageBoxButtons.OK);
                    return;
                }
            }
            for(int i=0; i<PwTextBox.Text.Length; i++)
            {
                bool ismatch = regex.IsMatch(PwTextBox.Text[i].ToString());
                if (ismatch == false)
                {
                    MessageBox.Show("비밀번호에는 특수 문자가 포함될 수 없습니다.", "오류", MessageBoxButtons.OK);
                    return;
                }
            }

            try
            {
                //로그인 메세지 전송
                string str = IdTextBox.Text + "/" + PwTextBox.Text;
                user.clnt_sock.Send(Message.MessageMake(0, Message.GetStrEncodingLength(str), str));

                //서버 응답 메세지 수신
                //고정 길이 메세지 부분을 받는다.
                Message packet = new Message();
                user.message = new byte[8];
                Message.MessageResive(user.message, 0, 8, user.clnt_sock);
                packet.MessageTranslate(user.message, false);

                //가변 길이 메세지 부분을 받는다.
                user.message = new byte[packet.MessageLength];
                Message.MessageResive(user.message, 0, packet.MessageLength, user.clnt_sock);
                packet.MessageTranslate(user.message, true);

                //로그인 실패
                if (packet.Str == "false")
                {
                    MessageBox.Show("계정 또는 비밀번호를 다시 확인해주세요", "오류", MessageBoxButtons.OK);
                }
                //로그인 성공
                else
                {
                    //닉네임 넘겨주고 폼을 닫음
                    user.nickname = packet.Str;
                    this.Close();
                }
            }
            //서버 닫힘
            catch (SocketException)
            {
                MessageBox.Show("서버가 닫혔습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        //회원가입 폼 띄어줌
        private void JoinLable_Click(object sender, EventArgs e)
        {
            JoinForm joinForm = new JoinForm(user);
            joinForm.ShowDialog();
        }

        //회원탈퇴 폼 띄어줌
        private void DropOutLable_Click(object sender, EventArgs e)
        {
            DropOutForm dropOutForm = new DropOutForm(user);
            dropOutForm.ShowDialog();
        }
    }
}
