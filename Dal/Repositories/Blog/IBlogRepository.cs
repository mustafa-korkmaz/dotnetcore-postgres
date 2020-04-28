using System.Collections.Generic;

namespace Dal.Repositories.Blog
{
    public interface IBlogRepository : IRepository<Entities.Blog>
    {
        IEnumerable<Entities.Blog> SearchBlogs(string url);
    }
}
