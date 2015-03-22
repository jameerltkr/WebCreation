using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserModel
/// </summary>
public class UserModel
{
    public string UserId { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string Password { get; set; }
    public int PasswordFailedAttempt { get; set; }

    public string Role { get; set; }
    public int isSuperAdmin { get; set; }
    public int isRejected { get; set; }
    
}
public class MembershipModel
{
    public string UserId { get; set; }
    public string GuidId { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string Name { get; set; }
    [Required(ErrorMessage="Required field",AllowEmptyStrings=false)]
    public string Gender { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string SecurityQues { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string SecurityAns { get; set; }
    public string DOB { get; set; }
    public string MobileNo { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string Country { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string City { get; set; }
    [Required(ErrorMessage = "Required field", AllowEmptyStrings = false)]
    public string Address { get; set; }
    public string DateTime { get; set; }
}