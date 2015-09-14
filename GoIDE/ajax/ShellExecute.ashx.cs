using System;
using System.Web;
using System.Web.UI;

namespace GoIDE
{
    // ItemInfo
    public class ShellExecute : System.Web.IHttpHandler
    {

        public System.Web.HttpContext m_Context;


        public void ProcessRequest(HttpContext context)
        {
            m_Context = context;

            using (WebProcess wp = new WebProcess(context, OutputProcessor))
            {

                string filename = @"D:\Programme\Go\bin\hw.go";
                if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                    filename = @"/root/sources/go/hw.go";
                
                //wp.SendInput("go", "{0} \"{1}\"", "run", filename);
                wp.SendInput("gofmt", "\"{1}\"", "run", filename);

                System.Console.WriteLine("ciao");
            }
        }

        public void OutputProcessor(string strText)
        {
            try
            {
                this.m_Context.Response.Output.WriteLine(strText);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }

        } // End Sub AddTextToOutputTextBox



        public void SendInput(string format, params object[] args)
        {
            SendInput(string.Format(format, args));
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
	
