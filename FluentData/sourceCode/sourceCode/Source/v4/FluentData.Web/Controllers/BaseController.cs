using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentData.Web.Filters;

using System.Web.Security;

namespace FluentData.Web.Controllers
{

    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = RedirectToAction("login", "account");
                return;
            }

            HttpCookie cookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                filterContext.Result = RedirectToAction("Login", "Account");
                return;
            }

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
        }

        public MyFormsAuthentication UserData
        {
            get
            {
                if (Request.IsAuthenticated && this.User != null)
                {
                    MyFormPrincipal principal = this.User as MyFormPrincipal;
                    if (principal != null && principal.UserData != null)
                    {
                        return principal.UserData;
                    }
                }

                return null;
            }
        }
    }
}
