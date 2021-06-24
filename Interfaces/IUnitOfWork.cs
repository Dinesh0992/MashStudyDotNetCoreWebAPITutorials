using System;
using System.Threading.Tasks;

namespace MashStudyDotNetCoreWebAPITutorials.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository {get;}

        IUserRepository UserRepository {get;}
        Task<bool> SaveAsync();
    }
}
