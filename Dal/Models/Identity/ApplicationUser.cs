using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dal.Models.Identity
{
    public class ApplicationUser : IdentityUser<System.Guid>
    {
        [MaxLength(100)]
        public string NameSurname { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}