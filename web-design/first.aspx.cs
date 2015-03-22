using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace generate_page_runtime {
    public partial class first : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            output.Text = "Our new page";
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
