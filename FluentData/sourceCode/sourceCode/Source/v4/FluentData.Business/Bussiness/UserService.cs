using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using FluentData.Business.ViewModels;
using FluentData.Business.Utils;

namespace FluentData.Business.Service
{
    public class UserService
    {

        #region 检查用户名是否已存在
        public bool CheckUserIsExist(string loginName)
        {

            if (string.IsNullOrEmpty(loginName)) return false;

            string sql = string.Format(@" select * from user u where u.LoginName = @loginName ");

            using (var dbContext = new DbContext().ConnectionStringName(ConnectionUtil.connFluentData, new MySqlProvider()))
            {
                UserVM user = dbContext.Sql(sql).Parameter("loginName", loginName).QuerySingle<UserVM>();

                return user == null ? false : true;
            }
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserVM Register(UserVM user)
        {

            if (user == null) return null;
            if (string.IsNullOrEmpty(user.LoginName) || string.IsNullOrEmpty(user.Password)) return null;

            using (var dbContext = new DbContext().ConnectionStringName(ConnectionUtil.connFluentData, new MySqlProvider()))
            {
                user.ID = dbContext.Insert("User").Column("LoginName", user.LoginName)
                                                  .Column("Password", MD5Util.GetMD5(user.Password))
                                                  .Column("InputTime", user.InputTime)
                                                  .ExecuteReturnLastId<int>();

                return user;
            }
        }
        #endregion

    }
}
