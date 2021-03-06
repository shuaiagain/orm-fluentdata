﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FluentData.Business.Service;
using FluentData.Business.ViewModels;
using System.Web.Security;
using Newtonsoft.Json;

namespace FluentData.Web2.Controllers
{
    public class AccountController : Controller
    {

        #region Login
        public ActionResult Login()
        {

            if(CurrentUser.UserID.HasValue)
            {
                return RedirectToAction("Index","Home");
            }

            return View();
        }
        #endregion

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UserVM user)
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

            user.InputTime = DateTime.Now;
            user = userSV.Login(user);
            if (user == null || !user.ID.HasValue)
            {
                return Json(new
                {
                    Code = -200,
                    Msg = "用户不存在",
                    Data = ""
                });
            }

            #region 添加登录cookie

            //MyFormsAuthentication.SetAuthCookie(user.LoginName, new MyFormsAuthentication() { UserID = user.ID, UserName = user.LoginName }, false);

            Session["UserID"] = user.ID;
            Session["UserName"] = user.LoginName;
            Session["RoleTypes"] = user.RoleTypes;
           
            #endregion

            return Json(new
            {
                Code = 200,
                Msg = "登录成功",
                Data = user
            });
        }
        #endregion

        #region 退出
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            //MyFormsAuthentication.RemoveAuthCookie();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        #endregion

    }
}
