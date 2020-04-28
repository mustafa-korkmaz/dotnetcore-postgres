using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dal.Entities
{
    public class Blog : EntityBase
    {
        [MaxLength(50)]
        public string Url { get; set; }

        public virtual ICollection<Post> Posts { get; set; } //1=>n relation
    }

}
