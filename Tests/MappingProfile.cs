
namespace Tests
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Dto.Post, Dal.Entities.Post>();
            CreateMap< Dal.Entities.Post, Dto.Post>();

            CreateMap<Dto.Blog, Dal.Entities.Blog>();
            CreateMap< Dal.Entities.Blog, Dto.Blog>();
        }
    }
}