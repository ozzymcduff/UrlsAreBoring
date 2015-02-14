using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Text;
using UrlsAreBoring.Core;
namespace UrlsAreBoring.Tests
{
    [TestFixture]
    public class QueryStringTests
    {
        [Test]
        public void Test()
        {
            var q = new QueryString("something=123");
            q["something"] = "5";
            q["more"] = "stuff";
            Assert.AreEqual("something=5&more=stuff", q.ToString());
        }
        [Test]
        public void UrlEncode([Values( "!", "*", "'", "(", ")", ";", ":", "@", "&", "=", "+", "$", ",", "/", "?", "%", "#", "[", "]")] string someChar)
        {
            var q = new QueryString("something=123");
            q["something"] = "5";
            q["more"] = someChar;
            Assert.AreEqual("something=5&more="+HttpUtility.UrlEncodeUnicode(someChar), q.ToString());
        }

        [Test]
        public void UrlDeEncode([Values("!", "*", "'", "(", ")", ";", ":", "@", "&", "=", "+", "$", ",", "/", "?", "%", "#", "[", "]")] string someChar)
        {
            var q = new QueryString("something=" + HttpUtility.UrlEncodeUnicode(someChar));
            Assert.AreEqual(someChar, q["something"]);
        }
    }
}
