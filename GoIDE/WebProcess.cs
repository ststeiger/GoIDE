
using System.Collections.Generic;
using System.Web;


namespace GoIDE
{
    

    // http://stackoverflow.com/questions/4107683/controling-cmd-exe-from-winforms/4118494#4118494
    public class WebProcess
    {
        System.Diagnostics.Process spdTerminal;
        System.IO.StreamWriter swInputStream;

        public delegate void fpTextBoxCallback_t(string strText);
        public fpTextBoxCallback_t fpTextBoxCallback;


        public WebProcess()
        {
            fpTextBoxCallback = new fpTextBoxCallback_t(AddTextToOutputTextBox);
        } // End Constructor


        ~WebProcess()  // Destructor 
        {
            WebProcess_Quit();
        } // End Destructor


        public void AddTextToOutputTextBox(string strText)
        {
            try
            {
                System.Web.HttpContext.Current.Response.Output.WriteLine(strText);
            }
            catch(System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        } // End Sub AddTextToOutputTextBox


        private void ConsoleOutputHandler(object sendingProcess, System.Diagnostics.DataReceivedEventArgs outLine)
        {
            
            if (!string.IsNullOrEmpty(outLine.Data))
            {
                fpTextBoxCallback(System.Environment.NewLine + outLine.Data);
            } // End if (!String.IsNullOrEmpty(outLine.Data))

        } // End Sub ConsoleOutputHandler


        public void SendInput(string command)
        {
            ExecuteCommand(command);

            while (!this.spdTerminal.HasExited)
            {
                System.Threading.Thread.Sleep(200);
            }

            System.Threading.Thread.Sleep(5000);

            if (!this.spdTerminal.HasExited)
            {
                swInputStream.WriteLine(command);
            }
        }


        public void ProcessExited(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("Process exited.");
            // MessageBox.Show("You idiot, you terminated the process.", "PBKAC");
        } // End Sub ProcessExited


        private void ExecuteCommand(string command)
        {
            spdTerminal = new System.Diagnostics.Process();

            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                //spdTerminal.StartInfo.FileName = "/usr/bin/gnome-terminal";
                // spdTerminal.StartInfo.FileName = "/bin/bash";
                spdTerminal.StartInfo.FileName = "go";
            else
                spdTerminal.StartInfo.FileName = "cmd.exe";

            spdTerminal.StartInfo.Arguments = command;

            // AddTextToOutputTextBox("Using this terminal: " + spdTerminal.StartInfo.FileName);

            spdTerminal.StartInfo.UseShellExecute = false;
            spdTerminal.StartInfo.CreateNoWindow = true;
            spdTerminal.StartInfo.RedirectStandardInput = true;
            spdTerminal.StartInfo.RedirectStandardOutput = true;
            spdTerminal.StartInfo.RedirectStandardError = true;

            spdTerminal.EnableRaisingEvents = true;
            spdTerminal.Exited += new System.EventHandler(ProcessExited);
            spdTerminal.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
            spdTerminal.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);

            spdTerminal.Start();

            swInputStream = spdTerminal.StandardInput;
            spdTerminal.BeginOutputReadLine();
            spdTerminal.BeginErrorReadLine();
        } // End Sub WebProcess_Load


        private void WebProcess_Quit()
        {
            if (!spdTerminal.HasExited)
            {
                swInputStream.WriteLine("exit");
                swInputStream.Close();    
            }

            //spdTerminal.WaitForExit();
            spdTerminal.Close();
            spdTerminal.Dispose();
            // Application.Exit();
        } // End Sub btnQuit_Click


    } // End Class WebProcess


}
