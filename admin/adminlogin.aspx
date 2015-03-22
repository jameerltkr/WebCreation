<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="admin_adminlogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:#808080;
            color:#4cff00;
        }
        .auto-style1 {
            width: 100%;
        }
        .back
        {
            background-color:gray;
            opacity:0.8;
        }
        .panel1
        {
            background-color:red;
            border-radius:110px;
            font-size:20px;
            height:300px;
            width:400px;
            opacity:0.9;
        }
        .but2
        {
            
            border:0px none ;
            background-color:#f6f1f1;
            opacity:0.7;
            font-size:x-large;


        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td align="right">
                    <asp:Button ID="Button1" runat="server" Text="Login" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:ModalPopupExtender CancelControlID="Button3" BackgroundCssClass="back" TargetControlID="Button1" PopupControlID="Panel1" ID="ModalPopupExtender1" runat="server">
                       
                                            </asp:ModalPopupExtender>
                     <asp:Panel CssClass="panel1" ID="Panel1" runat="server">
                        <table class="auto-style1">
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="Button3" CssClass="but2" runat="server" Text="X" />
                                </td>
                            </tr>
                            <tr>
                                <td>Login ID</td>
                                <td>
                                    <asp:TextBox placeholder="Enter login id" ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Password</td>
                                <td>
                                    <asp:TextBox placeholder="*****" ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="login" OnClick="Button2_Click" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
