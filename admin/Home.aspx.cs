using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Home : System.Web.UI.Page
{
    admin_management admin_manage = new admin_management();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated || Session[Constants.Session.USERNAME] == null || Session[Constants.Session.ID] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
               // fill number of pages created by the users
                FillPages();
                //fill number of users registered
                FillUsers();
                //fill total websites created by the users
                FillWebsites();
                //-------------
                
            }
        }
    }
    public void FillPages()
    {
        //fill pages-------------
        var q = admin_manage.GetPages();
        if (q.Any())
        {
            foreach (var a in q)
            {
                int total = 0;
                total = a.PageName.Count();     //counts total number of pages in table
                lt_pages.Text = total.ToString();
            }
        }
    }
    public void FillWebsites()
    {
        //fill websites
        var q = admin_manage.GetWebsites();
        if (q.Any())
        {
            foreach (var a in q)
            {
                int count = a.WebsiteName.Count();      //total website
                ltr_websites.Text = count.ToString();
            }
        }
    }
    public void FillUsers()
    {
        //fill total number of users created
        var q = admin_manage.GetUsers();
        if (q.Any())
        {
            foreach (var a in q)
            {
                int count = a.UserName.Count();     //total user
                ltr_users.Text = count.ToString();
            }
        }
    }
}