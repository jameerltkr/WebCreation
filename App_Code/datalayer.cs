using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Web.Services;
using System.Web.Script.Services;
public class datalayer
{
  public  MyProjectDataContext da = new MyProjectDataContext("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
  public void DoRegistration(string username, string email, string pass)
  {
      Registration rg = new Registration();
      rg.name = username;
      rg.email = email;
     // rg.password = pass;
      da.Registrations.InsertOnSubmit(rg);
      da.SubmitChanges();
  }
    public void Registration(string name,string email,string password,string gender,string s_ques,string s_ans,string dbbirth,string mobile,string country,string city,string address)
    {
        Registration rg = new Registration();
        rg.name = name;
        rg.email = email;
     //   rg.password = password;
        rg.gender = gender;
        rg.a_ques = s_ques;
        rg.s_ans = s_ans;
        rg.dob = dbbirth;
        rg.mobile = mobile;
        rg.country = country;
        rg.city = city;
        rg.address = address;
        da.Registrations.InsertOnSubmit(rg);

        logindetail lg = new logindetail();
        lg.name = name;
        lg.password = password;
        lg.email = email;
        lg.s_ques = s_ques;
        lg.s_ans = s_ans;
        lg.u_type = "user";
        da.logindetails.InsertOnSubmit(lg);

        ImageDetail img1 = new ImageDetail();
        img1.UserID = email;
        img1.Imagename = "";
        img1.ImagePath = "";
        da.ImageDetails.InsertOnSubmit(img1);

        da.SubmitChanges();
    }

    public IEnumerable<logindetail> login(string id)
    {
        var q = from a in da.logindetails
                where a.email == id
                select a;
        return q;
    }
    public IEnumerable<Registration> PersonalInfo(string id)
    {
        var q = from a in da.Registrations
                where a.email == id
                select a;
        return q;
    }
    public int update_Personal_info(string u,string name,string dob,string mobile,string country,string city,string address)

    {
        var q = from a in da.Registrations
                where a.email == u
                select a;
        if(q.Any())
        {
            foreach(Registration k in q)
            {
                k.name = name;
                k.dob = dob;
                k.mobile = mobile;
                k.country = country;
                k.city = city;
                k.address = address;
            }
            da.SubmitChanges();
            return 0;
        }
        else
        {
            return 1;
        }
        
    }
    public void UploadPropilepic(string u,string iname,string ipath)
    {
        var q = from a in da.ImageDetails
                where a.UserID == u
                select a;
        foreach(ImageDetail k in q)
        {
            k.Imagename = iname;
            k.ImagePath = ipath;
        }
        da.SubmitChanges();
    }
    public string getimge(string u)
    {
        var q = from a in da.ImageDetails
                where a.UserID == u
                select a;
        string imgdata = "";
        foreach(ImageDetail k in q)
        {
            imgdata = k.ImagePath;
        }
        return imgdata;
    }
    public void Compose(string sender,string rece,string subject,string message,string attachment)
    {
        Msgdetail msg = new Msgdetail();
        msg.sender1 = sender;
        msg.rece = rece;
        msg.subject = subject;
        msg.message = message;
        msg.attachment = attachment;
        msg.date1 = DateTime.Now.ToShortDateString();
        msg.Time1 = DateTime.Now.ToShortTimeString();
        msg.draft = "1";
        da.Msgdetails.InsertOnSubmit(msg);
        da.SubmitChanges();
    }
    public void draft(string sender, string rece, string subject, string message, string attachment)
    {
        Msgdetail msg = new Msgdetail();
        msg.sender1 = sender;
        msg.rece = rece;
        msg.subject = subject;
        msg.message = message;
        msg.attachment = attachment;
        msg.date1 = DateTime.Now.ToShortDateString();
        msg.Time1 = DateTime.Now.ToShortTimeString();
        msg.draft = "0";
        da.Msgdetails.InsertOnSubmit(msg);
        da.SubmitChanges();
        
    }
    public IEnumerable<Msgdetail> inbox(string id)
    {
        var q = from a in da.Msgdetails
                where a.rece == id && a.draft == "1"
                select a;
        return q;
    }
    public IEnumerable<Msgdetail> sentbox(string id)
    {
        var q = from a in da.Msgdetails
                where a.sender1 == id && a.draft == "1"
                select a;
        return q;
    }
    public IEnumerable<Msgdetail> userdraft(string id)
    {
        var q = from a in da.Msgdetails
                where a.sender1 == id && a.draft == "0"
                select a;
        return q;

    }
    public IEnumerable<Msgdetail> showMailData(string msgid)
    {
        var q = from a in da.Msgdetails
                where a.msgid == Convert.ToInt32(msgid)
                select a;
        return q;
    }
    public IEnumerable<Registration> search_data(string s)
    {
        var q = from a in da.Registrations
                //where a.Id==s
                where a.email.Contains(s) || a.dob.Contains(s) || a.name.Contains(s)
                || a.city.Contains(s) || a.country.Contains(s)
                select a;
        return q;
    }
    public void CreateSubDomain( string user_name, string domain_name,string email,string server_name)
    {
        HostingLogin hl = new HostingLogin();
        hl.DomainName = domain_name;
        hl.Email = email;
        hl.ServerName = server_name;
        hl.UserName = user_name;
        da.HostingLogins.InsertOnSubmit(hl);
        da.SubmitChanges();
    }
    public IEnumerable<HostingLogin> retrieve_domain_info(string email)
    {
        var q = from a in da.HostingLogins
                where a.Email == email
                select a;
        return q;
    }
    public void Store_Info_Host_Status(string username, string loginIP, string start_time, string end_time, string time_duration,string date,string email)
    {
        HostLoginStatus hls = new HostLoginStatus();
        hls.EndTime = end_time;
        hls.Date = date;
        hls.LastLoginIP = loginIP;
        hls.StartTime = start_time;
        hls.Email = email;
        hls.TimeDuration = time_duration;
        hls.UserName = username;
        da.HostLoginStatus.InsertOnSubmit(hls);
        da.SubmitChanges();
    }
    public IEnumerable<HostLoginStatus> Retrieve_Host_Info(string email)
    {
        var q = from a in da.HostLoginStatus
                where a.Email == email
                select a;
        return q;
    }
    //public System.Data.Linq.ISingleResult<HostLoginStatus> retrieve_second_row()
    //{
    //    var q=da.proc_retrieve_second_row();
    //    return q;
    //}




    public string SaveWebsite(string username, string websitename,Guid userid)
    {
        string msg;
        try
        {
            var q = GetWebsiteName(websitename,userid);
            if (q.Any())
            {
                msg = Constants.WEBSITE_ALREADY_EXIST;
                return msg;
            }
            else
            {
                BodyContent bd = new BodyContent();
                bd.UserName = username;
                bd.WebsiteName = websitename;
                bd.UserId = userid;
                da.BodyContents.InsertOnSubmit(bd);
                da.SubmitChanges();
                msg = Constants.SUCCESS;
                return msg;
            }
            
        }
        catch
        {
            msg = Constants.ERROR;
            return msg;
        }
    }
    public IEnumerable<BodyContent> GetWebsiteName(string name,Guid userid)
    {
        var q = from a in da.BodyContents
                where a.WebsiteName == name&&a.UserId==userid
                select a;
        return q;
    }
    public bool SavePages(Guid userid, string username, string pagename, string websitename)
    {
        SubPage sp = new SubPage();
        sp.userid = userid;
        sp.PageName = pagename;
        sp.UserName = username;
        sp.WebsiteName = websitename;
        try
        {
            da.SubPages.InsertOnSubmit(sp);
            da.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public IEnumerable<BodyContent> Retrieve_Website_Name(string email,string websitename)
    {
        var q = from a in da.BodyContents
                where a.UserName == email && a.WebsiteName == websitename
                select a;
        return q;
    }
    public IEnumerable<BodyContent> Retrieve_Website(string username)
    {
        var q = from a in da.BodyContents
                where a.UserName == username
                select a;
        return q;
    }
    public IEnumerable<Page> Retrieve_Web_Pages(Guid userid,string websitename)
    {
        var q = from a in da.Pages
                where a.UserId == userid && a.WebsiteName == websitename
                select a;
        return q;
    }
    [WebMethod]
   // [ScriptMethod(UseHttpGet = false)]
    public string Delete_Website(Guid userid, string websitename)
    {
        string delete = "";
        var q = from a in da.BodyContents
                where a.UserId == userid && a.WebsiteName == websitename
                select a;
        foreach (var o in q)
        {
            da.BodyContents.DeleteOnSubmit(o);
        }
        try
        {
            da.SubmitChanges();
            delete = "deleted";
        }
        catch
        {
            delete = "error";
        }
        return delete;
    }
}