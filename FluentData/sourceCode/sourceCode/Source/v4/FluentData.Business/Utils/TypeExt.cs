using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentData.Business.Utils
{
    public static class TypeExt
    {
        /// <summary>
        /// 日期格式化
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        public static string ToStringFormat(this DateTime? date, string dateFormat = "yyyy-MM-dd hh:mm:ss")
        {
            if (!date.HasValue || date.ToString() == "0001/1/1 0:00:00") return "";

            return date.Value.ToString(dateFormat);
        }

    }
}
