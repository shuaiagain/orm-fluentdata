using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentData.Business.ViewModels
{
    public class BaseQuery
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWord { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int? ID { get; set; }
    }
}
