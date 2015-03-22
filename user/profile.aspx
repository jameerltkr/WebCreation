<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="user_profile" %>

<%@ Register Src="~/ViewUser.ascx" TagPrefix="uc1" TagName="ViewUser" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form2" runat="server">
        <uc1:ViewUser runat="server" ID="ViewUser" />

        <div class="page-in">
<div class="page">
<div class="main">

<div class="content">
      
        <asp:Label ID="Label2" runat="server"></asp:Label>
        
        <table class="auto-style1" style="font-size:13px;">
            <tr>
                <td class="auto-style2">Profile PIC</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Image ID="Image1" runat="server" Height="112px" ImageUrl="~/img/default.png" Width="123px" />
                </td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="False" OnClick="LinkButton1_Click">Personal Infomation</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" Text="Upload PIc" OnClick="Button1_Click" />
                </td>
                <td>
                    <asp:Panel ID="Panel1" runat="server">
                        <table class="auto-style1">
                            <tr>
                                <td>Full Name</td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>D.O.B</td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Mobile NO</td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Country</td>
                                <td>
                                    <asp:DropDownList ID="ddlcountry" runat="server">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>Ind</asp:ListItem>
                                        <asp:ListItem>Us</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>City</td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Address</td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" />
                                    &nbsp;
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Cancel" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>                 
    

</div>

    <uc1:footer runat="server" ID="footer" />
</div>
</div>
</div>


    </form>
</body>
</html>