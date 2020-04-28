using System.Collections.Generic;

namespace Dal.Repositories.Post
{
    public interface IPostRepository : IRepository<Entities.Post>
    {
        IEnumerable<Entities.Post> SearchPosts(string title);
    }
}
