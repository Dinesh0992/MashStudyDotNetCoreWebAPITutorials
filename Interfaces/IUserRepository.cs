using System;
using System.Threading.Tasks;
using MashStudyDotNetCoreWebAPITutorials.Models;

namespace MashStudyDotNetCoreWebAPITutorials.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string User, string Password);
        
    }
}
