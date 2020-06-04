using System;
using Dal.Blog;

namespace Dal.Repositories.User
{
    public class UserRepository : PostgreSqlDbRepository<Entities.Identity.ApplicationUser, Guid>, IUserRepository
    {
        public UserRepository(BlogDbContext context) : base(context)
        {
        }
    }
}
