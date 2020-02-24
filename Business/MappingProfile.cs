
using AutoMapper;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Dto.DtoBase, Dal.Models.EntityBase>();
            CreateMap<Dal.Models.EntityBase, Dto.DtoBase>();


            CreateMap<Dal.Models.Identity.ApplicationUser, Dto.User.ApplicationUser>();
            CreateMap<Dto.User.ApplicationUser, Dal.Models.Identity.ApplicationUser>();

            CreateMap<Dto.Post, Dal.Models.Post>();
            CreateMap<Dal.Models.Post, Dto.Post>();


            CreateMap<Dto.Blog, Dal.Models.Blog>();
            CreateMap<Dal.Models.Blog, Dto.Blog>();
            //CreateMap<IEnumerable<Dto.Blog>, IEnumerable<Dal.Models.Blog>>();
            //CreateMap<IEnumerable<Dal.Models.Blog>, IEnumerable<Dto.Blog>>();
        }
    }
}