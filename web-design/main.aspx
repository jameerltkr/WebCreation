<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="web_design_main" %>

<%@ Register Src="~/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/web-design/menu.ascx" TagPrefix="uc2" TagName="menu" %>
<%@ Register Src="~/bottom.ascx" TagPrefix="uc1" TagName="bottom" %>






<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>

        span{
            color:red;
            font-weight:bold;
        }
    </style>
    <title>Main | webcreation.com</title>
    <link href="../css/animate.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/responsive.css" rel="stylesheet" />
</head>
<body class="homepage">
    <link href="../css/prettyPhoto.css" rel="stylesheet" />
    <form id="form1" runat="server">
    <div>
        <uc2:menu runat="server" ID="menu" />
    </div>


<section id="feature">
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <h1 style="color:#0d93d7; font-family:DengXian">Get ready to make websites within few minutes...</h1>
            <h4 style="color:#1e1f21; font-weight:normal">Here are some steps through which you can build a website by  giving us a couple of time...</h4>
            <h2 style="color:#0d93d7; font-family:DengXian">Click below to create website just now...</h2>
            <div class="col-md-3 col-sm-6">
                <a href="create.aspx" title="Click to go on website creation page"><img src="../images/read.png" /></a>
            </div><br /><br /><br /><br />
            <div style="margin-top:100px;margin-left:18%;">
                <img src="../images/drag-drop-upload.gif" />
            </div>


        </div>
    </section>

        <section >
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <div>
                <h2>Steps to create website.</h2>
                <b>1.</b>
                Click on <span>New Web</span>.<br />
                <b>2.</b>
                Drag and drop the tools and templates according to your need on the <span>blank page</span>.<br />
                <b>3.</b>
                Click on <span>Add another page</span> if you required.<br />
                <b>4.</b>
                Click <span>Create Database</span> if you want to build a dynamic website or click <span>Skip</span> if you want to build a static website.<br />
                <b>5.</b>
                Then click on <span>Finish</span> button.<br />
                <b>Now your site is created and you can see this site by clicking on <span>Publish</span> button, and also you can download thier source code by clicking on <span>Get source code.</span></b>
                <br />
                <br /><br />
                <a href="create.aspx" title="Click to go on website designing page.">Click here</a> to create website now.
            </div>
        </div>
    </section>

        <uc1:bottom runat="server" ID="bottom" />
        
         <footer id="footer" style="border-top:thick 5px rgba(248, 78, 203, 0.72);" class="midnight-blue">
             <uc1:footer runat="server" ID="footer1" />
    </footer><!--/#footer-->
        <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.prettyPhoto.js"></script>
    <script src="../js/jquery.isotope.min.js"></script>
    <script src="../js/main.js"></script>
    <script src="../js/wow.min.js"></script>
    </form>
</body>
</html>
