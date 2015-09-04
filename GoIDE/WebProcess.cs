
// using System.Collections.Generic;


namespace GoIDE
{


    // http://stackoverflow.com/questions/4107683/controling-cmd-exe-from-winforms/4118494#4118494
    public partial class WebProcess : System.IDisposable
    {
        public delegate void fpTextOutputCallback_t(string strText);
        
        System.Diagnostics.Process m_ProcessInstance;
        System.IO.StreamWriter m_InputStreamWriter;

        public System.Web.HttpContext m_HttpContext;
        public fpTextOutputCallback_t m_TextOutputCallback;
        

        public WebProcess():this(null, null)
        { }


        public WebProcess(System.Web.HttpContext context)
            : this(context, null)
        { } // End Constructor


        public WebProcess(fpTextOutputCallback_t callback)
            :this(null, callback)
        { }


        public WebProcess(System.Web.HttpContext context, fpTextOutputCallback_t callback)
        {
            this.m_HttpContext = context;

            if (callback == null)
                this.m_TextOutputCallback = new fpTextOutputCallback_t(DefaultTextOutput);
            else
                this.m_TextOutputCallback = callback;
        } // End Constructor


        ~WebProcess()  // Destructor 
        {
            WebProcess_Quit();
        } // End Destructor


        public void DefaultTextOutput(string strText)
        {
            if (this.m_HttpContext != null)
            {
                try
                {
                    this.m_HttpContext.Response.Output.WriteLine(strText);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    throw;
                }
            }
            else
                System.Console.WriteLine(strText);
        } // End Sub DefaultTextOutput


        private void ConsoleOutputHandler(object sendingProcess, System.Diagnostics.DataReceivedEventArgs outLine)
        {
            
            if (!string.IsNullOrEmpty(outLine.Data))
            {
                m_TextOutputCallback(System.Environment.NewLine + outLine.Data);
            } // End if (!String.IsNullOrEmpty(outLine.Data))

        } // End Sub ConsoleOutputHandler



        public void SendInput(string executable, string format, params object[] args )
        {
            SendInput(executable, string.Format(format, args));
        }


        public void SendInput(string executable, string command)
        {
            if (executable == null)
                throw new System.ArgumentNullException("executable is null");

            executable = executable.ToLowerInvariant();

            ExecuteCommand(executable, command);

            m_ProcessInstance.WaitForExit();


            //if (!this.spdTerminal.HasExited)
            //{
            //    m_InputStreamWriter.WriteLine(command);
            //}
        }


        public void ProcessExited(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("Process exited.");
            // MessageBox.Show("You idiot, you terminated the process.", "PBKAC");
        } // End Sub ProcessExited


        private void ExecuteCommand(string executable, string command)
        {
            m_ProcessInstance = new System.Diagnostics.Process();

            switch (executable)
            {
                case "go":
                    m_ProcessInstance.StartInfo.FileName = m_GoExe;
                    break;
                case "gofmt":
                    m_ProcessInstance.StartInfo.FileName = m_GoFmtExe;
                    break;
            }

            

            if (!string.IsNullOrEmpty(m_GoRoot))
                m_ProcessInstance.StartInfo.EnvironmentVariables["GOROOT"] = m_GoRoot;
            
            m_ProcessInstance.StartInfo.Arguments = command;

            // AddTextToOutputTextBox("Using this terminal: " + m_ProcessInstance.StartInfo.FileName);

            m_ProcessInstance.StartInfo.UseShellExecute = false;
            m_ProcessInstance.StartInfo.CreateNoWindow = true;
            m_ProcessInstance.StartInfo.RedirectStandardInput = true;
            m_ProcessInstance.StartInfo.RedirectStandardOutput = true;
            m_ProcessInstance.StartInfo.RedirectStandardError = true;

            m_ProcessInstance.EnableRaisingEvents = true;
            m_ProcessInstance.Exited += new System.EventHandler(ProcessExited);
            m_ProcessInstance.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);
            m_ProcessInstance.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(ConsoleOutputHandler);

            m_ProcessInstance.Start();

            m_InputStreamWriter = m_ProcessInstance.StandardInput;
            m_ProcessInstance.BeginOutputReadLine();
            m_ProcessInstance.BeginErrorReadLine();
        } // End Sub WebProcess_Load


        private void WebProcess_Quit()
        {
            if (m_ProcessInstance == null)
                return;

            if (!m_ProcessInstance.HasExited)
            {
                m_InputStreamWriter.WriteLine("exit");
                m_InputStreamWriter.Close();    
            }

            // m_ProcessInstance.WaitForExit();
            m_ProcessInstance.Close();
            m_ProcessInstance.Dispose();
            // Application.Exit();
        } // End Sub btnQuit_Click


        public void Dispose()
        {
            WebProcess_Quit();
        }


    } // End Partial Class WebProcess


}
