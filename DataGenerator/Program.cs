﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataGenerator
{
    static class Program
    {


        public static void Prettify(string inFile)
        {
            string outfile = System.IO.Path.GetDirectoryName(inFile);
            outfile = System.IO.Path.Combine(outfile, System.IO.Path.GetFileNameWithoutExtension(inFile) + "_prettyfied" + System.IO.Path.GetExtension(inFile));
            

            string JSON = System.IO.File.ReadAllText(inFile, System.Text.Encoding.UTF8);
            Newtonsoft.Json.Linq.JToken jt = Newtonsoft.Json.Linq.JToken.Parse(JSON);
            string formatted = jt.ToString(Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(outfile, formatted, System.Text.Encoding.UTF8);
        }



        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Prettify("/root/sources/GoIDE/GoIDE/App_Data/caniuse/fulldata-json/data-2.0.json");
            Prettify(@"d:\stefan.steiger\documents\visual studio 2013\Projects\GoIDE\GoIDE\App_Data\caniuse\region-usage-json\AD.json");
            return;

            // d:\stefan.steiger\documents\visual studio 2013\Projects\GoIDE\GoIDE\App_Data\caniuse\region-usage-json\AD.json


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}