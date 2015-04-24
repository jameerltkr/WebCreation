<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivationKeyExpired.aspx.cs" Inherits="ActivationKeyExpired" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lbl_msg"></asp:Label><br />
    Your activation key has been expired. Please enter your credentials to re-generate your activation key.<br />
        <asp:TextBox placeholder="Your email" runat="server" ID="txt_email"></asp:TextBox><br />
        <asp:TextBox placeholder="Your password" TextMode="Password" runat="server" ID="txt_password"></asp:TextBox><br />
        <asp:Button runat="server" Text="Generate Key" ID="btn_generatekey" OnClick="btn_generatekey_Click" />
    </div>
    </form>
</body>
</html>
