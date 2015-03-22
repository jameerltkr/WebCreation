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
}