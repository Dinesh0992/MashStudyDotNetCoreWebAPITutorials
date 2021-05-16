using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MashStudyDotNetCoreWebAPITutorials.Data;

namespace MashStudyDotNetCoreWebAPITutorials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public readonly DataContext dc;
        public CityController(DataContext DC)
        {
            dc = DC;
        }



        [HttpGet("")]
        public IActionResult Get()
        {
            var cities = dc.Cities.ToList();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "London";
        }


    }
}