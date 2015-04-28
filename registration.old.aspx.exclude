<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.old.aspx.cs" Inherits="registration" %>

<%@ Register Src="~/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/animate.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
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
</head>
<body>
    <form id="form2" runat="server">

         <div>
             <uc1:menu runat="server" ID="menu" />
    </div>
    <section id="feature" >
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <div style="margin-left:20%; width:50%; padding-left:15px; border-radius:7px;box-shadow:4px 4px 4px 0px rgba(0,0,0,0.3); background:linear-gradient(rgba(178, 246, 152, 0.44),rgba(182, 146, 177, 0.45))">
    
    
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
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Email Id(loginId)</td>
                <td>
                    <asp:TextBox ID="Temail" CssClass="textbox form-control" runat="server" TextMode="Email"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="Tpassword" runat="server" CssClass="textbox form-control" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox ID="Tconfirmpassword" runat="server" CssClass="textbox form-control" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButtonList ID="Rblgender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
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
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Your Answer</td>
                <td>
                    <asp:TextBox ID="TAnswer" runat="server" CssClass="textbox form-control"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Date Of Birth</td>
                <td>
                    <asp:TextBox ID="Tdob" runat="server" TextMode="Date" CssClass="textbox form-control"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Mobile No.</td>
                <td>
                    <asp:TextBox ID="Tmobile" runat="server" CssClass="textbox form-control"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
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
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="Tcity" runat="server" CssClass="textbox form-control" ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="Taddress" runat="server" Height="67px" CssClass="textbox form-control" TextMode="MultiLine" Width="198px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Type The Code</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
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
                   <asp:Button CssClass="progress-button " ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
               
</div>
       </div></section>
        
   <section id="bottom">
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <div class="widget">
                        <h3>Company</h3>
                        <ul>
                            <li><a href="#">About us</a></li>
                            <li><a href="#">Copyright</a></li>
                            <li><a href="#">Terms of use</a></li>
                            <li><a href="#">Privacy policy</a></li>
                            <li><a href="#">Contact us</a></li>
                        </ul>
                    </div>    
                </div><!--/.col-md-3-->

                <div class="col-md-3 col-sm-6">
                    <div class="widget">
                        <h3>Support</h3>
                        <ul>
                            <li><a href="#">Faq</a></li>
                            <li><a href="#">Blog</a></li>
                            <li><a href="#">Forum</a></li>
                            <li><a href="#">Hosting</a></li>
                            <li><a href="#">web designing</a></li>
                        </ul>
                    </div>    
                </div><!--/.col-md-3-->

                <div class="col-md-3 col-sm-6">
                    <div class="widget">
                        <h3>Developers</h3>
                        <ul>
                            <li><a href="#">Web Development</a></li>
                            <li><a href="#">Web hosting</a></li>
                            <li><a href="#">Theme</a></li>
                            <li><a href="#">Development</a></li>
                            <li><a href="#">Template creation</a></li>
                        </ul>
                    </div>    
                </div><!--/.col-md-3-->

                <div class="col-md-3 col-sm-6">
                    <div class="widget">
                        <h3>My Other Sites</h3>
                        <ul>
                            <li><a href="http://about.me/jimcute" title="Click to see about myself" target="_blank">About me</a></li>
                            <li><a href="http://jimcute.wordpress.com" title="My blogging place where my blogs are up to date." target="_blank">My blogging place</a></li>
                            <li><a href="http://sizeby100.wordpress.com" title="Blogging site for sizeby100.com" target="_blank">SizeBy100</a></li>
                            <li><a href="http://jimcute.somee.com" title="My class database" target="_blank">Faddoo engineers</a></li>
                        </ul>
                    </div>    
                </div><!--/.col-md-3-->
            </div>
        </div>
    </section>
    <footer id="footer" style="border-top:thick 5px rgba(248, 78, 203, 0.72);" class="midnight-blue">
        <uc1:footer runat="server" ID="footer2" />
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











		
		<!-- /container -->
		<script src="js/classie.js"></script>
		<script src="js/uiProgressButton.js"></script>
		
