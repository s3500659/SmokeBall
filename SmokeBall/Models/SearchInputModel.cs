using Models;

namespace Models
{
    public class SearchInputModel
    {
        public string? Keyword { get; set; }
        public int? SearchLimit { get; set; }
        public SearchEngine Engine { get; set; }
    }
}