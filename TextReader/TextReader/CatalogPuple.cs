using System;

namespace TextReader
{
    [Serializable]
    public class CatalogPuple
    {
        public CatalogPuple()
        {
            Begin = 1;
            End = 1;
        }

        //章节名

        public string Name { get; set; }

        //章节起始点

        public long Begin { get; set; }

        //章节结束点

        public long End { get; set; }

        public long Position { get; set; }

        public string Content { get; set; }

    }
}
