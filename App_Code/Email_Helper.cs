using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Email_Helper
/// </summary>
public class Email_Helper
{
    public void SendMail(MailMessage mail)
    {
        try
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings.Get("Host");
            smtp.Port = int.Parse(ConfigurationManager.AppSettings.Get("Port"));
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("UserName"), ConfigurationManager.AppSettings.Get("Password"));
            smtp.EnableSsl = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);
        }
        catch
        {
        }

        //rest code

    }
}