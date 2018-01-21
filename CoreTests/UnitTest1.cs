using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UrlsAreBoring.Tests;
using Xunit;
using Microsoft.AspNetCore.WebUtilities;

namespace CoreTests
{
    public class UnitTest1
    {
        private UrlInfo[] json;

        public UnitTest1()
        {
            json = JsonConvert.DeserializeObject<UrlInfo[]>(File.ReadAllText("urls.json"));
        }

        [Fact]
        public void ParseQuery()
        {
            foreach (var url in json.Where(u => 
                                           u.Is.Urn 
                                           && !string.IsNullOrEmpty(u.Parts.Query)
                                           && !string.IsNullOrEmpty(u.Parts.Protocol)
                                           && !string.IsNullOrEmpty(u.Parts.Hostname)
                                          ))
            {
                var query = QueryHelpers.ParseQuery(url.Parts.Query).ToDictionary(kv=>kv.Key,kv=>string.Join(",",kv.Value));
                var q= QueryHelpers.AddQueryString(url.Parts.Protocol + "://" + url.Parts.Hostname+url.Parts.Path, query);
                Assert.True(q == url.Url, url.Name);
            }
        }

        [Fact]
        public void Parse()
        {
            foreach (var url in json.Where(u =>
                                           u.Is.Urn
                                          ))
            {
                var uri = new Uri(url.Url);

                Assert.True(url.Parts.Path== uri.AbsolutePath, 
                            $"path {url.Name} '{uri.AbsolutePath}' = '{url.Parts.Path}'"
                           );
                Assert.True(url.Parts.Protocol== uri.Scheme,"scheme "+ url.Name);

                //var query = QueryHelpers.ParseQuery(url.Parts.Query).ToDictionary(kv => kv.Key, kv => string.Join(",", kv.Value));
                //var q = QueryHelpers.AddQueryString(url.Parts.Protocol + "://" + url.Parts.Hostname + url.Parts.Path, query);
                //Assert.True(q == url.Url, url.Name);
            }
        }
        [Fact(Skip = "Not implemented")]
        public void Parsing()
        {
            //https://github.com/medialize/URI.js/blob/gh-pages/test/test.js
            foreach (var url in json.Where(u => u.Is.Urn))
            {
                //Assert.AreEqual(url.Url,
                  //  new UrlBuilder(url.Url).ToString());
            }
        }
    }
}
