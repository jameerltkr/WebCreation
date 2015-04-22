<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="admin_report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="463px" Width="997px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="admin\Report1.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="LinqDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="MyProjectDataContext" EntityTypeName="" TableName="aspnet_Memberships">
        </asp:LinqDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DataSetTableAdapters.RegistrationTableAdapter"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
