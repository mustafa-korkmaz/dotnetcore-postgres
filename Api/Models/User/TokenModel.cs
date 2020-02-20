using System.ComponentModel.DataAnnotations;

namespace BoilerplateDotnetCorePostgres.Models.User
{
    public class TokenModel
    {
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
