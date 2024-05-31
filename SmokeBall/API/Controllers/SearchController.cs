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


        [HttpGet(Name = "GetSearchResult")]
        public string Get()
        {
            return "Your results!";
        }
    }
}
