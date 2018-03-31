using bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace bank.Helper
{
    public static class AppHelper
    {
        public static LogIn CurrentUser
        {
            get => HttpContext.Current.Session["user"] as LogIn;
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }
    }
}