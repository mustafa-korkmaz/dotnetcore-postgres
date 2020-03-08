
using System.Collections.Generic;

namespace Business.Post
{
    public interface IPostBusiness : ICrudBusiness<Dto.Post>
    {
        IEnumerable<Dto.Post> SearchPosts(string title);
    }
}
