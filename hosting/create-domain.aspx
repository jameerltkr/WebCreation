<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create-domain.aspx.cs" Inherits="hosting_create_domain" %>

<%@ Register Src="~/hosting/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/bottom.ascx" TagPrefix="uc1" TagName="bottom" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style5.css" rel="stylesheet" />
    <link href="../css/site.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <link href="../css/animate.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/responsive.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/component.css" />
    <script src="https://code.jquery.com/jquery-2.1.3.js"></script>
		<script src="js/modernizr.custom.js"></script>
    <style>
        .dropdown-background{
            background-color:rgba(239, 227, 245, 0.73);
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#img_hide").click(function () {
                $("#error").hide();
            });
        });
       
    </script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type='text/javascript'>


        $(function () {

            try {

                opera.setOverrideHistoryNavigationMode('compatible');
                history.navigationMode = 'compatible';
            } catch (e) { }


            function ReturnMessage() {
                return "wait";
            }



            function UnBindWindow() {
                $(window).unbind('beforeunload', ReturnMessage);
            }




            $(window).bind('beforeunload', ReturnMessage);

        });
    </script>
</head>
<body onsubmit="formSubmit()">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
        <uc1:menu runat="server" ID="menu" />
    </div>
        <section id="feature" >
        <div class="container wow fadeInDown fill" data-wow-duration="1000ms" data-wow-delay="600ms">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnl_error" Visible="false" runat="server">
                <div class="error">
                    <asp:Label ID="lbl_domain_creation_error" runat="server"></asp:Label>
                    <asp:ImageButton runat="server" CssClass="error-image" ID="img_error_hide" OnClick="img_error_hide_Click" ImageUrl="~/images/cancel-button.png" />
                    <%--<img src="../images/cancel-button.png"  id="img_hide"/>--%>
                </div>
            </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            <div class="create_domain_menu">

                <div class="main-content">
                 <div class="margin-from-top">

                 </div>
                                    
                <h2>Create a free domain name...</h2>
                <br />
                <span>Username:</span>
                <asp:TextBox runat="server" ID="txt_user_name" CssClass="less_width form-control input-control-background"></asp:TextBox>
                
                <span>Choose server name:</span>
                <asp:DropDownList runat="server" ID="ddl_choose_server" class="dropdown-background" CssClass="input-control form-control ">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Value="webcreation.com">webcreation.com (Free)</asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Button ID="btn_create_domain" runat="server" CssClass="create-domain-btn" Text="Create Now" OnClick="btn_create_domain_Click" />
                </div>
            </div>
            <div class="right-image">
                <img src="" />
            </div>
        </div>
        </section>
       
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
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script src="../js/jquery.dropdown.js"></script>
		<script type="text/javascript">

		    $(function () {

		        $('#cd-dropdown').dropdown({
		            gutter: 5,
		            stack: false,
		            slidingIn: 100
		        });

		    });

		</script>

    </form>
</body>
</html>
