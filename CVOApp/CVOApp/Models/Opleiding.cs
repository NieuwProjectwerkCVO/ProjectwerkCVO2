using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public static class Opleiding
    {
        public static int OpleidingSession
        {
            get
            {
                object value = HttpContext.Current.Session["OpleidingSession"];
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
                HttpContext.Current.Session["OpleidingSession"] = value;
            }

        }

        
    }

    
}