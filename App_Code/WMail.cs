using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WMail
/// </summary>
public class WMail
{
    private static string GetBody(string Path)
    {
        StreamReader _reader = new StreamReader(Path);
        try
        {
            string _builder = _reader.ReadToEnd();
            return _builder;
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message);
        }
        finally
        {
            _reader.Dispose();
        }
    }
    public bool Send(string toaddress, string cc, string bcc,string username ,string password , string activateurl, string website_url, string web_design_url, string hosting_url, string help_url, string contact_address)
	{
        try
        {
            string subject = "User Registration [Web Creation Inc.]";
            string templatepath = HttpContext.Current.Server.MapPath("~/Email-Template/UserRegistration.html");
            string body = GetBody(templatepath);
            body = body.Replace("#username", username);
            body = body.Replace("#password", password);
            body = body.Replace("#activate_url", activateurl);
            body = body.Replace("#website_url", website_url);
            body = body.Replace("#web_design_url", web_design_url);
            body = body.Replace("#hosting_url", hosting_url);
            body = body.Replace("#help_url", help_url);
            body = body.Replace("#contact_address", contact_address);


            Email_Helper email = new Email_Helper();
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toaddress);
            mail.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("From"));
            mail.Subject = string.Format(subject);
            mail.Body = string.Format(body);
            mail.IsBodyHtml = true;
            email.SendMail(mail);
            return true;
        }
        catch
        {
            return false;
        }
	}
}