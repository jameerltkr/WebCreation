<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Src="~/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/bottom.ascx" TagPrefix="uc1" TagName="bottom" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="../css/animate.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/responsive.css" rel="stylesheet" />
    <script src="js/validation.js"></script>
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
		<script src="js/modernizr.custom.js"></script>
     <style>
        .validation-error{
    color:red;
    font-size:14px;
    font-family: Arial;
    margin-left:5px;
}
    </style>
</head>
<body>
    <form id="form2" runat="server">
         <div >
            <uc1:menu runat="server" ID="menu" />
    </div>
        <section id="feature" >
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <asp:Panel ID="pnl_msg" runat="server"></asp:Panel>
            <div class="register_section">
    
                <table class="auto-style1" style="font-size:14px;margin-left:50px;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>User Name</td>
                <td>
                    <%--<asp:TextBox CssClass="textbox form-control" ID="TextBox1" runat="server" TextMode="Email"></asp:TextBox>--%>
                    <asp:TextBox CssClass="textbox form-control" ID="txt_username" runat="server"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_email"></div>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="TextBox2" CssClass="textbox form-control" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_password"></div>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="forgetpassword.aspx">Forgot Password?</a><br />
                    or click to&nbsp;&nbsp;<a href="registration.aspx">Register Now</a>
                    
                    </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="progress-button" Text="LogIn" OnClientClick="return: LoginValidation()" OnClick="Button1_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>

            </div>

            </div></section>

        

                        


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
