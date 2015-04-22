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
        txt_password.Text = string.Empty;
        txt_state.Text = string.Empty;
        txt_username.Text = string.Empty;
    }
    public void Save_Update_Data()
    {
        string username = txt_username.Text.Trim();
        string firstname = txt_firstname.Text.Trim();
        string lastname = txt_lastname.Text.Trim();
        string address = txt_address.Text.Trim();
        string city = txt_city.Text.Trim();
        string state = txt_state.Text.Trim();
        string country = txt_country.Text.Trim();
        string password = txt_password.Text;
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
                ClearText();        // clear the text.........
                pnl_message.Visible = true;
                div_msg.InnerHtml = "Records inserted successfully...";
            }
            else
            {
                pnl_message.Visible = true;
                error.Attributes["class"] = "box box-danger";
                div_msg.InnerHtml = "Could not created due to some errors...";
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