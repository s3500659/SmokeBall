using Models;

namespace API
{
    public class SearchInputModel
    {
        public string? Keyword { get; set; }
        public string? SearchLimit { get; set; }
        public SearchEngine Engine { get; set; }
    }
}