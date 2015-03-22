<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="user_changepassword" %>

<%@ Register Src="~/ViewUser.ascx" TagPrefix="uc1" TagName="ViewUser" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style5.css" rel="stylesheet" />
    <link href="css/site.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/animate.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/responsive.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
		<script src="js/modernizr.custom.js"></script></head>
<body>
    <form id="form1" runat="server">
        <uc1:ViewUser runat="server" ID="ViewUser" />
            <div class="page-in">
<div class="page">
<div class="main">

<div class="content">
                       
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Old Password</td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>New Password</td>
                <td>
                    <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="registrationButton" OnClick="Button1_Click" Text="Change" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    

</div>
    <uc1:footer runat="server" ID="footer" />
</div>
</div>
</div>

    <div>
    
    </div>
    </form>
</body>
</html>
