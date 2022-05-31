using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class FileData
    {
        public string filename { get; }             //파일 명(풀 네임 X)
        public long filesize { get; }               //파일 사이즈

        public FileData(string filename, long filesize)
        {
            this.filename = filename;
            this.filesize = filesize;
        }
    }
}
