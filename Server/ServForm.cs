using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Server
{
    public partial class ServForm : Form
    {
        public static List<Socket> LoginSockList = new List<Socket>();
        public static List<string> LoginNickNameList = new List<string>();
        Socket serv_sock = null;

        //생성자
        public ServForm()
        {
            InitializeComponent();
        }

        //서버폼 로드
        private void ServForm_Load(object sender, EventArgs e)
        {
            //소켓 생성 및 주소 할당
            serv_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint iP = new IPEndPoint(IPAddress.Parse(ServAddress.ip), ServAddress.port);
            try
            {
                serv_sock.Bind(iP);
            }

            //포트 번호가 중첩될 경우, 중복 실행할 경우
            catch (SocketException)
            {
                MessageBox.Show("이미 서버가 실행중이거나 서버 포트가 사용중입니다.", "오류", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            //소켓을 열어둔다.
            serv_sock.Listen(1000);

            //비동기적으로 클라이언트의 연결 요청을 받는다.
            serv_sock.BeginAccept(AcceptCallback, null);
        }

        //연결 요청 콜백 함수
        void AcceptCallback(IAsyncResult result)
        {
            User user = new User();
            user.message = new byte[8];
            user.clnt_sock = serv_sock.EndAccept(result);

            //또 다른 클라이언트의 연결을 대기한다.
            serv_sock.BeginAccept(AcceptCallback, null);

            //클라이언트의 데이터를 받는다.
            user.clnt_sock.BeginReceive(user.message, 0, 8, 0, ReciveCallback, user);
        }

        //소켓 수신 콜백 함수
        void ReciveCallback(IAsyncResult result)
        {
            User user = (User)result.AsyncState;
            int recv_cnt = 0;
            Message packet = new Message();
            FileStream fs = null;
            bool upload = false;

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
                //클라이언트 로그인 메세지
                if (packet.MessageType == 0)
                {
                    //가변 길이 메세지 분해
                    string[] str = packet.Str.Split('/');
                    string id = str[0];
                    string password = str[1];

                    //DB 연결
                    string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBase.mdb";
                    OleDbConnection connection = new OleDbConnection(conStr);
                    connection.Open();

                    //DB에 사용자 ID와 PassWord가 있는지 확인
                    string Sql = "select * from usertable where id = '" + id + "' and password = '" + password + "'";
                    OleDbCommand command = new OleDbCommand(Sql, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    //로그인 성공
                    if (reader.Read() == true)
                    {
                        //성공 메세지 전달(닉네임 전달)
                        user.clnt_sock.Send(Message.MessageMake(3, Message.GetStrEncodingLength((string)reader["nickname"]), (string)reader["nickname"]));

                        //로그인 했으므로 닉네임 추가
                        user.nickname = (string)reader["nickname"];

                        //4번 메세지(사용자 목록) 전달
                        foreach (string nickname in LoginNickNameList)
                        {
                            user.clnt_sock.Send(Message.MessageMake(4, Message.GetStrEncodingLength(nickname), nickname));
                        }

                        //로그인 되었으므로 소켓리스트와 닉네임리스트에 추가 
                        LoginSockList.Add(user.clnt_sock);
                        LoginNickNameList.Add(user.nickname);

                        //모든 사용자들에게 해당 클라이언트 닉네임을 넣은 4번 메세지와 7번메세지(입장 메세지) 전달
                        foreach (Socket socket in LoginSockList)
                        {
                            try
                            {
                                socket.Send(Message.MessageMake(4, Message.GetStrEncodingLength(user.nickname), user.nickname));
                                string joinstr = Environment.NewLine + "***************** " + user.nickname + " 님이 입장하셨습니다. *****************" + Environment.NewLine + Environment.NewLine;
                                socket.Send(Message.MessageMake(7, Message.GetStrEncodingLength(joinstr), joinstr));
                            }
                            catch (SocketException)
                            {

                            }
                        }

                        //8번 메세지(파일 목록) 전달
                        for (int i = 0; i < ServFile.FileList.Count; i++)
                        {
                            string msg = ServFile.FileList[i].filename + '/' + ServFile.FileList[i].filesize;
                            user.clnt_sock.Send(Message.MessageMake(8, Message.GetStrEncodingLength(msg), msg));
                        }
                    }

                    //로그인 실패
                    else
                    {
                        //실패 메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(3, Message.GetStrEncodingLength("false"), "false"));
                    }

                    //리소스 반환
                    reader.Close();
                    connection.Close();
                }

                //클라이언트 회원가입 메세지
                else if (packet.MessageType == 1)
                {
                    //가변 길이 메세지 분해
                    string[] str = packet.Str.Split('/');
                    string id = str[0];
                    string password = str[1];
                    string nickname = str[2];

                    //DB 연결
                    string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBase.mdb";
                    OleDbConnection connection = new OleDbConnection(conStr);
                    connection.Open();

                    //DB에 사용자 ID 또는 닉네임이 이미 있는지 확인
                    string Sql = "select * from usertable where id = '" + id + "' or nickname = '" + nickname + "'";
                    OleDbCommand command = new OleDbCommand(Sql, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    //회원가입 성공
                    if (reader.Read() == false)
                    {
                        //DB에 사용자 정보 추가
                        Sql = "insert into usertable values('" + id + "', '" + password + "', '" + nickname + "')";
                        command = new OleDbCommand(Sql, connection);
                        command.ExecuteNonQuery();

                        //성공 메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(3, Message.GetStrEncodingLength("true"), "true"));
                    }
                    //회원가입 실패
                    else
                    {
                        //실패 메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(3, Message.GetStrEncodingLength("false"), "false"));
                    }

                    //리소스 반환
                    reader.Close();
                    connection.Close();
                }

                //클라이언트 회원탈퇴 메세지
                else if (packet.MessageType == 2)
                {
                    //가변 길이 메세지 분해
                    string[] str = packet.Str.Split('/');
                    string id = str[0];
                    string password = str[1];

                    //DB 연결
                    string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBase.mdb";
                    OleDbConnection connection = new OleDbConnection(conStr);
                    connection.Open();

                    //DB에 사용자 ID와 PassWord 삭제
                    string Sql = "Delete from usertable where id = '" + id + "' and password = '" + password + "'";
                    OleDbCommand command = new OleDbCommand(Sql, connection);

                    //회원탈퇴 성공
                    if (command.ExecuteNonQuery() == 1)
                    {
                        //성공메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(3, Message.GetStrEncodingLength("true"), "true"));
                    }
                    //회원탈퇴 실패
                    else
                    {
                        //실패 메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(3, Message.GetStrEncodingLength("false"), "false"));
                    }

                    //리소스 반환
                    connection.Close();
                }

                //클라이언트 채팅 메세지
                else if (packet.MessageType == 6)
                {
                    //다른 사용자들에게 채팅 메세지 전달
                    foreach (Socket socket in LoginSockList)
                    {
                        if (socket == user.clnt_sock)
                            continue;
                        try
                        {
                            socket.Send(Message.MessageMake(7, Message.GetStrEncodingLength(packet.Str), packet.Str));
                        }
                        catch (SocketException)
                        {

                        }
                    }
                }

                //클라이언트 파일 다운로드 요청 메세지
                else if (packet.MessageType == 12)
                {
                    //다른 프로세스가 해당 파일을 점유 중인지 체크한다.
                    if (ServFile.IsAccessAble(ServFile.path + '/' + packet.Str) == false)
                    {
                        //실패 메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(4, Message.GetStrEncodingLength("false"), "false"));
                    }
                    //클라이언트에게 파일을 보낸다.
                    else
                    {
                        //성공 메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(4, Message.GetStrEncodingLength("true"), "true"));

                        fs = new FileStream(ServFile.path + '/' + packet.Str, FileMode.Open);
                        long eof = fs.Seek(0, SeekOrigin.End);
                        fs.Seek(0, SeekOrigin.Begin);
                        user.message = new byte[1024];

                        while (true)
                        {
                            if (eof <= 1024)
                            {
                                user.message = new byte[eof];
                                fs.Read(user.message, 0, (int)eof);
                                user.clnt_sock.Send(Message.FileMessageMake(14, user.message.Length, user.message));
                                break;
                            }
                            fs.Read(user.message, 0, 1024);
                            user.clnt_sock.Send(Message.FileMessageMake(13, user.message.Length, user.message));
                            eof -= 1024;
                        }
                        fs.Close();
                    }
                }

                //클라이언트 파일 업로드 요청 메세지
                else if (packet.MessageType == 9)
                {
                    string[] str = packet.Str.Split('/');
                    FileData filedata = new FileData(str[0], long.Parse(str[1]));

                    if (ServFile.IsAccessAble(ServFile.path + '/' + filedata.filename) == false)
                    {
                        //이미 같은 이름의 파일이 업로드 되었거나 되는중
                        upload = false;
                    }
                    else
                    {
                        upload = true;
                        for (int i = 0; i < ServFile.FileList.Count; i++)
                        {
                            if (ServFile.FileList[i].filename == filedata.filename)
                            {
                                upload = false;
                                break;
                            }
                        }
                    }
                   
                    if (upload == false)
                    {
                        //실패 메세지 전달
                        user.clnt_sock.Send(Message.MessageMake(4, Message.GetStrEncodingLength("false"), "false"));
                    }
                    else
                    {
                        user.clnt_sock.Send(Message.MessageMake(4, Message.GetStrEncodingLength("ture"), "ture"));

                        //클라이언트로부터 파일 데이터 (10번과 11번 메세지)를 받는다.
                        fs = new FileStream(ServFile.path + '/' + filedata.filename, FileMode.Create);
                        while (true)
                        {
                            //고정 길이 메세지 부분을 받는다.
                            user.message = new byte[8];
                            Message.MessageResive(user.message, 0, 8, user.clnt_sock);
                            packet.MessageTranslate(user.message, false);

                            //가변 길이 메세지 부분을 받는다.
                            user.message = new byte[packet.MessageLength];
                            Message.MessageResive(user.message, 0, packet.MessageLength, user.clnt_sock);
                            packet.MessageTranslate(user.message, true);

                            //파일에 가변 길이 메세지 부분을 쓴다.
                            fs.Write(user.message, 0, user.message.Length);

                            //11번 메세지이면 파일 쓰기를 끝낸다.
                            if (packet.MessageType == 11)
                            {
                                fs.Close();
                                upload = false;
                                break;
                            }
                        }
                        //파일 리스트에 추가하고 모든 클라이언트에게 8번 메세지를 보낸다.
                        ServFile.FileList.Add(filedata);

                        foreach (Socket socket in LoginSockList)
                        {
                            try
                            {
                                socket.Send(Message.MessageMake(8, Message.GetStrEncodingLength(str[0] + '/' + str[1]), str[0] + '/' + str[1]));
                            }
                            catch (SocketException)
                            {

                            }
                        }

                        //성공 메세지를 보낸다.
                        user.clnt_sock.Send(Message.MessageMake(4, Message.GetStrEncodingLength("true"), "true"));
                    }
                }

                //수신 대기
                user.message = new byte[8];
                user.clnt_sock.BeginReceive(user.message, 0, 8, 0, ReciveCallback, user);
            }

            //클라이언트에서 연결 끊음
            catch (SocketException)
            {
                //로그인 되었으므로 소켓 리스트와 닉네임 리스트에서 클라이언트 정보를 삭제한다.
                if (user.nickname != null)
                {
                    LoginSockList.Remove(user.clnt_sock);
                    LoginNickNameList.Remove(user.nickname);

                    //다른 사용자에게 5번 메세지와 7번 메세지(퇴장 메세지)를 보낸다.
                    foreach(Socket socket in LoginSockList)
                    {
                        try
                        {
                            socket.Send(Message.MessageMake(5, Message.GetStrEncodingLength(user.nickname), user.nickname));
                            string dropoutstr = Environment.NewLine + "***************** " + user.nickname + " 님이 퇴장하셨습니다. *****************" + Environment.NewLine + Environment.NewLine;
                            socket.Send(Message.MessageMake(7, Message.GetStrEncodingLength(dropoutstr), dropoutstr));
                        }
                        catch(SocketException)
                        {

                        }
                    }
                }

                //파일 스트림을 닫아준다.
                if(fs != null)
                {
                    fs.Close();
                    //업로드 중에 클라이언트에서 연결을 끊었음으로 업로드 되는 파일을 삭제한다.
                    if(upload == true)
                    {
                        File.Delete(fs.Name);
                    }
                }

                //클라이언트와 연결된 소켓 제거
                user.clnt_sock.Close();
                user.clnt_sock.Dispose();
                return;
            }
        }
    }
}



