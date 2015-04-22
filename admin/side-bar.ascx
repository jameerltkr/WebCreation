<%@ Control Language="C#" AutoEventWireup="true" CodeFile="side-bar.ascx.cs" Inherits="admin_Usercontrol_side_bar" %>

<script runat="server">
</script>
<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
        <!-- Sidebar user panel -->
        <div class="user-panel">
            <div class="pull-left image">
                <%--<asp:Image ID="user-img" runat="server" class="img-circle" alt="User Image"/>--%>
                <img src="dist/img/user2-160x160.jpg" runat="server" id="user_img" class="img-circle" alt="User Image" />
            </div>
            <div class="pull-left info">
                <p>
                    <asp:Literal runat="server" ID="ltr_admin"></asp:Literal></p>

                <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
            </div>
        </div>
        <!-- search form -->
        <section class="sidebar-form">
            <div class="input-group">
                <input type="text" name="q" class="form-control" placeholder="Search..." />
                <span class="input-group-btn">
                    <button type='submit' name='search' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button>
                </span>
            </div>
        </section>
        <!-- /.search form -->
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class="sidebar-menu">
            <li class="header">MAIN NAVIGATION</li>
            <li runat="server" id="dashboard" class="treeview">
                <a href="#">
                    <i class="fa fa-dashboard"></i><span>Dashboard</span> <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li id="home" runat="server" ><a href="Home.aspx?p=home"><i class="fa fa-circle-o"></i>Home</a></li>
                    <li id="users" runat="server"><a href="Users.aspx?p=users"><i class="fa fa-circle-o"></i>Manage Users</a></li>
                    <li id="roles" runat="server"><a href="Roles.aspx?p=roles"><i class="fa fa-circle-o"></i>Manage Roles</a></li>
                </ul>
            </li>
            <li class="treeview" runat="server" id="hosting">
                <a href="#">
                    <i class="fa fa-files-o"></i>
                    <span>Hosting Manager</span>
                    <span class="label label-primary pull-right">2</span>
                </a>
                <ul class="treeview-menu">
                    <li id="hosting_resources" runat="server"><a href="HostingResources.aspx?p=hosting_resources"><i class="fa fa-circle-o"></i>Manage Resources</a></li>
                    <li id="hosting_users" runat="server"><a href="HostingUsers.aspx?p=hosting_users"><i class="fa fa-circle-o"></i>Manage Users</a></li>
                </ul>
            </li>
            <li class="treeview" runat="server" id="web">
                <a href="#">
                    <i class="fa fa-pie-chart"></i>
                    <span>Web Manager</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li id="web_users" runat="server"><a href="WebUsers.aspx?p=web_users"><i class="fa fa-circle-o"></i>Manage Users</a></li>
                    <li id="web_resources" runat="server"><a href="WebResources.aspx?p=web_resources"><i class="fa fa-circle-o"></i>Manage Resources</a></li>
                </ul>
            </li>
            <li id="calendar" runat="server">
                <a href="Calendar.aspx?p=calendar">
                    <i class="fa fa-calendar"></i><span>Calendar</span>
                    <small class="label pull-right bg-red">3</small>
                </a>
            </li>
            <li class="treeview" runat="server" id="mail">
                <a href="#">
                    <i class="fa fa-pie-chart"></i>
                    <span>Mail Box</span>
                    <i class="fa fa-angle-left pull-right"></i>
                </a>
                <ul class="treeview-menu">
                    <li id="compose" runat="server"><a href="Compose.aspx?p=compose"><i class="fa fa-circle-o"></i>Compose Mail</a></li>
                    <li id="inbox" runat="server"><a href="Inbox.aspx?p=inbox"><i class="fa fa-circle-o"></i>Inbox</a></li>
                    <li id="sentmail" runat="server"><a href="SentMail.aspx?p=sentmail"><i class="fa fa-circle-o"></i>Sent Box</a></li>
                    <li id="trash" runat="server"><a href="Trash.aspx?p=trash"><i class="fa fa-circle-o"></i>Trash</a></li>
                </ul>
            </li>
        </ul>
    </section>
    <!-- /.sidebar -->
</aside>
