using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace TextReader
{
    [Serializable]
    public class TextBook
    {



        private TextBook(string fullFileName,string cacheDir)
        {
            FileInfo fi = new FileInfo(fullFileName);
            FullName = fi.FullName;
            FileName = fi.Name;
            CatalogsFileName = Path.Combine(cacheDir, FileName + ".~");
            Lenght = fi.Length;
            Current = 0;
            LastAccessTime = fi.LastAccessTime;
            Desc = "";
        }

        public static TextBook NewTextBook(string fullFileName,string cacheDir)
        {
            return new TextBook(fullFileName,cacheDir);
        }

        public static void NewCatalog(ref TextBook tb)
        {
            Catalog catalog = new Catalog();
            //以文本方式打开小说
            BufferedStream bs=new BufferedStream(File.OpenRead(tb.FullName));
            StreamReader sr = new StreamReader(bs,Encoding.Default);
            long position = 0;
            string buffer;
            Regex re = new Regex("书名:\\w{1,50}", RegexOptions.IgnorePatternWhitespace);

            while (string.IsNullOrEmpty(tb.BookName))
            {
                buffer = sr.ReadLine();
                tb.Lines++;
                if (!string.IsNullOrEmpty(buffer))
                {
                    position += buffer.Length;
                    Match m = re.Match(buffer);
                    if (m.Success)
                    {
                        tb.BookName = m.Value;
                        break;
                    }
                }
            }

            re = new Regex("作者:\\w{1,50}", RegexOptions.IgnorePatternWhitespace);

            while (string.IsNullOrEmpty(tb.Author))
            {
                buffer = sr.ReadLine();
                tb.Lines++;
                if (!string.IsNullOrEmpty(buffer))
                {
                    position += buffer.Length;
                    Match m = re.Match(buffer);
                    if (m.Success)
                    {
                        tb.Author = m.Value;
                        break;
                    }

                }
            }

            re = new Regex(@"第(一|二|三|四|五|六|七|八|九|十|零|百|千|万|\d){1,50}章.+\s", RegexOptions.IgnorePatternWhitespace);

            CatalogPuple cp = null;
            StringBuilder sb = new StringBuilder();
            while (!sr.EndOfStream)
            {
                buffer = sr.ReadLine();
                tb.Lines++;
                if (!string.IsNullOrEmpty(buffer))
                {
                    position += buffer.Length;
                
                    Match m=re.Match(buffer);
                    //判断章节
                    if (m.Success)
                    {
                        position += Environment.NewLine.Length;

                        if (cp != null)
                        {

                            //是章节保存内容
                            cp.Content = sb.ToString();
                            sb.Remove(0, sb.Length);
                        }

                        cp = new CatalogPuple();
                        cp.Position = position;
                        cp.Name = m.Value;
                        cp.Begin = tb.Lines;
                        if (catalog.Size > 1)
                        {
                            catalog.CatalogList[catalog.Size - 1].End = cp.Begin - 1;
                        }
                        catalog.CatalogList.Add(catalog.Size++, cp);
                    }
                    else
                    {
                        if (cp != null)
                        {
                            //不是章节则是内容
                            sb.AppendLine(buffer);
                        }
                    }
                }
                
            }
            sr.Close();
            tb.Catalogs = catalog;
        }

        public static void Save(TextBook tb)
        {
            BinaryFormatter bw = new BinaryFormatter();
            Stream sw = File.Create(tb.CatalogsFileName);
            bw.Serialize(sw, tb);
            sw.Close();
        }

        public static TextBook Restore(string cacheFile)
        {
            Stream sr = File.OpenRead(cacheFile);
            BinaryFormatter bf = new BinaryFormatter();
            TextBook t = (TextBook)bf.Deserialize(sr);
            sr.Close();
            return t;
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

        //章节目录文件
        public string CatalogsFileName { get; set; }

        //章节目录
        public Catalog Catalogs { get; set; }

        //行数

        public int Lines { get; set; }

       
    }
}
