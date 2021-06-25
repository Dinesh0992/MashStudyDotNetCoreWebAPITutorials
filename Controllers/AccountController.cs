using System.Text;
using System;
using System.Threading.Tasks;
using MashStudyDotNetCoreWebAPITutorials.Dto;
using MashStudyDotNetCoreWebAPITutorials.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MashStudyDotNetCoreWebAPITutorials.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace MashStudyDotNetCoreWebAPITutorials.Controllers
{

    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;

        public AccountController(IUnitOfWork uow,IConfiguration configuration)
        {
            this.uow = uow;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginReqDto loginreq)
        {
            var user = await uow.UserRepository.Authenticate(loginreq.UserName, loginreq.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            LoginResponseDto loginResponseDto = new LoginResponseDto();
            loginResponseDto.UserName = user.UserName;
            loginResponseDto.Token = CreateJWT(user);
            return Ok(loginResponseDto);
        }

        private string CreateJWT(User user)
        {
             string secretkey=configuration.GetSection("AppSettings:Key").Value;
            //Header section
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));

            //payload
            var claims = new Claim[]{
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            //Signature
            var signingCredeentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //combining Header--Payload--Signature
            var tokenDescriptor=new SecurityTokenDescriptor{
                Subject =new ClaimsIdentity(claims),
                Expires=DateTime.UtcNow.AddMinutes(7),
                SigningCredentials=signingCredeentials
            };


            var tokenHandler=new JwtSecurityTokenHandler();

            var token=tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
