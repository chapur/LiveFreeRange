using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using LiveFreeRange.Common;

/// <summary>
/// Summary description for BasePage
/// </summary>
public abstract class BasePage : Page
{
    internal const string KEY_CURRENTUSER = "Current Logged in User";
    internal const string KEY_CURRENTORDER = "Current Order";
    internal const string KEY_NEWSLETTERBODY = "Newsletter Message Body";

    public string NewsletterBody
    {
        get
        {
            try
            {
                return (string)(Session[KEY_NEWSLETTERBODY]);
            }
            catch
            {
                return (null);
            }
        }
        set
        {
            if (value == null)
            {
                Session.Remove(KEY_NEWSLETTERBODY);
            }
            else
            {
                Session[KEY_NEWSLETTERBODY] = value;
            }
        }
    }

    public EndUser CurrentEndUser
    {
        get
        {
            try
            {
                return (EndUser)(Session[KEY_CURRENTUSER]);
            }
            catch
            {
                return (null); //for design time
            }
        }
        set
        {
            if (value == null)
            {
                Session.Remove(KEY_CURRENTUSER);
            }
            else
            {
                Session[KEY_CURRENTUSER] = value;
            }
        }
    }

    public Orders CurrentOrder
    {
        get
        {
            try
            {
                return (Orders)(Session[KEY_CURRENTORDER]);
            }
            catch
            {
                return (null);  // for design time
            }
        }

        set
        {
            if (value == null)
            {
                Session.Remove(KEY_CURRENTORDER);
            }
            else
            {
                Session[KEY_CURRENTORDER] = value;
            }
        }
    }

    public string UrlBaseSSL
    {
        get { return Request.Url.AbsoluteUri.Replace(@"http://", @"https://"); }
    }
}
