using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class DownLoadForm : Form
    {
        Socket filesock;            //파일 데이터를 받기 위한 소켓
        FileStream fs;              //파일 스트림
        FileData fileData;          //다운로드 받을 파일명과 크기

        //UI 쓰레드에게 작업 지시를 내리기 위한 델리게이트와 델리게이트 객체
        delegate void ChangeTextDelegate(Control ctrl, string s);
        delegate void ChangeVisibleDelegate(Control ctrl, bool b);
        delegate void ChangeColorDelegate(Control ctrl, Color c);
        delegate void ProgressBarDeleagte(Control ctrl); 

        ChangeTextDelegate LableTextChanger;                //Lable 텍스트 바꿈
        ChangeVisibleDelegate ButtenVisibleChanger;         //Butten Visible 상태 바꿈
        ChangeColorDelegate ButtenColorChanger;             //Button 색상 바꿈
        ChangeVisibleDelegate ProgressBarVisibleChanger;    //ProgressBar Visible 상태 바꿈
        ProgressBarDeleagte ProgressBarStepper;             //ProgressBar step 증가


        public DownLoadForm()
        {
            InitializeComponent();
            LableTextChanger = LableTextChange;
            ButtenVisibleChanger = ButtenVisibleChange;
            ButtenColorChanger = ButtenColorChange;
            ProgressBarVisibleChanger = ProgressBarVisibleChange;
            ProgressBarStepper = ProgressBarStep;
        }

        void LableTextChange(Control ctrl, string str)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(LableTextChanger,ctrl,str);
            }
            //UI 쓰레드가 Lable 텍스트 바꿈
            else
            {
                ((Label)ctrl).Text = str;
            }
        }

        void ButtenVisibleChange(Control ctrl, bool b)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(ButtenVisibleChanger, ctrl, b);
            }
            //UI 쓰레드가 버튼 Visible 상태 바꿈
            else
            {
                ((Button)ctrl).Visible = b;
            }
        }

        void ButtenColorChange(Control ctrl, Color c)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(ButtenColorChanger, ctrl, c);
            }
            //UI 쓰레드가 버튼 색상 바꿈
            else
            {
                ((Button)ctrl).BackColor = c;
            }
        }

        void ProgressBarVisibleChange(Control ctrl, bool b)
        {
            //이 함수를 호출한 쓰레드가 UI 쓰레드가 아닐 경우
            if(ctrl.InvokeRequired)
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

        private void DownLoadForm_Load(object sender, EventArgs e)
        {
            //소켓 생성 및 서버와 연결
            filesock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint iP = new IPEndPoint(IPAddress.Parse(ServAddress.ip), ServAddress.port);
            filesock.Connect(iP);
        }

        //파일 리스트 뷰에 문자열 추가
        public void ListViewAdd(string filename, string filesize)
        {
            //(파일 이름, 파일 사이즈, 파일 바이트) 
            //파일 이름 추가
            string[] arr = new string[3];
            arr[0] = filename;

            //파일 사이즈, 바이트 추가
            arr[2] = Convert.ToString(filesize);
            double size = Convert.ToDouble(filesize);
            if (size >= 1073741824) //기가 바이트
            {
                size /= 107341824;
                arr[1] = string.Format("{0:F2} GB", size);
            }
            else if (size >= 1048576) //메가 바이트
            {
                size /= 1048576;
                arr[1] = string.Format("{0:F2} MB", size);
            }
            else
            {
                size /= 1024;
                arr[1] = string.Format("{0:F2} KB", size);
            }
            ListViewItem item = new ListViewItem(arr);
            FileList.Items.Add(item);
        }

        private void FileList_ItemActivate(object sender, EventArgs e)
        {
            //선택된 항목 레이블에 출력하고 버튼 흰색
            FileNameLable.Text = "파일명 : " + FileList.SelectedItems[0].SubItems[0].Text;
            FileSizeLable.Text = "파일 크기 : " + FileList.SelectedItems[0].SubItems[1].Text;
            DownLoadButten.BackColor = Color.White;
        }

        private void DownLoadButten_Click(object sender, EventArgs e)
        {
            //다운로드 버튼이 회색일때 작동 안함
            if (DownLoadButten.BackColor == Color.Gray)
            {
                return;
            }

            folderBrowserDialog.ShowDialog();
            //폴더를 선택하지 않으면 리턴
            if (folderBrowserDialog.SelectedPath == "")
            {
                FileNameLable.Text = "파일명 : ";
                FileSizeLable.Text = "파일 크기 : ";
                DownLoadButten.BackColor = Color.Gray;
                return;
            }

            //파일 이름과 바이트를 변수에 저장한다.
            fileData = new FileData(FileList.SelectedItems[0].SubItems[0].Text, long.Parse(FileList.SelectedItems[0].SubItems[2].Text));
            progressBar.Value = 0;

            //12번 (파일 다운로드 시작 메세지)를 전송
            filesock.Send(Message.MessageMake(12, Message.GetStrEncodingLength(fileData.filename), fileData.filename));

            DownLoadButten.BackColor = Color.Gray;
            byte[] buffer = new byte[8];
            filesock.BeginReceive(buffer, 0, 8, 0, ReciveCalback, buffer);
        }

        void ReciveCalback(IAsyncResult result)
        {
            byte[] buffer = (byte [])result.AsyncState;
            int recv_cnt = 0;
            Message packet = new Message();

            try
            {
                //고정 길이 메세지 부분을 받는다.
                recv_cnt = filesock.EndReceive(result);
                if (recv_cnt == 0)
                    throw new SocketException();
                Message.MessageResive(buffer, recv_cnt, 8, filesock);
                packet.MessageTranslate(buffer, false);

                //가변 길이 메세지 부분을 받는다.
                buffer = new byte[packet.MessageLength];
                Message.MessageResive(buffer, 0, packet.MessageLength, filesock);
                packet.MessageTranslate(buffer, true);

                //다운로드 실패
                if (packet.Str == "false")
                {
                    LableTextChanger(FileNameLable, "파일명 : ");
                    LableTextChanger(FileSizeLable, "파일 크기 : ");
                    ButtenColorChanger(DownLoadButten, Color.Gray);
                    MessageBox.Show("이미 다른 클라이언트가 다운로드 중입니다.", "오류", MessageBoxButtons.OK);
                    return;
                }

                //다운로드 시작
                //파일 스트림을 연다.
                try
                {
                    fs = File.Open(folderBrowserDialog.SelectedPath + '/' + fileData.filename, FileMode.CreateNew);
                }
                catch (IOException)
                {
                    //fs는 null
                    if (MessageBox.Show("해당 파일이 이미 있습니다. 덮어 쓰시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        LableTextChanger(FileNameLable, "파일명 : ");
                        LableTextChanger(FileSizeLable, "파일 크기 : ");
                        ButtenColorChanger(DownLoadButten, Color.Gray);
                        return;
                    }
                    else
                    {
                        try
                        {
                            fs = File.Open(folderBrowserDialog.SelectedPath + '/' + fileData.filename, FileMode.Create);
                        }
                        catch(IOException) //한 컴퓨터에서 여러개의 클라이언트를 실험할때 발생할수 있음. (원래는 한 컴퓨터당 클라이언트 하나)
                        {
                            MessageBox.Show("이미 다른 클라이언트가 다운로드 중입니다.", "오류", MessageBoxButtons.OK);
                            LableTextChanger(FileNameLable, "파일명 : ");
                            LableTextChanger(FileSizeLable, "파일 크기 : ");
                            ButtenColorChanger(DownLoadButten, Color.Gray);
                            return;
                        }
                    }
                }

                //ProgressBar 관련 변수
                double onestep = fileData.filesize / (double)100;
                double recivebyte = 0;

                //버튼은 ProgressBar로 교체
                ButtenVisibleChanger(DownLoadButten, false);
                ProgressBarVisibleChanger(progressBar, true);

                //13번 메세지와 14번 메시지를 받아 파일에다 씀
                while (true)
                {
                    //고정 길이 메세지 부분을 받는다.
                    buffer = new byte[8];
                    Message.MessageResive(buffer, 0, 8, filesock);
                    packet.MessageTranslate(buffer, false);

                    //가변 길이 메세지 부분을 받는다.
                    buffer = new byte[packet.MessageLength];
                    Message.MessageResive(buffer, 0, packet.MessageLength, filesock);
                    packet.MessageTranslate(buffer, true);

                    //파일에 가변 길이 메세지 부분을 쓴다.
                    fs.Write(buffer, 0, buffer.Length);

                    //ProgressBar를 증가시킨다.
                    recivebyte += buffer.Length;
                    while (recivebyte / onestep >= 1)
                    {
                        ProgressBarStepper(progressBar);
                        recivebyte -= onestep;
                    }

                    //14번 메세지이면 파일 쓰기를 끝낸다.
                    if (packet.MessageType == 14)
                    {
                        break;
                    }
                }
            }
            //서버가 연결 끊으면
            catch(SocketException)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return;
            }
            //중간에 파일 다운로드를 중지하면
            catch(ObjectDisposedException)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return;
            }

            //파일 스트림을 닫는다.
            fs.Close();

            //ProgressBar는 버튼으로 교체한다.
            ProgressBarVisibleChanger(progressBar, false);
            LableTextChanger(FileNameLable, "파일명 : ");
            LableTextChanger(FileSizeLable, "파일 크기 : ");
            ButtenColorChanger(DownLoadButten, Color.Gray);
            ButtenVisibleChanger(DownLoadButten, true);
            MessageBox.Show("다운로드가 완료되었습니다.", "알림", MessageBoxButtons.OK);
        }

        private void DownLoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //파일 소켓 소켓을 닫는다.
            filesock.Close();
            filesock.Dispose();
        }
    }
}
