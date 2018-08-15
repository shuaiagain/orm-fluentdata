using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FluentData.Business.Service;
using FluentData.Business.ViewModels;
using System.Web.Security;
using Newtonsoft.Json;

namespace FluentData.Web.Controllers
{
    public class AccountController : Controller
    {

        #region Login
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region 用户注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(UserVM user)
        {
            if (user == null) return Json(new
            {
                Code = -400,
                Msg = "参数不能为空",
                Data = ""
            });

            if (string.IsNullOrEmpty(user.LoginName) || string.IsNullOrEmpty(user.Password))
            {
                return Json(new
                {
                    Code = -400,
                    Msg = "用户名或密码不能为空",
                    Data = ""
                });
            }

            UserService userSV = new UserService();
            if (userSV.CheckUserIsExist(user.LoginName))
            {
                return Json(new
                {
                    Code = -400,
                    Msg = "用户名已存在",
                    Data = ""
                });
            }

            user.InputTime = DateTime.Now;
            userSV.Register(user);

            #region 添加登录cookie

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.LoginName, DateTime.Now, DateTime.Now.AddDays(1), false, JsonConvert.SerializeObject(user));
            //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.LoginName, false, 30);
            string encryptTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket) { Expires = DateTime.Now.AddMinutes(2) };
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

            #endregion

            return Json(new
            {
                Code = 200,
                Msg = "注册成功",
                Data = user
            });
        }
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public void Logout()
        {

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                HttpOnly = true,
                Domain = FormsAuthentication.CookieDomain,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath,
                Expires = DateTime.Now.AddDays(-1)
            };

            HttpContext.Response.Cookies.Add(cookie);
        }
        #endregion

    }
}
