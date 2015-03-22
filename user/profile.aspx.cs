using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_profile : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            string impath = c.getimge(Session[Constants.Session.ID].ToString());
            if (impath != "")
                Image1.ImageUrl = impath;
            else
                Image1.ImageUrl = "~/img/default.png";
            Panel1.Visible = false;
            //string u=Session[Constants.Session.ID].ToString();
           string u="s@gmail.com";
            var q = c.PersonalInfo(u);

            foreach(Registration k in q)
            {
                TextBox1.Text = k.name.ToString();
                TextBox2.Text = k.dob.ToString();
                TextBox3.Text = k.mobile.ToString();
                ddlcountry.Text = k.country.ToString();
                TextBox4.Text = k.city.ToString();
                TextBox5.Text = k.address.ToString();
            }
        }
        try
        {
            if (Session[Constants.Session.ID].ToString() == null)
            {

            }
        }
        catch
        {
            Response.Redirect("../home.aspx");
        }

        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string u =Session[Constants.Session.ID].ToString();
        string spath = "", fname = "", path = "";
        if(FileUpload1.HasFile)
        {
            fname = FileUpload1.FileName;
            path = Server.MapPath("/user/Profilepic/" + u + fname);
            FileUpload1.SaveAs(path);
            spath = "/user/Profilepic/" + u + fname;
            c.UploadPropilepic(u, fname, spath);
            Image1.ImageUrl = spath;
        }
        else
        {
            Response.Write("<script>alert('Plz Select Picture');</script>");
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string u = "s@gmail.com";
        string name = TextBox1.Text.Trim();
        string dob = TextBox2.Text.Trim();
        string mobile = TextBox3.Text.Trim();
        string country = ddlcountry.SelectedItem.ToString();
        string city = TextBox4.Text.Trim();
        string address = TextBox5.Text.Trim();
       int i =c.update_Personal_info(u, name, dob, mobile, country, city, address);
        if(i==0)
        {
            Label1.Text = "Data updated!!!!";
            Panel1.Visible = false;
        }
        else
        {
            Label1.Text = "Try Again..!!!!";
            Panel1.Visible = true;
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Response.Redirect("../logout.aspx");
    }
}