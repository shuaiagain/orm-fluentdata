using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace FluentData.Web2.Filters
{
    public class AuthFilters : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!CurrentUser.UserID.HasValue)
            {
                filterContext.Result = new RedirectResult("~/account/login");
                return;
            }
        }
    }
}