using System;
using AutoMapper;
using MashStudyDotNetCoreWebAPITutorials.Dto;
using MashStudyDotNetCoreWebAPITutorials.Models;

namespace MashStudyDotNetCoreWebAPITutorials.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City,CityDto>().ReverseMap();
            
        }
    }
}
