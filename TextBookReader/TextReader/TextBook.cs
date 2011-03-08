using System;

namespace TextReader
{
    [Serializable]
    public class TextBook
    {
        public int Lines{get;set;}
        public TextBook()
        {
            Current = 0;
            Desc = "";
        }

        //全名

        public string FullName { get; set; }

        //文件名

        public string Name { get; set; }

        //书名

        public string Title { get; set; }

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
    }
}
