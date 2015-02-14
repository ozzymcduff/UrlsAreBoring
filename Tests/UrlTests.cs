using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using UrlsAreBoring.Core;
namespace UrlsAreBoring.Tests
{
    [TestFixture]
    public class UrlTests
    {
        private UrlInfo[] json;
        [SetUp]
        public void SetUp()
        {
            json = JsonConvert.DeserializeObject<UrlInfo[]>(File.ReadAllText("urls.json"));
        }

        [Test]
        public void TestAccepts()
        {
            foreach (var url in json.Where(u => u.Is.Urn))
            {
                Assert.DoesNotThrow(() =>
                {
                    new UrlBuilder(url.Url);
                }, url.Url);
            }
        }

        [Test, Ignore("Not implemented")]
        public void Parsing()
        {
            //https://github.com/medialize/URI.js/blob/gh-pages/test/test.js
            foreach (var url in json.Where(u => u.Is.Urn))
            {
                Assert.AreEqual(url.Url,
                    new UrlBuilder(url.Url).ToString());
            }
        }
    }
}
