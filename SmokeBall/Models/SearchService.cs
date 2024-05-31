using System.Text;
using System.Text.RegularExpressions;

namespace Models
{
    public class SearchService : ISearchEngine
    {
        public string Search(SearchInputModel searchInput)
        {
            if (searchInput.Engine == SearchEngineType.Google)
            {
                string content;
                try
                {
                    content = File.ReadAllText(@"..\searchResult.txt");
                }
                catch (FileNotFoundException)
                {
                    return "Search result file not found.";
                }
                catch (Exception ex)
                {
                    return $"Error reading search result file: {ex.Message}";
                }

                // The search result is contained in div's with class MjjYud
                string pattern = "<div\\s+class=\"MjjYud\"[^>]*>(.*?)</div>";
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

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

                return sb.ToString();
            }

            throw new NotImplementedException("Only mocked Google search.");
        }
    }
}
