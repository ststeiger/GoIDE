﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace GoIDEtest
{


    public partial class Form1 : Form
    {

        System.Diagnostics.Process spdTerminal;
        System.IO.StreamWriter swInputStream;
        public delegate void fpTextBoxCallback_t(string strText);
        public fpTextBoxCallback_t fpTextBoxCallback;


        public Form1()
        {
            fpTextBoxCallback = new fpTextBoxCallback_t(AddTextToOutputTextBox);
            InitializeComponent();
        } // End Constructor


        public void AddTextToOutputTextBox(string strText)
        {
            this.txtOutput.AppendText(strText);
        } // End Sub AddTextToOutputTextBox


        public void OnQuit()
        {
            swInputStream.WriteLine("exit");
            swInputStream.Close();
            //spdTerminal.WaitForExit();
            spdTerminal.Close();
            spdTerminal.Dispose();
            // Application.Exit();
        } // End Sub btnQuit_Click


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


        public void ProcessExited(object sender, EventArgs e)
        {
            MessageBox.Show("You idiot, you terminated the process.", "PBKAC");
        } // End Sub ProcessExited


        private void Form1_Load(object sender, EventArgs e)
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
        } // End Sub Form1_Load


        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (this.spdTerminal.HasExited)
            {
                MessageBox.Show("You idiot, you have terminated the process", "Error");
                return;
            } // End if (this.spdTerminal.HasExited)

            swInputStream.WriteLine(this.txtInputCommand.Text);
            this.txtInputCommand.Clear();
        } // End Sub btnExecute_Click


        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            OnQuit();
        } // End Sub Form1_Closing


    } // End Class Form1 : Form


} // End Namespace GoIDEtest
