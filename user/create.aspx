<%@ Page Language="VB" AutoEventWireup="false" CodeFile="create.aspx.vb" Inherits="user_create" %>

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
    <div>
        <uc1:ViewUser runat="server" ID="ViewUser" />
    </div>
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
