using System;
using System.Threading.Tasks;

namespace MashStudyDotNetCoreWebAPITutorials.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository {get;}
        Task<bool> SaveAsync();
    }
}
