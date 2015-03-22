<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="web_design_create" %>

<%@ Register Src="~/web-design/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/bottom.ascx" TagPrefix="uc1" TagName="bottom" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/site.css" rel="stylesheet" />
    <title>Create website | webcreation.com</title>
    <link href="../css/animate.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    

     <link rel="stylesheet" type="text/css" href="../css/demo.css" />
     <link rel="stylesheet" type="text/css" href="../css/style4.css" />
     <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'/>
 


    <link href="../css/responsive.css" rel="stylesheet" />
    <link href="../images/icon.png" rel="shortcut icon" />
    <script src="../js/jquery-1.10.2.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#btn_new_page").css({"display":"none"});
        });
        $(document).ready(function () {
            $("#btn_create_page").click(function () {
                //$("#btn_create_page").css({ "display": "none" });
                //$("#btn_new_page").css({ "display": "block" });
            });
        });
        $(document).ready(function () {
            //if ($("#btn_new_page").css({ "display": "block" }))
            //{
            //    $("#btn_create_page").css({ "display": "none" });
            //}
            //$("#btn_create_page").click(function () {
            //    $("#btn_create_page").css({ "display": "none" });
            //    $("#btn_new_page").css({ "display": "block" });
            //});
        });
        $(document).ready(function () {
            $("#btn_add_code").click(function () {

            });
        });
    </script>
    <style>
        .ln1{
            height:33px;
            width:123px;
            border:1px groove;
            border-radius:5px;
            color:black;
            background-color:rgba(40, 38, 235, 0.76);
        }
        .ln1 a span{
            color:white;
        }
        .align-left{
            float:left;
        }
        #btn_new_page{
            display:none;
        }
        .show{
            display:block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
        <uc1:menu runat="server" ID="menu" />
    </div>
        <%
                            datalayer dl=new datalayer();
                            var q = dl.Retrieve_Website(Session[Constants.Session.ID].ToString());
                            if (q.Any())
                            {
                                foreach (var a in q)
                                {
                                    rpt_website_name.DataSource = q;
                                    rpt_website_name.DataBind();
                                }
                            }
                             %>

        <section id="feature">
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <br />
            <fieldset class="website-panel">
               <legend>Website editing</legend>
                <asp:Panel runat="server" ID="pnl_website_name">
                    <asp:TextBox CssClass="align-left" ID="txt_website_name" runat="server"></asp:TextBox>
                </asp:Panel>
           </fieldset>
            <fieldset class="align-right">
                <legend>Create and manage website</legend>
                <section >
                <asp:LinkButton CssClass="" Text="New Website" OnClick="btn_create_website_Click" runat="server" ID="btn_create_website">
            </asp:LinkButton>
            </section>
            </fieldset><br /><br /><br /><br /><br />
            <fieldset class="align-right2">
                <legend>Your websites</legend>
                <asp:Repeater ID="rpt_website_name" OnItemCommand="rpt_website_name_ItemCommand1" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_website_name" CommandName="website" OnCommand="btn_website_name_Command" CommandArgument="Hello" Text='<%#Eval("WebsiteName") %>' runat="server"></asp:LinkButton><br />
                    </ItemTemplate>
                </asp:Repeater>
            </fieldset>
           
            
            
            <asp:Panel Visible="false" ID="pnl_create_pages" runat="server">
            <asp:TextBox ID="txtpagename" CssClass="align-left" runat="server"></asp:TextBox>
            <asp:LinkButton CssClass="a_demo_four align-left" OnClick="btn_create_page_Click" runat="server" ID="btn_create_page">
                        Create Page
                        <%--<img src="../images/create-website/create-new-page.png" height="30" width="37" />
                        <span>New Project</span>--%>
                    </asp:LinkButton>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                        <%--<a class="a_demo_four" href="#">
                            Click me!
                        </a>--%>
                   <%-- <p class="ln1">--%>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                        <%--</p>--%>
                    <%--<button id="btn_create_page" value="Create a new page">
               <img src="../images/create-website/create-new-page.png" height="30" width="37" />
               <span>New Project</span>
           </button>--%>
                    <%--OnClientClick="document.getElementById('created_page_view').src='main.aspx';return false;"--%>
                       <asp:LinkButton runat="server" ID="btn_new_page"  OnClick="btn_new_page_Click" CssClass="a_demo_four align-left">
                           Show Page
                       </asp:LinkButton>

           <%-- <button id="btn_new_page">
                <img src="../images/create-website/add-new-page.png" height="30" width="30" />
                <span>Add new page</span>
            </button>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
            </asp:Panel>
            <br />
          <div style="display:none">
              <iframe id="created_page_view" style="min-height:100px;max-height:1000000px; width:100%;"></iframe>
          </div>

            </div>
            </section>



        



        <uc1:bottom runat="server" ID="bottom" />
       
         <footer id="footer" style="border-top:thick 5px rgba(248, 78, 203, 0.72);" class="midnight-blue">
             <uc1:footer runat="server" ID="footer1" />
    </footer>
        <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.prettyPhoto.js"></script>
    <script src="../js/jquery.isotope.min.js"></script>
    <script src="../js/main.js"></script>
    <script src="../js/wow.min.js"></script>
        
    </form>
</body>
</html>
