
using System;
using System.Collections.Generic;
using System.Web;


// Yes, the support data on this site is free to use under the CC BY 4.0 license.
// https://github.com/Fyrd/caniuse
// https://raw.githubusercontent.com/Fyrd/caniuse/master/features-json/arrow-functions.json
namespace GoIDE.CanIuse.Features
{


    public class Link
    {
        public string url { get; set; }
        public string title { get; set; }
    }


    public class Stats
    {
        public System.Collections.Generic.Dictionary<string, string> ie { get; set; }
        public System.Collections.Generic.Dictionary<string, string> edge { get; set; }
        public System.Collections.Generic.Dictionary<string, string> firefox { get; set; }
        public System.Collections.Generic.Dictionary<string, string> chrome { get; set; }
        public System.Collections.Generic.Dictionary<string, string> safari { get; set; }
        public System.Collections.Generic.Dictionary<string, string> opera { get; set; }
        public System.Collections.Generic.Dictionary<string, string> ios_saf { get; set; } // iOS Safari
        public System.Collections.Generic.Dictionary<string, string> op_mini { get; set; } // Opera Mini
        public System.Collections.Generic.Dictionary<string, string> android { get; set; } // Android Browser
        
        // Hidden
        public System.Collections.Generic.Dictionary<string, string> bb { get; set; } // BlackBerry Browser
        public System.Collections.Generic.Dictionary<string, string> op_mob { get; set; } // Opera Mobile
        
        // Shown 
        public System.Collections.Generic.Dictionary<string, string> and_chr { get; set; } // Chrome for Android
        
        // Hidden
        public System.Collections.Generic.Dictionary<string, string> and_ff { get; set; } // Firefox for Android
        public System.Collections.Generic.Dictionary<string, string> ie_mob { get; set; } // IE Mobile
        public System.Collections.Generic.Dictionary<string, string> and_uc { get; set; } // UC Browser for Android
    }


    public class NotesByNum
    {
    }


    public class RootObject
    {
        public string title { get; set; }
        public string description { get; set; }
        public string spec { get; set; }
        public string status { get; set; }
        public List<Link> links { get; set; }
        public List<object> bugs { get; set; }
        public List<string> categories { get; set; }
        public Stats stats { get; set; }
        public string notes { get; set; }
        public NotesByNum notes_by_num { get; set; }
        public double usage_perc_y { get; set; }
        public int usage_perc_a { get; set; }
        public bool ucprefix { get; set; }
        public string parent { get; set; }
        public string keywords { get; set; }
        public string ie_id { get; set; }
        public string chrome_id { get; set; }
        public bool shown { get; set; }
    }


}
