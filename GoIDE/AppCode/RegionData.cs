using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoIDE.CanIuse.RegionData
{


    public class Data
    {
        public Dictionary<string, double> chrome { get; set; }
        public Dictionary<string, double> firefox { get; set; }
        public Dictionary<string, double> opera { get; set; }
        public Dictionary<string, double> safari { get; set; }
        public Dictionary<string, double> android { get; set; }
        public Dictionary<string, double> ios_saf { get; set; }
        public Dictionary<string, double> op_mob { get; set; }
        public Dictionary<string, double> ie { get; set; }
        public Dictionary<string, double> bb { get; set; }
        public Dictionary<string, double> ie_mob { get; set; }
        public Dictionary<string, double> and_uc { get; set; }
        public Dictionary<string, double> op_mini { get; set; }
        public Dictionary<string, double> and_chr { get; set; }
        public Dictionary<string, double> and_ff { get; set; }
        public Dictionary<string, double> edge { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string month { get; set; }
        public string access_date { get; set; }
        public Data data { get; set; }
        public double total { get; set; }
    }


}