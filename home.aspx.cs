using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    /*
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string id = tbUserNameLogin.Text.Trim();
        string pass = tbPasswordLogin.Text;
        try
        {
            var q = c.login(id);
            if (q.Any())
            {

                foreach (logindetail k in q)
                {
                    Session["id"] = k.email;
                    Session["pass"] = k.password;
                    Session["utype"] = k.u_type;

                }
                if (Session["id"].ToString() == id && Session["pass"].ToString() == pass && Session["utype"].ToString() == "user")
                {
                    Response.Redirect("/user/userwelcome.aspx");
                }


                else if (Session["pass"].ToString() != pass)
                {
                    Label1.Text = "Invalid Password";
                    tbPasswordLogin.Focus();

                }
                else
                {
                    Label1.Text = "Invalid Id && Password!!";
                    tbUserNameLogin.Text = tbPasswordLogin.Text = "";
                    tbUserNameLogin.Focus();
                    tbUserNameLogin.BackColor = System.Drawing.Color.Yellow;
                }
            }
            else
            {
                Label1.Text = "Data not Found....Enter valid Id!!!";
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        if (tbUsernameSignUp.Text.Trim() != null && tbEmail.Text != null && tbPassword.Text != null)
        {
            string username = tbUsernameSignUp.Text.Trim();
            string email = tbEmail.Text.Trim();
            string pass = tbPassword.Text;
            c.DoRegistration(username, email, pass);
            Response.Redirect("registration.aspx");
        }
        else
            Label2.Text = "Fill the mendatory fields...";

    }
     */


}