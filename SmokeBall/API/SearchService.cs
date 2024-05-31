using Models;
using System.Text;
using System.Text.RegularExpressions;

namespace API
{
    public class SearchService : ISearchEngine
    {
        private const string FILE_PATH = @"..\searchResult.txt";
        private const string REGEX_PATTERN = "<div\\s+class=\"MjjYud\"[^>]*>(.*?)</div>";
        private const string SEARCH_URL = "www.smokeball.com.au";

        private readonly IFileReader _fileReader;
        private readonly IStringBuilderWrapper _sb;
        private readonly IRegexMatcher _regex;
        public SearchService(IFileReader fileReader, IStringBuilderWrapper stringBuilder, IRegexMatcher regexMatcher)
        {
            _fileReader = fileReader;
            _sb = stringBuilder;
            _regex = regexMatcher;
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

                var matches = _regex.Matches(content, REGEX_PATTERN);

                for (int i = 0; i < matches.Count; i++)
                {
                    if (matches[i].Value.Contains(SEARCH_URL))
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
