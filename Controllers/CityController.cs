using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MashStudyDotNetCoreWebAPITutorials.Data;
using Microsoft.EntityFrameworkCore;
using MashStudyDotNetCoreWebAPITutorials.Models;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;
using MashStudyDotNetCoreWebAPITutorials.Dto;

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
            IEnumerable<CityDto> citiesDto=cities.Select(x=>new CityDto{Id=x.Id,Name=x.Name});
            return Ok(citiesDto);
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
        public async Task<IActionResult> AddCity([FromBody] CityDto newcity)
        {
            // City newcity = new City();
            // newcity.Name = CityName;
            City city=new City{
                Name=newcity.Name,
                LastUpdatedby=1,
                LastUpdatedOn=DateTime.Now
            };
             uow.CityRepository.AddCity(city); 
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