using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private ISearchEngine _searchEngine;
        public SearchController(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }

        public ISearchEngine SearchEngine { get; }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchInputModel searchInput)
        {
            if (searchInput == null)
            {
                return BadRequest("Search input cannot be null.");
            }

            string result = _searchEngine.Search(searchInput);


            return Ok(result);
        }
    }


}
