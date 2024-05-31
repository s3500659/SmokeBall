using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public interface IRegexMatcher
    {
        MatchCollection Matches(string input, string pattern);
    }

    public class RegexMatcher : IRegexMatcher
    {
        public MatchCollection Matches(string input, string pattern)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return regex.Matches(input);
        }
    }
}
