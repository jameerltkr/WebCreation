using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivationKeyExpired : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_generatekey_Click(object sender, EventArgs e)
    {
        try
        {
            string email = txt_email.Text.ToString();
            Guid userid;
            string username = "";
            Guid key;
            key = Guid.NewGuid();
            //fetching userid from database
            System.Web.Security.MembershipUser user;
            username = System.Web.Security.Membership.GetUserNameByEmail(email);
            user = System.Web.Security.Membership.GetUser(username);
            userid = (Guid)user.ProviderUserKey;
            Account act = new Account();
            if (System.Web.Security.Membership.ValidateUser(username, txt_password.Text))
            {
                if (act.SaveActivationKey(userid, key))
                {
                    var siteRoot = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                    string activate_url = siteRoot + "ActivateAccount.aspx?key=" + key;
                    string site_url = siteRoot;
                    string web_design_url = siteRoot + "web-design/create.aspx";
                    string hosting_url = siteRoot + "hosting/main.aspx";
                    string help = siteRoot + "contact-us.html";
                    string address = "Balaganj, Lucknow Up 226003</br> Web Creation Inc.";
                    WMail mail = new WMail();
                    if (mail.Send(email, "", "", username, txt_password.Text, activate_url, site_url, web_design_url, hosting_url, help, address))
                    {
                        lbl_msg.ForeColor = System.Drawing.Color.Green;
                        lbl_msg.Text = "Activation key has been sent again. Please check your email!";
                    }
                }
            }
            else
            {
                lbl_msg.ForeColor = System.Drawing.Color.Red;
                lbl_msg.Text = "Please enter correct password!";
            }
        }
        catch
        {
            lbl_msg.ForeColor = System.Drawing.Color.Red;
            lbl_msg.Text = "Error.";
        }
    }
}