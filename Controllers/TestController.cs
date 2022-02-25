using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleDB.API.Controllers
{
    
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("api/Test/Test")]

        public IActionResult Test()
        {
            return Ok("API Connection Successfull");
        }

    }
}
