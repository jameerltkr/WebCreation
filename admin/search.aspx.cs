using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_search : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            string q_str = Request.QueryString["str"];
          
           var q1 = c.search_data(q_str);
           GridView1.DataSource = q1;
           GridView1.DataBind();
        }

    }
}