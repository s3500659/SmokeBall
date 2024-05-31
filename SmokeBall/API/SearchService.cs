﻿using Models;
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
        private readonly ILogger<SearchService> _logger;

        public SearchService(IFileReader fileReader, IStringBuilderWrapper stringBuilder, 
            IRegexMatcher regexMatcher, ILogger<SearchService> logger)
        {
            _fileReader = fileReader;
            _sb = stringBuilder;
            _regex = regexMatcher;
            _logger = logger;
        }

        public string Search(SearchInputModel searchInput)
        {
            if (searchInput.Engine == SearchEngineType.Google)
            {
                _logger.LogInformation("Starting Google search");

                string content;
                try
                {
                    content = _fileReader.ReadAllText(FILE_PATH);
                }
                catch (FileNotFoundException ex)
                {
                    string message = "Search result file not found.";
                    _logger.LogError(ex, message);
                    return message;
                }
                catch (Exception ex)
                {
                    string message = "Error reading search result file.";
                    _logger.LogError(ex, message);
                    return message + ex.Message;
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
                    _sb.Remove(_sb.GetLength() - 2, 2);
                }

                _logger.LogInformation("Search completed.");

                return _sb.ToString();
            }

            _logger.LogError($"Search engine not implemented");

            throw new NotImplementedException("Only mocked Google search.");
        }
    }
}
