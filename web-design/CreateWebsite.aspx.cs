using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class web_design_CreateWebsite : System.Web.UI.Page
{
    datalayer dl = new datalayer();
    DatabaseManagement dbmanagement = new DatabaseManagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.Session.USERNAME] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                bind_website_ddl();
            }
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
            //deleting name from drop down
            web_design_CreateWebsite ob = new web_design_CreateWebsite();
            ob.bind_website_ddl();
            //ob.ddl_select_website.Items.Remove(websitename);
            //--------------------------

            //deleting website folder and files

            string subPath = "~/web-design/" + username + "/" + websitename + "/";
            System.Web.UI.Page p = new System.Web.UI.Page();   //creating instance of object

            bool exists = System.IO.Directory.Exists(p.Server.MapPath(subPath));

            if (exists)
                System.IO.Directory.Delete(p.Server.MapPath(subPath), true);
            //deleting db
            DatabaseManagement dbManage = new DatabaseManagement();
            dbManage.DeleteDatabaseByWebsiteName(userid, websitename, username);
            //  end-------------
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
                ddl_select_website.Items.Add(txt_websitename.Text.Trim());
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
    [WebMethod]
    public static string add_page(Guid userid, string username, string websitename, string pagename)
    {
        string msg = "";

        datalayer dl = new datalayer();
        if (dl.SavePages(userid, username, pagename, websitename))
        {
            msg = "inserted";
        }
        else
        {
            msg = "error";
        }

        return msg;
    }

    [WebMethod]
    public static string edit(Guid userid, string websitename)
    {
        string msg = "";
        return msg;
    }

    [WebMethod]
    public static string Print()
    {
        string result = "Guid is ";
        return result;
    }
    protected void btn_create_new_page_Click(object sender, EventArgs e)
    {
        // create();
    }
    protected void create()
    {
        //btn_create_page.Enabled = false;
        //btn_new_page.CssClass = "show" + " " + "a_demo_four" + " " + "align-left";
        //btn_create_page.CssClass = "align-left" + " " + "a_demo_four";



        //dl.Retrieve_Website_Name(Session["id"].ToString(),);

        //dl.SavePages(Session["id"].ToString(),txtpagename.Text.Trim(),)

        string[] aspxLines = {"<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeFile=\""+hf_page_name.Value+".aspx.cs\" Inherits=\"generate_page_runtime."+hf_page_name.Value+"\" %>",
                                     "<!DOCTYPE html>",
"<html xmlns=\"http://www.w3.org/1999/xhtml\">",
"<head runat=\"server\">",
"   <title> Build websites using Web Creation Inc. ",
"    </title>",
"   <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />",
"   <link href=\"../../admin/bootstrap/css/bootstrap.min.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"http://code.ionicframework.com/ionicons/2.0.0/css/ionicons.min.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/dist/css/AdminLTE.min.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/dist/css/skins/_all-skins.min.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/plugins/iCheck/flat/blue.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/plugins/morris/morris.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/plugins/jvectormap/jquery-jvectormap-1.2.2.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/plugins/datepicker/datepicker3.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/plugins/daterangepicker/daterangepicker-bs3.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css\" rel=\"stylesheet\" type=\"text/css\" />",
"   <link href=\"../../admin/dist/css/style.css\" rel=\"stylesheet\" />",
"   <script src=\"../../admin/dist/js/script.js\"></script>",
"   <script src=\"../../js/jquery-1.10.2.js\"></script>",
//"   <link href=\"css/site.css\" rel=\"stylesheet\" />",
//"    <script type=\"text/javascript\" src=\"js/jquery.min.js\"></script>",

"    <script src=\"js/controls.js\" type=\"text/javascript\"></script>",
//"     <link href=\"css/popup-style.css\"",
//"        rel=\"stylesheet\" type=\"text/css\" />",
//"   <script type=\"text/javascript\">",
//"       $(\"[id*=btn_add_menu]\").live(\"click\", function () {",
//"           $(\"#show_menu\").dialog({",
//"               title: \"jQuery Modal Dialog Popup\",",
//"               buttons: {",
//"                   Close: function () {",
//"                       $(this).dialog('close');",
//"                   }",
//"               },",
//"           modal: true",
//"       });",
//"       return false;",
//"       });",
//"       $(document).ready(function () {",
//"           $(\"#btn_add_code\").click(function () {",
//"               ",
//"           });",
//"       });",
//"       $(document).ready(function () {",
//"           $(\".div-img\").mouseover(function () {",
//"               $(\"#img_edit\").css({ \"display\": \"block\" });",
//"           });",
//"       });",
//"       $(document).ready(function () {",
//"           $(\".div-img\").mouseout(function () {",
//"               $(\"#img_edit\").css({ \"display\": \"none\" });",
//"           });",
//"       });",



//"       $(document).ready(function () {",
//"           $(\".div-contents\").mouseover(function () {",
//"               $(\"#img_edit2\").css({ \"display\": \"block\" });",
//"           });",
//"       });",
//"       $(document).ready(function () {",
//"           $(\".div-contents\").mouseout(function () {",
//"               $(\"#img_edit2\").css({ \"display\": \"none\" });",
//"           });",
//"       });",



//"       $(document).ready(function () {",
//"           $(\".content\").mouseover(function () {",
//"               $(\"#img_edit3\").css({ \"display\": \"block\" });",
//"           });",
//"       });",
//"       $(document).ready(function () {",
//"           $(\".content\").mouseout(function () {",
//"               $(\"#img_edit3\").css({ \"display\": \"none\" });",
//"           });",
//"       });",
//"   </script>",
"</head>",
"<body>",
"   <form id=\"form1\" runat=\"server\">",

//"       <div id='header'></div>",
//"         <div id='body'><label id='lb'>Hello</label></div>",
//"       <div id='footer'></div>",

//"       ",

"   <div class=\"wrapper\">",
"       <div class=\"content-wrapper\">",
"           <section class=\"content-header\">",
"               <div class=\"row\">",
"                   <section class=\"col-lg-12 connectedSortable\">",
"                       <div class=\"box-body\">",
"                       </div>",
"                   </section>",
"               </div>",
"           </section>",
"       </div>",
"   </div>",


//"       <div style=\"display:none;\">",
//"           <asp:literal id=\"output\" runat=\"server\"/>",
//"       </div>",
//"        <header>",
//"        <div id=\"header\" runat=\"Server\" class=\"header\">",
//"           <div style=\"display:none;\" id=\"show_menu\">",
//"               This is a demo.",
//"               <div id=\"code1\">",
//"               <span><a href=\"#\">Home</a></span>&nbsp;&nbsp;<span><a href=\"#\">Message</a></span>&nbsp;&nbsp;<span><a href=\"#\">Photo</a></span>",
//"               </div>",
//"               <span><button id=\"btn_add_code\">",
//"                   Add",
//"               </button></span>",
//"           </div>",
//"           <div runat=\"Server\" style=\"display:none;\" class=\"menu\">",
//"               ",
//"           </div>",
//"            <div class=\"bottom-right\">",
//"               <asp:Button ID=\"btn_edit_header\" OnClick=\"btn_edit_header_Click\" runat=\"Server\" Text=\"Edit Header\"/>",
//"               <asp:Button Visible=\"False\" ID=\"btn_save_header\" OnClick=\"btn_save_header_Click\" runat=\"Server\" Text=\"Save Changes\"/>",
//"            </div>",
//"           <div style=\"display:none;\" runat=\"Server\" id=\"div_add_menu\">",
//"               <button id=\"btn_add_menu\">",
//"                   Add menu",
//"               </button>",
//"           </div>",
//"           ",
//"        </div>",
//"        </header>",
//"        <div id=\"body\" runat=\"Server\" class=\"container\">",
//"            <div class=\"bottom-right\">",
//"               <asp:Button Visible=\"False\" ID=\"btn_edit_body\" OnClick=\"btn_edit_body_Click\" runat=\"Server\" Text=\"Edit Body\"/>",
//"               <asp:Button Visible=\"False\" ID=\"btn_save_body\" OnClick=\"btn_save_body_Click\" runat=\"Server\" Text=\"Save Changes\"/>",

//"            </div>",

//"               <section class=\"first-section\">",
//"                   <div class=\"div-img\">",
//"                       <img style=\"height:250px; width:300px;\" src=\"images/img1.jpg\" alt=\"\"/>",
//"                       <asp:ImageButton CssClass=\"img-edit\" ID=\"img_edit\" OnClick=\"img_edit_Click\" runat=\"server\" ImageUrl=\"~/web-design/images/edit-icon.png\" />",
//"                       <asp:LinkButton Visible=\"False\" OnClick=\"hl_save_Click\" ID=\"hl_save\" runat=\"server\">",
//"                           <img src=\"images/save.jpg\" class=\"img-save\" alt=\"Save changes\" />",
//"                       </asp:LinkButton>",
//"                   </div>",

//"                   <div class=\"div-contents\">",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       <asp:ImageButton CssClass=\"img-edit\" ID=\"img_edit2\" OnClick=\"img_edit2_Click\" runat=\"server\" ImageUrl=\"~/web-design/images/edit-icon.png\" />",
//"                   </div>",
//"                   <div class=\"content\">",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       This is a demo text. Edit these text before publish  the site.",
//"                       <asp:ImageButton CssClass=\"img-edit\" ID=\"img_edit3\" OnClick=\"img_edit3_Click\" runat=\"server\" ImageUrl=\"~/web-design/images/edit-icon.png\" />",                        
//"                   </div>",

//"               </section>",


//"        </div>",
//"        <footer>",
//"        <div id=\"footer\" runat=\"Server\" class=\"footer\">",
//"            <div class=\"bottom-right\">",
//"               <asp:Button ID=\"btn_edit_footer\" OnClick=\"btn_edit_footer_Click\" runat=\"Server\" Text=\"Edit Footer\"/>",
//"               <asp:Button Visible=\"False\" ID=\"btn_save_footer\" OnClick=\"btn_save_footer_Click\" runat=\"Server\" Text=\"Save Changes\"/>",
//"            </div>",
//"        </div>",
//"        </footer>",
        
"   </form>",
"   <script src=\"../../admin/plugins/jQuery/jQuery-2.1.3.min.js\"></script>",
"   <script src=\"http://code.jquery.com/ui/1.11.2/jquery-ui.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/bootstrap/js/bootstrap.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js\"></script>",
"   <script src=\"../../admin/plugins/morris/morris.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/sparkline/jquery.sparkline.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/jvectormap/jquery-jvectormap-world-mill-en.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/knob/jquery.knob.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/daterangepicker/daterangepicker.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/datepicker/bootstrap-datepicker.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/iCheck/icheck.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/plugins/slimScroll/jquery.slimscroll.min.js\" type=\"text/javascript\"></script>",
"   <script src='../../admin/plugins/fastclick/fastclick.min.js'></script>",
"   <script src=\"../../admin/dist/js/app.min.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/dist/js/pages/dashboard.js\" type=\"text/javascript\"></script>",
"   <script src=\"../../admin/dist/js/demo.js\" type=\"text/javascript\"></script>",
"</body>",
"</html>"};
        string[] csLines = {"using System;",
"using System.Web.UI.WebControls;",
"using System.Data;",
"using System.Data.SqlClient;",
"namespace generate_page_runtime {",
"    public partial class "+hf_page_name.Value+" : System.Web.UI.Page {",

"        protected void Page_Load(object sender, EventArgs e) {",
//"            output.Text = \"Our new page\";",
"        }",
"           ",
//"       protected void btn_edit_header_Click(object sender, EventArgs e)",
//"       {",
//"          header.Attributes[\"class\"]=\"header\"+\" \"+\"select\";",
//"          btn_edit_header.Visible = false;",
//"          btn_save_header.Visible = true;",
//"          div_add_menu.Attributes[\"class\"] = \"center\";",
//"          div_add_menu.Attributes[\"style\"] = \"display : block\";",
//"       }",
//"           ",
//"       protected void btn_edit_body_Click(object sender, EventArgs e)",
//"       {",
//"          body.Attributes[\"class\"] = \"container\"+\" \"+\"select\";",
//"          btn_edit_body.Visible = false;",
//"          btn_save_body.Visible = true;",
//"       }",
//"           ",
//"       protected void btn_edit_footer_Click(object sender, EventArgs e)",
//"       {",
//"          footer.Attributes[\"class\"] = \"footer\"+\" \"+\"select\";",
//"          btn_edit_footer.Visible = false;",
//"          btn_save_footer.Visible = true;",
//"       }",
//"       ",
//"       protected void btn_save_header_Click(object sender, EventArgs e)",
//"       {",
//"          header.Attributes[\"class\"]=\"header\";",
//"          btn_edit_header.Visible = true;",
//"          btn_save_header.Visible = false;",
//"          div_add_menu.Attributes[\"class\"] = \"center\";",
//"          div_add_menu.Attributes[\"style\"] = \"display : none\";",
//"       }",
//"       ",
//"       protected void btn_save_body_Click(object sender, EventArgs e)",
//"       {",
//"          body.Attributes[\"class\"] = \"container\";",
//"          btn_edit_body.Visible = true;",
//"          btn_save_body.Visible = false;",
//"       }",
//"       ",
//"       protected void btn_save_footer_Click(object sender, EventArgs e)",
//"       {",
//"          footer.Attributes[\"class\"] = \"footer\";",
//"          btn_edit_footer.Visible = true;",
//"          btn_save_footer.Visible = false;",
//"       }",


//"       protected void img_edit_Click(object sender, System.Web.UI.ImageClickEventArgs e)",
//"       {",
//"           hl_save.Visible = true;",

//"       }",
//"       protected void img_edit2_Click(object sender, System.Web.UI.ImageClickEventArgs e)",
//"       {",

//"       }",
//"       protected void img_edit3_Click(object sender, System.Web.UI.ImageClickEventArgs e)",
//"       {",
//"           ",
//"       }",

//"       protected void hl_save_Click(object sender, EventArgs e)",
//"       {",
//"           hl_save.Visible = false;",
//"           img_edit.Attributes[\"style\"] = \"display : block\";",
//"       }",

//"       ",
"    }",
"}"};
        string username;
        username = (Session[Constants.Session.USERNAME] != null ? Session[Constants.Session.USERNAME].ToString() : string.Empty);
        string subPath = "~/web-design/" + username + "/" + hf_website_name.Value + "/";

        bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

        if (!exists)
            System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

        File.WriteAllLines(Server.MapPath(subPath + hf_page_name.Value + ".aspx"), aspxLines);
        File.WriteAllLines(Server.MapPath(subPath + hf_page_name.Value + ".aspx.cs"), csLines);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //   create();
    }
    protected void btn_create_page_Click(object sender, EventArgs e)
    {
        create();
    }
    protected void bind_website_ddl()
    {
        ///DatabaseManagement dbmanage = new DatabaseManagement();
        string username = "";
        if (Session[Constants.Session.USERNAME] != null)
            username = Session[Constants.Session.USERNAME].ToString();
        else
        {
            Response.Redirect("~/login.aspx");
        }
        datalayer c = new datalayer();
        var q = c.Retrieve_Website(username);

        if (q.Any())
        {
            ddl_select_website.Items.Clear();
            ddl_select_website.Items.Insert(0, "Select");  // inserting at first position
            foreach (var a in q)
            {
                //binding website list in drop down------------

                ddl_select_website.Items.Add(a.WebsiteName);
                //------------------------------------------
            }
        }
    }
    protected void btn_create_database_Click(object sender, EventArgs e)
    {
        if (txt_database_name.Text.Trim() == "")
        {
            lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
            lb_create_database_msg.Text = "Enter a database name.";
        }
        else if (ddl_select_website.SelectedItem.Text.Equals("Select"))
        {
            lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
            lb_create_database_msg.Text = "Select a website.";
        }
        else
        {
            lb_create_database_msg.Text = "";
            System.Web.Security.MembershipUser mu;
            Guid userid;
            mu = System.Web.Security.Membership.GetUser();
            userid = (Guid)mu.ProviderUserKey;
            string username = Session[Constants.Session.USERNAME].ToString();

            string dbname = txt_database_name.Text.Trim();
            string websitename = ddl_select_website.SelectedItem.Text.ToString();

            int websiteid = GetWebsiteId(userid, username, websitename);

            if (Session["databaseid"] != null)
            {
                if (dbmanagement.CheckDatabaseByDbNameAndWebsite(dbname, websitename))
                {
                    Clear();
                    btn_create_database.Text = "Create Database";
                    lb_create_database_msg.ForeColor = System.Drawing.Color.Green;
                    lb_create_database_msg.Text = "Database updated successfully.";
                    Session["databaseid"] = null;
                    hf_db_id.Value = "";
                }
                else
                {
                    int dbid = dbmanagement.GetDbIdByWebsiteName(websitename);
                    if (dbid == Convert.ToInt32(hf_db_id.Value))
                    {
                        if (dbmanagement.UpdateDbByDBId(Convert.ToInt32(hf_db_id.Value), dbname, websiteid, userid, websitename, username))
                        {
                            Clear();
                            btn_create_database.Text = "Create Database";
                            lb_create_database_msg.ForeColor = System.Drawing.Color.Green;
                            lb_create_database_msg.Text = "Database updated successfully.";
                            Session["databaseid"] = null;
                            hf_db_id.Value = "";
                        }
                    }
                    else
                    {
                        if (dbmanagement.IsDbCreatedForWebsite(websitename))
                        {
                            Clear();
                            lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
                            lb_create_database_msg.Text = "Could not attach database with this website because you have already created a database for this website.";
                            Session["databaseid"] = null;
                            hf_db_id.Value = "";
                        }
                        else
                        {
                            if (dbmanagement.UpdateDbByDBId(Convert.ToInt32(hf_db_id.Value), dbname, websiteid, userid, websitename, username))
                            {
                                Clear();
                                btn_create_database.Text = "Create Database";
                                lb_create_database_msg.ForeColor = System.Drawing.Color.Green;
                                lb_create_database_msg.Text = "Database updated successfully.";
                                Session["databaseid"] = null;
                                hf_db_id.Value = "";
                            }
                            else
                            {
                                Clear();
                                lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
                                lb_create_database_msg.Text = "Could not update. Please try again.";
                                Session["databaseid"] = null;
                                hf_db_id.Value = "";
                            }
                        }
                    }
                }
            }
            else
            {

                //checking for is database created for this website or not?
                if (dbmanagement.IsDbCreatedForWebsite(websitename))
                {
                    lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
                    lb_create_database_msg.Text = "You have already created a database for this website.";
                }
                else
                {
                    if (dbmanagement.CheckDatabaseByDbNameAndWebsite(dbname, websitename))        // checking for updates.  if record exist already then update the database
                    {
                        //   update the database with new change..........
                        if (dbmanagement.UpdateDbRecord(dbname, websitename))
                        {
                            Clear();
                            btn_create_database.Text = "Create Database";
                            lb_create_database_msg.ForeColor = System.Drawing.Color.Green;
                            lb_create_database_msg.Text = "Database updated successfully.";
                        }
                        else
                        {
                            lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
                            lb_create_database_msg.Text = "Could not update database. Please try again.";
                        }
                    }
                    else
                    {

                        //if (dbmanagement.Save(dbname, websiteid, websitename, userid, username))
                        {
                            //    Clear();
                            //    lb_create_database_msg.ForeColor = System.Drawing.Color.Green;
                            //    lb_create_database_msg.Text = "Database created successfully.";

                            // code to create database.........................-----------------------
                            String str;
                            SqlConnection myConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                            string db_path = "~/web-design/" + Session[Constants.Session.USERNAME].ToString() + "/" + websitename + "/" + "App_Data/";
                            bool exists = System.IO.Directory.Exists(Server.MapPath(db_path));
                            Random r = new Random();
                            var random = r.Next(9999);
                            if (!exists)
                                System.IO.Directory.CreateDirectory(Server.MapPath(db_path));
                            str = "CREATE DATABASE " + dbname + websiteid + " ON PRIMARY " +
                                "(NAME = " + dbname + websitename + ", " +
                                "FILENAME = '" + Server.MapPath(db_path + dbname + ".mdf") + "', " +
                                "SIZE = 4MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                                "LOG ON (NAME = " + dbname + ", " +
                                "FILENAME = '" + Server.MapPath(db_path + dbname + "_log.ldf") + "', " +
                                "SIZE = 1MB, " +
                                "MAXSIZE = 5MB, " +
                                "FILEGROWTH = 10%)";

                            SqlCommand myCommand = new SqlCommand(str, myConn);
                            try
                            {
                                myConn.Open();
                                myCommand.ExecuteNonQuery();
                                // entering details in db-----------------
                                if (dbmanagement.Save(dbname, websiteid, websitename, userid, username))
                                {
                                    Clear();
                                    lb_create_database_msg.ForeColor = System.Drawing.Color.Green;
                                    lb_create_database_msg.Text = "Database created successfully.";
                                }
                                //---------------------
                                //  MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (System.Exception ex)
                            {
                                lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
                                lb_create_database_msg.Text = "Choose database name atleast 10 characters long.";
                                // MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            finally
                            {
                                if (myConn.State == ConnectionState.Open)
                                {
                                    myConn.Close();
                                }
                            }
                            //----------------------------------
                        }
                        //else
                        //{
                        //    lb_create_database_msg.ForeColor = System.Drawing.Color.Red;
                        //    lb_create_database_msg.Text = "Could not created. Please try again.";
                        //}
                    }
                }

            }
        }
    }
    protected void btn_edit_db_Click(object sender, EventArgs e)
    {
        var q = dbmanagement.GetDatabaseListByDbId(Convert.ToInt32(hf_db_id.Value));
        if (q.Any())
        {
            //  Session[Constants.Database.DATABASE_ID] = Convert.ToInt32(hf_db_id.Value);
            //  Session[Constants.Database.UPDATE_DATABASE] = "Update";
            /// hf_database_id.Value = hf_db_id.Value;

            Session["databaseid"] = hf_db_id.Value;
            btn_create_database.Text = "Update Database";
            foreach (var a in q)
            {
                txt_database_name.Text = a.DatabaseName;
                ddl_select_website.SelectedValue = a.WebsiteName;
            }
        }
    }
    [WebMethod]
    public static void delete_database(int databaseid)
    {
        MyProjectDataContext dbcontext = new MyProjectDataContext();
        DatabaseManagement dbManage = new DatabaseManagement();
        string websitename = dbManage.GetWebsiteNameByDbId(databaseid);
        if (dbManage.DeleteDatabaseById(databaseid))
        {

            System.Web.UI.Page ob = new System.Web.UI.Page();
            string db_path = "~/web-design/" + ob.Session[Constants.Session.USERNAME].ToString() + "/" + websitename + "/" + "App_Data/";
            bool exists = System.IO.Directory.Exists(ob.Server.MapPath(db_path));

            if (exists)
            {
                //System.IO.Directory.CreateDirectory(Server.MapPath(db_path));
                System.IO.Directory.Delete(ob.Server.MapPath(db_path), true);
            }
        }
        else
        {

        }
        // var q=
    }
    private void Clear()
    {
        txt_database_name.Text = "";
        ddl_select_website.ClearSelection();
    }
    protected void btn_manage_tables_Click(object sender, EventArgs e)
    {
        Guid userid;
        System.Web.Security.MembershipUser mu;
        mu = System.Web.Security.Membership.GetUser();
        userid = (Guid)mu.ProviderUserKey;
        DatabaseManagement dbmanage = new DatabaseManagement();
        int dbid = hf_db_id_for_tbl.Value != "" ? Convert.ToInt32(hf_db_id_for_tbl.Value) : 0;
        if (hf_db_id_for_tbl.Value != "")
        {
            var q = dbmanage.GetTableRecords(dbid, userid);
            if (q.Any())
            {
                HtmlTableRow tr = null;
                HtmlTableCell td_tablename = null;
                LinkButton lb_tablename = null;
                foreach (var a in q)
                {
                    tr = new HtmlTableRow();
                    td_tablename = new HtmlTableCell();
                    lb_tablename = new LinkButton();
                    lb_tablename.Text = a.TableName;
                    td_tablename.Controls.Add(lb_tablename);
                    tr.Controls.Add(td_tablename);
                    tbl_table_detail.Controls.Add(tr);
                }
            }
        }


        section_tbl_list.Attributes["class"] = "display-none";
        section_manage_tables.Attributes["class"] = "display-block";
        //disabling controls
        txt_database_name.ReadOnly = true;
        //ddl_select_website.Items.IsReadOnly = true;
        //  txt_database_name.Attributes["class"] = "form-control disabled";
        //ddl_select_website.Attributes["class"] = "form-control disabled";
        //ddl_select_website.Attributes["disabled"] = "disabled";
        btn_create_database.Attributes["class"] = "btn btn-block bg-purple btn-flat disabled";
    }
    protected void btn_save_table_manage_Click(object sender, EventArgs e)
    {
        section_tbl_list.Attributes["class"] = "display-block";
        section_manage_tables.Attributes["class"] = "display-none";

        // enabling controls
        txt_database_name.ReadOnly = false;
        //ddl_select_website.Attributes["enabled"] = "enabled";
        //   txt_database_name.Attributes["class"] = "form-control";
        //ddl_select_website.Attributes["class"] = "form-control";
        btn_create_database.Attributes["class"] = "btn btn-block bg-purple btn-flat";
    }
    protected void btn_cancel_table_manage_Click(object sender, EventArgs e)
    {
        section_tbl_list.Attributes["class"] = "display-block";
        section_manage_tables.Attributes["class"] = "display-none";
        // enabling controls
        txt_database_name.ReadOnly = false;
        //ddl_select_website.Attributes["enabled"] = "enabled";
        btn_create_database.Attributes["class"] = "btn btn-block bg-purple btn-flat";
    }
    protected void lb_preview_Click(object sender, EventArgs e)
    {
        System.Web.Security.MembershipUser mu;
        Guid userid;
        mu = System.Web.Security.Membership.GetUser();
        userid = (Guid)mu.ProviderUserKey;
        string username = Session[Constants.Session.USERNAME].ToString();
        if (dl.GetTotalWebPageCount(userid, username, hf_website_preview.Value) == 1)
        {

        }
    }
    protected void btn_create_table_Click(object sender, EventArgs e)
    {
        string websitename = "";
        string databasename = "";
        string tablename = txt_table_name.Text.Trim();
        string columnname = (Session["column"] != null ? Session["column"].ToString() : "");
        string datatype = (Session["datatype"] != null ? Session["datatype"].ToString() : "");
        if (columnname != "")
        {
            columnname = columnname.Remove(columnname.Length - 1, 1);
        }
        if (datatype != "")
        {
            datatype = datatype.Remove(datatype.Length - 1, 1);
        }
        string query = "";
        if (Session["column_details"] != null)
        {
            query = Session["column_details"].ToString();
            query = query.Remove(query.Length - 1, 1);
        }
        Guid userid;
        System.Web.Security.MembershipUser mu;
        mu = System.Web.Security.Membership.GetUser();
        userid = (Guid)mu.ProviderUserKey;
        var q = dbmanagement.GetDatabaseListByDbId(Convert.ToInt32(hf_db_id_for_tbl.Value));
        if (q.Any())
        {
            foreach (var a in q)
            {
                websitename = a.WebsiteName;
                databasename = a.DatabaseName;
            }
        }
        string path = Server.MapPath("~/web-design/" + Session[Constants.Session.USERNAME].ToString() + "/" + websitename + "/" + "App_Data/" + databasename + ".mdf");
        bool exists = System.IO.File.Exists(path);
        if (exists)
        {
            SqlConnection myConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + path + "';Integrated Security=True");
            string str = "create table " + tablename + "(" + query + ")";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                //  saving table details in database------------------
                if (dbmanagement.SaveTable(tablename, Convert.ToInt32(hf_db_id_for_tbl.Value), websitename, Session[Constants.Session.USERNAME].ToString(), userid))
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    dbmanagement.SaveTableColumnDetails(Convert.ToInt32(hf_db_id_for_tbl.Value), tablename, columnname, datatype, userid);
                    ClearManageTableData();
                    lbl_create_table_msg.ForeColor = System.Drawing.Color.Green;
                    lbl_create_table_msg.Text = "Table created successfully.";
                }
                else
                {
                    lbl_create_table_msg.ForeColor = System.Drawing.Color.Red;
                    lbl_create_table_msg.Text = "Could not created.";
                }
                //---------------------------

            }
            catch
            {
                lbl_create_table_msg.ForeColor = System.Drawing.Color.Red;
                lbl_create_table_msg.Text = "Could not created.";
                int tableid = dbmanagement.GetTableId(Convert.ToInt32(hf_db_id_for_tbl.Value), websitename, userid);
                if (tableid != 0)
                {
                    dbmanagement.DeleteTableByTableId(tableid);
                }
            }
            finally
            {
                Session["column_details"] = null;
                Session["column"] = null;
                Session["datatype"] = null;
            }
        }
        else
        {
            lbl_create_table_msg.ForeColor = System.Drawing.Color.Red;
            lbl_create_table_msg.Text = "Database does not exist.";
        }
        Session["column_details"] = null;
        Session["column"] = null;
        Session["datatype"] = null;
        //string db_path = "~/web-design/" + Session[Constants.Session.USERNAME].ToString() + "/" + websitename + "/" + "App_Data/";
        //bool exists = System.IO.Directory.Exists(Server.MapPath(db_path));
    }
    public void ClearManageTableData()
    {
        txt_column_name.Text = "";
        ddl_data_type.ClearSelection();
    }
    protected void btn_add_columns_Click(object sender, EventArgs e)
    {
        if (txt_table_name.Text.Trim() == "")
        {
            lbl_create_table_msg.ForeColor = System.Drawing.Color.Red;
            lbl_create_table_msg.Text = "Enter a table name.";
        }
        else
            if (txt_column_name.Text.Trim() == "")
            {
                lbl_create_table_msg.ForeColor = System.Drawing.Color.Red;
                lbl_create_table_msg.Text = "Enter atleast one column.";
            }
            else
                if (ddl_data_type.SelectedItem.Text.Equals("Select"))
                {
                    lbl_create_table_msg.ForeColor = System.Drawing.Color.Red;
                    lbl_create_table_msg.Text = "Choose a datatype.";
                }
                else
                {
                    lbl_create_table_msg.ForeColor = System.Drawing.Color.Green;
                    lbl_create_table_msg.Text = "Added.";
                    //hf_column_details.Value += txt_column_name.Text.Trim() + " " + ddl_data_type.SelectedItem.Text + ",";
                    Session["column_details"] += txt_column_name.Text.Trim() + " " + ddl_data_type.SelectedItem.Text + ",";
                    Session["column"] += txt_column_name.Text.Trim() + ",";
                    Session["datatype"] += ddl_data_type.SelectedItem.Text + ",";
                    ClearManageTableData();
                }
    }
}