using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MashStudyDotNetCoreWebAPITutorials.Models;

namespace MashStudyDotNetCoreWebAPITutorials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public CityController()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Get() => new List<string> { "London", "Rome", "Paris" };

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "London";
        }

        
    }
}