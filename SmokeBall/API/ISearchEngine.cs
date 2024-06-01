using Models;

namespace API
{
    public interface ISearchEngine
    {
        string Search(SearchInputModel searchInput, string filePath, string searchUrl);
    }
}