using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for admin_management
/// </summary>
public class admin_management
{
    private MyProjectDataContext dbContext;
    public bool AddAdmin(Guid userid, string username)
    {
        dbContext = new MyProjectDataContext();
        string imgPath = "~/admin/dist/img/male-user.png";
        AdminProfile ap = new AdminProfile();
        ap.UserId = userid;
        ap.Username = username;
        ap.Created = DateTime.Now;
        ap.Updated = DateTime.Now;
        ap.UpdatedBy = username;
        ap.UserImgPath = imgPath;
        ap.Rejected = false;
        try
        {
            dbContext.AdminProfiles.InsertOnSubmit(ap);
            dbContext.SubmitChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return false;
    }
    public IEnumerable<SubPage> GetPages()
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.SubPages
                select a;
      //  dbContext.Connection.Close();
        return q;
    }
    public IEnumerable<BodyContent> GetWebsites()
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.BodyContents
                select a;
     //   dbContext.Connection.Close();
        return q;
    }
    public IEnumerable<aspnet_User> GetUsers()
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.aspnet_Users
                select a;
        return q;
    }
    public IEnumerable<AdminProfile> GetUserImage(Guid userid)
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.AdminProfiles
                where a.UserId == userid
                select a;
        return q;
    }
    public bool UpdateAdmin(Guid userid, string img_path, string username, string firstname, string lastname, string address, string city, string state, string country)
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.AdminProfiles
                where a.UserId == userid
                select a;
        if (q.Any())
        {
            AdminProfile ap = new AdminProfile();
            ap.Address = address;
            ap.City = city;
            ap.Country = country;
            ap.FirstName = firstname;
            ap.LastName = lastname;
            ap.State = state;
            ap.Updated = DateTime.Now;
            ap.UpdatedBy = username;
            ap.UserId = userid;
            ap.UserImgPath = img_path;
            ap.Username = username;
            try
            {
                dbContext.AdminProfiles.InsertOnSubmit(ap);
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
    public IEnumerable<SiteUser> GetTotalUsers()
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.SiteUsers
                select a;
        return q;
    }
    public bool SaveSiteUsers(string username, string firstname, string lastname, string email, string address, string city, string state, string country, string createdby, Guid creatorid, string password)
    {
        dbContext = new MyProjectDataContext();
        SiteUser su = new SiteUser();
        su.Address = address;
        su.City = city;
        su.Country = country;
        su.CreatedBy = createdby;
        su.CreatedOn = DateTime.Now;
        su.CreatorId = creatorid;
        su.Email = email;
        su.FirstName = firstname;
        su.IsDeleted = false;
        su.IsRejected = false;
        su.Lastname = lastname;
        su.Password = password;
        su.State = state;
        su.UpdatedOn = DateTime.Now;
        su.Username = username;
        try
        {
            dbContext.SiteUsers.InsertOnSubmit(su);
            dbContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
        return false;
    }
    public IEnumerable<SiteUser> Get_Site_Users(string username,Guid creatorid)
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.SiteUsers
                where a.Username == username && a.CreatorId == creatorid
                select a;
        return q;
    }
    public IEnumerable<SiteUser> GetAllSiteUsers()
    {
        dbContext = new MyProjectDataContext();
        var q = from a in dbContext.SiteUsers
                select a;
        return q;
    }
}