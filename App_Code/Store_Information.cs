using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Store
/// </summary>
public class StoreInformation
{
    MyProjectDataContext db = new MyProjectDataContext();
    public StoreInformation()
	{
        
	}
    public string Register_Success(UserModel model)
    {
        if (model != null)
        {
            Membership m = new Membership();
            m.Password = model.Password;

            m.UserId = model.UserId;
            m.PasswordFailedAttempt = model.PasswordFailedAttempt;
            m.Role = model.Role;
            m.isSuperAdmin = model.isSuperAdmin;
            m.isRejected = model.isRejected;
            db.Memberships.InsertOnSubmit(m);
            db.SubmitChanges();
            return Constants.SUCCESS;
        }
        else
            return Constants.ERROR;
    }
    public string Register(MembershipModel model)
    {
        if (model != null)
        {
            Registration r = new Registration();
            r.UserId = model.UserId;
            r.GuidId = model.GuidId;
            r.email = model.Email;
            r.name = model.Name;
            r.gender = model.Gender;
            r.a_ques = model.SecurityQues;
            r.s_ans = model.SecurityAns;
            r.dob = model.DOB;
            r.mobile = model.MobileNo;
            r.country = model.Country;
            r.city = model.City;
            r.address = model.Address;
            r.DateTime = model.DateTime;
            db.Registrations.InsertOnSubmit(r);
            db.SubmitChanges();
            return Constants.SUCCESS;
        }
        else
            return Constants.ERROR;
        

    }

    //public IEnumerable<Membership> Get_Value(string email, string pass)
    //{
    //    List<UserModel> lst_user_model = null;
    //    var? a = (from o in db.Memberships
    //              join r in db.Registrations
    //              on o.UserId equals r.GuidId
    //              select new {
    //                  o.Password,
    //                  o.isSuperAdmin,
    //                  o.isRejected,
    //                  o.Role,
    //                  o.UserId,
    //              });
    //    return a;
                  
    //  //  return lst_user_model;
    //}
}