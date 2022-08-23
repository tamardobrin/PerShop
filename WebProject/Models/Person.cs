using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter your password")]
        public string? Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email address")]
        public string? Email { get; set; }
    }
}
