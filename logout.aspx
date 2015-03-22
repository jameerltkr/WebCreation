<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>

<%@ Register Src="~/menu.ascx" TagPrefix="uc1" TagName="menu" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/site.css" rel="stylesheet" />
</head>
<body>
    <div style="margin-left:15%;">
        <uc1:menu runat="server" ID="menu" />
    </div>
    <form id="form2" runat="server">
                    <div class="logoutBox">
    <h2>You have successfully logged out... Click below to Login again.</h2>
                        <br />
        <asp:LinkButton ID="LinkButton1" CssClass="clickLogin" runat="server" OnClick="LinkButton1_Click">Go to Login</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
