using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapinet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {

        [HttpGet]
        [Route("getmyname")]
        public string GetMyName()
        {
            return "Bharath";
        }
    }
}
