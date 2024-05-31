namespace Models
{
    public interface ISearchEngine
    {
        string Search(SearchInputModel searchInput);
    }
}