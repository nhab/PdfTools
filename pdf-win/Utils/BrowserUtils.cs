using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_win.Utils
{
    public class BrowserUtils
    {
        public static void ShowInBrowser(WebBrowser webBrowser, string sHtml)
        {
            webBrowser.DocumentText = sHtml;
            //webBrowser.Navigate(new Uri("https://www.google.com"));        
        }
        public static void CreateBrowser(ref WebBrowser webBrowser,int width,int height,int top)
        {
            webBrowser.Top = top;
            webBrowser.Left = 0;

            webBrowser.Width = width - 10;
            webBrowser.Height = height - webBrowser.Top;
            webBrowser.Anchor = AnchorStyles.Left | AnchorStyles.Right |
                AnchorStyles.Bottom | AnchorStyles.Top;
            //  webBrowser.Width = this.Width;

           
        }
    }
}
