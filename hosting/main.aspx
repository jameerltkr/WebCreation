<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="hosting_main" %>

<%@ Register Src="~/bottom.ascx" TagPrefix="uc1" TagName="bottom" %>
<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/web-design/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/hosting/menu.ascx" TagPrefix="uc2" TagName="menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
		<script src="js/modernizr.custom.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc2:menu runat="server" ID="menu" />
    </div>
        <br />
        <br />
        <section id="feature" >
        <div class="container wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
            <div class="">
                <div class="left-items">
                    <div class="left-inner">
                    <div class="heading">
                        <span>Notices</span>
                        <img src="../images/Free-Web-Hosting.jpg" height="250" width="372" style="margin-top:10px" />
                    </div>

                </div>
                <div class="left-innner-small">
                    <div class="heading">
                        <span>Find</span>
                    </div>
                    <input type="text" id="txt_find" name="txt_find" />
                    <label id="no_records">No records found.</label>
                </div>
                  <div class="left-innner-stats">
                    <div class="heading">
                        <span>Stats</span>
                    </div>
                      <div class="contents">
                          <label>
                            Main Domain
                          </label>
                          <span style="font-weight:bold;">
                            <asp:Label ID="lbl_domain_name" runat="server"></asp:Label>
                          </span>
                      </div>
                      <div class="contents-second">
                          <label>
                            Home Directory
                          </label>
                          <span style="font-weight:bold;">
                            <asp:Label ID="Label1" runat="server" Text="jimkhan.5gbfree.com"></asp:Label>
                          </span>
                      </div>
                      <div class="contents">
                          <label>
                            Last Login From
                          </label>
                          <span style="font-weight:bold;">
                            <asp:Label ID="lbl_last_login_IP" runat="server"></asp:Label>
                          </span>
                      </div>
                      <div class="contents-second">
                          <label>
                            CPU Used
                          </label>
                              <div class="skill progress_show">
                              <div class="progress-wrap">
                                  20 / 100 %
                            <div class="progress">
                                <div class="progress-bar color1" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 20%">
                              </div>
                            </div>
                          </div>
                              </div>
                          <%--<span style="font-weight:bold;">
                            <asp:Label ID="Label3" runat="server" Text="jimkhan.5gbfree.com"></asp:Label>
                          </span>--%>
                      </div>
                      <div class="contents">
                          <label>
                            Ivemem
                          </label>
                          <div class="skill progress_show">
                              <div class="progress-wrap">
                                  20 / 902.6 MB
                            <div class="progress">
                                <div class="progress-bar color1" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 2%">
                              </div>
                            </div>
                          </div>
                              </div>
                      </div>
                      <div class="contents-second">
                          <label>
                            Ivepmem
                          </label>
                          <div class="skill progress_show">
                              <div class="progress-wrap">
                                  20 / 902.6 MB
                            <div class="progress">
                                <div class="progress-bar color1" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 10%">
                              </div>
                            </div>
                          </div>
                              </div>
                      </div>
                      <div class="contents">
                          <label>
                            Disk Space Usage
                          </label>
                          <div class="skill progress_show">
                              <div class="progress-wrap">
                                  20 KB / 5 GB
                            <div class="progress">
                                <div class="progress-bar color1" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 1%">
                              </div>
                            </div>
                          </div>
                              </div>
                      </div>
                      <div class="contents-second">
                          <label>
                            Bandwidth Transfer / Month
                          </label>
                          <div class="skill progress_show" style="bottom:53px;">
                              <div class="progress-wrap">
                                  0 Bytes / 20 GB
                            <div class="progress">
                                <div class="progress-bar color1" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 0%">
                              </div>
                            </div>
                          </div>
                              </div>
                      </div>
                </div>
              </div>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Preferences</span>
                    </div>
                   
                   <div class="perform_operations">
                        <span>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/getting-started.jpg"  /><br />
                        Getting<br />Started<br />Wizard
                    </a>
                    </span>
                       <a href="#" class="operations">
                        <img src="../images/hosting-icon/change-password.png" /><br />
                        Change<br />Password
                    </a>
                       <a href="#" class="operations">
                        <img src="../images/hosting-icon/update-contact-information.png" /><br />
                        Update<br />Contact<br />Information
                    </a>
                       <a href="#" class="operations">
                        <img src="../images/hosting-icon/change-style.png" /><br />
                        Change<br />Style
                    </a>
                    <span>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/shortcut.png" /><br />
                        Shortcuts
                    </a>
                    </span>
                       <a href="#" class="operations">
                        <img src="../images/hosting-icon/change-language.png" /><br />
                        Change<br />Language
                    </a>

                   </div>
                </section>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Mail</span>
                    </div>
                    <div class="perform_operations">
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/email-account.png" /><br />
                        Email<br />Account
                    </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/web-mail.jpg" /><br />
                        Web<br />Mail
                    </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/user-level-filtering.jpg" /><br />
                        User<br />Level<br />Filtering
                    </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/user-authentication.jpg" /><br />
                        Email<br />Authentication
                    </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/create-email.jpg" /><br />
                        Create<br />Email<br />Wizard
                    </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/account-level-filtering.png" /><br />
                        Account<br />Level<br />Filtering
                    </a>
                    </div>
                    
                </section>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Files</span>
                    </div>
                    <div class="perform_operations">
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/file-manager.png" /><br />
                        File<br />Manager
                    </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/disk-space-uses.png" /><br />
                        Disk<br />Space<br />Uses
                    </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/ftp-accounts.jpg" /><br />
                        FTP<br />Accounts
                    </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/ftp-session-control.png" /><br />
                        FTP<br />Session<br />Control
                    </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/anonymous-ftp-control.jpg" /><br />
                        Anonymous<br />FTP
                    </a>
                    </div>
                    
                </section>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Backup and Security</span>
                    </div>
                    <div class="perform_operations">
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/ip-address-deny-manager.png" /><br />
                        IP Address<br />Deny<br />Manager
                        </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/hotlink-protection.jpg"/><br />
                        Hotlink<br />Protection
                        </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/create-backup.jpg" /><br />
                        Create<br />Backup
                        </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/restore-backup.jpg" /><br />
                        Restore<br />Backup
                        </a>
                    </div>
                </section>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Domains</span>
                    </div>
                    <div class="perform_operations">
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/subdomains.jpg" /><br />
                        Subdomains
                        </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/addon-domains.png"/><br />
                        Addon<br />Domains
                        </a>
                    <a href="#" class="operations">
                        <img src="../images/hosting-icon/redirects-domains.png" /><br />
                        Redirects
                        </a>
                        </div>
                </section>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Databases</span>
                    </div>
                    <div class="perform_operations">
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/mssql.png" /><br />
                        MSSQL<br />Database
                        </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/mssql-wizard.png" /><br />
                        MSSQL<br />Database<br />Wizard
                        </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/remote-mssql.png" /><br />
                        Remote<br />MSSQL
                        </a>
                    </div>
                </section>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Web Appilcations</span>
                    </div>
                    <div class="perform_operations">
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/mvc.png"/><br />
                        MVC
                        </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/asp.net.jpg" /><br />
                        ASP.Net
                        </a>
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/remote-mssql.png" /><br />
                        Remote<br />MSSQL
                        </a>
                    </div>
                </section>
                <section class="hosting_option">
                    <div class="heading">
                        <span>Advanced</span>
                    </div>
                    <div class="perform_operations">
                        <a href="#" class="operations">
                        <img src="../images/hosting-icon/error-pages.png" /><br />
                        Error<br />Pages
                        </a>
                    </div>
                </section>
                
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
