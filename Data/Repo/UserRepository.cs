using System;
using System.Threading.Tasks;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;
using MashStudyDotNetCoreWebAPITutorials.Models;
using Microsoft.EntityFrameworkCore;

namespace MashStudyDotNetCoreWebAPITutorials.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dc;

        public UserRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public   async Task<User> Authenticate(string UserName, string Password)
        {
            return await dc.Users.FirstOrDefaultAsync(x=>x.UserName==UserName && x.Password==Password);
        }
    }
}
