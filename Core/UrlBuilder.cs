using System;
using System.Web;
using System.Collections.Specialized;

namespace UrlsAreBoring.Core
{
    /// <summary>
    /// http://www.codeproject.com/Articles/11041/A-useful-UrlBuilder-class
    /// </summary>
    public class UrlBuilder : UriBuilder
    {
        QueryString _queryString = null;

        #region Properties
        public QueryString QueryString
        {
            get
            {
                if (_queryString == null)
                {
                    _queryString = new QueryString();
                }

                return _queryString;
            }
        }

        public string PageName
        {
            get
            {
                string path = base.Path;
                return path.Substring(path.LastIndexOf("/") + 1);
            }
            set
            {
                string path = base.Path;
                path = path.Substring(0, path.LastIndexOf("/"));
                base.Path = string.Concat(path, "/", value);
            }
        }
        #endregion

        #region Constructor overloads
        public UrlBuilder()
            : base()
        {
        }

        public UrlBuilder(string uri)
            : base(uri)
        {
            PopulateQueryString();
        }

        public UrlBuilder(Uri uri)
            : base(uri)
        {
            PopulateQueryString();
        }

        public UrlBuilder(string schemeName, string hostName)
            : base(schemeName, hostName)
        {
        }

        public UrlBuilder(string scheme, string host, int portNumber)
            : base(scheme, host, portNumber)
        {
        }

        public UrlBuilder(string scheme, string host, int port, string pathValue)
            : base(scheme, host, port, pathValue)
        {
        }

        public UrlBuilder(string scheme, string host, int port, string path, string extraValue)
            : base(scheme, host, port, path, extraValue)
        {
        }
#if FALSE
        public UrlBuilder(System.Web.UI.Page page)
            : base(page.Request.Url.AbsoluteUri)
        {
            PopulateQueryString();
        }
#endif
        #endregion

        #region Public methods
        public new string ToString()
        {
            GetQueryString();

            return base.Uri.AbsoluteUri;
        }
#if FALSE
        public void Navigate()
        {
            _Navigate(true);
        }

        public void Navigate(bool endResponse)
        {
            _Navigate(endResponse);
        }

        private void _Navigate(bool endResponse)
        {
            string uri = this.ToString();
            HttpContext.Current.Response.Redirect(uri, endResponse);
        }
#endif

        #endregion

        #region Private methods
        private void PopulateQueryString()
        {
            string query = base.Query;

            if (query == string.Empty || query == null)
            {
                return;
            }

            if (_queryString == null)
            {
                _queryString = new QueryString();
            }

            _queryString.Clear();

            query = query.Substring(1); //remove the ?

            string[] pairs = query.Split(new char[] { '&' });
            foreach (string s in pairs)
            {
                string[] pair = s.Split(new char[] { '=' });

                _queryString[pair[0]] = (pair.Length > 1) ? pair[1] : string.Empty;
            }
        }

        private void GetQueryString()
        {
            int count = _queryString.Count;

            if (count == 0)
            {
                base.Query = string.Empty;
                return;
            }

            base.Query = _queryString.ToString();
        }
        #endregion
    }
}
