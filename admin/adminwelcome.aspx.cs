using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminwelcome : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session[Constants.Session.ID].ToString() == null)
            {

            }
        }
        catch
        {
            Response.Redirect("../login.aspx");
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../logout.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text!="")
        {
            var q = c.search_data(TextBox1.Text);
            if(q.Any())
            {
                
                Response.Redirect("search.aspx?str=" + TextBox1.Text + "");
            }
            else
            {
                Label1.Text = "Data not Found!!!!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            Label1.Text = "Enter value for Search";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }
}