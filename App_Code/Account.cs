using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
	public Account()
	{
		
	}
    public string Register_Post(string userid,string password,int passwordfailedattempt,string role,int issuperadmin,int isrejected )
    {
        UserModel model = new UserModel();
        model.UserId = userid;
        model.Password = password;
        model.PasswordFailedAttempt = passwordfailedattempt;
        model.Role = role;
        model.isSuperAdmin = issuperadmin;
        model.isRejected = isrejected;
        StoreInformation s = new StoreInformation();
        s.Register_Success(model);
        return Constants.SUCCESS;
    }
    public string Register(string userId,string guid, string name,string email,string gender,string sec_ques,string sec_ans,string dob,string mobile,string country,string city,string address,string datetime)
    {
        string password = System.Web.Security.Membership.GeneratePassword(9, 1);
        Guid user_guid;
        MembershipModel model = new MembershipModel();

        model.UserId = userId;
        model.GuidId = guid;
        model.Email = email;
        model.Name = name;
        model.Gender = gender;
        model.SecurityQues = sec_ques;
        model.SecurityAns = sec_ans;
        model.DOB = dob;
        model.MobileNo = mobile;
        model.Country = country;
        model.City = city;
        model.Address = address;
        model.DateTime = datetime;
        StoreInformation s = new StoreInformation();
        string msg=s.Register(model);
        if (msg.Contains(Constants.SUCCESS))
        {
            return Constants.SUCCESS;
        }
        else
            return Constants.ERROR;
       // model.UserId = user_id;
        //model.Password = password;
    }
    public bool SaveActivationKey(Guid userid, Guid key)
    {
        MyProjectDataContext dbContext = new MyProjectDataContext();
        ActivateUser act = new ActivateUser();
        act.ActivationKey = key;
        act.Created = DateTime.Now;
        act.IsActivated = false;
        act.IsExpired = false;
        act.UserId = userid;
        try
        {
            dbContext.ActivateUsers.InsertOnSubmit(act);
            dbContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public IEnumerable<ActivateUser> ValidateKey(Guid key)
    {
        MyProjectDataContext dbContext=new MyProjectDataContext();
        var q = from a in dbContext.ActivateUsers
                where a.ActivationKey == key
                select a;
        return q;
    }
    public IEnumerable<ActivateUser> ActivationInfo(Guid key)
    {
        MyProjectDataContext dbcontex=new MyProjectDataContext();
        var q = from a in dbcontex.ActivateUsers
                where a.ActivationKey == key
                select a;
        return q;
    }
    public bool ActivateAccount(Guid key)
    {
        MyProjectDataContext dbContext = new MyProjectDataContext();
        ActivateUser act = new ActivateUser();
        var q = from a in dbContext.ActivateUsers
                where a.ActivationKey == key
                select a;
        foreach (var a in q)
        {
            a.IsActivated = true;
          //  a.IsExpired = true;
            try
            {
                dbContext.ActivateUsers.InsertOnSubmit(act);
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
    public bool IsActivated(Guid userid)
    {
        MyProjectDataContext dbContext=new MyProjectDataContext();
        var q = from a in dbContext.ActivateUsers
                where a.UserId == userid
                select a;
        foreach (var a in q)
        {
            if (a.IsActivated == true && a.IsExpired == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    public void DoExpire(Guid key)
    {
        MyProjectDataContext dbcontex = new MyProjectDataContext();
        var q = from a in dbcontex.ActivateUsers
                where a.ActivationKey == key
                select a;
        foreach (var a in q)
        {
            a.IsExpired = true;
        }
    }
}