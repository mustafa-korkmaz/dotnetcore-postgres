using Dal.Blog;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Repositories.Post
{
    public class PostRepository : PostgreSqlDbRepository<Models.Post>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context)
        {
        }

        public IEnumerable<Models.Post> SearchPosts(string title)
        {
            var query = Entities.Where(p => p.Title.Contains(title));

            return query.ToList();
        }
    }
}
