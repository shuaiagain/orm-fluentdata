using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.SessionState;

namespace FluentData.Web2
{
    public static class CurrentUser
    {

        public static string UserName
        {
            get
            {
                if (HttpContext.Current == null) return null;

                object userName = HttpContext.Current.Session["UserName"];
                if (userName == null) return null;

                return userName.ToString();
            }
        }

        public static int? UserID
        {
            get
            {
                if (HttpContext.Current == null) return null;

                object userId = HttpContext.Current.Session["UserID"];
                if (userId == null) return null;

                return Convert.ToInt32(userId);
            }
        }

        public static string RoleTypes
        {
            get
            {
                if (HttpContext.Current == null) return null;

                object roleTypes = HttpContext.Current.Session["RoleTypes"];
                if (roleTypes == null) return null;

                return roleTypes.ToString();
            }
        }
    }
}