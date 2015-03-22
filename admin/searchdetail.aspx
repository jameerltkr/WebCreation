<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchdetail.aspx.cs" Inherits="admin_searchdetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DetailsView AutoGenerateRows="false" ID="DetailsView1" runat="server" Height="207px" Width="184px">
             <Fields>
                
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                
                <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                
                                <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
                <asp:BoundField DataField="mobile" HeaderText="mobile" SortExpression="mobile" />
                <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
                <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
            </Fields>
       
        </asp:DetailsView>
    
    </div>
    </form>
</body>
</html>
