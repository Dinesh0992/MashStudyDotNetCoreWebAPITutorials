using System;
using System.ComponentModel.DataAnnotations;

namespace MashStudyDotNetCoreWebAPITutorials.Dto
{
    public class LoginReqDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
