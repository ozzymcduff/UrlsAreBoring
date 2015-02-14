using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlsAreBoring.Tests
{
    public class UrlInfoParts
    {
        public string Protocol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public string Port { get; set; }
        public string Path { get; set; }
        public string Query { get; set; }
        public string Fragment { get; set; }
    }
    public class UrlInfoAccessors
    {
        public string Protocol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public string Port { get; set; }
        public string Path { get; set; }
        public string Query { get; set; }
        public string Fragment { get; set; }
        public string Resource { get; set; }
        public string Authority { get; set; }
        public string Userinfo { get; set; }
        public string Subdomain { get; set; }
        public string Domain { get; set; }
        public string Tld { get; set; }
        public string Directory { get; set; }
        public string Filename { get; set; }
        public string Suffix { get; set; }
        public string Hash { get; set; }
        public string Search { get; set; }
        public string Host { get; set; }
    }

    public class UrlInfoIs
    {
        public bool Urn { get; set; }
        public bool Url { get; set; }
        public bool Relative { get; set; }
        public bool Name { get; set; }
        public bool Sld { get; set; }
        public bool Ip { get; set; }
        public bool Ip4 { get; set; }
        public bool Ip6 { get; set; }
        public bool Idn { get; set; }
        public bool Punycode { get; set; }
    }

    public class UrlInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string _url { get; set; }
        public UrlInfoParts Parts { get; set; }
        public UrlInfoAccessors Accessors { get; set; }
        public UrlInfoIs Is { get; set; }
    }
}
