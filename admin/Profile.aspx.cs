using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Profile : System.Web.UI.Page
{
    admin_management admin_manage = new admin_management();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                ShowDetails();
            }
        }
    }
    public void ShowDetails()
    {
        Guid userid;
        System.Web.Security.MembershipUser mu;
        mu = System.Web.Security.Membership.GetUser();
        userid = (Guid)mu.ProviderUserKey;
        var q = admin_manage.GetUserImage(userid);
        if (q.Any())
        {
            foreach (var a in q)
            {
                txt_username.Text = a.Username;
                txt_firstname.Text = a.FirstName;
                txt_lastname.Text = a.LastName;
                txt_address.Text = a.Address;
                txt_city.Text = a.City;
                txt_country.Text = a.Country;
                txt_state.Text = a.State;
                img_user.ImageUrl = a.UserImgPath;
            }
        }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        string userimgage = "~/admin/dist/img/male-user.png";
        string username = txt_username.Text.Trim();
        string firstname = txt_firstname.Text.Trim();
        string lastname = txt_lastname.Text.Trim();
        string address = txt_address.Text.Trim();
        string city = txt_city.Text.Trim();
        string state = txt_state.Text.Trim();
        string country = txt_country.Text.Trim();
        Guid userid;
        System.Web.Security.MembershipUser mu;
        mu = System.Web.Security.Membership.GetUser();
        userid = (Guid)mu.ProviderUserKey;
        if (admin_manage.UpdateAdmin(userid, userimgage, username, firstname, lastname, address, city, state, country))
        {
            ShowDetails();
            pnl_message.Visible = true;
            div_msg.InnerHtml = "Records updated successfully...";
        }
        else
        {
            pnl_message.Visible = true;
            error.Attributes["class"] = "box box-danger";
            div_msg.InnerHtml = "Could not updated...";
        }
    }
}