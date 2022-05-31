using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Client
{
    public partial class UpLoadForm : Form
    {
        Socket filesock;    //파일 데이터를 받기 위한 소켓
        FileStream fs;      //파일 스트림
        FileData filedata;  //업로드할 파일명과 크기

        //UI 쓰레드에게 작업 지시를 내리기 위한 델리게이트와 델리게이트 객체
        delegate void ChangeTextDelegate(Control ctrl, string s);
        delegate void ChangeVisibleDelegate(Control ctrl, bool b);
        delegate void ChangeColorDelegate(Control ctrl, Color c);
        delegate void ProgressBarDeleagte(Control ctrl);

        ChangeTextDelegate LabelTextChanger;
        ChangeVisibleDelegate ButtonVisibleChanger;
        ChangeColorDelegate ButtonColorChanger;
        ChangeVisibleDelegate ProgressBarVisibleChanger;
        ProgressBarDeleagte ProgressBarStepper;

        public UpLoadForm()
        {
            InitializeComponent();
            LabelTextChanger = LabelTextChange;
            ButtonColorChanger = ButtonColorChange;
            ButtonVisibleChanger = ButtonVisibleChange;
            ProgressBarVisibleChanger = ProgressBarVisibleChange;
            ProgressBarStepper = ProgressBarStep;
        }

        void LabelTextChange(Control ctrl, string str)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(LabelTextChanger, ctrl, str);
            }
            //UI 쓰레드가 Label 텍스트 바꿈
            else
            {
                ((Label)ctrl).Text = str;
            }
        }

        void ButtonColorChange(Control ctrl, Color c)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(ButtonColorChanger, ctrl, c);
            }
            //UI 쓰레드가 버튼 색상 바꿈
            else
            {
                ((Button)ctrl).BackColor = c;
            }
        }

        void ButtonVisibleChange(Control ctrl, bool b)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(ButtonVisibleChanger, ctrl, b);
            }
            //UI 쓰레드가 버튼 Visible 상태 바꿈
            else
            {
                ((Button)ctrl).Visible = b;
            }
        }

        void ProgressBarVisibleChange(Control ctrl, bool b)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(ProgressBarVisibleChanger, ctrl, b);
            }
            //UI 쓰레드가 ProgreeBar Visible 상태 바꿈
            else
            {
                ((ProgressBar)ctrl).Visible = b;
            }
        }

        void ProgressBarStep(Control ctrl)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(ProgressBarStepper, ctrl);
            }
            else
            {
                ((ProgressBar)ctrl).PerformStep();
            }
        }

        private void UpLoadForm_Load(object sender, EventArgs e)
        {
            //소켓 생성 및 서버와 연결
            filesock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint iP = new IPEndPoint(IPAddress.Parse(ServAddress.ip), ServAddress.port);
            filesock.Connect(iP);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            //업로드 파일 선택
            openFileDialog.ShowDialog();
            //파일을 선택하지 않으면 리턴
            if(openFileDialog.FileName == "openFileDialog1")
            {
                FileNameLabel.Text = "파일명 : ";
                FileSizeLabel.Text = "파일크기 : ";
                UpLoadButton.BackColor = Color.Gray;
                return;
            }
            
            //파일 이름, 파일 바이트 추가
            FileInfo info = new FileInfo(openFileDialog.FileName);
            FileNameLabel.Text = "파일명 : " + info.Name;
            double size = info.Length;
            
            if(size >= 1073741824) //기가 바이트
            {
                size /= 107341824;
                FileSizeLabel.Text = string.Format("파일 크기 {0:F2} GB", size);
            }
            else if (size >= 1048576) //메가 바이트
            {
                size /= 1048576;
                FileSizeLabel.Text = string.Format("파일 크기 {0:F2} MB", size);
            }
            else //킬로 바이트
            {
                size /= 1024;
                FileSizeLabel.Text = string.Format("파일 크기 {0:F2} KB", size);
            }

            UpLoadButton.BackColor = Color.White;
        }

        private void UpLoadButton_Click(object sender, EventArgs e)
        {
            //업로드 버튼이 회색일때 작동 안함
            if (UpLoadButton.BackColor == Color.Gray)
            {
                return;
            }
            UpLoadButton.BackColor = Color.Gray;

            //파일 이름과 바이트를 변수에 저장한다.
            FileInfo info = new FileInfo(openFileDialog.FileName);
            filedata = new FileData(info.Name, info.Length);
            string str = filedata.filename + '/' + filedata.filesize;

            //9번 (파일 업로드 시작 메세지)을 전송한다.
            filesock.Send(Message.MessageMake(9, Message.GetStrEncodingLength(str), str));

            ProgressBar.Value = 0;
            byte[] buffer = new byte[8];
            filesock.BeginReceive(buffer, 0, 8, 0, ReciveCalback, buffer);
        }

        private void ReciveCalback(IAsyncResult result)
        {
            byte[] buffer = (byte[])result.AsyncState;
            int recv_cnt = 0;
            Message packet = new Message();

            try
            {   //고정 길이 메세지 부분을 받는다.
                recv_cnt = filesock.EndReceive(result);
                if (recv_cnt == 0)
                    throw new SocketException();
                Message.MessageResive(buffer, recv_cnt, 8, filesock);
                packet.MessageTranslate(buffer, false);

                //가변 길이 메세지 부분을 받는다.
                buffer = new byte[packet.MessageLength];
                Message.MessageResive(buffer, 0, packet.MessageLength, filesock);
                packet.MessageTranslate(buffer, true);

                if(packet.Str == "false")
                {
                    LabelTextChanger(FileNameLabel, "파일명 : ");
                    LabelTextChanger(FileSizeLabel, "파일 크기 : ");
                    ButtonColorChanger(UpLoadButton, Color.Gray);
                    MessageBox.Show("이미 같은 이름의 파일이 업로드 중이거나 업로드 되었습니다.", "오류", MessageBoxButtons.OK);
                    return;
                }

                //파일 스트림을 연다
                fs = File.Open(openFileDialog.FileName, FileMode.Open);
              
                //업로드 시작
                //ProgressBar, 파일 관련 변수
                double onestep = filedata.filesize / (double)100;
                double sendbyte = 0;
                long eof = filedata.filesize;
                buffer = new byte[1024];

                //버튼은 ProgressBar로 교체
                ButtonVisibleChanger(UpLoadButton, false);
                ProgressBarVisibleChanger(ProgressBar, true);

                //10번과 11번 메세지를 전송
                while (true)
                {
                    if (eof <= 1024)
                    {
                        buffer = new byte[eof];
                        fs.Read(buffer, 0, (int)eof);
                        filesock.Send(Message.FileMessageMake(11, buffer.Length, buffer));
                        sendbyte += eof;
                        while (sendbyte / onestep >= 1)
                        {
                            ProgressBarStepper(ProgressBar);
                            sendbyte -= onestep;
                        }
                        break;
                    }
                    fs.Read(buffer, 0, 1024);
                    filesock.Send(Message.FileMessageMake(10, buffer.Length, buffer));
                    eof -= 1024;
                    sendbyte += 1024;
                    while (sendbyte / onestep >= 1)
                    {
                        ProgressBar.PerformStep();
                        sendbyte -= onestep;
                    }
                }
                
                //응답 메세지를 받는다.
                buffer = new byte[8];
                Message.MessageResive(buffer, recv_cnt, 8, filesock);
                packet.MessageTranslate(buffer, false);

                buffer = new byte[packet.MessageLength];
                Message.MessageResive(buffer, 0, packet.MessageLength, filesock);
                packet.MessageTranslate(buffer, true);

                //ProgressBar는 버튼으로 교체한다.
                fs.Close();
                ProgressBarVisibleChanger(ProgressBar, false);
                LabelTextChanger(FileNameLabel, "파일명: ");
                LabelTextChanger(FileSizeLabel, "파일크기: ");
                ButtonColorChanger(UpLoadButton, Color.Gray);
                ButtonVisibleChanger(UpLoadButton, true);
                MessageBox.Show("업로드가 완료되었습니다.", "알림", MessageBoxButtons.OK);
            }
            //서버가 연결 끊으면
            catch (SocketException)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return;
            }
            //중간에 파일 전송을 중지하면
            catch (ObjectDisposedException)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return;
            }
        }
        
        private void UpLoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //파일 소켓 소켓을 닫는다.
            filesock.Close();
            filesock.Dispose();
        }
    }
}
