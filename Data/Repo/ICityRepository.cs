using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using MashStudyDotNetCoreWebAPITutorials.Models;

namespace MashStudyDotNetCoreWebAPITutorials.Data.Repo
{
    public interface ICityRepository
    {
         Task<IEnumerable<City>> GetCitiesAsync();
         void AddCity(City city);
         void DeleteCity(int CityId);

         Task<bool> SaveAsync();


    }
}
