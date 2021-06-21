using System;
using System.Threading.Tasks;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;
using MashStudyDotNetCoreWebAPITutorials.Data.Repo;

namespace MashStudyDotNetCoreWebAPITutorials.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext _dataContext)
        {
                this.dataContext=_dataContext;
        }
        public ICityRepository CityRepository => new CityRepository(dataContext);

        public  async Task<bool> SaveAsync()
        {
            return await dataContext.SaveChangesAsync()>0;
        }
    }
}
