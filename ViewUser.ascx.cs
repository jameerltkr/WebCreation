using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ViewUser : System.Web.UI.UserControl
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("../home.aspx");
            }
        }
        catch
        {
            
        }

        if (!IsPostBack)
        {
            var q = c.login(Session[Constants.Session.ID].ToString());
            if (q.Any())
            {
                foreach (logindetail k in q)
                {
                    Label1.Text = k.name.ToString();
                }
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../logout.aspx");
    }
}