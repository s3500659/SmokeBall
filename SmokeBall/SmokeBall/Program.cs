
using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

var content = File.ReadAllText("searchResult.txt");

// Website url are contained in div's with class MjjYud
string pattern = "<div\\s+class=\"MjjYud\"[^>]*>(.*?)</div>";
Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

var matches = regex.Matches(content);

StringBuilder sb = new StringBuilder();
for (int i = 0; i < matches.Count; i++)
{
    if (matches[i].Value.Contains("www.smokeball.com.au"))
    {
        sb.Append(i + 1).Append(", ");
    }
}

// Remove comma from end of line. 
if (sb.Length > 0)
{
    sb.Remove(sb.Length - 2, 1);
}

Console.WriteLine(sb.ToString()); ;