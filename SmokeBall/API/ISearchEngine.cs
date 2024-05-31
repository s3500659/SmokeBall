using Models;

namespace API
{
    public interface ISearchEngine
    {
        string Search(SearchInputModel searchInput);
    }
}