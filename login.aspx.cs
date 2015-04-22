using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.Session.ID]!=null)
        {
           // Response.Redirect("~/home.aspx");
        }
        if (!Request.IsAuthenticated)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = txt_username.Text.Trim();
        string pass = TextBox2.Text.Trim();


            DateTime dtLastLogin = DateTime.UtcNow;
                MembershipUser memberLockedOut = System.Web.Security.Membership.GetUser(username);
                if (memberLockedOut != null && memberLockedOut.IsLockedOut)
                    memberLockedOut.UnlockUser();
                if (memberLockedOut != null)
                    dtLastLogin = memberLockedOut.LastLoginDate;
                TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(dtLastLogin);
               // if (ts.Days > 60 && model.UserName != us.SuperadminUserName) // do not lock down super admin
                {
                    // force to expire cookies
                    HttpCookie UserNameCookie = new HttpCookie("CurrentUser");
                    if (UserNameCookie != null)
                    {
                        UserNameCookie.Value = txt_username.Text;
                        UserNameCookie.Expires = DateTime.Now.AddDays(10);
                     //   Response.Cookies.Add(UserNameCookie);
                    }
                }
                if (System.Web.Security.Membership.ValidateUser(username,pass))
                {
                    Session[Constants.Session.USERNAME] = username;

                    var user = System.Web.Security.Membership.GetUser(Session[Constants.Session.USERNAME].ToString());
                    if (user != null)
                    {
                        Session[Constants.Session.ID] = user.Email.ToString();
                    }
                    //System.Web.Security.MembershipUser mu;
                    //mu = System.Web.Security.Membership.FindUsersByName(Session[Constants.Session.USERNAME].ToString());

                    //Session[Constants.Session.ID] = mu.Email.ToString();

                    //Session[Constants.Session.ID]=System.Web.Security.Membership.ge
                    string[] roles = Roles.GetRolesForUser(username);
                    foreach (string role in roles)
                    {
                        if (role.Equals("Administrator"))
                        {
                            FormsAuthentication.SetAuthCookie(username, false);
                            Response.Redirect("admin/Home.aspx");
                        }
                    }
                    FormsAuthentication.SetAuthCookie(username, false);
                    Response.Redirect("~/home.aspx");
                }
                else
                {
                    Message m = new Message();
                    pnl_msg.Controls.Add(m.Error("Invalid Username or Password!"));
                    TextBox2.Text = txt_username.Text = "";
                }


       // System.Web.Security.Membership m = new System.Web.Security.Membership();
        //StoreInformation si = new StoreInformation();
       // si.Get_Value(id, pass);
        


        //try
        //{
        //    var q = c.login(id);
        //    if (q.Any())
        //    {

        //        foreach (logindetail k in q)
        //        {
        //            Session["id"] = k.email;
        //            Session["pass"] = k.password;
        //            Session["name"] = k.name;
        //            Session["utype"] = k.u_type;

        //        }
        //        if (Session["id"].ToString() == id && Session["pass"].ToString() == pass && Session["utype"].ToString() == "user")
        //        {
        //            string ipadress = Dns.GetHostEntry(Dns.GetHostName())
        //            .AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
        //            .ToString();
        //            string date = DateTime.Now.ToString();
        //            string start_time = DateTime.Now.TimeOfDay.ToString();
        //            c.Store_Info_Host_Status(Session["name"].ToString(), ipadress, start_time, "", "", date, Session["id"].ToString());
        //            Response.Redirect("home.aspx");
        //        }


        //        else if (Session["pass"].ToString() != pass)
        //        {
        //            Label1.ForeColor = System.Drawing.Color.Red;
        //            Label1.Text = "Invalid Password";
        //            TextBox2.Text = "";
        //            TextBox2.Focus();

        //        }
        //        else
        //        {
        //            Label1.ForeColor = System.Drawing.Color.Red;
        //            Label1.Text = "Invalid Id && Password!!";
        //            TextBox1.Text = TextBox2.Text = "";
        //            TextBox1.Focus();
        //            TextBox1.BackColor = System.Drawing.Color.Yellow;
        //        }
        //    }
        //    else
        //    {
        //        Label1.Text = "Data not Found....Enter valid Id!!!";
        //    }
        //}
        //catch (Exception ex)
        //{

        //}


    }
}