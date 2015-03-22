<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="admin_search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="269px" Width="635px">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="email" HeaderText="Email Id" />
                <asp:BoundField DataField="city" HeaderText="City" />
                <asp:HyperLinkField Text="View Detail" HeaderText="Detail" DataNavigateUrlFields="email" DataNavigateUrlFormatString="searchdetail.aspx?v={0}" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
