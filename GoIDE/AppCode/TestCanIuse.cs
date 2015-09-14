
namespace GoIDE
{


    public class CanIuseData
    {


        public static System.DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            System.DateTime origin = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            System.DateTime utcPointInTime = origin.AddMilliseconds(timestamp);

            System.DateTime localtimePointInTime = utcPointInTime.ToLocalTime();
            return localtimePointInTime;
        }


        public static System.DateTime ConvertFromSecondTimestamp(double timestamp)
        {
            System.DateTime origin = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            System.DateTime utcPointInTime = origin.AddSeconds(timestamp);

            System.DateTime localtimePointInTime = utcPointInTime.ToLocalTime();
            return localtimePointInTime;
        }


        public static void Test()
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/caniuse/fulldata-json/data-1.0.json");
            global::CanIuse.RootObject mydata = Tools.Serialization.JSON.Deserialize<global::CanIuse.RootObject>(System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8));
            System.Console.WriteLine(mydata);

            System.DateTime updated = ConvertFromSecondTimestamp(1441865648.0);
            System.Console.WriteLine(updated);
        }


    }


}
