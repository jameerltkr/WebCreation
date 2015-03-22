using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adp = new SqlDataAdapter();
   /////// DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cmd.Connection = con;
            con.Open();
            //Response.Write("jammer");
            cmd.CommandText = "update HostLoginStatus set EndTime='"+DateTime.Now.TimeOfDay.ToString()+"' where ID=(select top 1 id from HostLoginStatus order by id desc)";
            cmd.ExecuteNonQuery();
            con.Close();
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            
        }
        catch
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        System.Web.Security.FormsAuthentication.SignOut();
        Session.Abandon();
        Session.Clear();
        Response.Redirect("login.aspx");
    }
}