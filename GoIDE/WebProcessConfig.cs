
namespace GoIDE
{
    

    public partial class WebProcess
    { 
    
        public static string m_GoExe;
        public static string m_GoRoot;
        public static string m_GoFmtExe;

        static WebProcess()
        {
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
            {
                // m_GoRoot = GetGoRoot();
                m_GoExe = "go";
                m_GoFmtExe = "gofmt";
            }
            else
            {
                try
                {
                    m_GoRoot = GetGoRoot();
                    m_GoExe = System.IO.Path.Combine(m_GoRoot, "bin", "go.exe");
                    m_GoFmtExe = System.IO.Path.Combine(m_GoRoot, "bin", "gofmt.exe");
                } // End Try
                catch (System.Exception ex)
                {
                    throw new System.Exception(@"Please configure the ""goroot"" environment variable in WebProcessConfig.cs (function GetGoRoot)", ex);
                } // End Catch 

            } // End Else of if (System.Environment.OSVersion.Platform == System.PlatformID.Unix) 

        } // End Static Constructor WebProcess 


        public static string GetGoRoot()
        {
            System.Collections.Generic.Dictionary<string, string> dict = 
                new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.InvariantCultureIgnoreCase);
            dict.Add("COR-W81-101", @"D:\Programme\Go\");

            if (!dict.ContainsKey(System.Environment.MachineName))
                throw new System.NotSupportedException("You need to configure the goroot environment variable");

            return dict[System.Environment.MachineName];
        } // End Function GetGoRoot


    } // End Partial Class WebProcess


} // End Namespace GoIDE 
