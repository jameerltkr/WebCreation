<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminwelcome.aspx.cs" Inherits="admin_adminwelcome" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/admin/adminwelcome.aspx">Home</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Height="31px" Width="399px"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Height="36px" OnClick="Button1_Click" Text="Search" Width="66px" />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/user/changepassword.aspx">Change Password</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LogOut</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td><a href="../Message/compose.aspx">compose</a></td>
            </tr>
            <tr>
                <td><a href="../Message/inbox.aspx">Inbox</a></td>
            </tr>
            <tr>
                <td><a href="../Message/sentbox.aspx">SentBox</a></td>
            </tr>
            <tr>
                <td><a href="../Message/draft.aspx">Draft</a></td>
            </tr>
            <tr>
                <td><a href="report.aspx">Report</a></td>
            </tr>
            <tr>
                <td><a href="viewregi_user.aspx">Registered User</a></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
