using Dal.Blog;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Repositories.Blog
{
    public class BlogRepository : PostgreSqlDbRepository<Entities.Blog, int>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context) : base(context)
        {
        }

        public IEnumerable<Entities.Blog> SearchBlogs(string url)
        {
            var query = Entities.Where(p => p.Url.Contains(url));

            return query.ToList();
        }
    }
}
