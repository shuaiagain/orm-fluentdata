using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentData.Business.ViewModels
{
    public class ArticleQuery : PageQuery
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
