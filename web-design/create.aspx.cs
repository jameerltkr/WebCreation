using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
        btn_create_page.Enabled = false;
        btn_new_page.CssClass = "show" + " " + "a_demo_four" + " " + "align-left";
        btn_create_page.CssClass = "align-left" + " " + "a_demo_four";

        

        //dl.Retrieve_Website_Name(Session["id"].ToString(),);

        //dl.SavePages(Session["id"].ToString(),txtpagename.Text.Trim(),)

        string[] aspxLines = {"<%@ Page Language=\"C#\" AutoEventWireup=\"true\"CodeFile=\""+txtpagename.Text.Trim()+".aspx.cs\" Inherits=\"generate_page_runtime."+txtpagename.Text.Trim()+"\" %>",
                                     "<!DOCTYPE html>",
"<html xmlns=\"http://www.w3.org/1999/xhtml\">",
"<head>",
"   <title>The New Page</title>",
"   <link href=\"css/site.css\" rel=\"stylesheet\" />",
"    <script type=\"text/javascript\" src=\"js/jquery.min.js\"></script>",

"    <script src=\"js/jquery-ui.js\" type=\"text/javascript\"></script>",
"     <link href=\"css/popup-style.css\"",
"        rel=\"stylesheet\" type=\"text/css\" />",
"   <script type=\"text/javascript\">",
"       $(\"[id*=btn_add_menu]\").live(\"click\", function () {",
"           $(\"#show_menu\").dialog({",
"               title: \"jQuery Modal Dialog Popup\",",
"               buttons: {",
"                   Close: function () {",
"                       $(this).dialog('close');",
"                   }",
"               },",
"           modal: true",
"       });",
"       return false;",
"       });",
"       $(document).ready(function () {",
"           $(\"#btn_add_code\").click(function () {",
"               ",
"           });",
"       });",
"       $(document).ready(function () {",
"           $(\".div-img\").mouseover(function () {",
"               $(\"#img_edit\").css({ \"display\": \"block\" });",
"           });",
"       });",
"       $(document).ready(function () {",
"           $(\".div-img\").mouseout(function () {",
"               $(\"#img_edit\").css({ \"display\": \"none\" });",
"           });",
"       });",



"       $(document).ready(function () {",
"           $(\".div-contents\").mouseover(function () {",
"               $(\"#img_edit2\").css({ \"display\": \"block\" });",
"           });",
"       });",
"       $(document).ready(function () {",
"           $(\".div-contents\").mouseout(function () {",
"               $(\"#img_edit2\").css({ \"display\": \"none\" });",
"           });",
"       });",



"       $(document).ready(function () {",
"           $(\".content\").mouseover(function () {",
"               $(\"#img_edit3\").css({ \"display\": \"block\" });",
"           });",
"       });",
"       $(document).ready(function () {",
"           $(\".content\").mouseout(function () {",
"               $(\"#img_edit3\").css({ \"display\": \"none\" });",
"           });",
"       });",
"   </script>",
"</head>",
"<body>",
"   <form id=\"form1\" runat=\"server\">",
"       <div style=\"display:none;\">",
"           <asp:literal id=\"output\" runat=\"server\"/>",
"       </div>",
"        <header>",
"        <div id=\"header\" runat=\"Server\" class=\"header\">",
"           <div style=\"display:none;\" id=\"show_menu\">",
"               This is a demo.",
"               <div id=\"code1\">",
"               <span><a href=\"#\">Home</a></span>&nbsp;&nbsp;<span><a href=\"#\">Message</a></span>&nbsp;&nbsp;<span><a href=\"#\">Photo</a></span>",
"               </div>",
"               <span><button id=\"btn_add_code\">",
"                   Add",
"               </button></span>",
"           </div>",
"           <div runat=\"Server\" style=\"display:none;\" class=\"menu\">",
"               ",
"           </div>",
"            <div class=\"bottom-right\">",
"               <asp:Button ID=\"btn_edit_header\" OnClick=\"btn_edit_header_Click\" runat=\"Server\" Text=\"Edit Header\"/>",
"               <asp:Button Visible=\"False\" ID=\"btn_save_header\" OnClick=\"btn_save_header_Click\" runat=\"Server\" Text=\"Save Changes\"/>",
"            </div>",
"           <div style=\"display:none;\" runat=\"Server\" id=\"div_add_menu\">",
"               <button id=\"btn_add_menu\">",
"                   Add menu",
"               </button>",
"           </div>",
"           ",
"        </div>",
"        </header>",
"        <div id=\"body\" runat=\"Server\" class=\"container\">",
"            <div class=\"bottom-right\">",
"               <asp:Button Visible=\"False\" ID=\"btn_edit_body\" OnClick=\"btn_edit_body_Click\" runat=\"Server\" Text=\"Edit Body\"/>",
"               <asp:Button Visible=\"False\" ID=\"btn_save_body\" OnClick=\"btn_save_body_Click\" runat=\"Server\" Text=\"Save Changes\"/>",

"            </div>",

"               <section class=\"first-section\">",
"                   <div class=\"div-img\">",
"                       <img style=\"height:250px; width:300px;\" src=\"images/img1.jpg\" alt=\"\"/>",
"                       <asp:ImageButton CssClass=\"img-edit\" ID=\"img_edit\" OnClick=\"img_edit_Click\" runat=\"server\" ImageUrl=\"~/web-design/images/edit-icon.png\" />",
"                       <asp:LinkButton Visible=\"False\" OnClick=\"hl_save_Click\" ID=\"hl_save\" runat=\"server\">",
"                           <img src=\"images/save.jpg\" class=\"img-save\" alt=\"Save changes\" />",
"                       </asp:LinkButton>",
"                   </div>",

"                   <div class=\"div-contents\">",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       <asp:ImageButton CssClass=\"img-edit\" ID=\"img_edit2\" OnClick=\"img_edit2_Click\" runat=\"server\" ImageUrl=\"~/web-design/images/edit-icon.png\" />",
"                   </div>",
"                   <div class=\"content\">",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       This is a demo text. Edit these text before publish  the site.",
"                       <asp:ImageButton CssClass=\"img-edit\" ID=\"img_edit3\" OnClick=\"img_edit3_Click\" runat=\"server\" ImageUrl=\"~/web-design/images/edit-icon.png\" />",                        
"                   </div>",

"               </section>",


"        </div>",
"        <footer>",
"        <div id=\"footer\" runat=\"Server\" class=\"footer\">",
"            <div class=\"bottom-right\">",
"               <asp:Button ID=\"btn_edit_footer\" OnClick=\"btn_edit_footer_Click\" runat=\"Server\" Text=\"Edit Footer\"/>",
"               <asp:Button Visible=\"False\" ID=\"btn_save_footer\" OnClick=\"btn_save_footer_Click\" runat=\"Server\" Text=\"Save Changes\"/>",
"            </div>",
"        </div>",
"        </footer>",
        
"   </form>",
"</body>",
"</html>"};
        string[] csLines = {"using System;",
"using System.Web.UI.WebControls;",
"using System.Data;",
"using System.Data.SqlClient;",
"namespace generate_page_runtime {",
"    public partial class "+txtpagename.Text.Trim()+" : System.Web.UI.Page {",

"        protected void Page_Load(object sender, EventArgs e) {",
"            output.Text = \"Our new page\";",
"        }",
"           ",
"       protected void btn_edit_header_Click(object sender, EventArgs e)",
"       {",
"          header.Attributes[\"class\"]=\"header\"+\" \"+\"select\";",
"          btn_edit_header.Visible = false;",
"          btn_save_header.Visible = true;",
"          div_add_menu.Attributes[\"class\"] = \"center\";",
"          div_add_menu.Attributes[\"style\"] = \"display : block\";",
"       }",
"           ",
"       protected void btn_edit_body_Click(object sender, EventArgs e)",
"       {",
"          body.Attributes[\"class\"] = \"container\"+\" \"+\"select\";",
"          btn_edit_body.Visible = false;",
"          btn_save_body.Visible = true;",
"       }",
"           ",
"       protected void btn_edit_footer_Click(object sender, EventArgs e)",
"       {",
"          footer.Attributes[\"class\"] = \"footer\"+\" \"+\"select\";",
"          btn_edit_footer.Visible = false;",
"          btn_save_footer.Visible = true;",
"       }",
"       ",
"       protected void btn_save_header_Click(object sender, EventArgs e)",
"       {",
"          header.Attributes[\"class\"]=\"header\";",
"          btn_edit_header.Visible = true;",
"          btn_save_header.Visible = false;",
"          div_add_menu.Attributes[\"class\"] = \"center\";",
"          div_add_menu.Attributes[\"style\"] = \"display : none\";",
"       }",
"       ",
"       protected void btn_save_body_Click(object sender, EventArgs e)",
"       {",
"          body.Attributes[\"class\"] = \"container\";",
"          btn_edit_body.Visible = true;",
"          btn_save_body.Visible = false;",
"       }",
"       ",
"       protected void btn_save_footer_Click(object sender, EventArgs e)",
"       {",
"          footer.Attributes[\"class\"] = \"footer\";",
"          btn_edit_footer.Visible = true;",
"          btn_save_footer.Visible = false;",
"       }",


"       protected void img_edit_Click(object sender, System.Web.UI.ImageClickEventArgs e)",
"       {",
"           hl_save.Visible = true;",

"       }",
"       protected void img_edit2_Click(object sender, System.Web.UI.ImageClickEventArgs e)",
"       {",

"       }",
"       protected void img_edit3_Click(object sender, System.Web.UI.ImageClickEventArgs e)",
"       {",
"           ",
"       }",

"       protected void hl_save_Click(object sender, EventArgs e)",
"       {",
"           hl_save.Visible = false;",
"           img_edit.Attributes[\"style\"] = \"display : block\";",
"       }",

"       ",
"    }",
"}"};
        File.WriteAllLines(Server.MapPath("" + txtpagename.Text.Trim() + ".aspx"), aspxLines);
        File.WriteAllLines(Server.MapPath("" + txtpagename.Text.Trim() + ".aspx.cs"), csLines);


    }
    protected void btn_new_page_Click(object sender, EventArgs e)
    {
        Response.Redirect("" + txtpagename.Text.Trim() + ".aspx");
    }
    protected void btn_create_website_Click(object sender, EventArgs e)
    {
        pnl_website_name.Visible = true;
        
    }
    protected void rpt_website_name_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "website":
                string lb = e.CommandArgument.ToString();
                pnl_create_pages.Visible = true;
                break;
            default:
                break;
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
    protected void WizardStep1_Activate(object sender, EventArgs e)
    {
       // Response.Write("hello");
    }
    protected void WizardStep1_Deactivate(object sender, EventArgs e)
    {
        //Response.Write("hello");

        datalayer dl = new datalayer();

        System.Web.Security.MembershipUser mu;
        if (!Request.IsAuthenticated)
        {
            mu = null;
            Response.Redirect("~/login.aspx");
        }
        else
        {
            Guid userid;
            mu = System.Web.Security.Membership.GetUser();
            userid = (Guid)mu.ProviderUserKey;
            if (dl.SaveWebsite(Session[Constants.Session.ID].ToString(), txt_website_name.Text.Trim(), userid) == Constants.SUCCESS)
            {
                pnl_create_pages.Visible = true;
                pnl_website_name.Visible = false;
            }
            else
                if (dl.SaveWebsite(Session[Constants.Session.ID].ToString(), txt_website_name.Text.Trim(), userid) == Constants.WEBSITE_ALREADY_EXIST)
                {
                    Message m = new Message();
                    error_div.Controls.Add(m.Error(Constants.WEBSITE_ALREADY_EXIST));
                }
                else
                    if (dl.SaveWebsite(Session[Constants.Session.ID].ToString(), txt_website_name.Text.Trim(), userid) == Constants.ERROR)
                    {
                        Message m = new Message();
                        error_div.Controls.Add(m.Error(Constants.ERROR));
                    }
            //  userid = (Guid)string.Empty;
        }
    }
}
