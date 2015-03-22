<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="web_design_menu" %>
<%@ Register Src="~/user_control/UserShow.ascx" TagPrefix="uc1" TagName="UserShow" %>



<header id="header">
        <div class="top-bar">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6 col-xs-4">
                        <div class="top-number"><p><i class=""></i>  Make your websites for free...</p></div>
                    </div>
                    <div class="col-sm-6 col-xs-8">
                       <div class="social">
                            <ul class="social-share">
                                <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                <li><a href="#"><i class="fa fa-linkedin"></i></a></li> 
                                <li><a href="#"><i class="fa fa-dribbble"></i></a></li>
                                <li><a href="#"><i class="fa fa-skype"></i></a></li>
                            </ul>
                            <div class="search">
                                <section role="form">
                                    <input type="text" class="search-form" autocomplete="off" placeholder="Search">
                                    <i class="fa fa-search"></i>
                                </section>
                           </div>
                           <div class="show_user">
                               <uc1:UserShow runat="server" ID="UserShow" />
                            </div>
                       </div>
                    </div>
                </div>
            </div><!--/.container-->
        </div><!--/.top-bar-->


<nav class="navbar navbar-inverse" role="banner">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="../home.aspx"><img src="../images/logo new.png" alt="logo"></a>
                </div>
				
                <div class="collapse navbar-collapse navbar-right">
                    <ul class="nav navbar-nav">
                        <li ><a href="../home.aspx">Home</a></li>
                        <li><a href="../about-us.html">About Us</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Samples <i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu">
                                <li><a href="blog-item.html">HTML Templates</a></li>
                                <li><a href="pricing.html">ASP.Net Samples</a></li>
                                <li><a href="help.html">Help</a></li>
                            </ul>
                        </li>
                        <li><a href="main.aspx">Create Website</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Services <i class="fa fa-angle-down"></i></a>
                            <ul class="dropdown-menu">
                                <li><a href="../hosting/create-domain.aspx">Hosting</a></li>
                                <li><a href="pricing.html">Web Creation</a></li>
                                <li><a href="404.html">Cloud Space</a></li>
                                <li><a href="../help/help.html">Help</a></li>
                            </ul>
                        </li>
                        <li><a href="../hosting/main.aspx">Control Panel</a></li> 
                    </ul>
                </div>
            </div><!--/.container-->
        </nav>        

        <!--/nav-->
		
    </header>