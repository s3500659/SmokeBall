using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private const string FILE_PATH = @"..\searchResult.txt";
        private const string SEARCH_URL = "www.smokeball.com.au";

        private readonly ISearchEngine _searchEngine;

        public SearchController(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }


        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchInputModel searchInput)
        {
            if (searchInput == null)
            {
                return BadRequest("Search input cannot be null.");
            }

            // Mock search
            await Task.Delay(100);
            string result = _searchEngine.Search(searchInput, FILE_PATH, SEARCH_URL);


            return Ok(result);
        }
    }


}
