using System;
using System.Collections.Generic;
using System.Text;

namespace GoIDEtest.Unnecessary
{



    // https://saezndaree.wordpress.com/2009/03/29/how-to-redirect-the-consoles-output-to-a-textbox-in-c/
    public class TextBoxStreamWriter : System.IO.TextWriter
    {
        System.Windows.Forms.TextBox _output = null;

        public TextBoxStreamWriter(System.Windows.Forms.TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            // _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }


}
