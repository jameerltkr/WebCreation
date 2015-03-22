<%@ Page Language="C#" AutoEventWireup="true" CodeFile="control-panel.aspx.cs" Inherits="user_control_panel" %>

<%@ Register Src="~/ViewUser.ascx" TagPrefix="uc1" TagName="ViewUser" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:ViewUser runat="server" ID="ViewUser" />
            <div class="page-in">
<div class="page">
<div class="main">

<div class="content">
                       
    

</div>

    <uc1:footer runat="server" ID="footer" />
</div>
</div>
</div>
    </form>
</body>
</html>
