using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class web_design_create : System.Web.UI.Page
{
    datalayer dl = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.Session.USERNAME] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            var q = dl.Retrieve_Website(Session[Constants.Session.ID].ToString());
            if (q.Any())
            {
                foreach (var a in q)
                {
                    // btn_website_name.Text += a.WebsiteName;
                }
            }
        }
    }
    protected void btn_create_page_Click(object sender, EventArgs e)
    {

    }
    protected void create()
    {
        btn_create_page.Enabled = false;
        btn_new_page.CssClass = "show" + " " + "a_demo_four" + " " + "align-left";
        btn_create_page.CssClass = "align-left" + " " + "a_demo_four";



        //dl.Retrieve_Website_Name(Session["id"].ToString(),);

        //dl.SavePages(Session["id"].ToString(),txtpagename.Text.Trim(),)

        string[] aspxLines = {"<%@ Page Language=\"C#\" AutoEventWireup=\"true\"CodeFile=\""+hf_page_name.Value+".aspx.cs\" Inherits=\"generate_page_runtime."+hf_page_name.Value+"\" %>",
                                     "<!DOCTYPE html>",
"<html xmlns=\"http://www.w3.org/1999/xhtml\">",
"<head>",
//"   <title>The New Page</title>",
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
//"</head>",
"<body>",
"   <form id=\"form1\" runat=\"server\">",

"       <div id='header'></div>",
"         <div id='body'><label id='lb'>Hello</label></div>",
"       <div id='footer'></div>",

"       ",


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
        string subPath = "~/web-design/" + username + "/";

        bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

        if (!exists)
            System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

        File.WriteAllLines(Server.MapPath(subPath + hf_page_name.Value + ".aspx"), aspxLines);
        File.WriteAllLines(Server.MapPath(subPath + hf_page_name.Value + ".aspx.cs"), csLines);

    }
    protected void btn_new_page_Click(object sender, EventArgs e)
    {
        Response.Redirect("" + txtpagename.Text.Trim() + ".aspx");
    }
    protected void btn_create_website_Click(object sender, EventArgs e)
    {

        // Wizard_Create_Web.ActiveStepIndex = 1;
        Wizard_Create_Web.Visible = true;
        pnl_website_name.Visible = true;

    }
    protected void rpt_website_name_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "website")
        {
            //case "website":
            //    string lb = e.CommandArgument.ToString();
            //    pnl_create_pages.Visible = true;
            //    break;
            //default:
            //    break;
        }
    }
    protected void btn_website_name_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "website")
        {
            Response.Write("Hello");
        }
    }
    //protected void btn_save_website_Click(object sender, EventArgs e)
    //{

    //}

    protected void Wizard_Create_Web_ActiveStepChanged(object sender, EventArgs e)
    {
        if (Wizard_Create_Web.ActiveStepIndex == 1)
        {

        }
    }
    protected void Wizard_Create_Web_NextButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (Wizard_Create_Web.ActiveStepIndex == 0)
        {
            Message m = new Message();
            datalayer dl = new datalayer();

            System.Web.Security.MembershipUser mu;
            if (!Request.IsAuthenticated)
            {
                mu = null;
                Response.Redirect("~/login.aspx");
            }
            else

                if (txt_website_name.Text.Trim() == "")
                {
                    e.Cancel = true;
                    error_div.Controls.Add(m.Error(Constants.ENTER_WEBSITE_NAME));
                }
                else
                {
                    Guid userid;
                    mu = System.Web.Security.Membership.GetUser();
                    userid = (Guid)mu.ProviderUserKey;
                    if (dl.SaveWebsite(Session[Constants.Session.ID].ToString(), txt_website_name.Text.Trim(), userid) == Constants.SUCCESS)
                    {
                        e.Cancel = false;
                        Session[Constants.WEBSITE_NAME] = txt_website_name.Text.Trim();

                        //  pnl_create_pages.Visible = true;
                        //  pnl_website_name.Visible = false;
                    }
                    else
                        if (dl.SaveWebsite(Session[Constants.Session.ID].ToString(), txt_website_name.Text.Trim(), userid) == Constants.WEBSITE_ALREADY_EXIST)
                        {
                            e.Cancel = true;

                            Session[Constants.ERROR] = Constants.WEBSITE_ALREADY_EXIST;
                            error_div.Controls.Add(m.Error(Constants.WEBSITE_ALREADY_EXIST));

                        }
                        else
                            if (dl.SaveWebsite(Session[Constants.Session.ID].ToString(), txt_website_name.Text.Trim(), userid) == Constants.ERROR)
                            {
                                Session[Constants.ERROR] = Constants.ERROR;
                                e.Cancel = true;

                                error_div.Controls.Add(m.Error(Constants.ERROR));
                            }
                    //  userid = (Guid)string.Empty;
                }
        }
    }
    protected void Wizard_Create_Web_SideBarButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (Wizard_Create_Web.ActiveStepIndex == 0)
        {
            Message m = new Message();
            if (txt_website_name.Text.Trim() == "")
            {
                e.Cancel = true;
                error_div.Controls.Add(m.Error(Constants.ENTER_WEBSITE_NAME));
            }
            else
                if (Session[Constants.ERROR] != null)
                {

                    if (Session[Constants.ERROR] == Constants.WEBSITE_ALREADY_EXIST)
                    {
                        e.Cancel = true;
                        error_div.Controls.Add(m.Error(Constants.WEBSITE_ALREADY_EXIST));
                    }
                    else if (Session[Constants.ERROR] == Constants.ERROR)
                    {
                        e.Cancel = true;
                        error_div.Controls.Add(m.Error(Constants.ERROR));
                    }
                }
            //  Response.Write("h");
        }
    }
    protected void Wizard_Create_Web_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        //Wizard_Create_Web.WizardSteps.Clear();
        Wizard_Create_Web.Visible = false;
        if (Session[Constants.WEBSITE_NAME] != null)
        {
            pnl_web.Visible = true;
        }
    }

    [WebMethod]
    public static string get_page(string username, string websitename)
    {
        string msg = "";
        MyProjectDataContext da = new MyProjectDataContext();
        var q = from a in da.SubPages
                where a.UserName == username && a.WebsiteName == websitename
                select a;
        return msg;
    }

    [WebMethod]
    public static string show(Guid userid, string username, string websitename)
    {
        string msg = "";
        MyProjectDataContext da = new MyProjectDataContext();
        var q = from a in da.SubPages
                where a.UserName == username && a.WebsiteName == websitename
                select a;
        foreach (var o in q)
        {
            if (o.PageName.Count() == 0)
            {
                msg = "nothing";
                //pnl_web.Visible = true;
            }
            else
            {
                msg = "data";
                //pnl_web.Visible = false;
            }
        }
        return msg;
    }
    [WebMethod]
    public static PageData[] getpage(string username, string websitename)
    {
        List<PageData> page = new List<PageData>();
        MyProjectDataContext da = new MyProjectDataContext();
        var q = from a in da.SubPages
                where a.UserName == username && a.WebsiteName == websitename
                select a;
        foreach (var o in q)
        {
            PageData pd = new PageData();
            pd.PageName = o.PageName;
            pd.WebsiteName = o.WebsiteName;
            page.Add(pd);
        }
        return page.ToArray();
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

    protected void a2_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = sender as ImageButton;
        string id = img.ID;
        Response.Write(id);
    }
    [WebMethod]
    //[ScriptMethod(UseHttpGet = false)]
    public static string delete(Guid userid, string websitename)
    {
        string msg;
        // Response.Write(userid);
        // Response.Write(websitename);
        msg = "Hello";
        //  datalayer dl = new datalayer();
        MyProjectDataContext da = new MyProjectDataContext();
        var q = from a in da.BodyContents
                where a.UserId == userid && a.WebsiteName == websitename
                select a;
        var q1 = from b in da.SubPages
                 where b.WebsiteName == websitename
                 select b;
        foreach (var o in q)
        {
            da.BodyContents.DeleteOnSubmit(o);
        }
        foreach (var o in q1)
        {
            da.SubPages.DeleteOnSubmit(o);   // removing foreign key references
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

    protected void clickme(object sender, CommandEventArgs e)
    {
        Response.Write("Image clicked");
        // Label1.Text = "Image clicked";
    }
    protected void Wizard_Create_Web_CancelButtonClick(object sender, EventArgs e)
    {
        Wizard_Create_Web.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        create();
        //if(Session[Constants.Session.USERNAME]!=null)
        //{
        //    if(Session[Constants.WEBSITE_NAME]!=null)
        //    {
        //        Guid userid;
        //        System.Web.Security.MembershipUser mu;
        //        mu = System.Web.Security.Membership.GetUser();
        //        userid = (Guid)mu.ProviderUserKey;
        //        if (dl.SavePages(userid, Session[Constants.Session.USERNAME].ToString(), txt_page_name.Text.Trim(), Session[Constants.WEBSITE_NAME].ToString()))
        //        {
        //            txt_page_name.Text = "";
        //            Message m = new Message();
        //           error_div.Controls.Add(m.Error(Constants.PAGE_CREATED));
        //        }
        //        else
        //        {
        //            Message m = new Message();
        //            error_div.Controls.Add(m.Error(Constants.ERROR));
        //        }
        //    }
        //    else
        //    {
        //        div_create_page.Visible=false;

        //    }
        //}
    }
}
