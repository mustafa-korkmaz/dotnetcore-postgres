
namespace Business
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Dto.Post, Dal.Models.Post>();
            CreateMap<Dal.Models.Post, Dto.Post>();

            CreateMap<Dto.Blog, Dal.Models.Blog>();
            CreateMap<Dal.Models.Blog, Dto.Blog>();
        }
    }
}