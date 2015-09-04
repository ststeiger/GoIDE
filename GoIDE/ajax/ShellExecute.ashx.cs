using System;
using System.Web;
using System.Web.UI;

namespace GoIDE
{
	
    public class ShellExecute : System.Web.IHttpHandler
    {
	
        public void ProcessRequest(HttpContext context)
        {
            WebProcess wp = new WebProcess();
            wp.SendInput("run \"/root/sources/go/hw.go\"");
            System.Console.WriteLine("ciao");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
	
