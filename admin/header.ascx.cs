using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Usercontrol_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated || Session[Constants.Session.USERNAME] == null || Session[Constants.Session.ID] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            ltr_admin.Text = Session[Constants.Session.USERNAME].ToString();
            string[] roles = Roles.GetRolesForUser(Session[Constants.Session.USERNAME].ToString());
            foreach (string role in roles)
            {
                ltr_admin2.Text = Session[Constants.Session.USERNAME].ToString() + " (" + role + ")";
            }
        }
    }
}