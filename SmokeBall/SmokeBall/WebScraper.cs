using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmokeBall
{
    internal class WebScraper
    {

        public static async Task ScrapeAsync(string url)
        {
            HttpClient client = new HttpClient();

            // Set user-agent to avoid being blocked by Google
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            string htmlContent = await client.GetStringAsync(url);

            // Simple parsing using regex (this example extracts titles of search results)
            Regex regex = new Regex("<h3 class=\".*?\">(.*?)</h3>", RegexOptions.Singleline);
            MatchCollection matches = regex.Matches(htmlContent);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1].Value);
            }

        }
    }
}
