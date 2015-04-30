using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_design_CreateWebsite : System.Web.UI.Page
{
    datalayer dl = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.Session.USERNAME] == null)
        {
            Response.Redirect("~/login.aspx");
        }
    }
    [WebMethod]
    public static string show(Guid userid, string username, string websitename)
    {
        //getting website id from tables
        int websiteid = GetWebsiteId(userid, username, websitename);
        string msg = "";
        MyProjectDataContext da = new MyProjectDataContext();
        var q = from a in da.WebsitePages
                where a.Username == username && a.UserId == userid && a.WebsiteId == websiteid
                select a;
        if (q.Any())
        {
            msg = "data";
        }
        else
        {
            msg = "nothing";
        }
        //foreach (var o in q)
        //{
        //    if (o.PageName.Count() == 0)
        //    {
        //        msg = "nothing";
        //        //pnl_web.Visible = true;
        //    }
        //    else
        //    {
        //        msg = "data";
        //        //pnl_web.Visible = false;
        //    }
        //}
        return msg;
    }
    public static int GetWebsiteId(Guid userid, string username, string websitename)
    {
        MyProjectDataContext da = new MyProjectDataContext();
        int id = 0;
        var q = from a in da.Websites
                where a.UserId == userid && a.Username == username && a.WebsiteName == websitename
                select a.WebsiteId;
        if (q.Any())
        {
            id = Convert.ToInt32(q.Single());
        }
        return id;
    }
    [WebMethod]
    public static PageData[] getpage(string username, string websitename, Guid userid)
    {
        //getting website id from tables
        int websiteid = GetWebsiteId(userid, username, websitename);


        List<PageData> page = new List<PageData>();
        MyProjectDataContext da = new MyProjectDataContext();
        var q = from a in da.WebsitePages
                where a.Username == username && a.WebsiteId == websiteid
                select a;
        foreach (var o in q)
        {
            PageData pd = new PageData();
            pd.PageName = o.PageName;
            pd.WebsiteName = websitename;
            page.Add(pd);
        }
        return page.ToArray();
    }
    [WebMethod]
    public static WebsiteName[] getwebsites(string username)
    {
        
        List<WebsiteName> websitename = new List<WebsiteName>();
        MyProjectDataContext dbcontext = new MyProjectDataContext();
        var q = from a in dbcontext.Websites
                where a.Username == username
                select a;
        foreach (var a in q)
        {
            WebsiteName wname = new WebsiteName();
            wname.Name = a.WebsiteName;
            websitename.Add(wname);
        }
        return websitename.ToArray();
    }
    [WebMethod]
    //[ScriptMethod(UseHttpGet = false)]
    public static string delete(Guid userid, string websitename, string username)
    {
        string msg;
        // Response.Write(userid);
        // Response.Write(websitename);
        msg = "Hello";
        //  datalayer dl = new datalayer();
        MyProjectDataContext da = new MyProjectDataContext();
        var q = from a in da.Websites
                where a.UserId == userid && a.WebsiteName == websitename
                select a;
        int websiteid = GetWebsiteId(userid, username, websitename);
        var q1 = from b in da.WebsitePages
                 where b.WebsiteId == websiteid
                 select b;
        foreach (var o in q1)
        {
            da.WebsitePages.DeleteOnSubmit(o);   // removing foreign key references
        }
        foreach (var o in q)
        {
            da.Websites.DeleteOnSubmit(o);
        }
        
        try
        {
            da.SubmitChanges();
            msg = "success";
        }
        catch
        {
            msg = "error";
        }

        //   msg=dl.Delete_Website(userid, websitename);
        return msg;
    }
    protected void lb_create_project_Click(object sender, EventArgs e)
    {
        website_details.Attributes["class"] = "display-none";   // hide website details
        create_website.Attributes["class"] = "display-block";   // shoo create website page
        create_database.Attributes["class"] = "display-none";   // creatign datavase page  // hide
    }
    protected void btn_open_project_Click(object sender, EventArgs e)
    {
        website_details.Attributes["class"] = "display-block";  // showing website details page
        create_website.Attributes["class"] = "display-none";    // hide create website page
        create_database.Attributes["class"] = "display-none";   // creatign datavase page  // hide
    }
    protected void lb_create_database_Click(object sender, EventArgs e)
    {
        website_details.Attributes["class"] = "display-none";  // hiding website details page
        create_website.Attributes["class"] = "display-none";    // hide create website page
        create_database.Attributes["class"] = "display-block";   // creatign datavase page  // show
    }
    protected void btn_create_website_Click(object sender, EventArgs e)
    {
        if (txt_websitename.Text.Trim() == "")
        {
            lbl_message.ForeColor = System.Drawing.Color.Red;
            lbl_message.Text = "Please enter a website name.";
        }
        else
        {
            System.Web.Security.MembershipUser mu;
            Guid userid;
            mu = System.Web.Security.Membership.GetUser();
            userid = (Guid)mu.ProviderUserKey;
            if (dl.SaveWebsite(Session[Constants.Session.USERNAME].ToString(), txt_websitename.Text.Trim(), userid) == Constants.SUCCESS)
            {
                lbl_message.ForeColor = System.Drawing.Color.Green;
                lbl_message.Text = "Website created successfully!";
                txt_websitename.Text = "";
                Session[Constants.WEBSITE_NAME] = txt_websitename.Text.Trim();
                //  pnl_create_pages.Visible = true;
                //  pnl_website_name.Visible = false;
            }
            else
                if (dl.SaveWebsite(Session[Constants.Session.USERNAME].ToString(), txt_websitename.Text.Trim(), userid) == Constants.WEBSITE_ALREADY_EXIST)
                {
                    lbl_message.ForeColor = System.Drawing.Color.Red;
                    lbl_message.Text = "Website already exist.";
                }
                else
                {
                    lbl_message.ForeColor = System.Drawing.Color.Red;
                    lbl_message.Text = "An error occurred.";
                }
        }
    }
}