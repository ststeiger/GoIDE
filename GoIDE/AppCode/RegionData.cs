using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoIDE.RegionData
{


    public class Data
    {
        public Chrome chrome { get; set; }
        public Firefox firefox { get; set; }
        public Opera opera { get; set; }
        public Safari safari { get; set; }
        public Android android { get; set; }
        public IosSaf ios_saf { get; set; }
        public OpMob op_mob { get; set; }
        public Ie ie { get; set; }
        public Bb bb { get; set; }
        public IeMob ie_mob { get; set; }
        public AndUc and_uc { get; set; }
        public OpMini op_mini { get; set; }
        public AndChr and_chr { get; set; }
        public AndFf and_ff { get; set; }
        public Edge edge { get; set; }
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