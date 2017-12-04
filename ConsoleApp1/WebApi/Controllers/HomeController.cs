using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("")] // Set as default route for when root site is accessed.
    public class HomeController : Controller
    {
        /// <summary>
        /// Health check endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Heartbeat()
        {
            return "Ok.";
        }
    }
}
