<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" %>

<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/bottom.ascx" TagPrefix="uc1" TagName="bottom" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/animate.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/validation.js"></script>
    <link href="../css/responsive.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
		<script src="js/modernizr.custom.js"></script>
    <script>
        [].slice.call(document.querySelectorAll('.progress-button')).forEach(function (bttn, pos) {
            new UIProgressButton(bttn, {
                callback: function (instance) {
                    var progress = 0,
                        interval = setInterval(function () {
                            progress = Math.min(progress + Math.random() * 0.1, 1);
                            instance.setProgress(progress);

                            if (progress === 1) {
                                instance.stop(pos === 1 || pos === 3 ? -1 : 1);
                                clearInterval(interval);
                            }
                        }, 150);
                }
            });
        });
		</script>
    <style>
        .validation-error{
    color:red;
    font-size:14px;
    font-family: Arial;
    margin-left:5px;
}
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <uc1:menu runat="server" ID="menu" />
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    
        <section id="feature" >
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <asp:Panel ID="pnl_msg" runat="server"></asp:Panel>
            <div class="register_section">
    
    <%--<asp:UpdatePanel runat="server">--%>
        <%--<ContentTemplate>--%>

        

                 <table class="auto-style1" style="font-size:14px;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox CssClass="textbox form-control" ID="Tname" runat="server"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_name"></div>
                </td>
            </tr>
            <tr>
                <td>Email Id(loginId)</td>
                <td>
                    <asp:TextBox ID="Temail" CssClass="textbox form-control" runat="server" ></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_email"></div>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="Tpassword" runat="server" CssClass="textbox form-control" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_password"></div>
                </td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox ID="Tconfirmpassword" runat="server" CssClass="textbox form-control" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_conf_pass"></div>
                </td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButtonList ID="Rblgender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <div class="validation-error" id="error_gender"></div>
                </td>
            </tr>
            <tr>
                <td>Security Question</td>
                <td>
                    <asp:DropDownList CssClass="textbox form-control" ID="ddlsecurityQ" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Frnd Name?</asp:ListItem>
                        <asp:ListItem>book name?</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Visible="false" ID="Label2" runat="server"></asp:Label>
                    <div class="validation-error" id="error_security_que"></div>
                </td>
            </tr>
            <tr>
                <td>Your Answer</td>
                <td>
                    <asp:TextBox ID="TAnswer" runat="server" CssClass="textbox form-control"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_security_ans"></div>
                </td>
            </tr>
            <tr>
                <td>Date Of Birth</td>
                <td>
                    <asp:TextBox ID="Tdob" runat="server" TextMode="Date" CssClass="textbox form-control"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_dob"></div>
                </td>
            </tr>
            <tr>
                <td>Mobile No.</td>
                <td>
                    <asp:TextBox ID="Tmobile" runat="server" CssClass="textbox form-control"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_mobile"></div>
                </td>
            </tr>
            <tr>
                <td>Country</td>
                <td>
                    <asp:DropDownList CssClass="textbox form-control" ID="ddlcountry" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Ind</asp:ListItem>
                        <asp:ListItem>Us</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label Visible="false" ID="Label3" runat="server"></asp:Label>
                    <div class="validation-error" id="error_country"></div>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="Tcity" runat="server" CssClass="textbox form-control" ></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_city"></div>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="Taddress" runat="server" Height="67px" CssClass="textbox form-control" TextMode="MultiLine" Width="220px"></asp:TextBox>
                </td>
                <td>
                    <div class="validation-error" id="error_address"></div>
                </td>
            </tr>
            <tr>
                <td>Type The Code</td>
                <td>
                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="textbox form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="UP1" runat="server">

                        <ContentTemplate>

                            <table>

                                <tr>

                                    <td >

                                        <asp:Image ID="imgCaptcha" runat="server" />

                                    </td>

                                    <td valign="middle">

                                        <%--<asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />--%>
                                        <asp:ImageButton ID="img_refresh" OnClick="img_refresh_Click" runat="server" ImageUrl="~/img/Refresh-icon.png" Height="27" Width="27" />

                                    </td>

                                </tr>

                            </table>

                        </ContentTemplate>

                    </asp:UpdatePanel>

                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="You Agree To our" />
&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/terms.html">Terms &amp; Cond.</asp:HyperLink>
                </td>
                <td>
                    <%--<div class="container">
			<section>
				<div class="box">
					<!-- progress button -->
					<div class="progress-button elastic">
						<button><span>Submit</span></button>
						<svg class="progress-circle" width="70" height="70"><path d="m35,2.5c17.955803,0 32.5,14.544199 32.5,32.5c0,17.955803 -14.544197,32.5 -32.5,32.5c-17.955803,0 -32.5,-14.544197 -32.5,-32.5c0,-17.955801 14.544197,-32.5 32.5,-32.5z"/></svg>
						<svg class="checkmark" width="70" height="70"><path d="m31.5,46.5l15.3,-23.2"/><path d="m31.5,46.5l-8.5,-7.1"/></svg>
						<svg class="cross" width="70" height="70"><path d="m35,35l-9.3,-9.3"/><path d="m35,35l9.3,9.3"/><path d="m35,35l-9.3,9.3"/><path d="m35,35l9.3,-9.3"/></svg>
					</div><!-- /progress-button -->
				</div>
			</section>
		</div>--%>
                   <asp:Button CssClass="progress-button" OnClientClick="return UpdateUserValidation()" ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                </td>
                <td><asp:Label ID="lbl_message" runat="server"></asp:Label></td>
            </tr>
        </table>
        
            <%--</ContentTemplate>--%>
    <%--</asp:UpdatePanel>--%>       
</div>
       </div></section>

        
        <uc1:bottom runat="server" ID="bottom" />
        <footer id="footer" style="border-top:thick 5px rgba(248, 78, 203, 0.72);" class="midnight-blue">
            <uc1:footer runat="server" ID="footer1" />
    </footer><!--/#footer-->

        <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.prettyPhoto.js"></script>
    <script src="../js/jquery.isotope.min.js"></script>
    <script src="../js/main.js"></script>
    <script src="../js/wow.min.js"></script>

    </form>
</body>
</html>
