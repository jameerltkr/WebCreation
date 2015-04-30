<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateWebsite.aspx.cs" Inherits="web_design_CreateWebsite" %>

<%@ Register Src="~/admin/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/admin/side-bar.ascx" TagPrefix="uc1" TagName="sidebar" %>
<%@ Register Src="~/admin/footer.ascx" TagPrefix="uc1" TagName="footer" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Creation Inc.</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <link href="../admin/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://code.ionicframework.com/ionicons/2.0.0/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="../admin/dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <link href="../admin/dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />
    <link href="../admin/plugins/iCheck/flat/blue.css" rel="stylesheet" type="text/css" />
    <!-- Morris chart -->
    <link href="../admin/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <!-- jvectormap -->
    <link href="../admin/plugins/jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" type="text/css" />
    <!-- Date Picker -->
    <link href="../admin/plugins/datepicker/datepicker3.css" rel="stylesheet" type="text/css" />
    <!-- Daterange picker -->
    <link href="../admin/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <!-- bootstrap wysihtml5 - text editor -->
    <link href="../admin/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />
    <link href="../admin/dist/css/style.css" rel="stylesheet" />
    <script src="../admin/dist/js/script.js"></script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <script src="../js/jquery-1.10.2.js"></script>
    <script src="js/controls.js"></script>
    <script src="js/delete.js"></script>
    <style>
        .create-web-header {
            margin-top: 11px;
        }

        .display-none {
            display: none;
        }

        .display-block {
            display: block;
        }
    </style>
</head>
<body class="skin-blue" onload="get_websites_name('web_sa_admin')">
    <form id="form1" runat="server">
        <div class="wrapper">
            <%--<uc1:header runat="server" ID="header" />--%>
            <!-- Header contents goes here  -->
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <!-- side bar ends here-->
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <header class="main-header">
                        <!-- Logo -->
                        <a href="Home.aspx" class="logo"><b>Web</b>Creation</a>
                        <!-- Header Navbar: style can be found in header.less -->
                        <nav class="navbar navbar-static-top" role="navigation" style="background-color: #2C3032">
                            <!-- Sidebar toggle button-->
                            <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
                                <span class="sr-only">Toggle navigation</span>
                            </a>
                            <nav class="create-web-header">

                                <asp:LinkButton runat="server" ID="lb_create_project" OnClick="lb_create_project_Click" Text="New Project">
                            <i class="fa fa-plus btn btn-flat btn-success">  New Project</i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lb_create_database" OnClick="lb_create_database_Click">
                            <i class="fa fa-table btn btn-flat btn-success">  Create Database</i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btn_open_project" OnClick="btn_open_project_Click">
                            <i class="fa fa-folder-open-o btn btn-flat btn-success">  Open</i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btn_save_project">
                            <i class="fa fa-save btn btn-flat btn-success">  Save</i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btn_project_settings">
                            <i class="fa fa-gear btn btn-flat btn-success">  Project Settings</i>
                                </asp:LinkButton>
                                <nav style="float: right; margin-right: 30px;">
                                    <asp:LinkButton runat="server" ID="lb_preview">
                                <i class="fa fa-external-link-square btn btn-flat btn-success"> Preview</i>
                                    </asp:LinkButton>
                                </nav>
                            </nav>

                        </nav>
                    </header>


                    <!--   end of header contents-->

                    <!-- side bar starts here-->
                    <%--<uc1:sidebar runat="server" ID="sidebar" />--%>
                    <aside class="main-sidebar">
                        <!-- sidebar: style can be found in sidebar.less -->
                        <section class="sidebar">
                        </section>
                        <!-- /.sidebar -->
                    </aside>



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
                                <!--   show created website on page-->
                                <%
                                    datalayer c = new datalayer();
                                    var q = c.Retrieve_Website(Session[Constants.Session.USERNAME].ToString());
                                    if (q.Any())
                                    {
                                        HtmlTableRow row = null;
                                        HtmlTableCell cell_website_name = null;
                                        HtmlTableCell cell_edit_website = null;
                                        HtmlTableCell cell_delete_website = null;
                                        foreach (var a in q)
                                        {
                                            row = new HtmlTableRow();
                                            cell_delete_website = new HtmlTableCell();
                                            cell_edit_website = new HtmlTableCell();
                                            cell_website_name = new HtmlTableCell();
                                            cell_website_name.InnerHtml = a.WebsiteName;
                                            cell_edit_website.InnerHtml = "<a class='btn confirmation' onclick='edit(" + a.WebsiteId + ")' title='Edit your application name'><i class='fa fa-edit'></i></a>";
                                            // cell_edit_website += "<i class='fa fa-edit'></i></asp:LinkButton>";
                                            var msg = "Are you sure you want to delete website?";
                                            cell_delete_website.InnerHtml = "<a class='btn confirmation' onclick='javascript:if(confirm(" + msg + ")) delete(" + a.WebsiteId + ")' title='Delete your application'><i class='fa fa-times'></i></a>";
                                            row.Controls.Add(cell_website_name);
                                            row.Controls.Add(cell_edit_website);
                                            row.Controls.Add(cell_delete_website);
                                            //  tbl_created_websites.Controls.Add(row);
                                        }
                                    }
                                    
                                %>
                                <a onclick="javascript:if(confirm('heelo'))" class="btn">click</a>
                                <!-- end of showing created websites on page-->
                                <div runat="server" class=" display-none" id="create_website">
                                    <section class="col-lg-12">
                                        <div class="box box-primary">
                                            <div class="box-header">
                                                <i class="fa fa-edit"></i>
                                                <h3 class="box-title">Create Website</h3>
                                                <div class="box-body">
                                                    <div class="col-lg-4">
                                                        Website Name:<asp:TextBox runat="server" placeholder="Choose website name" class="form-control" ID="txt_websitename"></asp:TextBox><br />
                                                        <asp:Button ID="btn_create_website" runat="server" OnClientClick="get_websites_name('web_sa_admin'); return false" Text="Create Website" OnClick="btn_create_website_Click" class="btn btn-block bg-maroon btn-flat" />
                                                        <asp:Label runat="server" ID="lbl_message"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-8">
                                                        <i class="fa fa-list"></i>
                                                        <h3 class="box-title">List of websites</h3>
                                                        <div class="box-body">
                                                            <table id="tbl_created_websites" class="table table-bordered table-hover dataTable">
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
                            <div class="row">
                                <div runat="server" class=" display-none" id="create_database">
                                    <section class="col-lg-6">
                                        <div class="box box-primary">
                                            <div class="box-header">
                                                <i class="fa fa-edit"></i>
                                                <h3 class="box-title">Create Database</h3>
                                                <div class="box-body">
                                                    <div class="col-lg-12">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                    <section class="col-lg-6">
                                        <div class="box box-primary">
                                            <div class="box-header">
                                                <i class="fa fa-list"></i>
                                                <h3 class="box-title">List of Databases</h3>
                                                <div class="box-body">
                                                    <div class="col-lg-12">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>

                                </div>
                            </div>
                            <div class="row">
                                <div runat="server" id="website_details">
                                    <section class="col-lg-6">
                                        <div class="box box-success">
                                            <div class="box-header">
                                                <i class="fa fa-list-alt"></i>
                                                <h3 class="box-title">Website</h3>
                                                <div class="box-body">
                                                    <div class="col-lg-12">
                                                        <span>List of websites you have created...</span>
                                                        <br />
                                                        <!-- retrieving website name from database        -->
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
                                                                            tbl_websites.Controls.Add(row);
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
                                                        <!-- end of website retrieval from db -->
                                                        <br />
                                                        <div class="show-website" id="list_website" runat="server">
                                                            <table runat="server" id="tbl_websites" class="table table-bordered table-hover dataTable">
                                                                <thead>
                                                                    <tr>
                                                                        <th width="290">Website Name</th>
                                                                        <th>Edit Name</th>
                                                                        <th>Delete Website</th>
                                                                    </tr>
                                                                </thead>
                                                            </table>


                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                    <section class="col-lg-6">
                                        <div class="box box-success">
                                            <div class="box-header">
                                                <i class="fa fa-list-ol"></i>
                                                <h3 class="box-title">Pages</h3>
                                                <div class="box-body">
                                                    <div class="col-lg-12">
                                                        <table id="tbl_pages" style="display: none;" class="table table-condensed">
                                                        </table>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </section>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <uc1:footer runat="server" ID="footer" />
        </div>
    </form>
    <!-- jQuery 2.1.3 -->
    <script src="../admin/plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <!-- jQuery UI 1.11.2 -->
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.min.js" type="text/javascript"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <%--   <script>
        $.widget.bridge('uibutton', $.ui.button);
    </script>--%>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="../admin/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Morris.js charts -->
    <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="../admin/plugins/morris/morris.min.js" type="text/javascript"></script>
    <!-- Sparkline -->
    <script src="../admin/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- jvectormap -->
    <script src="../admin/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
    <script src="../admin/plugins/jvectormap/jquery-jvectormap-world-mill-en.js" type="text/javascript"></script>
    <!-- jQuery Knob Chart -->
    <script src="../admin/plugins/knob/jquery.knob.js" type="text/javascript"></script>
    <!-- daterangepicker -->
    <script src="../admin/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <!-- datepicker -->
    <script src="../admin/plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="../admin/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <script src="../admin/plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <!-- Slimscroll -->
    <script src="../admin/plugins/slimScroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <!-- FastClick -->
    <script src='../admin/plugins/fastclick/fastclick.min.js'></script>
    <!-- AdminLTE App -->
    <script src="../admin/dist/js/app.min.js" type="text/javascript"></script>

    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="../admin/dist/js/pages/dashboard.js" type="text/javascript"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../admin/dist/js/demo.js" type="text/javascript"></script>
</body>
</html>
