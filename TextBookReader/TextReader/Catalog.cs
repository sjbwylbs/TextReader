using System;
using System.Collections.Generic;

namespace TextReader
{
    [Serializable]
    public class Catalog
    {
        public Catalog()
        {
            CatalogList = new SortedList<int, CatalogPuple>();
            Size = 1;
        }

        //章节文件名

        public string FileName { get; set; }

        //章节数

        public int Size { get; set; }

        //章节

        public SortedList<int, CatalogPuple> CatalogList { get; set; }
    }
}
