using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UrlsAreBoring.Core
{
    /// <summary>
    /// John Gruber's "Improved Liberal, Accurate Regex Pattern for Matching URLs" 
    /// https://gist.github.com/gruber/249502
    /// </summary>
    class UrlParser
    {
        Regex regex = new Regex(@"
(?xi)
\b
(							# Capture 1: entire matched URL
  (?:
    [a-z][\w-]+:				# URL protocol and colon
    (?:
      /{1,3}						# 1-3 slashes
      |								#   or
      [a-z0-9%]						# Single letter or digit or '%'
      								# (Trying not to match e.g. ""URI::Escape"")
    )
    |							#   or
    www\d{0,3}[.]				# ""www."", ""www1."", ""www2."" … ""www999.""
    |							#   or
    [a-z0-9.\-]+[.][a-z]{2,4}/	# looks like domain name followed by a slash
  )
  (?:							# One or more:
    [^\s()<>]+						# Run of non-space, non-()<>
    |								#   or
    \(([^\s()<>]+|(\([^\s()<>]+\)))*\)	# balanced parens, up to 2 levels
  )+
  (?:							# End with:
    \(([^\s()<>]+|(\([^\s()<>]+\)))*\)	# balanced parens, up to 2 levels
    |									#   or
    [^\s`!()\[\]{};:'"".,<>?«»“”‘’]		# not a space or one of these punct char
  )
)", RegexOptions.IgnorePatternWhitespace);

    }
}
