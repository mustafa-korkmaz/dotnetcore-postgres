using System;
using Microsoft.AspNetCore.Identity;

namespace Dal.Entities.Identity
{
    public class ApplicationRole : IdentityRole<Guid>, IEntity<Guid>
    {
    }
}
