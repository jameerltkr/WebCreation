using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class registration : System.Web.UI.Page
{
    datalayer c = new datalayer();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (CheckBox1.Checked == true)
            {

                if (ddlcountry.SelectedIndex == 0)
                {
                    Label3.Text = "Pls select Country..";
                    Label1.Text = "";
                }

                else if (ddlsecurityQ.SelectedIndex == 0)
                {
                    Label2.Text = "Pls select Ques!!!!";
                    Label1.Text = "";
                }
                else
                {
                    string name = Tname.Text.Trim();
                    string email = Temail.Text.Trim();
                    string password = Tpassword.Text.Trim();
                    string gender = Rblgender.Text.Trim();
                    string s_ques = ddlsecurityQ.Text.Trim();
                    string s_ans = TAnswer.Text.Trim();
                    string dob = Tdob.Text.Trim();
                    string mobileno = Tmobile.Text.Trim();
                    string country = ddlcountry.Text.Trim();
                    string city = Tcity.Text.Trim();
                    string address = Taddress.Text.Trim();

                    c.Registration(name, email, password, gender, s_ques, s_ans, dob, mobileno, country, city, address);
                    Label1.Text = "Registration Done!!!";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    clear();

                }
            }
            else
            {
                Label1.Text = "Pls Read Terms && Cond.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        catch (Exception ex)
        {

            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = ex.Message;
        }
    }
    void clear()
    {
        Tname.Text = Tpassword.Text = Tconfirmpassword.Text =
     TAnswer.Text = Taddress.Text = Temail.Text = Tdob.Text = Tcity.Text = Tmobile.Text = "";
        ddlsecurityQ.ClearSelection();
        ddlcountry.ClearSelection();
        Rblgender.ClearSelection();
        CheckBox1.Checked = false;
        Label2.Text = "";
        Label3.Text = "";

    }
}