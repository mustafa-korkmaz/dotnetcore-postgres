using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Dal.Models.Identity
{
    public class ApplicationUserLogin<T> : IdentityUserLogin<T> where T : IEquatable<T>
    {
        [Required]
        public DateTime ExpiresAt { get; set; }
    }
}
