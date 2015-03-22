using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message_sentbox : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var q = c.sentbox(Session[Constants.Session.ID].ToString());
            if (q.Any())
            {
                GridView1.Visible = true;
                GridView1.DataSource = q;
                GridView1.DataBind();
            }
            else
            {
                Label1.Text = "No Mail Found!!!";
                Label1.BackColor = System.Drawing.Color.Yellow;
                GridView1.Visible = false;

            }
        }

    }
}