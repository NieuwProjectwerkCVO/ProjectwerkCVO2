using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVOApp.Models
{
    public static class ModuleClass
    {
        public static int ModuleSession
        {
            get
            {
                object value = HttpContext.Current.Session["ModuleSession"];
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
                HttpContext.Current.Session["ModuleSession"] = value;
            }
        }
    }

    
}