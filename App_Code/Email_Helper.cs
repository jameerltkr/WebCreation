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
	public Email_Helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool SendMail(string To, string cc, string bcc, string subject, string body)
    {
        try
        {
            MailMessage Msg = new MailMessage();
            if (!String.IsNullOrEmpty(To))
            {
                Msg.To.Add(To);
            }
            if (!String.IsNullOrEmpty(cc))
            {
                Msg.CC.Add(cc);
            }
            if (!String.IsNullOrEmpty(bcc))
            {
                Msg.CC.Add(bcc);
            }

            Msg.Subject = subject;
            Msg.Body = body;
            Msg.IsBodyHtml = true;
            var smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["DefaultEmailHost"].ToString();
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["DefaultFromAddress"].ToString(), ConfigurationManager.AppSettings["EmailPassword"].ToString());
            Msg.From = new MailAddress("mail4@laitkor.com", "noreply@creditornet.com");
            smtp.Timeout = 20000;
            smtp.Send(Msg);
        }
        catch
        {
        }

        return true;

        //rest code

    }
}