using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MashStudyDotNetCoreWebAPITutorials.Data;
using Microsoft.EntityFrameworkCore;
using MashStudyDotNetCoreWebAPITutorials.Models;

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
        public async Task<IActionResult> Get()
        {
            var cities = await dc.Cities.ToListAsync();
            return Ok(cities);
        }

        [HttpPost("addcity/{cityname}")]
        public async Task<IActionResult> AddCity(string CityName)
        {
            City newcity = new City();
            newcity.Name = CityName;
            await dc.Cities.AddAsync(newcity);
            await dc.SaveChangesAsync();
            return Ok(newcity);
        }

        [HttpPost("post/addcity")]
        public async Task<IActionResult> AddCity([FromBody] City newcity)
        {
            // City newcity = new City();
            // newcity.Name = CityName;
            await dc.Cities.AddAsync(newcity);
            await dc.SaveChangesAsync();
            return Ok(newcity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await dc.Cities.FindAsync(id);
            dc.Cities.Remove(city);
            await dc.SaveChangesAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "London";
        }


    }
}