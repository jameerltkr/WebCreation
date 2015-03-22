using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{
    public Message()
    { 

    }
    public System.Web.UI.HtmlControls.HtmlGenericControl Error(string message)
    {
        HtmlGenericControl errorDiv = new HtmlGenericControl("div");
        errorDiv.Attributes["class"] = "error-div";
        errorDiv.InnerHtml = message;
        return errorDiv;
    }
}