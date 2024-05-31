using Models;
using System.Text;
using System.Text.RegularExpressions;

namespace API
{
    public class SearchService : ISearchEngine
    {
        private const string FILE_PATH = @"..\searchResult.txt";
        private readonly IFileReader _fileReader;
        private readonly IStringBuilderWrapper _sb;
        public SearchService(IFileReader fileReader, IStringBuilderWrapper stringBuilder)
        {
            _fileReader = fileReader;
            _sb = stringBuilder;
        }

        public string Search(SearchInputModel searchInput)
        {
            if (searchInput.Engine == SearchEngineType.Google)
            {
                string content;
                try
                {
                    content = _fileReader.ReadAllText(FILE_PATH);
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

                for (int i = 0; i < matches.Count; i++)
                {
                    if (matches[i].Value.Contains("www.smokeball.com.au"))
                    {
                        _sb.Append((i + 1).ToString());
                        _sb.Append(", ");
                    }
                }

                // Remove comma from end of line. 
                if (_sb.GetLength() > 0)
                {
                    _sb.Remove(_sb.GetLength() - 2, 1);
                }

                return _sb.ToString();
            }

            throw new NotImplementedException("Only mocked Google search.");
        }
    }
}
