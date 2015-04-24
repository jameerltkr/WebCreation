using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users : System.Web.UI.Page
{
    admin_management admin = new admin_management();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        Save_Update_Data();
        //Hash_Pass hash = new Hash_Pass();
        //Hash_Pass.DecryptText("Jameer");
    }
    public void ClearText()
    {
        txt_address.Text = string.Empty;
        txt_city.Text = string.Empty;
        txt_country.Text = string.Empty;
        txt_email.Text = string.Empty;
        txt_firstname.Text = string.Empty;
        txt_lastname.Text = string.Empty;
        //txt_password.Text = string.Empty;
        txt_state.Text = string.Empty;
        txt_username.Text = string.Empty;
    }
    public void Save_Update_Data()
    {
        Guid key;
        key = Guid.NewGuid();   // generating key for the users

        string username = txt_username.Text.Trim();
        string firstname = txt_firstname.Text.Trim();
        string lastname = txt_lastname.Text.Trim();
        string address = txt_address.Text.Trim();
        string city = txt_city.Text.Trim();
        string state = txt_state.Text.Trim();
        string country = txt_country.Text.Trim();
      //  string password = txt_password.Text;
        string password = Guid.NewGuid().ToString("d").Substring(1, 6);
        string email = txt_email.Text;
        Guid creatorid;
        System.Web.Security.MembershipUser mu;
        mu = System.Web.Security.Membership.GetUser();
        creatorid = (Guid)mu.ProviderUserKey;
        // initialise data class
        MembershipCreateStatus createStatus;
        MembershipUser user = System.Web.Security.Membership.CreateUser(username, password, email, "question", "answer", true, out createStatus);
        if (MembershipCreateStatus.Success==createStatus)
        {
            if (admin.SaveSiteUsers(username, firstname, lastname, email, address, city, state, country, Session[Constants.Session.USERNAME].ToString(), creatorid, ""))
            {
                Guid userid;
                System.Web.Security.MembershipUser mu1;
                mu1 = System.Web.Security.Membership.GetUser(username);
                userid = (Guid)mu1.ProviderUserKey;
                Account act = new Account();
                if (act.SaveActivationKey(userid, key))
                {
                    //  Hash_Pass hash = new Hash_Pass();
                    // string hash_pass = Hash_Pass.DESCryptoHelper.DESEncrypt(Tpassword.Text.Trim());
                    var siteRoot = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/");
                    string activate_url = siteRoot + "ActivateAccount.aspx?key=" + key;
                    string site_url = siteRoot;
                    string web_design_url = siteRoot + "web-design/create.aspx";
                    string hosting_url = siteRoot + "hosting/main.aspx";
                    string help = siteRoot + "contact-us.html";
                    string company_address = "Balaganj, Lucknow Up 226003</br> Web Creation Inc.";
                    WMail mail = new WMail();
                    if (mail.Send(email, "", "", username, password, activate_url, site_url, web_design_url, hosting_url, help, company_address))
                    {
                        ClearText();        // clear the text.........
                        pnl_message.Visible = true;
                        div_msg.InnerHtml = "Records inserted successfully! And password sent to the mail. Please check your mail.";
                    }
                    else
                    {
                        pnl_message.Visible = true;
                        error.Attributes["class"] = "box box-danger";
                        div_msg.InnerHtml = "Problem while sending mail.";
                    }
                }
                
            }
            else
            {
                pnl_message.Visible = true;
                error.Attributes["class"] = "box box-danger";
                div_msg.InnerHtml = "Could not created due to some errors...";
                System.Web.Security.Membership.DeleteUser(username);
            }
        }
        else
        {
            pnl_message.Visible = true;
            error.Attributes["class"] = "box box-danger";
            div_msg.InnerHtml = "Could not created due to "+createStatus;
        }
    }
    public void Get_Data()
    {

    }
    protected void lb_edit_Click(object sender, EventArgs e)
    {
        pnl_message.Visible = true;
        error.Attributes["class"] = "box box-danger";
        div_msg.InnerHtml = count_delete.Value;
    }
    protected void lb_delete_Click(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string delete_data(string username, string email)
    {
        try
        {
            SiteUser su = new SiteUser();
            MyProjectDataContext dbContext = new MyProjectDataContext();
            var q = from a in dbContext.SiteUsers
                    where a.Username == username && a.Email == email
                    select a;
            if (q.Any())
            {
                foreach (var a in q)
                {
                    a.IsDeleted = true;
                    return "deleted";
                }
            }
            else
            {
                return "data not found";
            }
        }
        catch
        {
            return "could not deleted.";
        }
        return "";
    }
}