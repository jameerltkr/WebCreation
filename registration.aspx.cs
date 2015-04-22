using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class registration : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillCapctha();
        }
    }
    void FillCapctha()
    {

        try
        {

            Random random = new Random();

            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            StringBuilder captcha = new StringBuilder();

            for (int i = 0; i < 6; i++)

                captcha.Append(combination[random.Next(combination.Length)] + "");

            Session["captcha"] = captcha.ToString();

            imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
        }

        catch
        {
            throw;

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Message m = new Message();
            if (Session["captcha"].ToString() != txtCaptcha.Text)
            {
                pnl_msg.Controls.Add(m.Error("Invalid captcha!"));
            }
            else
            {
                
                string username = Tname.Text.Trim();
                string user_name = ConfigurationManager.AppSettings["Administrator"];
                if (user_name == username)
                {
                    string[] roles = Roles.GetRolesForUser(username);
                    foreach (string role in roles)
                    {
                        if (role.Equals("Administrator"))
                        {
                           // Response.Redirect("admin/Home.aspx");
                            pnl_msg.Controls.Add(m.Error("This user already exists!"));

                        }
                    }
                    string[] admin_roles = Roles.GetAllRoles();
                    foreach (string role in admin_roles)
                    {
                        if (role.Equals("Administrator"))
                        {
                            Roles.AddUserToRole(username, "Administrator");
                            if (Register())
                            {
                                Guid userid;
                                System.Web.Security.MembershipUser mu;
                                mu = System.Web.Security.Membership.GetUser(username);
                                userid = (Guid)mu.ProviderUserKey;
                                admin_management admin = new admin_management();
                                if (admin.AddAdmin(userid, username))
                                {
                                    Response.Redirect("admin/Home.aspx");
                                }
                                else
                                {
                                    pnl_msg.Controls.Add(m.Error("User can not created!"));
                                }
                            }
                        }
                        else
                        {
                            Roles.CreateRole("Administrator");
                            Roles.AddUserToRole(username, "Administrator");
                            if (Register())
                            {
                                Guid userid;
                                System.Web.Security.MembershipUser mu;
                                mu = System.Web.Security.Membership.GetUser(username);
                                userid = (Guid)mu.ProviderUserKey;
                                admin_management admin = new admin_management();
                                if (admin.AddAdmin(userid, username))
                                {
                                    Response.Redirect("admin/Home.aspx");
                                }
                                else
                                {
                                    pnl_msg.Controls.Add(m.Error("User can not created!"));
                                }
                            }
                        }
                    }
                    Roles.CreateRole("Administrator");
                    Roles.AddUserToRole(username, "Administrator");
                    if (Register())
                    {
                        Guid userid;
                        System.Web.Security.MembershipUser mu;
                        mu = System.Web.Security.Membership.GetUser(username);
                        userid = (Guid)mu.ProviderUserKey;
                        admin_management admin = new admin_management();
                        if (admin.AddAdmin(userid, username))
                        {
                            Response.Redirect("admin/Home.aspx");
                        }
                        else
                        {
                            pnl_msg.Controls.Add(m.Error("User can not created!"));
                        }
                    }
                    
                }
                else
                {
                    if (Register())
                    {
                        Response.Redirect("home.aspx");
                    }
                }
               
            }
    }
    public bool Register()
    {
        Message m = new Message();
        lbl_message.Text = "";
        MembershipCreateStatus createStatus;
        MembershipUser user = System.Web.Security.Membership.CreateUser(Tname.Text, Tpassword.Text, Temail.Text, ddlsecurityQ.SelectedItem.Text, TAnswer.Text, true, out createStatus);
        switch (createStatus)
        {
            case MembershipCreateStatus.Success:
                {
                    {
                        Session[Constants.Session.USERNAME] = Tname.Text;
                    }
                    var user1 = System.Web.Security.Membership.GetUser(Session[Constants.Session.USERNAME].ToString());
                    if (user1 != null)
                    {
                        Session[Constants.Session.ID] = user.Email.ToString();
                    }
                    //System.Web.Security.MembershipUser mu;
                    FormsAuthentication.SetAuthCookie(Tname.Text, true);

                    clear();
                    
                    //  Response.Redirect("~/home.aspx");
                }
                //  if (Session[Constants.Session.USERNAME] != null)
                return true;
                break;
               
            case MembershipCreateStatus.DuplicateUserName:
                // lbl_message.ForeColor = Color.Red;
                //lbl_message.Text = "The user with the same UserName already exists!";
                pnl_msg.Controls.Add(m.Error("The user with the same UserName already exists!"));
                return false;
                break;
            case MembershipCreateStatus.DuplicateEmail:
                // lbl_message.ForeColor = Color.Red;
                //lbl_message.Text = "The user with the same email address already exists!";
                pnl_msg.Controls.Add(m.Error("The user with the same email address already exists!"));
                return false;
                break;
            case MembershipCreateStatus.InvalidEmail:
                //lbl_message.ForeColor = Color.Red;
                //lbl_message.Text = "The email address you provided is invalid.";
                pnl_msg.Controls.Add(m.Error("The email address you provided is invalid."));
                return false;
                break;
            //This Case Occured whenver we send empty data or Invalid Data
            case MembershipCreateStatus.InvalidAnswer:
                //lbl_message.ForeColor = Color.Red;
                //lbl_message.Text = "The security answer was invalid.";
                pnl_msg.Controls.Add(m.Error("The security answer was invalid."));
                return false;
                break;
            // This Case Occured whenver we supplied weak password
            case MembershipCreateStatus.InvalidPassword:
                //lbl_message.ForeColor = Color.Red;
                //lbl_message.Text = "The password you provided is invalid. It must be 7 characters long and have at least 1 special character.";
                pnl_msg.Controls.Add(m.Error("The password you provided is invalid. It must be 7 characters long and have at least 1 special character."));
                return false;
                break;
            default:
                //lbl_message.ForeColor = Color.Red;
                //lbl_message.Text = "There was an unknown error; the user account was NOT created.";
                pnl_msg.Controls.Add(m.Error("There was an unknown error; the user account was NOT created."));
                return false;
                break;
        }
        return false;
    }
    void clear()
    {
        Tname.Text = Tpassword.Text = Tconfirmpassword.Text =
     TAnswer.Text = Taddress.Text = Temail.Text = Tdob.Text = Tcity.Text = Tmobile.Text = "";
        ddlsecurityQ.ClearSelection();
        ddlcountry.ClearSelection();
        Rblgender.ClearSelection();
        CheckBox1.Checked = false;
        Label2.Text = "";
        Label3.Text = "";

    }
    //protected void btnRefresh_Click(object sender, EventArgs e)
    //{
    //    FillCapctha();
    //}
    protected void img_refresh_Click(object sender, ImageClickEventArgs e)
    {
        FillCapctha();
    }
}