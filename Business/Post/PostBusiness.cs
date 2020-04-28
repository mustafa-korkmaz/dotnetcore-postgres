using System.Collections.Generic;
using AutoMapper;
using Dal.Repositories.Post;
using Microsoft.Extensions.Logging;
using Dal;

namespace Business.Post
{
    public class PostBusiness : CrudBusiness<PostRepository, Dal.Entities.Post, Dto.Post>, IPostBusiness
    {
        public PostBusiness(IUnitOfWork uow, ILogger<PostBusiness> logger, IMapper mapper)
        : base(uow, logger, mapper)
        {
        }

        //[CacheableResult(Provider = "LocalMemoryCacheService", ExpireInMinutes = 10)]
        public IEnumerable<Dto.Post> SearchPosts(string title)
        {
            Logger.LogInformation("searching blogs!");

            var posts = Repository.SearchPosts(title);

            var dtos = Mapper.Map<IEnumerable<Dal.Entities.Post>, IEnumerable<Dto.Post>>(posts);

            return dtos;
        }
    }
}
