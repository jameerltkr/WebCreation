using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
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
            lbl_message.Text = "";
            MembershipCreateStatus createStatus;
            MembershipUser user = System.Web.Security.Membership.CreateUser(Tname.Text, Tpassword.Text, Temail.Text, ddlsecurityQ.SelectedItem.Text, TAnswer.Text, true, out createStatus);
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    clear();
                    lbl_message.Text = "Please wait...";
                    Button1.Enabled = false;
                    System.Threading.Thread.Sleep(500);
                    Response.Redirect("~/Home.aspx");
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    lbl_message.ForeColor = Color.Red;
                    lbl_message.Text = "The user with the same UserName already exists!";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    lbl_message.ForeColor = Color.Red;
                    lbl_message.Text = "The user with the same email address already exists!";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    lbl_message.ForeColor = Color.Red;
                    lbl_message.Text = "The email address you provided is invalid.";
                    break;
                //This Case Occured whenver we send empty data or Invalid Data
                case MembershipCreateStatus.InvalidAnswer:
                    lbl_message.ForeColor = Color.Red;
                    lbl_message.Text = "The security answer was invalid.";
                    break;
                // This Case Occured whenver we supplied weak password
                case MembershipCreateStatus.InvalidPassword:
                    lbl_message.ForeColor = Color.Red;
                    lbl_message.Text = "The password you provided is invalid. It must be 7 characters long and have at least 1 special character.";
                    break;
                default:
                    lbl_message.ForeColor = Color.Red;
                    lbl_message.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }
           // Account ac = new Account();
           // string userid = Guid.NewGuid().ToString();
           // string guid = Guid.NewGuid().ToString();
           // string name = Tname.Text.Trim();
           // string email = Temail.Text.Trim();
           // string passwordold = Tpassword.Text.Trim();
           // string password = System.Web.Security.Membership.GeneratePassword(9, 1);

           // StringBuilder final_pass = new StringBuilder();
           // using (RijndaelManaged myRijndael = new RijndaelManaged())
           // {

           //     myRijndael.GenerateKey();
           //     myRijndael.GenerateIV();
           //     byte[] key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
           //     byte[] iv = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
           //     byte[] encrypted =Hash_Pass.EncryptStringToBytes(passwordold, key, iv);

                

           //     var date = DateTime.Now;
           //     var date2 = date.Date.ToString("ddMMyyyy");
           //     // s.Append(date2);
           //     foreach (byte item in encrypted)
           //     {
           //         final_pass.Append(item.ToString("X2"));
           //     }
           // }
            

           //// password = Hash_Pass.EncryptText(password);
           // string gender = Rblgender.Text.Trim();
           // string s_ques = ddlsecurityQ.Text.Trim();
           // string s_ans = TAnswer.Text.Trim();
           // string dob = Tdob.Text.Trim();
           // string mobileno = Tmobile.Text.Trim();
           // string country = ddlcountry.Text.Trim();
           // string city = Tcity.Text.Trim();
           // string address = Taddress.Text.Trim();
           // string msg1 = ac.Register_Post(guid, final_pass.ToString(), 0, "user", 0, 0);
           // string msg = ac.Register(userid, guid, name, email, gender, s_ques, s_ans, dob, mobileno, country, city, address,DateTime.Now.ToString());
           // //Response.Write(msg);
           // clear();
           // if (msg.Contains(Constants.SUCCESS)&&msg1.Contains(Constants.SUCCESS))
           // {
           //     //Email_Helper.SendMail("jameer@mailinator.com", "", "", "hi", "hello jameerr");
           //     Response.Redirect("~/home.aspx");
           // }
           // else
           // {
           //     Response.Write(Constants.ERROR);
           // }
            
        }
        catch (Exception ex)
        {
            Response.Write("Error : " + ex.Message);
        }






        //try
        //{

        //    if (CheckBox1.Checked == true)
        //    {

        //        if (ddlcountry.SelectedIndex == 0)
        //        {
        //            Label3.Text = "Pls select Country..";
        //            Label1.Text = "";
        //        }

        //        else if (ddlsecurityQ.SelectedIndex == 0)
        //        {
        //            Label2.Text = "Pls select Ques!!!!";
        //            Label1.Text = "";
        //        }
        //        else
        //        {
        //            string name = Tname.Text.Trim();
        //            string email = Temail.Text.Trim();
        //            string password = Tpassword.Text.Trim();
        //            string gender = Rblgender.Text.Trim();
        //            string s_ques = ddlsecurityQ.Text.Trim();
        //            string s_ans = TAnswer.Text.Trim();
        //            string dob = Tdob.Text.Trim();
        //            string mobileno = Tmobile.Text.Trim();
        //            string country = ddlcountry.Text.Trim();
        //            string city = Tcity.Text.Trim();
        //            string address = Taddress.Text.Trim();

        //            c.Registration(name, email, password, gender, s_ques, s_ans, dob, mobileno, country, city, address);
        //            //Label1.Text = "Registration Done!!!";
        //            //Label1.ForeColor = System.Drawing.Color.Green;
        //            Response.Redirect("home.aspx");
        //            clear();

        //        }
        //    }
        //    else
        //    {
        //        Label1.Text = "Pls Read Terms && Cond.";
        //        Label1.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

        //catch (Exception ex)
        //{

        //    Label1.ForeColor = System.Drawing.Color.Red;
        //    Label1.Text = ex.Message;
        //}
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