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
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />

    <link href="../css/responsive.css" rel="stylesheet" />
    <link href="../images/icon.png" rel="shortcut icon" />
    <script src="js/controls.js"></script>
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
        .pages_div {
            height: 200px;
            margin-left: 17px;
            width: 824px;
            border-radius: 12px;
            background-color: #E7FEFF;
        }

        .ln1 {
            height: 33px;
            width: 123px;
            border: 1px groove;
            border-radius: 5px;
            color: black;
            background-color: rgba(40, 38, 235, 0.76);
        }

            .ln1 a span {
                color: white;
            }

        .align-left {
            float: left;
        }

        #btn_new_page {
            display: none;
        }

        .show {
            display: block;
        }

        #mask {
            position: absolute; /* important */
            top: 0px; /* start from top */
            left: 0px; /* start from left */
            height: 100%; /* cover the whole page */
            width: 100%; /* cover the whole page */
            display: none; /* don't show it '*/
            /* styling bellow */
            background-color: black;
        }

        .modal_window {
            position: absolute; /* important so we can position it on center later */
            display: none; /* don't show it */
            height: 80px;
            padding-top: 30px;
            width: 500px;
            top: 100px;
            background: linear-gradient(rgba(84, 245, 30, 0.33),rgba(242, 54, 42, 0.48));
            left: 35%;
            /* styling bellow */
            color: white;
        }

        /* style a specific modal window  */
        #modal_window {
            padding: 50px;
            border: 1px solid gray;
            background: #246493;
            color: black;
        }
    </style>
    <script>
        function Hello() {
            //alert("JK");
        }
    </script>

    <script src="js/delete.js"></script>
    <script src="../js/modal.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
</head>
<body id="bd1">
    <form id="form1" runat="server">
        <asp:ScriptManager EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <div>
            <uc1:menu runat="server" ID="menu" />
        </div>


        <section id="feature">
            <div class="container wow fadeInDown" style="width: 1300px;" data-wow-duration="1000ms" data-wow-delay="600ms">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <%
                                
                            if (Session[Constants.Session.ID] != null)
                            {
                                Guid userid;
                                System.Web.Security.MembershipUser mu;
                                mu = System.Web.Security.Membership.GetUser();
                                userid = (Guid)mu.ProviderUserKey;
                                datalayer dl = new datalayer();
                                var q = dl.Retrieve_Website(Session[Constants.Session.USERNAME].ToString());
                                if (q.Any())
                                {


                                    HtmlTableRow row = null;
                                    HtmlTableCell cell = null;
                                    HtmlTableCell cell2 = null;
                                    HtmlTableCell cell3 = null;

                                    LinkButton lb_web_name = null;
                                    ImageButton a1 = null;
                                    ImageButton a2 = null;

                                    foreach (var a in q)
                                    {

                                        //  for (int i = 0; i < 11; i++)
                                        {

                                            row = new HtmlTableRow();
                                            cell = new HtmlTableCell();
                                            cell2 = new HtmlTableCell();
                                            cell3 = new HtmlTableCell();
                                            a2 = new ImageButton();
                                            a1 = new ImageButton();
                                            lb_web_name = new LinkButton();
                                            a1.Height = 15;
                                            a2.Height = 15;
                                            a1.Width = 16;
                                            a2.Width = 16;

                                            //string str = @"<asp:ImageButton ID=""img_delete_website"" OnClick=""clickme""  ImageUrl=""~/img/delete.png"" runat=""server"" oncommand=""clickme"" commandname=""btn"" />";
                                            //Control c = ParseControl(str);
                                            string username = "";
                                            TextBox txt_rename_website = new TextBox();
                                            if (Session[Constants.Session.USERNAME] != null)
                                            {
                                                username = Session[Constants.Session.USERNAME].ToString();
                                            }

                                            a1.ToolTip = "Edit your application name.";
                                            a2.ToolTip = "Delete your application.";
                                            a1.ImageUrl = "~/img/edit.png";
                                            a2.ImageUrl = "~/img/delete.png";
                                            //a2.Click = "a2_click";
                                            lb_web_name.ID = "lb_web";
                                            lb_web_name.Text = a.WebsiteName;
                                            tbl_web_name.Controls.Add(row);
                                            row.Controls.Add(cell);
                                            row.Controls.Add(cell2);
                                            row.Controls.Add(cell3);
                                            a1.OnClientClick = "edit_data('" + userid + "','" + a.WebsiteName + "')";
                                            a2.ID = "img_delete";

                                            lb_web_name.OnClientClick = "show('" + userid + "' ,'" + username + "','" + a.WebsiteName + "'); return false;";

                                            a2.OnClientClick = "if(confirm('Are you sure you want to delete website?')) delete_data('" + userid + "','" + a.WebsiteName + "','" + username + "')";
                                            //a2.OnClientClick = "Hello(); return false;";
                                            cell.ID = "data";
                                            //cell.InnerText = a.WebsiteName;
                                            cell.Controls.Add(lb_web_name);
                                            cell2.ID = "action";
                                            cell2.Controls.Add(a1);
                                            cell3.Controls.Add(a2);

                                            //  ((ImageButton)Page.FindControl("img_delete_website")).Command += new CommandEventHandler(clickme);
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


                            <link href="../admin/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
                            <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
                            <!-- Ionicons -->
                            <link href="http://code.ionicframework.com/ionicons/2.0.0/css/ionicons.min.css" rel="stylesheet" type="text/css" />
                            <!-- fullCalendar 2.2.5-->
                            <link href="../admin/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
                            <link href="../admin/plugins/fullcalendar/fullcalendar.print.css" rel="stylesheet" type="text/css" media='print' />
                            <!-- Theme style -->
                            <link href="../admin/dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
                            <!-- AdminLTE Skins. Choose a skin from the css/skins 
         folder instead of downloading all of them to reduce the load. -->
                            <link href="../admin/dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />

                           


                            <section class="content">
                                <div class="row">
                                    <div class="col-md">
                                        <div class="box box-solid">
                                            <div class="box-header with-border">
                                                <h4 class="box-title">Draggable Events</h4>
                                            </div>
                                            <div class="box-body">
                                                <!-- the events -->
                                                <div id='external-events'>
                                                    <div class='external-event bg-green '>Lunch</div>
                                                    <div class='external-event bg-yellow'>Go home</div>
                                                    <div class='external-event bg-aqua'>Do homework</div>
                                                    <div class='external-event bg-light-blue'>Work on UI design</div>
                                                    <div class='external-event bg-red'>Sleep tight</div>
                                                    <div class="checkbox">
                                                        <label for='drop-remove'>
                                                            <input type='checkbox' id='drop-remove' />
                                                            remove after drop
                     
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- /.box-body -->
                                        </div>
                                        <!-- /. box -->
                                    </div>
                                </div>
                            </section>


                            <div id="toolbox">
                                <ul>
                                    <li>
                                        <label onclick="add_anchor()" id="anchor">Anchor (a)</label></li>
                                    <li>
                                        <label id="button">Button</label></li>
                                    <li>
                                        <label>Checkbox</label></li>
                                    <li>
                                        <label>Division (div)</label></li>
                                    <li>
                                        <label>Dropdown</label></li>
                                    <li>
                                        <label>File Upload</label></li>
                                    <li>
                                        <label>Image</label></li>
                                    <li>
                                        <label>Textbox</label></li>
                                    <li>
                                        <label>Paragraph (p)</label></li>
                                    <li>
                                        <label>Radio Button</label></li>
                                    <li>
                                        <label>Table</label></li>

                                </ul>
                            </div>

                        </fieldset>
                        <fieldset class="website-panel">
                            <div id="calendar"></div>
                            <legend>Website editing</legend>
                            <asp:Panel CssClass="create-web" Visible="false" runat="server" ID="pnl_website_name">

                                <asp:Wizard OnCancelButtonClick="Wizard_Create_Web_CancelButtonClick" OnFinishButtonClick="Wizard_Create_Web_FinishButtonClick" OnSideBarButtonClick="Wizard_Create_Web_SideBarButtonClick" OnNextButtonClick="Wizard_Create_Web_NextButtonClick" OnActiveStepChanged="Wizard_Create_Web_ActiveStepChanged" ID="Wizard_Create_Web" runat="server" Height="407px" Width="572px" BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
                                    <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderTemplate>
                                    </HeaderTemplate>


                                    <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                                    <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                                    <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />



                                    <StartNavigationTemplate>
                                        <asp:Button ID="btn_cancel" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Cancel" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" runat="server" Text="Cancel" />
                                        <asp:Button ID="StartNextButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="MoveNext" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" Text="Next" />
                                    </StartNavigationTemplate>
                                    <StepNavigationTemplate>
                                        <asp:Button ID="StepPreviousButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="MovePrevious" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" Text="Previous" />
                                        <asp:Button ID="StepNextButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="MoveNext" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" Text="Next" />
                                    </StepNavigationTemplate>



                                    <StepStyle BorderWidth="0px" ForeColor="#5D7B9D" />


                                    <WizardSteps>
                                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Application Name">
                                            <table>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <span>Website name:</span>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="txt_website_name" runat="server" CssClass="align-left"></asp:TextBox><br />
                                                    </td>
                                                </tr>
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
                            <div id="website_div">
                            </div>
                            <div id="pages">
                                <style>
                                    #website_name {
                                        font-size: 34px;
                                        padding-right: 78%;
                                    }
                                </style>
                                <span id="website_name"></span>
                                <div class="pages_div" style="display: none;">
                                </div>

                                <table id="tbl_pages" style="display: none;">
                                    <thead>
                                        <tr>
                                            <th>Pages</th>
                                        </tr>
                                    </thead>
                                </table>

                                <iframe style="display: none;" id="iframe_edit_page" height="450" width="855"></iframe>

                                <div runat="server" id="div_create_page">
                                    <!--<span>Page name:</span>-->
                                    <asp:TextBox Style="display: none;" runat="server" ID="txt_page_name"></asp:TextBox>
                                    <asp:HiddenField ID="hf_page_name" runat="server" />
                                    <br />
                                    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="Create page" OnClick="Button1_Click" />
                                </div>
                                <%--<p><a class='activate_modal' name='first_window' href='#'>First modal window.</a></p>--%>
                                <div id='mask' class='close_modal' onclick="close_modal()"></div>
                                <div id='first_window' class='modal_window'></div>
                            </div>
                            <asp:Panel runat="server" ID="pnl_edit_web" Visible="false">
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
                                            if (Session[Constants.Session.USERNAME] != null && Session[Constants.WEBSITE_NAME] != null)
                                                mu = System.Web.Security.Membership.GetUser(Session[Constants.Session.USERNAME].ToString());
                                            var q = dl.Retrieve_Web_Pages(userid, Session[Constants.WEBSITE_NAME].ToString());
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
                                        .btn-website-name {
                                            cursor: pointer;
                                        }

                                            .btn-website-name:hover {
                                                text-decoration: underline;
                                            }
                                    </style>
                                    <asp:Label runat="server" ID="lbl_pages_name"></asp:Label>


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
                            <section>
                                <%--<asp:UpdatePanel runat="server">--%>                        <%--<ContentTemplate>--%>
                                <asp:LinkButton CssClass="" Text="New Website" OnClick="btn_create_website_Click" runat="server" ID="btn_create_website">
                                </asp:LinkButton>
                                <%--</ContentTemplate>--%>                    <%--</asp:UpdatePanel>--%>
                            </section>
                        </fieldset>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <fieldset class="align-right2">
                            <legend>Your websites</legend>
                            <div class="">
                                <script>
                                    $(function () {// write your code in document ready
                                        $('.btn-website-name').click(function () {
                                            alert($(this).html());
                                        });
                                    });
                                </script>
                                <style>
                                    .btn-website-name {
                                        cursor: pointer;
                                    }

                                        .btn-website-name:hover {
                                            text-decoration: underline;
                                        }

                                    #action {
                                        width: 40px;
                                    }

                                    #data {
                                        width: 110px;
                                    }
                                </style>
                                <table>
                                    <tr>
                                        <th style="width: 99px">Website name</th>
                                        <th>Action</th>
                                    </tr>
                                </table>
                                <table class="wb" id="tbl_web_name" runat="server">
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
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                        <fieldset class="pages-section">
                            <legend>Pages</legend>

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
                                    <asp:LinkButton runat="server" ID="btn_new_page" OnClick="btn_new_page_Click" CssClass="a_demo_four align-left">
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
                        <div style="display: none">
                            <iframe id="created_page_view" style="min-height: 100px; max-height: 1000000px; width: 100%;"></iframe>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>


        
                    <div class="content-wrapper">
                        <!-- Content Header (Page header) -->
                        <section class="content-header">
                            <!-- Main row -->
                            <div class="row">
                                <!-- Main col -->
                                <section class="col-lg-12 ">
                                    <div class="box box-success">
                                    </div>
                                </section>
                            </div>
                            <script type="text/javascript">
                                $('.confirmation').on('click', function () {
                                    return confirm('Are you sure?');
                                });
                            </script>
                            <div class="row">
                                <div runat="server" class=" display-none" id="create_website">
                                    <section class="col-lg-12">
                                        <div class="box box-primary">
                                            <div class="box-header">
                                                <i class="fa fa-edit"></i>
                                                <h3 class="box-title">Create Website</h3>
                                                <div class="box-body">
                                                    <div class="col-lg-4">
                                                        Website Name:<asp:TextBox runat="server" placeholder="Choose website name" class="form-control" ID="txt_websitename"></asp:TextBox><br />
                                                        <asp:Button ID="Button2" runat="server" Text="Create Website" OnClick="btn_create_website_Click" class="btn btn-block bg-maroon btn-flat" />
                                                        <asp:Label runat="server" ID="lbl_message"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <i class="fa fa-list"></i>
                                                        <h3 class="box-title">List of websites</h3>
                                                        <div class="box-body">
                                                            <table id="tbl_created_websites" runat="server" class="table table-bordered table-hover dataTable">
                                                                <thead>
                                                                    <tr>
                                                                        <th width="290">Website Name</th>
                                                                        <th>Edit Name</th>
                                                                        <th>Delete website</th>
                                                                    </tr>
                                                                </thead>
                                                            </table>
                                                            <!-- DATA TABLES -->
                                                            <link href="../admin/plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
                                                            <!-- DATA TABES SCRIPT -->
                                                            <script src="../admin/plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
                                                            <script src="../admin/plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>
                                                            <script type="text/javascript">
                                                                $(function () {
                                                                    //  $("#tbl_created_websites").dataTable();
                                                                    $('#tbl_created_websites').dataTable({
                                                                        "bPaginate": true,
                                                                        "bLengthChange": false,
                                                                        "bFilter": false,
                                                                        "bSort": true,
                                                                        "bInfo": true,
                                                                        "bAutoWidth": false
                                                                    });
                                                                });
                                                            </script>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>

                                </div>
                            </section>
                        </div>
        
    


        <uc1:bottom runat="server" ID="bottom" />

        <footer id="footer" style="border-top: thick 5px rgba(248, 78, 203, 0.72);" class="midnight-blue">
            <uc1:footer runat="server" ID="footer1" />
        </footer>
        <script src="../js/jquery.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script src="../js/jquery.prettyPhoto.js"></script>
        <script src="../js/jquery.isotope.min.js"></script>
        <script src="../js/main.js"></script>
        <script src="../js/wow.min.js"></script>

    </form>
    
                             <script src="../admin/plugins/jQuery/jQuery-2.1.3.min.js"></script>
                            <!-- Bootstrap 3.3.2 JS -->
                            <script src="../admin/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
                            <!-- jQuery UI 1.11.1 -->
                            <script src="https://code.jquery.com/ui/1.11.1/jquery-ui.min.js" type="text/javascript"></script>
                            <!-- Slimscroll -->
                            <script src="../admin/plugins/slimScroll/jquery.slimscroll.min.js" type="text/javascript"></script>
                            <!-- FastClick -->
                            <script src='../admin/plugins/fastclick/fastclick.min.js'></script>
                            <!-- AdminLTE App -->
                            <script src="../admin/dist/js/app.min.js" type="text/javascript"></script>
                            <!-- AdminLTE for demo purposes -->
                            <script src="../admin/dist/js/demo.js" type="text/javascript"></script>
                            <!-- fullCalendar 2.2.5 -->
                            <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.7.0/moment.min.js" type="text/javascript"></script>
                            <script src="../admin/plugins/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
                            <!-- Page specific script -->
                            
                            <script type="text/javascript">
                                $(function () {

                                    /* initialize the external events
                                     -----------------------------------------------------------------*/
                                    function ini_events(ele) {
                                        ele.each(function () {

                                            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
                                            // it doesn't need to have a start or end
                                            var eventObject = {
                                                title: $.trim($(this).text()) // use the element's text as the event title
                                            };

                                            // store the Event Object in the DOM element so we can get to it later
                                            $(this).data('eventObject', eventObject);

                                            // make the event draggable using jQuery UI
                                            $(this).draggable({
                                                zIndex: 1070,
                                                revert: true, // will cause the event to go back to its
                                                revertDuration: 0  //  original position after the drag
                                            });

                                        });
                                    }
                                    ini_events($('#external-events div.external-event'));

                                    /* initialize the calendar
                                     -----------------------------------------------------------------*/
                                    //Date for the calendar events (dummy data)
                                    var date = new Date();
                                    var d = date.getDate(),
                                            m = date.getMonth(),
                                            y = date.getFullYear();
                                    $('#calendar').fullCalendar({
                                        header: {
                                            left: 'prev,next today',
                                            center: 'title',
                                            right: 'month,agendaWeek,agendaDay'
                                        },
                                        buttonText: {
                                            today: 'today',
                                            month: 'month',
                                            week: 'week',
                                            day: 'day'
                                        },
                                        //Random default events
                                        events: [
                                          {
                                              title: 'All Day Event',
                                              start: new Date(y, m, 1),
                                              backgroundColor: "#f56954", //red
                                              borderColor: "#f56954" //red
                                          },
                                          {
                                              title: 'Long Event',
                                              start: new Date(y, m, d - 5),
                                              end: new Date(y, m, d - 2),
                                              backgroundColor: "#f39c12", //yellow
                                              borderColor: "#f39c12" //yellow
                                          },
                                          {
                                              title: 'Meeting',
                                              start: new Date(y, m, d, 10, 30),
                                              allDay: false,
                                              backgroundColor: "#0073b7", //Blue
                                              borderColor: "#0073b7" //Blue
                                          },
                                          {
                                              title: 'Lunch',
                                              start: new Date(y, m, d, 12, 0),
                                              end: new Date(y, m, d, 14, 0),
                                              allDay: false,
                                              backgroundColor: "#00c0ef", //Info (aqua)
                                              borderColor: "#00c0ef" //Info (aqua)
                                          },
                                          {
                                              title: 'Birthday Party',
                                              start: new Date(y, m, d + 1, 19, 0),
                                              end: new Date(y, m, d + 1, 22, 30),
                                              allDay: false,
                                              backgroundColor: "#00a65a", //Success (green)
                                              borderColor: "#00a65a" //Success (green)
                                          },
                                          {
                                              title: 'Click for Google',
                                              start: new Date(y, m, 28),
                                              end: new Date(y, m, 29),
                                              url: 'http://google.com/',
                                              backgroundColor: "#3c8dbc", //Primary (light-blue)
                                              borderColor: "#3c8dbc" //Primary (light-blue)
                                          }
                                        ],
                                        editable: true,
                                        droppable: true, // this allows things to be dropped onto the calendar !!!
                                        drop: function (date, allDay) { // this function is called when something is dropped

                                            // retrieve the dropped element's stored Event Object
                                            var originalEventObject = $(this).data('eventObject');

                                            // we need to copy it, so that multiple events don't have a reference to the same object
                                            var copiedEventObject = $.extend({}, originalEventObject);

                                            // assign it the date that was reported
                                            copiedEventObject.start = date;
                                            copiedEventObject.allDay = allDay;
                                            copiedEventObject.backgroundColor = $(this).css("background-color");
                                            copiedEventObject.borderColor = $(this).css("border-color");

                                            // render the event on the calendar
                                            // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
                                            $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

                                            // is the "remove after drop" checkbox checked?
                                            if ($('#drop-remove').is(':checked')) {
                                                // if so, remove the element from the "Draggable Events" list
                                                $(this).remove();
                                            }

                                        }
                                    });

                                    /* ADDING EVENTS */
                                    var currColor = "#3c8dbc"; //Red by default
                                    //Color chooser button
                                    var colorChooser = $("#color-chooser-btn");
                                    $("#color-chooser > li > a").click(function (e) {
                                        e.preventDefault();
                                        //Save color
                                        currColor = $(this).css("color");
                                        //Add color effect to button
                                        $('#add-new-event').css({ "background-color": currColor, "border-color": currColor });
                                    });
                                    $("#add-new-event").click(function (e) {
                                        e.preventDefault();
                                        //Get value and make sure it is not null
                                        var val = $("#new-event").val();
                                        if (val.length == 0) {
                                            return;
                                        }

                                        //Create events
                                        var event = $("<div />");
                                        event.css({ "background-color": currColor, "border-color": currColor, "color": "#fff" }).addClass("external-event");
                                        event.html(val);
                                        $('#external-events').prepend(event);

                                        //Add draggable funtionality
                                        ini_events(event);

                                        //Remove event from text input
                                        $("#new-event").val("");
                                    });
                                });
    </script>

</body>
</html>
