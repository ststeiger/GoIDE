using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGenerator
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string JSON = System.IO.File.ReadAllText("/root/sources/GoIDE/GoIDE/App_Data/caniuse/fulldata-json/data-2.0.json", System.Text.Encoding.UTF8);
            Newtonsoft.Json.Linq.JToken jt = Newtonsoft.Json.Linq.JToken.Parse(JSON);
            string formatted = jt.ToString(Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText("/root/sources/GoIDE/GoIDE/App_Data/caniuse/fulldata-json/pretty-data-2.0.json", formatted, System.Text.Encoding.UTF8);
            return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
