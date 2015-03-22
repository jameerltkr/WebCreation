<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compose.aspx.cs" Inherits="Message_compose" %>

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
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>To</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="252px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Subject</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="21px" Width="256px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Message</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Height="116px" TextMode="MultiLine" Width="255px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Attachment</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Send Mail" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancel" />
&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Draft" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
