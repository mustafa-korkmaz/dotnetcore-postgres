using System.ComponentModel.DataAnnotations;

namespace BoilerplateDotnetCorePostgres.Models.User
{
    public class RegisterModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} field must be max {1} characters.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "{0} field must be min {2} max {1} characters.", MinimumLength = 4)]
        public string NameSurname { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
