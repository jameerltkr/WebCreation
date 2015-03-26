<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="web_design_create" %>

<%@ Register Src="~/web-design/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/bottom.ascx" TagPrefix="uc1" TagName="bottom" %>
<%@ Register Src="~/user_control/CreateWebsite.ascx" TagPrefix="uc1" TagName="CreateWebsite" %>





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
        

        <section id="feature">
        <div class="container wow fadeInDown" style="width:1300px;" data-wow-duration="1000ms" data-wow-delay="600ms">
            <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <%
                                
                                if (Session[Constants.Session.ID] != null)
                                {
                                    datalayer dl = new datalayer();
                                    var q = dl.Retrieve_Website(Session[Constants.Session.ID].ToString());
                                    if (q.Any())
                                    {
                                        HtmlTableRow row = null;
                                        HtmlTableCell cell = null;
                                        HtmlTableCell cell2 = null;
                                        HtmlAnchor a1 = null;
                                        HtmlAnchor a2 = null;
                                      
                                        foreach (var a in q)
                                        {

                                          //  for (int i = 0; i < 11; i++)
                                            {

                                                row = new HtmlTableRow();
                                                cell = new HtmlTableCell();
                                                cell2 = new HtmlTableCell();
                                                a2 = new HtmlAnchor();
                                                a1 = new HtmlAnchor();
                                                a1.InnerText = "Edit";
                                                a1.HRef = "#";
                                                a2.HRef = "#";
                                                a2.InnerText = "Delete";

                                                tbl_web_name.Controls.Add(row);
                                                row.Controls.Add(cell);
                                                row.Controls.Add(cell2);
                                                cell.ID = "data";
                                                cell.InnerText = a.WebsiteName;
                                                cell2.ID = "action";
                                                cell2.Controls.Add(a1);
                                                cell2.Controls.Add(a2);
                                                
                                            }
                                            
                                            //lbl_website_name.Text = a.WebsiteName;
                                            //rpt_website_name.DataSource = q;
                                            //rpt_website_name.DataBind();
                                        }
                                    }
                                }
                             %>
            <div runat="server" id="error_div"></div>
                            <fieldset class="left-toolbox">
                    <legend>Toolbox</legend>
                                <ul>
                                    <li><label>Anchor (a)</label></li>
                                    <li><label>Button</label></li>
                                    <li><label>Checkbox</label></li>
                                    <li><label>Division (div)</label></li>
                                    <li><label>Dropdown</label></li>
                                    <li><label>File Upload</label></li>
                                    <li><label>Image</label></li>
                                    <li><label>Textbox</label></li>
                                    <li><label>Paragraph (p)</label></li>
                                    <li><label>Radio Button</label></li>
                                    <li><label>Table</label></li>
                                    
                                </ul>

                </fieldset>
            <fieldset class="website-panel">
               <legend>Website editing</legend>
                
                <asp:Panel CssClass="create-web" Visible="false" runat="server" ID="pnl_website_name" >
                    
                            <asp:Wizard OnFinishButtonClick="Wizard_Create_Web_FinishButtonClick" OnSideBarButtonClick="Wizard_Create_Web_SideBarButtonClick" OnNextButtonClick="Wizard_Create_Web_NextButtonClick" OnActiveStepChanged="Wizard_Create_Web_ActiveStepChanged" ID="Wizard_Create_Web" runat="server" Height="407px" Width="572px" BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
                        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Left" />
                        <HeaderTemplate>
                            
                        </HeaderTemplate>
                        
                        
                        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                        <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
                        
                      
                            
                        <StepStyle BorderWidth="0px" ForeColor="#5D7B9D" />
                        
                            
                        <WizardSteps>
                            <asp:WizardStep ID="WizardStep1" runat="server" Title="Application Name" >
                                <table>
                                    <tr>
                                        <td style="text-align:left">
                                            <span>Website name:</span>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="text-align:left">
                                            <asp:TextBox ID="txt_website_name" runat="server" CssClass="align-left"></asp:TextBox><br />
                                        </td>
                                    </tr>
                                   <%-- <tr>
                                        <td style="text-align:left">
                                            <asp:Button ID="btn_save_website" runat="server" OnClick="btn_save_website_Click" Text="Create" />
                                        </td>
                                    </tr>--%>
                                </table>
                            
                            </asp:WizardStep>
                            <asp:WizardStep ID="WizardStep2" runat="server" Title="Choose templates">

                            </asp:WizardStep>
                            <asp:WizardStep runat="server" Title="Create database">
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>
                    <br />
                </asp:Panel>
                <asp:Panel runat="server" ID="pnl_edit_web">
                    <%--<uc1:CreateWebsite runat="server" id="CreateWebsite" />--%>

                    <asp:Panel Visible="false" runat="server" ID="pnl_web">
    <%
                                
                                if (Session[Constants.Session.ID] != null)
                                {
                                    datalayer dl = new datalayer();
                                    Guid userid;
                                    System.Web.Security.MembershipUser mu;
                                    mu = System.Web.Security.Membership.GetUser();
                                    userid = (Guid)mu.ProviderUserKey;
                                    if(Session[Constants.Session.USERNAME]!=null && Session[Constants.WEBSITE_NAME]!=null)
                                    mu = System.Web.Security.Membership.GetUser(Session[Constants.Session.USERNAME].ToString());
                                    var q = dl.Retrieve_Web_Pages(userid,Session[Constants.WEBSITE_NAME].ToString());
                                    if (q.Any())
                                    {
                                        foreach (var a in q)
                                        {
                                            Repeater1.DataSource = q;
                                            Repeater1.DataBind();
                                        }
                                    }
                                    else
                                    {
                                        lbl_pages_name.Text = "There are no pages... Please create one.";
                                        div_create_page.Visible = true;
                                    }
                                }
                               
                             %>

                     <script>
                         $(function () {// write your code in document ready
                             $('.btn-website-name').click(function () {
                                 alert($(this).html());
                             });
                         });
                </script>
                <style>
                    .btn-website-name{
                        cursor:pointer;
                    }
                    .btn-website-name:hover{
                        text-decoration:underline;
                    }
                </style>
    <asp:Label runat="server" ID="lbl_pages_name"></asp:Label>
    <div runat="server" id="div_create_page" visible="false">
        <span>Page name:</span>
        <asp:TextBox runat="server" ID="txt_page_name"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Create page" OnClick="btn_create_page_Click"/>
    </div>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbl_website_name" class="btn-website-name" Text='<%#Eval("WebsiteName") %>'></asp:Label>
                        <%--<asp:LinkButton ID="btn_website_name" class="bt-website-name" CommandName="website" OnCommand="btn_website_name_Command" CommandArgument="Hello" Text='<%#Eval("WebsiteName") %>' runat="server"></asp:LinkButton>--%><br />
                    </ItemTemplate>
                </asp:Repeater>
</asp:Panel>
                </asp:Panel>
           </fieldset>
            <fieldset class="align-right">
                <legend>Create website</legend>
                <section >
                    <%--<asp:UpdatePanel runat="server">--%>                        <%--<ContentTemplate>--%>
                            <asp:LinkButton CssClass="" Text="New Website" OnClick="btn_create_website_Click" runat="server" ID="btn_create_website">
                            </asp:LinkButton>
                    <%--</ContentTemplate>--%>                    <%--</asp:UpdatePanel>--%>
            </section>
            </fieldset><br /><br /><br /><br /><br />
            <fieldset class="align-right2">
                <legend>Your websites</legend>
                <div class="wb">
                <script>
                    $(function () {// write your code in document ready
                        $('.btn-website-name').click(function () {
                            alert($(this).html());
                        });
                    });
                </script>
                <style>
                    .btn-website-name{
                        cursor:pointer;
                    }
                    .btn-website-name:hover{
                        text-decoration:underline;
                    }
                    #action{
                        width:40px;
                    }
                    #data{
                        width:110px;
                    }
                </style>
                <table>
                    <tr>
                        <th>Website name</th>
                        <th>Action</th>
                    </tr>
                </table>
                <table id="tbl_web_name" runat="server">
                    <%--<tr>
                        <th>Website Name</th>
                        <th>Action</th>
                    </tr>
                    <tr>
                        <td>--%>
                            <%--<asp:Repeater ID="rpt_website_name" OnItemCommand="rpt_website_name_ItemCommand1" runat="server">--%>
                    <%--<ItemTemplate>--%>
                        <%--<asp:Label runat="server" ID="lbl_website_name" class="btn-website-name" Text='<%#Eval("WebsiteName") %>'></asp:Label>--%>
                    <%--</ItemTemplate>--%>
                                <%--</asp:Repeater>--%>
                        <%--</td>
                        <td>
                            <asp:LinkButton ID="lb_edit" runat="server" Text="Edit"></asp:LinkButton>
                            <asp:LinkButton runat="server" Text="Delete" ID="lb_delete"></asp:LinkButton>
                        </td>
                    </tr>--%>
                </table>
                <%--<asp:Repeater ID="rpt_website_name" OnItemCommand="rpt_website_name_ItemCommand1" runat="server">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbl_website_name" class="btn-website-name" Text='<%#Eval("WebsiteName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:Repeater>--%>
                    </div>
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
            </ContentTemplate>
                    </asp:UpdatePanel>
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
