using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hosting_main : System.Web.UI.Page
{
    datalayer dl = new datalayer();
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adp = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cmd.Connection = con;
            if (Session[Constants.Session.ID].ToString() != "")
            {
                var id = Session[Constants.Session.ID].ToString();
                var q = dl.retrieve_domain_info(id);
                if (q.Any())
                {
                    foreach (var a in q)
                    {
                        if (a.DomainName != null)
                        {
                            lbl_domain_name.Text = a.DomainName;
                            adp = new SqlDataAdapter("select top 1 * from HostLoginStatus where id not in (select top 1 id from HostLoginStatus order by id desc) order by id desc", con);
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0].ItemArray[7].ToString() == Session[Constants.Session.ID].ToString())
                                {
                                    lbl_last_login_IP.Text = dt.Rows[0].ItemArray[2].ToString();



                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("~/hosting/create-domain.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/hosting/create-domain.aspx");
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }
        catch (Exception)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/login.aspx");
            }
            //Response.Redirect("~/login.aspx");
        }
    }
}