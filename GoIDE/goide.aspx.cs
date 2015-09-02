
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GoIDE
{


    public partial class goide : System.Web.UI.Page
    {


        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            // Page.LoadComplete += Page_LoadComplete;
        } // End Sub OnInit 


        // These are the main lifecycle steps:
        // PreInit -> Init -> InitComplete -> PreLoad -> Load -> [Control events] ->
        // LoadComplete -> PreRender -> SaveStateComplete -> Render -> Unload
        protected virtual void Page_LoadComplete(object sender, System.EventArgs e)
        {
            // Page.LoadComplete -= Page_LoadComplete;

            // https://codemirror.net/demo/theme.html#blackboard
            string val = this.ddThemes.SelectedItem.Value;
            this.litTheme.Text = val;
            this.litThemeName.Text = val;
        } // End Sub Page_LoadComplete 


        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Page.IsPostBack)
                return;

            string[] filez = System.IO.Directory.GetFiles(Server.MapPath("~/Scripts/CodeMirror/theme"), "*.css");

            foreach (string file in filez)
            {
                // if(StringComparer.OrdinalIgnoreCase.Equals(theme,"yeti"))
                string theme = System.IO.Path.GetFileNameWithoutExtension(file);
                this.ddThemes.Items.Add(new ListItem() { Text = theme, Value = theme });
            }

        } // End Sub Page_Load


    } // End Class goide : System.Web.UI.Page


} // End Namespace GoIDE
