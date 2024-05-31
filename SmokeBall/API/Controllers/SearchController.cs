using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        public SearchController()
        {

        }


        [HttpPost]
        public string Search(SearchInputModel searchInput)
        {
            return "Your results!";
        }
    }
}
