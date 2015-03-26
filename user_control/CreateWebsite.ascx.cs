using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_control_CreateWebsite : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.WEBSITE_NAME] != null)
        {
            pnl_web.Visible = true;
        }
        else
        {
            pnl_web.Visible = false;
           // Response.Redirect("~/web-design/create.aspx");
        }
    }
    protected void btn_create_page_Click(object sender, EventArgs e)
    {

    }
}