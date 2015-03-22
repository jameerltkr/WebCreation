using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Net.Mail;

public partial class forgetpassword : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text.Trim();
        string s_ques = ddlsecurityQ.SelectedItem.ToString();
        string s_qns = TextBox2.Text.Trim();
        var q = c.login(id);
        if(q.Any())
        {
            foreach (logindetail k in q)
            {
                Session[Constants.Session.ID] = k.email;
                Session["sq"] = k.s_ques;
                Session["sa"] = k.s_ans;
            }
            if(Session[Constants.Session.ID].ToString()==id && Session["sq"].ToString()==s_ques && Session["sa"].ToString()==s_qns)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }
        else
        {
            Label1.Text = "Invalid Login...";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string reset_pass = TextBox3.Text.Trim();
        var q = c.login(Session[Constants.Session.ID].ToString());
        if(q.Any())
        {
            foreach(logindetail k in q)
            {
                k.password = reset_pass;

            }
            c.da.SubmitChanges();
            Response.Redirect("user/userwelcome.aspx");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string email = TextBox5.Text.Trim();
        var q = c.login(email);
        if(q.Any())
        {
            MailMessage m = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("avinashsharmaibm@gmail.com", "avinash123");
            m.From = new MailAddress("avinashsharmaibm@gmail.com");
            m.To.Add(email);
            m.Subject = "Forget Password Info....";
            foreach(logindetail k in q)
            {
              Session["pass"] = k.password;
            }
            m.Body = "Your Password <br/>" + Session["pass"].ToString() + "<br/>" + "http://localhost:1032/login.aspx" + "<br/>" + "Thank You <br/> Regards,<br/> Abc.com ";
            client.Send(m);
            TextBox5.Text = "";
            Label2.Text = "Check Email Address";
            Label2.ForeColor = System.Drawing.Color.Green;
            Panel3.Visible = true;



        }
        else
        {
            Label2.Text = "Invalid ID";
            Label2.ForeColor = System.Drawing.Color.Red;
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
    }
}