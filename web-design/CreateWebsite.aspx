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
    <script src="js/website-creation.js"></script>
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

    <!-- determine first visit of the user-->
    <script type="text/javascript">
        function CheckFirstVisit() {
            // check cookie
            var visited = $.cookie("visited")

            if (visited == null) {
                //   $('.newsletter_layer').show();
                $.cookie('visited', 'yes');
                alert($.cookie("visited"));
            }

            // set cookie
            $.cookie('visited', 'yes', { expires: 1, path: '/' });
        });
    </script>
    <!--   end of first user visiting -------------->
    <script type="text/javascript">

    </script>

    <link href="../admin/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
    <link href="../admin/plugins/fullcalendar/fullcalendar.print.css" rel="stylesheet" type="text/css" media='print' />
</head>
<body class="skin-blue" onload="CheckFirstVisit()">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hf_page_name" runat="server" />
        <asp:HiddenField ID="hf_website_name" runat="server" />
        <asp:HiddenField runat="server" ID="hf_db_id" />
        <asp:HiddenField ID="hf_db_id_for_tbl" runat="server" />
        <asp:HiddenField runat="server" ID="hf_website_preview" />
        <asp:HiddenField runat="server" ID="hf_column_details" />
        <%--<asp:HiddenField runat="server" ID="hf_database_id" />--%>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <!--   these events are being clicked using javascript  --------------->
                <asp:Button ID="btn_write_page" Style="display: none;" runat="server" Text="Create page" OnClick="btn_create_page_Click" />
                <!-- this onclik event used to create page --------------->
                <asp:Button ID="btn_edit_db" Style="display: none" runat="server" OnClick="btn_edit_db_Click" />
                <!--   this onclikc event used to edit the database on user request---------------->

                <!--   table mngment event   ---->
                <asp:Button ID="btn_manage_tables" Style="display: none" runat="server" OnClick="btn_manage_tables_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="wrapper">
            <%--<uc1:header runat="server" ID="header" />--%>
            <!-- Header contents goes here  -->

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
                                    <asp:LinkButton runat="server" ID="lb_download_project">
                                <i class="fa fa-download btn btn-flat btn-success"> Download Project</i>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lb_preview" OnClick="lb_preview_Click">
                                <i class="fa fa-external-link-square btn btn-flat btn-success"> Preview</i>
                                    </asp:LinkButton>
                                </nav>
                            </nav>

                        </nav>
                    </header>

                </ContentTemplate>
            </asp:UpdatePanel>
            <!--   end of header contents-->

            <!-- side bar starts here-->
            <%--<uc1:sidebar runat="server" ID="sidebar" />--%>
            <aside class="main-sidebar">
                <!-- sidebar: style can be found in sidebar.less -->
                <section class="sidebar">
                    <div class="box-body">
                        <div class="box-group" id="accordion">
                            <!-- we are adding the .panel class so bootstrap.js collapse plugin detects it -->
                            <div class="panel box box-success">
                                <div class="box-header with-border">
                                    <h4>
                                        <a style="color: black;" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">HTML toolbox
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseOne" class="panel-collapse collapse">
                                    <div id="external-events">
                                        <div class="external-event bg-purple">Anchor (a)</div>
                                        <div class="external-event bg-purple">Button</div>
                                        <div class="external-event bg-purple">Div</div>
                                        <div class="external-event bg-purple">Checkbox</div>
                                        <div class="external-event bg-purple">Input (File)</div>
                                        <div class="external-event bg-purple">Input (Text)</div>
                                        <div class="external-event bg-purple">Input (Password)</div>
                                        <div class="external-event bg-purple">Input (Radio)</div>
                                        <div class="external-event bg-purple">Textarea</div>
                                        <div class="external-event bg-purple">Table</div>
                                        <div class="external-event bg-purple">Image</div>
                                        <div class="external-event bg-purple">Select</div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel box box-danger">
                                <div class="box-header with-border">
                                    <h4>
                                        <a style="color: black;" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">ASP.Net toolbox
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseTwo" class="panel-collapse collapse">
                                    <div>
                                        <div class="external-event bg-purple">Button</div>
                                        <div class="external-event bg-purple">Calendar</div>
                                        <div class="external-event bg-purple">Checkbox</div>
                                        <div class="external-event bg-purple">CheckboxList</div>
                                        <div class="external-event bg-purple">DropDownList</div>
                                        <div class="external-event bg-purple">FileUpload</div>
                                        <div class="external-event bg-purple">HyperLink</div>
                                        <div class="external-event bg-purple">Image</div>
                                        <div class="external-event bg-purple">ImageButton</div>
                                        <div class="external-event bg-purple">Label</div>
                                        <div class="external-event bg-purple">LinkButton</div>
                                        <div class="external-event bg-purple">ListBox</div>
                                        <div class="external-event bg-purple">Literal</div>
                                        <div class="external-event bg-purple">Panel</div>
                                        <div class="external-event bg-purple">RadioButton</div>
                                        <div class="external-event bg-purple">RadioButtonList</div>
                                        <div class="external-event bg-purple">Table</div>
                                        <div class="external-event bg-purple">TextBox</div>
                                        <div class="external-event bg-purple">GridView</div>
                                        <%-- <div class="external-event bg-purple">Image</div>
                                                <div class="external-event bg-purple">ImageButton</div>
                                                <div class="external-event bg-purple">Label</div>
                                                <div class="external-event bg-purple">LinkButton</div>
                                                <div class="external-event bg-purple">ListBox</div>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="panel box box-primary">
                                <div class="box-header with-border">
                                    <h4>
                                        <a style="color: black;" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">UI templates
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseThree" class="panel-collapse collapse">
                                    <div>
                                        <div class="external-event bg-purple">Anchor (a)</div>
                                        <div class="external-event bg-purple">Button</div>
                                        <div class="external-event bg-purple">Div</div>
                                        <div class="external-event bg-purple">Checkbox</div>
                                        <div class="external-event bg-purple">Input (File)</div>
                                        <div class="external-event bg-purple">Input (Text)</div>
                                        <div class="external-event bg-purple">Input (Password)</div>
                                        <div class="external-event bg-purple">Input (Radio)</div>
                                        <div class="external-event bg-purple">Textarea</div>
                                        <div class="external-event bg-purple">Table</div>
                                        <div class="external-event bg-purple">Image</div>
                                        <div class="external-event bg-purple">Select</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div>
                    </div>
                </section>
                <!-- /.sidebar -->
            </aside>


            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="content-wrapper">
                        <!-- Content Header (Page header) -->
                        <section class="content-header">
                            <!-- Main row -->
                            <div class="row">
                                <!-- Main col -->
                                <section class="col-lg-12 ">
                                    <div class="box">
                                        <iframe style="display: none; min-height: 500px; max-height: 100%;" id="iframe_edit_page" class="col-lg-12 "></iframe>
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
                                        //ddl_select_website.Items.Clear();
                                        //ddl_select_website.Items.Insert(0, "Select");  // inserting at first position
                                        foreach (var a in q)
                                        {
                                            //binding website list in drop down------------

                                            //    ddl_select_website.Items.Add(a.WebsiteName);
                                            //------------------------------------------

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
                                            tbl_created_websites.Controls.Add(row);
                                        }
                                    }
                                    
                                %>
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
                                                        <asp:Button ID="btn_create_website" runat="server" Text="Create Website" OnClick="btn_create_website_Click" class="btn btn-block bg-maroon btn-flat" />
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
                            <div class="row">
                                <div runat="server" class=" display-none" id="create_database">
                                    <section class="col-lg-4">
                                        <div class="box box-primary">
                                            <div class="box-header">
                                                <i class="fa fa-edit"></i>
                                                <h3 class="box-title">Create Database</h3>
                                                <div class="box-body">
                                                    <div class="col-lg-12">
                                                        Enter Database Name:
                                                        <asp:TextBox runat="server" ID="txt_database_name" placeholder="Database name" class="form-control"></asp:TextBox>
                                                        Select Website:
                                                        <img height="22" title="Select your website for which you want to create database." src="../img/question.jpg" />
                                                        <asp:DropDownList runat="server" ID="ddl_select_website" class="form-control">
                                                        </asp:DropDownList><br />
                                                        <asp:Button runat="server" ID="btn_create_database" OnClick="btn_create_database_Click" Text="Create Database" class="btn btn-block bg-purple btn-flat" />
                                                        <asp:Label runat="server" ID="lb_create_database_msg"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                    <div runat="server" id="section_tbl_list" class="display-block">
                                        <section class="col-lg-8">
                                            <div class="box box-primary">
                                                <div class="box-header">
                                                    <i class="fa fa-list"></i>
                                                    <h3 class="box-title">List of Databases</h3>
                                                    <div class="box-body">
                                                        <div class="col-lg-12">
                                                            <%
                                                                DatabaseManagement dbmanage = new DatabaseManagement();
                                                                string username = "";
                                                                if (Session[Constants.Session.USERNAME] != null)
                                                                    username = Session[Constants.Session.USERNAME].ToString();
                                                                else
                                                                {
                                                                    Response.Redirect("~/login.aspx");
                                                                }
                                                                var q = dbmanage.GetDatabaseListByUsername(username);
                                                                HtmlTableRow row = null;
                                                                HtmlTableCell cell_dbname = null;
                                                                HtmlTableCell cell_edit = null;
                                                                HtmlTableCell cell_delete = null;
                                                                HtmlTableCell cell_website_name = null;
                                                                HtmlTableCell cell_manage_tables = null;

                                                                ImageButton a1 = null;
                                                                ImageButton a2 = null;
                                                                foreach (var a in q)
                                                                {
                                                                    row = new HtmlTableRow();
                                                                    cell_dbname = new HtmlTableCell();
                                                                    cell_edit = new HtmlTableCell();
                                                                    cell_delete = new HtmlTableCell();
                                                                    cell_website_name = new HtmlTableCell();
                                                                    cell_manage_tables = new HtmlTableCell();
                                                                    a2 = new ImageButton();
                                                                    a1 = new ImageButton();
                                                                    a1.Height = 15;
                                                                    a2.Height = 15;
                                                                    a1.Width = 16;
                                                                    a2.Width = 16;
                                                                    //a1.CssClass = "btn";
                                                                    //a2.CssClass = "btn";

                                                                    a1.ToolTip = "Edit your database.";
                                                                    a2.ToolTip = "Delete database.";
                                                                    a1.ImageUrl = "~/img/edit.png";
                                                                    a2.ImageUrl = "~/img/delete.png";
                                                                    tbl_database_list.Controls.Add(row);
                                                                    row.Controls.Add(cell_dbname);
                                                                    row.Controls.Add(cell_website_name);
                                                                    row.Controls.Add(cell_manage_tables);
                                                                    row.Controls.Add(cell_edit);
                                                                    row.Controls.Add(cell_delete);
                                                                    a1.OnClientClick = "edit_database('" + a.DatabaseId + "'); return false";
                                                                    a2.OnClientClick = "if(confirm('Are you sure you want to delete database?')) delete_db('" + a.DatabaseId + "')";
                                                                    cell_dbname.InnerHtml = a.DatabaseName;
                                                                    cell_website_name.InnerHtml = a.WebsiteName;
                                                                    cell_manage_tables.InnerHtml += "<a class='btn' onclick='manage_tables(" + a.DatabaseId + ")'><i class='fa fa-gear'></i></a>";
                                                                    cell_manage_tables.InnerHtml += "[Total Tables = " + dbmanage.GetNumberOfTotalTableByDbId(a.DatabaseId) + "]";
                                                                    cell_edit.Controls.Add(a1);
                                                                    cell_delete.Controls.Add(a2);
                                                                }
                                                                   
                                                            %>
                                                            <table runat="server" id="tbl_database_list" class="table table-bordered table-hover dataTable">
                                                                <thead>
                                                                    <tr>
                                                                        <th width="120">Database Name</th>
                                                                        <th width="140">Created for (Website)</th>
                                                                        <th width="190">Tables in DB</th>
                                                                        <th>Edit</th>
                                                                        <th>Delete</th>
                                                                    </tr>
                                                                </thead>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </section>
                                    </div>
                                    <%
                                        //Guid userid;
                                        //System.Web.Security.MembershipUser mu;
                                        //mu = System.Web.Security.Membership.GetUser();
                                        //userid = (Guid)mu.ProviderUserKey;
                                        //DatabaseManagement dbmanage = new DatabaseManagement();
                                        //int dbid = hf_db_id_for_tbl.Value != "" ? Convert.ToInt32(hf_db_id_for_tbl.Value) : 0;
                                        //if (hf_db_id_for_tbl.Value != "")
                                        //{
                                        //    var q = dbmanage.GetTableRecords(dbid, userid);
                                        //    if (q.Any())
                                        //    {
                                        //        TableRow tr = null;
                                        //        TableCell td_tablename = null;
                                        //        LinkButton lb_tablename = null;
                                        //        foreach (var a in q)
                                        //        {
                                        //            tr = new TableRow();
                                        //            td_tablename = new TableCell();
                                        //            lb_tablename = new LinkButton();
                                        //            lb_tablename.Text = a.TableName;
                                        //            td_tablename.Controls.Add(lb_tablename);
                                        //            tr.Controls.Add(td_tablename);
                                        //            tbl_table_detail.Controls.Add(tr);
                                        //        }
                                        //    }
                                        //}
                                    %>
                                    <div runat="server" class="display-none" id="section_manage_tables">
                                        <section class="col-lg-8">
                                            <div class="box box-success">
                                                <div class="box-header">
                                                    <i class="fa fa-edit"></i>
                                                    <h3 class="box-title">Manage Tables</h3>
                                                    <div class="box-body">
                                                        <!--  creating table in a particular database--------->
                                                        <div class="col-lg-4">
                                                            Choose table name:
                                                    <asp:TextBox runat="server" ID="txt_table_name" class="form-control" placeholder="Table name"></asp:TextBox>
                                                            Enter column name:
                                                    <asp:TextBox runat="server" ID="txt_column_name" class="form-control" placeholder="Column name"></asp:TextBox>
                                                            Data type:
                                                    <%--<asp:TextBox runat="server" ID="txt_data_type" class="form-control" placeholder="Data type"></asp:TextBox>--%>
                                                            <asp:DropDownList runat="server" ID="ddl_data_type" class="form-control">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem>varchar(50)</asp:ListItem>
                                                                <asp:ListItem>varchar(100)</asp:ListItem>
                                                                <asp:ListItem>int</asp:ListItem>
                                                                <asp:ListItem>bit</asp:ListItem>
                                                                <asp:ListItem>uniqueidentifier</asp:ListItem>
                                                                <asp:ListItem>date</asp:ListItem>
                                                                <asp:ListItem>datetime</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Button runat="server" ID="btn_add_columns" Text="Add" class="btn btn-block bg-blue btn-flat" OnClick="btn_add_columns_Click" />
                                                        </div>
                                                        <br />
                                                        <div class="col-lg-5">
                                                            <asp:Button runat="server" ID="btn_create_table" class="btn btn-block bg-red btn-flat" Text="Create Table" OnClick="btn_create_table_Click" /><br />

                                                            <div class="col-lg-6">
                                                                <asp:Button ID="btn_save_table_manage" class="btn btn-block bg-purple btn-flat" runat="server" Text="Save" OnClick="btn_save_table_manage_Click" />
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <asp:Button ID="btn_cancel_table_manage" class="btn btn-block bg-gray btn-flat" runat="server" Text="Cancel" OnClick="btn_cancel_table_manage_Click" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3">

                                                            <table runat="server" id="tbl_table_detail" class="table table-bordered table-hover dataTable">
                                                                <thead>
                                                                    <th>Table name</th>
                                                                </thead>
                                                            </table>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="">
                                                    <asp:Label runat="server" ID="lbl_create_table_msg"></asp:Label>
                                                </div>
                                            </div>

                                        </section>
                                    </div>
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
                                                        <%--<iframe style="display: none;" id="iframe_edit_page" height="450" width="855"></iframe>--%>
                                                        <div id="website_div">
                                                            <div runat="server" id="div_create_page">
                                                                <!--<span>Page name:</span>-->
                                                                <asp:TextBox Style="display: none;" runat="server" ID="txt_page_name"></asp:TextBox>

                                                                <br />
                                                                <asp:Button ID="Button1" Style="display: none;" runat="server" Text="Create page" OnClick="Button1_Click" />

                                                            </div>
                                                        </div>
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
    <script src="../js/jquery.js"></script>

    <!-- fullCalendar 2.2.5 -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.7.0/moment.min.js" type="text/javascript"></script>
    <script src="../admin/plugins/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
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
