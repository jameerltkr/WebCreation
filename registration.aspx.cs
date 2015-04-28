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
        Guid key;
        key = Guid.NewGuid();
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
                                string name = Tname.Text.Trim();
                                string email = Temail.Text.Trim();
                                //string password = Tpassword.Text.Trim();
                                string gender = Rblgender.Text.Trim();
                                string s_ques = ddlsecurityQ.Text.Trim();
                                string s_ans = TAnswer.Text.Trim();
                                string dob = Tdob.Text.Trim();
                                string mobileno = Tmobile.Text.Trim();
                                string country = ddlcountry.Text.Trim();
                                string city = Tcity.Text.Trim();
                                string address = Taddress.Text.Trim();
                                datalayer c = new datalayer();
                                c.Registration(name, email, gender, s_ques, s_ans, dob, mobileno, country, city, address);
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
                                string name = Tname.Text.Trim();
                                string email = Temail.Text.Trim();
                                //string password = Tpassword.Text.Trim();
                                string gender = Rblgender.Text.Trim();
                                string s_ques = ddlsecurityQ.Text.Trim();
                                string s_ans = TAnswer.Text.Trim();
                                string dob = Tdob.Text.Trim();
                                string mobileno = Tmobile.Text.Trim();
                                string country = ddlcountry.Text.Trim();
                                string city = Tcity.Text.Trim();
                                string address = Taddress.Text.Trim();
                                datalayer c = new datalayer();
                                c.Registration(name, email, gender, s_ques, s_ans, dob, mobileno, country, city, address);
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
                        string name = Tname.Text.Trim();
                        string email = Temail.Text.Trim();
                        //string password = Tpassword.Text.Trim();
                        string gender = Rblgender.Text.Trim();
                        string s_ques = ddlsecurityQ.Text.Trim();
                        string s_ans = TAnswer.Text.Trim();
                        string dob = Tdob.Text.Trim();
                        string mobileno = Tmobile.Text.Trim();
                        string country = ddlcountry.Text.Trim();
                        string city = Tcity.Text.Trim();
                        string address = Taddress.Text.Trim();
                        datalayer c = new datalayer();
                        c.Registration(name, email, gender, s_ques, s_ans, dob, mobileno, country, city, address);
                        Response.Redirect("admin/Home.aspx");
                    }
                    else
                    {
                        pnl_msg.Controls.Add(m.Error("User can not created!"));
                        System.Web.Security.Membership.DeleteUser(username);
                    }
                }
            }
            else
            {
                Account act = new Account();
                if (Register())
                {
                    Guid userid;
                    System.Web.Security.MembershipUser mu;
                    mu = System.Web.Security.Membership.GetUser(username);
                    userid = (Guid)mu.ProviderUserKey;
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
                        string address = "Balaganj, Lucknow Up 226003</br> Web Creation Inc.";
                        string password = Hash_Pass.DESCryptoHelper.DESDecrypt(Session[Constants.Session.PASSWORD].ToString());
                        WMail mail = new WMail();
                        if (mail.Send(Temail.Text.Trim(), "", "", Tname.Text.Trim(), password, activate_url, site_url, web_design_url, hosting_url, help, address))
                        {
                            string name = Tname.Text.Trim();
                            string email = Temail.Text.Trim();
                            //string password = Tpassword.Text.Trim();
                            string gender = Rblgender.Text.Trim();
                            string s_ques = ddlsecurityQ.Text.Trim();
                            string s_ans = TAnswer.Text.Trim();
                            string dob = Tdob.Text.Trim();
                            string mobileno = Tmobile.Text.Trim();
                            string country = ddlcountry.Text.Trim();
                            string city = Tcity.Text.Trim();
                            string user_address = Taddress.Text.Trim();
                            datalayer c = new datalayer();
                            c.Registration(name, email, gender, s_ques, s_ans, dob, mobileno, country, city, user_address);
                            pnl_msg.Controls.Add(m.Error("An activation link has been sent to your email."));
                            clear();
                        }
                    }
                    else
                    {
                        pnl_msg.Controls.Add(m.Error("An error occurred while sending mail."));
                        System.Web.Security.Membership.DeleteUser(username);
                    }
                    // Response.Redirect("home.aspx");
                }
                else
                {
                    pnl_msg.Controls.Add(m.Error("An error occurred while processing your request."));
                }
            }

        }
    }
    public bool Register()
    {
        string password = "";
        password = Guid.NewGuid().ToString("d").Substring(1, 6);
        Session[Constants.Session.PASSWORD] = Hash_Pass.DESCryptoHelper.DESEncrypt(password);
        Message m = new Message();
        lbl_message.Text = "";
        MembershipCreateStatus createStatus;
        MembershipUser user = System.Web.Security.Membership.CreateUser(Tname.Text, password, Temail.Text, ddlsecurityQ.SelectedItem.Text, TAnswer.Text, true, out createStatus);
        switch (createStatus)
        {
            case MembershipCreateStatus.Success:
                {
                    //{
                    //    Session[Constants.Session.USERNAME] = Tname.Text;
                    //}
                    //var user1 = System.Web.Security.Membership.GetUser(Session[Constants.Session.USERNAME].ToString());
                    //if (user1 != null)
                    //{
                    //    Session[Constants.Session.ID] = user.Email.ToString();
                    //}
                    //System.Web.Security.MembershipUser mu;
                    //   FormsAuthentication.SetAuthCookie(Tname.Text, true);

                    //    clear();

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
        Tname.Text = 
     TAnswer.Text = Taddress.Text = Temail.Text = Tdob.Text = Tcity.Text = Tmobile.Text = "";
        ddlsecurityQ.ClearSelection();
        ddlcountry.ClearSelection();
        Rblgender.ClearSelection();
        CheckBox1.Checked = false;
        Label2.Text = "";
        Label3.Text = "";
        txtCaptcha.Text = "";

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