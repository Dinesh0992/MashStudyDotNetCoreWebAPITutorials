//using System.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using MashStudyDotNetCoreWebAPITutorials.Dto;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;
//using MashStudyDotNetCoreWebAPITutorials.Data;
//using Microsoft.EntityFrameworkCore;
using MashStudyDotNetCoreWebAPITutorials.Models;
using Microsoft.AspNetCore.Authorization;

namespace MashStudyDotNetCoreWebAPITutorials.Controllers
{
  
    [Authorize]
    public class CityController : BaseController
    {

        private readonly IUnitOfWork uow;

        public IMapper mapper { get; }

        public CityController(IUnitOfWork _uow, IMapper mapper)
        {
            this.uow = _uow;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
           /* throw new UnauthorizedAccessException();*/
            IEnumerable<CityDto> citiesDto = mapper.Map<IEnumerable<CityDto>>(await uow.CityRepository.GetCitiesAsync());
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
            // City city = new City
            // {
            //     Name = newcity.Name,
            //     LastUpdatedby = 1,
            //     LastUpdatedOn = DateTime.Now
            // };
            City city = mapper.Map<City>(newcity);
            city.LastUpdatedby = 1;
            city.LastUpdatedOn = DateTime.Now;
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("updatecity")]
        public async Task<IActionResult> UpdateCity([FromBody] CityDto newcity)
        {
              
            var cityfromDb = await uow.CityRepository.FindCity(newcity.Id);
            cityfromDb.LastUpdatedby = 1;
            cityfromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(newcity, cityfromDb);
            await uow.SaveAsync();
            return StatusCode(200);

        }

        /*
        [
          {
            "op": "replace",   
            "path": "/Name",
            "value" : "New York"
          },
           {
            "op": "replace",   
            "path": "/Country",
            "value" : "USA"
        }
        ]
        */
        [HttpPatch("updatepatchcity/{id}")]
        public async Task<IActionResult> UpdatePatchCity(int id, [FromBody] JsonPatchDocument<City> citypatch)
        {

            var cityfromDb = await uow.CityRepository.FindCity(id);
            cityfromDb.LastUpdatedby = 1;
            cityfromDb.LastUpdatedOn = DateTime.Now;
            // mapper.Map(newcity,cityfromDb);
            citypatch.ApplyTo(cityfromDb, ModelState);
            await uow.SaveAsync();
            return StatusCode(200);

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