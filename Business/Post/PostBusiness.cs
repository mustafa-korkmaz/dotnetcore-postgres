using System.Collections.Generic;
using AutoMapper;
using Dal.Repositories.Post;
using Dal.Blog;
using Microsoft.Extensions.Logging;

namespace Business.Post
{
    public class PostBusiness : CrudBusiness<PostRepository, Dal.Models.Post, Dto.Post>, IPostBusiness
    {
        public PostBusiness(BlogDbContext context, ILogger<PostBusiness> logger, IMapper mapper)
        : base(context, logger, mapper)
        {
        }

        //[CacheableResult(Provider = "LocalMemoryCacheService", ExpireInMinutes = 10)]
        public IEnumerable<Dto.Post> SearchPosts(string title)
        {
            Logger.LogInformation("searching blogs!");

            var posts = Repository.SearchPosts(title);

            var dtos = Mapper.Map<IEnumerable<Dal.Models.Post>, IEnumerable<Dto.Post>>(posts);

            return dtos;
        }
    }
}
