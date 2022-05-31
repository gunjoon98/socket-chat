using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Server
{
    class User
    {
        public byte[] message { set; get; }         //메세지(패킷)
        public Socket clnt_sock { get; set; }       //클라이언트와 연결된 소켓
        public string nickname { get; set; }        //해당 클라이언트 사용자
    }

    class Message
    {
        private int messagetype;
        private int messageLength;
        private string str;

        public int MessageType
        {
            get { return messagetype; }
        }

        public int MessageLength
        {
            get { return messageLength; }
        }

        public string Str
        {
            get { return str; }
        }

        //메세지를 받아 해석하여 멤버 변수에 할당
        public void MessageTranslate(byte[] message, bool variable)
        {
            //고정 메세지 부분
            if (variable == false)
            {
                messagetype = BitConverter.ToInt32(message, 0);
                messageLength = BitConverter.ToInt32(message, 4);
            }
            //가변 메세지 부분
            else
            {
                str = Encoding.UTF8.GetString(message);
            }
        }

        //메세지를 만들어서 반환
        static public byte[] MessageMake(int messagetype, int messageLength, string str)
        {
            byte[] array1 = BitConverter.GetBytes(messagetype);
            byte[] array2 = BitConverter.GetBytes(messageLength);
            byte[] array3 = Encoding.UTF8.GetBytes(str);
            byte[] result = new byte[array1.Length + array2.Length + array3.Length];

            Array.ConstrainedCopy(array1, 0, result, 0, array1.Length);
            Array.ConstrainedCopy(array2, 0, result, array1.Length, array2.Length);
            Array.ConstrainedCopy(array3, 0, result, array1.Length + array2.Length, array3.Length);
            return result;
        }

        //파일 메세지를 만들어서 반환
        static public byte[] FileMessageMake(int messagetype, int messageLength, byte[] filebyte)
        {
            byte[] array1 = BitConverter.GetBytes(messagetype);
            byte[] array2 = BitConverter.GetBytes(messageLength);
            byte[] result = new byte[array1.Length + array2.Length + filebyte.Length];

            Array.ConstrainedCopy(array1, 0, result, 0, array1.Length);
            Array.ConstrainedCopy(array2, 0, result, array1.Length, array2.Length);
            Array.ConstrainedCopy(filebyte, 0, result, array1.Length + array2.Length, filebyte.Length);
            return result;
        }

        //문자열을 UTF8로 인코딩 했을때의 바이트 개수 반환
        static public int GetStrEncodingLength(string str)
        {
            return Encoding.UTF8.GetBytes(str).Length;
        }

        //message에 recv_cnt 인덱스부터 recv_len 길이의 바이트를 계속 수신
        static public void MessageResive(byte[] message, int recv_cnt, int recv_len, Socket clnt_sock)
        {
            while (recv_cnt < recv_len)
            {
                recv_cnt += clnt_sock.Receive(message, recv_cnt, recv_len - recv_cnt, 0);
            }
        }
    }
}
