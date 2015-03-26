<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateWebsite.ascx.cs" Inherits="user_control_CreateWebsite" %>

<asp:Panel Visible="false" runat="server" ID="pnl_web">
    <%
                                
                                if (Session[Constants.Session.ID] != null)
                                {
                                    datalayer dl = new datalayer();
                                    Guid userid;
                                    System.Web.Security.MembershipUser mu;
                                    mu = System.Web.Security.Membership.GetUser();
                                    userid = (Guid)mu.ProviderUserKey;
                                    if(Session[Constants.Session.USERNAME]!=null && Session[Constants.WEBSITE_NAME]!=null)
                                    mu = System.Web.Security.Membership.GetUser(Session[Constants.Session.USERNAME].ToString());
                                    var q = dl.Retrieve_Web_Pages(userid,Session[Constants.WEBSITE_NAME].ToString());
                                    if (q.Any())
                                    {
                                        foreach (var a in q)
                                        {
                                            rpt_website_name.DataSource = q;
                                            rpt_website_name.DataBind();
                                        }
                                    }
                                }
                                else
                                {
                                    lbl_pages_name.Text="There are no pages... Please create one.";
                                    div_create_page.Visible=true;
                                }
                             %>

                     <script>
                    $(function () {// write your code in document ready
                        $('.btn-website-name').click(function () {
                            alert($(this).html());
                        });
                    });
                </script>
                <style>
                    .btn-website-name{
                        cursor:pointer;
                    }
                    .btn-website-name:hover{
                        text-decoration:underline;
                    }
                </style>
    <asp:Label runat="server" ID="lbl_pages_name"></asp:Label>
    <div runat="server" id="div_create_page" visible="false">
        <span>Page name:</span>
        <asp:TextBox runat="server" ID="txt_page_name"></asp:TextBox>
        <br />
        <asp:Button ID="btn_create_page" runat="server" Text="Create page" OnClick="btn_create_page_Click"/>
    </div>
                <asp:Repeater ID="rpt_website_name" runat="server">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbl_website_name" class="btn-website-name" Text='<%#Eval("WebsiteName") %>'></asp:Label>
                        <%--<asp:LinkButton ID="btn_website_name" class="bt-website-name" CommandName="website" OnCommand="btn_website_name_Command" CommandArgument="Hello" Text='<%#Eval("WebsiteName") %>' runat="server"></asp:LinkButton>--%><br />
                    </ItemTemplate>
                </asp:Repeater>
</asp:Panel>