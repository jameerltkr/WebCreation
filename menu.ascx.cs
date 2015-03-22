using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        check();
        if (!Request.IsAuthenticated)
        {

        }
        else
        {

        }

    }
    public void check()
    {
        if (Session[Constants.Session.USERNAME]==null)
        {
            register.Visible = true;
            login.Visible = true;
        }
        else
        {
            register.Visible = false;
            login.Visible = false;
        }
    }
}