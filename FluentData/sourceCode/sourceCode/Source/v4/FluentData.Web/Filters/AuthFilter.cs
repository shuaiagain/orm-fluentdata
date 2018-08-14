using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using System.Web.Security;

namespace FluentData.Web.Filters
{
    public class AuthFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }

            var cookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
           
        }
    }
}