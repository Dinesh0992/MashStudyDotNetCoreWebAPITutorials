using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MashStudyDotNetCoreWebAPITutorials.Data;
using Microsoft.EntityFrameworkCore;
using MashStudyDotNetCoreWebAPITutorials.Models;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;

namespace MashStudyDotNetCoreWebAPITutorials.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork _uow)
        {
            this.uow = _uow;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();
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
             uow.CityRepository.AddCity(newcity); 
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
           uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "London";
        }


    }
}