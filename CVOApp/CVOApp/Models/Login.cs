using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public static class LoginClass
    {
        public static int LoginSession
        {
            get
            {
                object value = HttpContext.Current.Session["LoginSession"];
                if (value != null)
                {
                    return Convert.ToInt32(value);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["LoginSession"] = value;
            }
        }

        public static void logout()
        {
            string confirmValue = HttpContext.Current.Request.Form["confirm_value"];
            
            if (confirmValue == "Yes")
            {
                HttpContext.Current.Session["LoginSession"] = 0;
            }
        }
    }
}