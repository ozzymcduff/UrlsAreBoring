using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Text;
using UrlsAreBoring.Core;

namespace UrlsAreBoring.Tests
{
    [TestFixture]
    public class UrlBuilderTests
    {
        [Test]
        public void CanBuild()
        {
            var builder = new UrlBuilder("http://localhost/test/page?something=123");
            builder.Path = "/test/hello";
            builder.QueryString["something"] = "5";
            builder.QueryString["more"] = "stuff";
            Assert.AreEqual("http://localhost/test/hello?something=5&more=stuff", builder.ToString());
        }
    }
}
