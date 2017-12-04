using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        /// <summary>
        /// Returns the message as specified in the business specs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}
