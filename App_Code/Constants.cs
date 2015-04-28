using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
public class Constants
{
	public Constants()
	{
		
	}

    // created to access from other files 
    public const string SUCCESS = "Success";
    public const string ERROR = "Error";
    public class Session
    {
        public const string USERNAME = "Username";
        public const string ID = "Id";
        public const string PASSWORD = "Password";
    }
    public class Login
    {
        public const string ERROR = "Invalid Email or Password!";
        public const string SUCCESS = "Login Successful!";
    }
    public const string WEBSITE_ALREADY_EXIST = "This website is already exist. Please choose another name!";
    public const string ENTER_WEBSITE_NAME = "Please choose a website name.";
    public const string WEBSITE_NAME = "Website Name";
    public const string PAGE_CREATED = "Page Created";
}