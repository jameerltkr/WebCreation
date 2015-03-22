using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace generate_page_runtime {
    public partial class first : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            output.Text = "Our new page";
        }
        private void LoadCategories()
        {
           // allCategories = GetAllCategories();
            rptCategories.DataSource = GetCategories();
            rptCategories.DataBind();
        }
        private DataTable GetCategories()
        {
        SqlConnection connection = new SqlConnection("Data Source=NITESH;Initial Catalog=TestDB;Integrated Security=SSPI");
        SqlCommand selectCommand = new SqlCommand("SELECT ID,CategoryName FROM Categories WHERE ParentCategoryID=0", connection);
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return dt;
        }
        private DataTable GetAllCategories()
        {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand selectCommand = new SqlCommand("SELECT ID,CategoryName FROM Categories", connection);
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        return dt;
        }
        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
              //  if (allCategories != null)
                {
                    DataRowView drv = e.Item.DataItem as DataRowView;
                    string ID = drv["ID"].ToString();
                  //  DataRow[] rows = allCategories.Select("ParentCategoryID=" + ID, "Name");
                    if (rows.Length > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<ul>");
                        foreach (var item in rows)
                        {
                            sb.Append("<li><a href='#'>" + item["CategoryName"] + "</a></li>");
                        }
                        sb.Append("</ul>");
                        (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
                    }
                }
            }
        }
           
       protected void btn_edit_header_Click(object sender, EventArgs e)
       {
          header.Attributes["class"]="header"+" "+"select";
          btn_edit_header.Visible = false;
          btn_save_header.Visible = true;
          div_add_menu.Attributes["class"] = "center";
          div_add_menu.Attributes["style"] = "display : block";
       }
           
       protected void btn_edit_body_Click(object sender, EventArgs e)
       {
          body.Attributes["class"] = "container"+" "+"select";
          btn_edit_body.Visible = false;
          btn_save_body.Visible = true;
       }
           
       protected void btn_edit_footer_Click(object sender, EventArgs e)
       {
          footer.Attributes["class"] = "footer"+" "+"select";
          btn_edit_footer.Visible = false;
          btn_save_footer.Visible = true;
       }
       
       protected void btn_save_header_Click(object sender, EventArgs e)
       {
          header.Attributes["class"]="header";
          btn_edit_header.Visible = true;
          btn_save_header.Visible = false;
          div_add_menu.Attributes["class"] = "center";
          div_add_menu.Attributes["style"] = "display : none";
       }
       
       protected void btn_save_body_Click(object sender, EventArgs e)
       {
          body.Attributes["class"] = "container";
          btn_edit_body.Visible = true;
          btn_save_body.Visible = false;
       }
       
       protected void btn_save_footer_Click(object sender, EventArgs e)
       {
          footer.Attributes["class"] = "footer";
          btn_edit_footer.Visible = true;
          btn_save_footer.Visible = false;
       }
       protected void img_edit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
       {
           hl_save.Visible = true;
       }
       protected void img_edit2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
       {
       }
       protected void img_edit3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
       {
           
       }
       protected void hl_save_Click(object sender, EventArgs e)
       {
           hl_save.Visible = false;
           img_edit.Attributes["style"] = "display : block";
       }

      
}
}
