using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message_compose : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string resc = TextBox1.Text.Trim();
        string subject = TextBox2.Text.Trim();
        string message = TextBox3.Text.Trim();
        string attachment = "No File";
       if(FileUpload1.HasFile)
       {
           FileUpload1.SaveAs(Server.MapPath("attachment/" + FileUpload1.FileName));
           attachment = FileUpload1.FileName;
       }
       c.Compose(Session[Constants.Session.ID].ToString(), resc, subject, message, attachment);
       Label1.Text = "Mail Sent..!!!!!";


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var q = c.login(Session[Constants.Session.ID].ToString());
        if(q.Any())
        {
            string resc = TextBox1.Text.Trim();
            string subject = TextBox2.Text.Trim();
            string message = TextBox3.Text.Trim();
            string attachment = "No File";
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("attachment/" + FileUpload1.FileName));
                attachment = FileUpload1.FileName;
            }
            c.draft(Session[Constants.Session.ID].ToString(), resc, subject, message, attachment);
            Label1.Text = "Saved to Draft..!!!!!";

            foreach(logindetail k in  q)
            {
                ViewState["u_type"] = k.u_type;
            }
            if(ViewState["u_type"].ToString()=="user")
            {
                Response.Redirect("../user/userwelcome.aspx");
            }
            else
            {
                Response.Redirect("../admin/adminwelcome.aspx");
            }
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        string resc = TextBox1.Text.Trim();
        string subject = TextBox2.Text.Trim();
        string message = TextBox3.Text.Trim();
        string attachment = "No File";
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("attachment/" + FileUpload1.FileName));
            attachment = FileUpload1.FileName;
        }
        c.draft(Session[Constants.Session.ID].ToString(), resc, subject, message, attachment);
        Label1.Text = "Saved to Draft..!!!!!";
    }
}