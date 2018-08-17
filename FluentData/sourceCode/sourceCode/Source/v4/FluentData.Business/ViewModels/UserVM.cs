using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentData.Business.ViewModels
{
    /// <summary>
    /// 用户视图
    /// </summary>
    public class UserVM
    {
        public int? ID { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? InputTime { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public string RoleTypes { get; set; }
    }
}
