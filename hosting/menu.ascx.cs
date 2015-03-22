using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hosting_menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Request.IsAuthenticated)
            {
              //  Response.Redirect("~/login.aspx");
            }
            else
            {

            }
//            string ipadress = Dns.GetHostEntry(Dns.GetHostName())
//.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork)
//.ToString();
//            Response.Write(ipadress);
        }
        catch (Exception)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
    
}