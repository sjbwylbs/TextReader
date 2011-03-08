using System.Windows.Forms;

namespace TextReader
{
    public class TRTextBox:TextBox
    {
        /*
       private int WM_ERASEBKGND = 0x0014;
       
       [DisplayName("背景图片")]
       public Image BackgroundImage { get; set; }
        

       protected void OnEraseBkgnd(Graphics g)
       {
           g.FillRectangle(Brushes.White, this.ClientRectangle);
           if (BackgroundImage != null)
           {
               g.DrawImage(BackgroundImage, this.ClientRectangle);
           }
           g.Dispose();
       }

       protected override void WndProc(ref Message m)
       {
           if (m.Msg == WM_ERASEBKGND) //绘制背景
           {
               OnEraseBkgnd(Graphics.FromHdc(m.WParam));
               m.Result = (IntPtr)1;
           }
           base.WndProc(ref m);
       }
        *  * */
    }
}
