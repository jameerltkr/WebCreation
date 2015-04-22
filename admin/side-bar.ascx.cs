using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Usercontrol_side_bar : System.Web.UI.UserControl
{
    admin_management admin_manage = new admin_management();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated || Session[Constants.Session.USERNAME] == null || Session[Constants.Session.ID] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            ChangeClass();
            user_img.Src = "dist/img/male-user.png";
            ltr_admin.Text = Session[Constants.Session.USERNAME].ToString();
            HideMenu();

        }
    }
    public void ChangeClass()
    {
        if (Request.QueryString["p"] == "home")
        {
            dashboard.Attributes.Add("class", "active");
            home.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "users")
        {
            dashboard.Attributes.Add("class", "active");
            users.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "roles")
        {
            dashboard.Attributes.Add("class", "active");
            roles.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "hosting_resources")
        {
            hosting.Attributes.Add("class", "active");
            hosting_resources.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "hosting_users")
        {
            hosting.Attributes.Add("class", "active");
            hosting_users.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "web_resources")
        {
            web.Attributes.Add("class", "active");
            web_resources.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "web_users")
        {
            web.Attributes.Add("class", "active");
            web_users.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "compose")
        {
            mail.Attributes.Add("class", "active");
            compose.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "inbox")
        {
            mail.Attributes.Add("class", "active");
            inbox.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "sentmail")
        {
            mail.Attributes.Add("class", "active");
            sentmail.Attributes.Add("class", "active");
        }
        else if (Request.QueryString["p"] == "trash")
        {
            mail.Attributes.Add("class", "active");
            trash.Attributes.Add("class", "active");
        }
        else
        {
            dashboard.Attributes.Add("class", "active");
            home.Attributes.Add("class", "active");
        }
    }
    public void HideMenu()
    {
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            System.Web.Security.MembershipUser user;
            user = System.Web.Security.Membership.GetUser();
            string[] roles = Roles.GetRolesForUser(user.UserName);
            foreach (var role in roles)
            {
                if (role.Equals("Administrator"))
                {
                   // hosting.Style.Add("display", "none");
                    hosting.Visible = false;
                    web.Visible = false;
                }
                else
                if (role.Equals("Hosting Manager"))
                {
                    dashboard.Visible = false;
                    web.Visible = false;
                }
                else if (role.Equals("Web Manager"))
                {
                    dashboard.Visible = false;
                    hosting.Visible = false;
                }
                else
                {

                }
            }
        }
    }
}