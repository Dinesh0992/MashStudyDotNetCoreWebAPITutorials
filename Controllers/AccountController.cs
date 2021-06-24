using System;
using System.Threading.Tasks;
using MashStudyDotNetCoreWebAPITutorials.Dto;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MashStudyDotNetCoreWebAPITutorials.Controllers
{
   
    public class AccountController :BaseController
    {
        private readonly IUnitOfWork uow;

        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginReqDto loginreq)
        {
          var user=  await uow.UserRepository.Authenticate(loginreq.UserName,loginreq.Password);

            if(user==null)
            {
                return Unauthorized();
            }
            LoginResponseDto loginResponseDto=new LoginResponseDto();
            loginResponseDto.UserName=user.UserName;
              loginResponseDto.Token="Token generated";
           return  Ok(loginResponseDto);
        }
    }
}
