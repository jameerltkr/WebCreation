using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Message_reply : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            Button3.Visible = false;
            Panel1.Visible = false;
            string msgid=Request.QueryString["v"];
            var q = c.showMailData(msgid);
            if(q.Any())
            {
                foreach(Msgdetail k in q)
                {
                    Label1.Text = k.date1.ToString();
                    Label2.Text = k.Time1.ToString();
                    TextBox1.Text = k.rece.ToString();
                    TextBox2.Text = k.subject.ToString();
                   TextBox3.Text = k.message.ToString()+"\nFrom"+k.sender1+"\nSubject"+k.subject;
                    

                 
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string resc = TextBox1.Text.Trim();
        string subject ="Re: "+TextBox2.Text.Trim();
        string message = TextBox3.Text.Trim();
        string attachment = "No File";
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("attachment/" + FileUpload1.FileName));
            attachment = FileUpload1.FileName;
        }
        c.Compose(Session[Constants.Session.ID].ToString(), resc, subject, message, attachment);
       // Label1.Text = "Mail Sent..!!!!!";
        Session["message"] = "1";
        Response.Redirect("inbox.aspx");


    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
            Panel1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = true;
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string resc = TextBox1.Text.Trim();
        string subject = "Frw: "+TextBox2.Text.Trim();
        string message = TextBox3.Text.Trim();
        string attachment = "No File";
        if (FileUpload1.HasFile)
        {
            FileUpload1.SaveAs(Server.MapPath("attachment/" + FileUpload1.FileName));
            attachment = FileUpload1.FileName;
        }
        c.Compose(Session[Constants.Session.ID].ToString(), resc, subject, message, attachment);
        // Label1.Text = "Mail Sent..!!!!!";
        Session["message"] = "1";
        Response.Redirect("inbox.aspx");

    }
}