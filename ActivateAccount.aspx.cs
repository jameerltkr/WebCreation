using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["key"] != null)
        {
            Account act = new Account();
            Guid guid_key = new Guid();
            string key = Request.QueryString["key"];
            try
            {
                guid_key = new Guid(key);
            }
            catch
            {
                msg.ForeColor = System.Drawing.Color.Red;
                msg.Text = "Account activation failed!";
            }
            var q = act.ValidateKey(guid_key);
            if (q.Any())
            {
                foreach (var a in q)
                {
                    System.Web.Security.MembershipUser username;
                    username = System.Web.Security.Membership.GetUser(a.UserId);

                    DateTime current_time = DateTime.Now;
                    TimeSpan ts = DateTime.Now.Subtract(a.Created.Value);
                    string[] admins = Roles.GetRolesForUser(username.UserName);
                    bool flag = false;
                    foreach (var admin in admins)
                    {
                        if (admin.Equals("Administrator"))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (ts.Hours > 48 && flag != true)
                    {
                        act.DoExpire(guid_key);
                        Response.Redirect("~/ActivationKeyExpired.aspx");
                    }
                    else
                    {
                        var q1 = act.ActivationInfo(guid_key);
                        foreach (var a1 in q1)
                        {
                            if (a1.IsActivated == true)
                            {
                                msg.Text = "Your account is already activated!";
                            }
                            else
                            {
                                if (act.ActivateAccount(guid_key))
                                {
                                    msg.Text = "Your account is activated! Now you can login by your credentials.";
                                }
                                else
                                {
                                    msg.Text = "Could not activate your account due to some technical faults.";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                msg.ForeColor = System.Drawing.Color.Red;
                msg.Text = "Account activation failed.";
            }
        }
        else
        {
            msg.ForeColor = System.Drawing.Color.Red;
            msg.Text = "Account activation failed.";
        }
    }
}