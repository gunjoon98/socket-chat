using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace Client
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //소켓과 닉네임을 받을 객체 user 생성
            User user = new User();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(user));

            //로그인이 안됬으면 프로그램 종료
            if(user.nickname == null)
            {
                return;
            }
            Application.Run(new ChatRoomFrom(user));
        }
    }
}
