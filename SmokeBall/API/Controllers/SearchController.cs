using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
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
            string result = _searchEngine.Search(searchInput);


            return Ok(result);
        }
    }


}
