using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hosting_create_domain : System.Web.UI.Page
{
    datalayer dl = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            System.Web.Security.MembershipUser mu;
            mu = System.Web.Security.Membership.GetUser();
            Response.Write(mu.UserName);
            txt_user_name.Focus();
        }
    }
    protected void btn_create_domain_Click(object sender, EventArgs e)
    {
        try
        {

            lbl_domain_creation_error.Text = "";
            var email = Session[Constants.Session.ID].ToString();
            var username = txt_user_name.Text.Trim();
            var servername = ddl_choose_server.SelectedValue;
            var domainname = username + "." + servername;
            
            var q = dl.retrieve_domain_info(email);
            if (q.Any())
            {
                
                foreach (var a in q)
                {
                    if (a.Email == Session[Constants.Session.ID].ToString())
                    {
                        //lbl_domain_creation_error.ForeColor = System.Drawing.Color.Red;
                        pnl_error.Visible = true;
                        lbl_domain_creation_error.Text = "This email already exist!";
                    }
                    if (a.UserName == username)
                    {
                        pnl_error.Visible = true;
                        //lbl_domain_creation_error.ForeColor = System.Drawing.Color.Red;
                        lbl_domain_creation_error.Text = "Username already exist!";
                    }
                }
            }
            else
            {
                dl.CreateSubDomain(username, domainname, email, servername);
                Response.Redirect("~/hosting/main.aspx");
            }

            
        }
        catch(Exception ex)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/login.aspx");
            }
            lbl_domain_creation_error.ForeColor = System.Drawing.Color.Red;
            lbl_domain_creation_error.Text = ex.Message;
        }
    }
    protected void img_error_hide_Click(object sender, ImageClickEventArgs e)
    {
        pnl_error.Visible = false;
    }
}