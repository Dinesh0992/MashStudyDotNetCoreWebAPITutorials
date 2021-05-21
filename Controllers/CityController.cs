using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MashStudyDotNetCoreWebAPITutorials.Data;
using Microsoft.EntityFrameworkCore;
using MashStudyDotNetCoreWebAPITutorials.Models;
using MashStudyDotNetCoreWebAPITutorials.Data.Repo;

namespace MashStudyDotNetCoreWebAPITutorials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        
        private readonly ICityRepository repo;

        public CityController(ICityRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var cities = await repo.GetCitiesAsync();
            return Ok(cities);
        }
        /*
        [HttpPost("addcity/{cityname}")]
        public async Task<IActionResult> AddCity(string CityName)
        {
            City newcity = new City();
            newcity.Name = CityName;
            await dc.Cities.AddAsync(newcity);
            await dc.SaveChangesAsync();
            return Ok(newcity);
        }
        */

        [HttpPost("post/addcity")]
        public async Task<IActionResult> AddCity([FromBody] City newcity)
        {
            // City newcity = new City();
            // newcity.Name = CityName;
             repo.AddCity(newcity); 
            await repo.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
           repo.DeleteCity(id);
            await repo.SaveAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "London";
        }


    }
}