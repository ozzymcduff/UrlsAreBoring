using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlsAreBoring.Core
{
    public class HttpUtility
    {
        public class Instance
        {
            public virtual string UrlEncodeUnicode(string value)
            {
                return System.Web.HttpUtility.UrlEncodeUnicode(value);
            }

            public virtual string UrlDecode(string value)
            {
                return System.Web.HttpUtility.UrlDecode(value);
            }
        }

        public static Instance Current = new Instance();

        public static string UrlEncodeUnicode(string value)
        {
            return Current.UrlEncodeUnicode(value);
        }

        public static string UrlDecode(string value)
        {
            return Current.UrlDecode(value);
        }
    }

}
