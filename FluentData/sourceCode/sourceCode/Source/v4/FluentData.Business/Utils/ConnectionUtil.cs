using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace FluentData.Business.Utils
{
    public class ConnectionUtil
    {
        public static readonly string connWXB = ConfigurationManager.ConnectionStrings["connWXB"].Name;
        //public static readonly string connCMS = ConfigurationManager.ConnectionStrings["connCMS"].Name;
    }
}
