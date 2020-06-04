using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dal.Entities.Identity
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity<Guid>
    {
        [MaxLength(100)]
        public string NameSurname { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}