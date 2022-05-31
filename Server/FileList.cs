using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class FileData
    {
        public string filename { get;}             //파일 명(풀 네임 X)
        public long filesize { get; }              //파일 사이즈
     
        public FileData(string filename, long filesize)
        {
            this.filename = filename;
            this.filesize = filesize;
        }
    }

    static class ServFile
    {
        static private List<FileData> filelist; //파일 리스트
        static public string path = "FileList"; //파일 경로

        static public List<FileData> FileList
        {
            get { return filelist; }
        }
        
        static ServFile()
        {
            //파일 관련 정보를 저장하는 파일 리스트 생성
            filelist = new List<FileData>();

            //path 경로에 있는 파일 명들로 파일 리스트 초기화
            string[] fullname = Directory.GetFiles(path);
            for(int i=0; i<fullname.Length; i++)
            {
                FileInfo info = new FileInfo(fullname[i]);
                FileList.Add(new FileData(info.Name, info.Length));
            }
        }

        //다른 프로세스가 해당 파일을 점유중이면 false를 해당 파일이 없거나 점유중이 아니면 true반환
        static public bool IsAccessAble(String path)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open);
            }
            catch (FileNotFoundException)
            {
                return true;
            }
            catch(IOException)
            {
                return false;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return true;
        }
    }

}
