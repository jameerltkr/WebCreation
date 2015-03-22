<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewUser.ascx.cs" Inherits="user_ViewUser" %>

<div style="margin-left:19%;">
            <ul id="css3menu1" class="topmenu">
  <li class="topmenu" style="background: transparent none repeat scroll 0% 50%; -moz-background-clip: initial; -moz-background-origin: initial; -moz-background-inline-policy: initial; padding-left: 0px;"><a href="userwelcome.aspx">Home</a></li>
  <li class="topmenu"><a href="samples.aspx">Samples</a></li>
  <li class="topmenu"><a href="create.aspx">Create Website</a></li>
  <li class="topmenu"><a href="control-panel.aspx">Control Panel</a></li>
  <li class="topmenu"><a>Profile</a>
      <ul>
          <li class="subfirst"><a href="profile.aspx">View Profile</a></li>
          <li><a href="changepassword.aspx">Change Password</a></li>
          <li class="sublast"><a href="edit-profile.aspx">Edit Profile</a></li>
      </ul>
  </li>
  
</ul>
            <div style="float:right;background:linear-gradient(#40f24e,rgba(137, 243, 129, 0.46));  padding:10px; height:14px;width:220px; font-size:14px; color:black;">
        <label>Welcome,</label>&nbsp;
        [&nbsp;<b><asp:Label ID="Label1" runat="server"></asp:Label></b>&nbsp;]
        <asp:LinkButton CssClass="logoutButton" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LogOut</asp:LinkButton>
    </div>
</div>

