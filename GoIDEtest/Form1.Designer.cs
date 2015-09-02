namespace GoIDEtest
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtInputCommand = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(12, 528);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtInputCommand
            // 
            this.txtInputCommand.Location = new System.Drawing.Point(12, 12);
            this.txtInputCommand.Multiline = true;
            this.txtInputCommand.Name = "txtInputCommand";
            this.txtInputCommand.Size = new System.Drawing.Size(725, 241);
            this.txtInputCommand.TabIndex = 1;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 270);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(725, 241);
            this.txtOutput.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 575);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInputCommand);
            this.Controls.Add(this.btnExecute);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtInputCommand;
        private System.Windows.Forms.TextBox txtOutput;
    }
}

