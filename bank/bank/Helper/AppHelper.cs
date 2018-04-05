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

        public static string CurrentLayout
        {
            get => HttpContext.Current.Session["layout"] as string;
            set
            {
                HttpContext.Current.Session["layout"] = value;
            }
        }
    }
}