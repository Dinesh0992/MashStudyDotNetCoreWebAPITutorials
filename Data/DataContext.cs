using System;
using Microsoft.EntityFrameworkCore;
using MashStudyDotNetCoreWebAPITutorials.Models;

namespace MashStudyDotNetCoreWebAPITutorials.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options){ }

        public DbSet<City> Cities {get;set;}
        
    }
}
