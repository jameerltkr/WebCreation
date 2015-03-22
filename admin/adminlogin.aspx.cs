using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminlogin : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        //ModalPopupExtender1.Show();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

       
        string id = TextBox1.Text.Trim();
        string pass = TextBox2.Text.Trim();
        try
        {
            var q = c.login(id);
            if (q.Any())
            {

                foreach (logindetail k in q)
                {
                    Session[Constants.Session.ID] = k.email;
                    Session["pass"] = k.password;
                    Session["utype"] = k.u_type;

                }
                if (Session[Constants.Session.ID].ToString() == id && Session["pass"].ToString() == pass && Session["utype"].ToString() == "admin")
                {
                    Response.Redirect("adminwelcome.aspx");
                }


                else if (Session["pass"].ToString() != pass)
                {
                    ModalPopupExtender1.Show();
                    Label1.Text = "Invalid Password";
                    TextBox2.Text = "";
                    TextBox2.Focus();

                }
                else
                {
                    ModalPopupExtender1.Show();
                    Label1.Text = "Invalid Id && Password!!";
                    TextBox1.Text = TextBox2.Text = "";
                    TextBox1.Focus();
                    TextBox1.BackColor = System.Drawing.Color.Yellow;
                }
            }
            else
            {
                ModalPopupExtender1.Show();
                Label1.Text = "Data not Found....Enter valid Id!!!";
            }
        }
        catch (Exception ex)
        {

        }

    }
}