﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Dal.Entities
{
    public class Post : EntityBase
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; } // navigation 
    }
}
