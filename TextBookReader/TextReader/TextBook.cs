using System;
using System.IO;

namespace TextReader
{
    [Serializable]
    public class TextBook
    {
      


        private TextBook(string fullfilename)
        {
            FileInfo fi = new FileInfo(fullfilename);
            FullName = fi.FullName;
            FileName = fi.Name;
            Lenght = fi.Length;
            Current = 0;
            LastAccessTime = fi.LastAccessTime;
            Desc = "";
        }

        public static TextBook NewTextBook(string fullfilename)
        {
            return new TextBook(fullfilename);
        }


        //全名

        public string FullName { get; set; }

        //文件名

        public string FileName { get; set; }

        //书名

        public string BookName { get; set; }

        //作者

        public string Author { get; set; }

        //上次阅读时间

        public DateTime LastAccessTime { get; set; }

        //描述

        public string Desc { get; set; }

        //长度

        public long Lenght { get; set; }

        //当前阅读位置

        public long Current { get; set; }

        //当前阅读章节

        public int CurrentCatalog { get; set; }

        //章节目录

        public Catalog Catalogs { get; set; }

        //行数

        public int Lines { get; set; }

    }
}
