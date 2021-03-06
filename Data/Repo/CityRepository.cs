using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MashStudyDotNetCoreWebAPITutorials.Models;
using Microsoft.EntityFrameworkCore;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;

namespace MashStudyDotNetCoreWebAPITutorials.Data.Repo
{
    public class CityRepository : ICityRepository
    {
         public  readonly DataContext Dc ;
        public CityRepository(DataContext dc)
        {
            Dc = dc;
        }
        
        public void AddCity(City city)
        {
            Dc.Cities.Add(city);
        }

        public void DeleteCity(int CityId)
        {
           var city =  Dc.Cities.Find(CityId);
            Dc.Cities.Remove(city);
        }

        public async Task<City> FindCity(int id)
        {
           return  await Dc.Cities.FindAsync(id);
            // return  await Dc.Cities.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public  async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return  await Dc.Cities.ToListAsync();

        }

        // public async Task<bool> SaveAsync()
        // {
        //     return await Dc.SaveChangesAsync()>0;
        // }
    }
}
