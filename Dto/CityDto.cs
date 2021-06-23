using System;
using System.ComponentModel.DataAnnotations;

namespace MashStudyDotNetCoreWebAPITutorials.Dto
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name field is Mandatory")]
        [StringLength(10, MinimumLength = 2)]
        [RegularExpression(".*[a-zA-Z]+.*",ErrorMessage ="Only numerics are not  allowed")]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
