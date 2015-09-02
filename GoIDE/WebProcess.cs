
using System;
using System.Collections.Generic;
using System.Web;


namespace GoIDE
{


    public class MessageBox
    {
        public static void Show(string message)
        {
            Show(message, "");
        }


        public static void Show(string message, string title)
        {
            System.Console.WriteLine(message);
        }
    }


    public class MyTextBoxSimulator
    {

        public string Text;

        public void AppendText(string str)
        {
            this.Text = this.Text + str;
        }

        
        public void Clear()
        {
            this.Text = "";
        }

    }


    public partial class WebProcess
    {
        MyTextBoxSimulator txtOutput = new MyTextBoxSimulator();
        MyTextBoxSimulator txtInputCommand = new MyTextBoxSimulator();

        public bool InvokeRequired = false;
        public void Invoke(fpTextBoxCallback_t fpTextBoxCallback, string bla)
        {
            fpTextBoxCallback(bla);
        }

    }



    // http://stackoverflow.com/questions/4107683/controling-cmd-exe-from-winforms/4118494#4118494
    public partial class WebProcess
    {
        System.Diagnostics.Process spdTerminal;
        System.IO.StreamWriter swInputStream;

        public delegate void fpTextBoxCallback_t(string strText);
        public fpTextBoxCallback_t fpTextBoxCallback;


        public WebProcess()
        {
            fpTextBoxCallback = new fpTextBoxCallback_t(AddTextToOutputTextBox);
            WebProcess_Load();
        } // End Constructor


        ~WebProcess()  // 
        {
            WebProcess_Quit();
        } // End Destructor


        public void AddTextToOutputTextBox(string strText)
        {
            this.txtOutput.AppendText(strText);
        } // End Sub AddTextToOutputTextBox


        private void ConsoleOutputHandler(object sendingProcess, System.Diagnostics.DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                //this.Invoke(new fpTextBoxCallback_t(AddTextToOutputTextBox), Environment.NewLine + outLine.Data);
                if (this.InvokeRequired)
                    this.Invoke(fpTextBoxCallback, Environment.NewLine + outLine.Data);
                else
                    fpTextBoxCallback(Environment.NewLine + outLine.Data);
            } // End if (!String.IsNullOrEmpty(outLine.Data))

        } // End Sub ConsoleOutputHandler


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (this.spdTerminal.HasExited)
            {
                MessageBox.Show("You idiot, you have terminated the process", "Error");
                return;
            } // End if (this.spdTerminal.HasExited)

            swInputStream.WriteLine(txtInputCommand.Text);
            txtInputCommand.Clear();
        } // End Sub btnExecute_Click


        public void ProcessExited(object sender, EventArgs e)
        {
            MessageBox.Show("You idiot, you terminated the process.", "PBKAC");
        } // End Sub ProcessExited


        private void WebProcess_Load()
        {
            spdTerminal = new System.Diagnostics.Process();

            if (Environment.OSVersion.Platform == PlatformID.Unix)
                //spdTerminal.StartInfo.FileName = "/usr/bin/gnome-terminal";
                spdTerminal.StartInfo.FileName = "/bin/bash";
            else
                spdTerminal.StartInfo.FileName = "cmd.exe";

            AddTextToOutputTextBox("Using this terminal: " + spdTerminal.StartInfo.FileName);

            spdTerminal.StartInfo.UseShellExecute = false;
            spdTerminal.StartInfo.CreateNoWindow = true;
            spdTerminal.StartInfo.RedirectStandardInput = true;
            spdTerminal.StartInfo.RedirectStandardOutput = true;
            spdTerminal.StartInfo.RedirectStandardError = true;

            spdTerminal.EnableRaisingEvents = true;
            spdTerminal.Exited += new EventHandler(ProcessExited);
            spdTerminal.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
            spdTerminal.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);

            spdTerminal.Start();

            swInputStream = spdTerminal.StandardInput;
            spdTerminal.BeginOutputReadLine();
            spdTerminal.BeginErrorReadLine();
        } // End Sub WebProcess_Load


        private void WebProcess_Quit()
        {
            swInputStream.WriteLine("exit");
            swInputStream.Close();
            //spdTerminal.WaitForExit();
            spdTerminal.Close();
            spdTerminal.Dispose();
            // Application.Exit();
        } // End Sub btnQuit_Click


    } // End Class WebProcess


}
