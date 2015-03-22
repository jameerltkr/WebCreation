using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_changepassword : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string oldpass, newpass;
        oldpass = TextBox1.Text.Trim();
        newpass = TextBox2.Text.Trim();
       var q =c.login(Session[Constants.Session.ID].ToString());
        if(q.Any())
        {

            foreach(logindetail k in q)
            {
                ViewState["pass"] = k.password;
            }
            if(oldpass==ViewState["pass"].ToString())
            {
                foreach(logindetail k in q)
                {
                    k.password = newpass;
                }
                c.da.SubmitChanges();

                Label1.Text = "Password changeddd!!!!";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label1.Text = "Invalid Password!!!!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }

        }
        else
        {
            Label1.Text = "Invalid Eamil Id Or Password";
            Label1.ForeColor = System.Drawing.Color.Red;
        }


    }
}