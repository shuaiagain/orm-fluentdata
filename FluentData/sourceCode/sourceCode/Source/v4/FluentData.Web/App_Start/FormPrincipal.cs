using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Principal;
using Newtonsoft.Json;
using System.Web.Security;

namespace FluentData.Web
{
    public class MyFormPrincipal : IPrincipal
    {
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            return false;
        }
    }

    public class MyFormsAuthentication
    {
        public int? UserID { get; set; }

        public string UserName { get; set; }

        public string RoleTypes { get; set; }

        #region SetAuthCookie
        public static void SetAuthCookie(string userName, MyFormsAuthentication userData, bool isRemember)
        {

            if (userData == null) throw new ArgumentNullException("userData");

            var data = JsonConvert.SerializeObject(userData);
            DateTime expires = isRemember ? DateTime.Now.AddDays(30) : DateTime.Now.AddDays(1);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expires, isRemember, data);
            string cookieValue = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue)
            {
                HttpOnly = false,
                Domain = FormsAuthentication.CookieDomain,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath,
                Expires = expires
            };

            HttpContext currentHttp = HttpContext.Current;
            if (currentHttp == null) new InvalidOperationException();

            currentHttp.Response.Cookies.Remove(cookie.Name);
            currentHttp.Response.Cookies.Add(cookie);
        }
        #endregion

        #region RemoveAuthCookie
        public static void RemoveAuthCookie()
        {

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName)
            {
                HttpOnly = true,
                Domain = FormsAuthentication.CookieDomain,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath,
                Expires = DateTime.Now.AddDays(-1)
            };

            HttpContext currentHttp = HttpContext.Current;
            if (currentHttp == null) throw new InvalidOperationException();

            currentHttp.Response.Cookies.Add(cookie);

        }
        #endregion
    }
}