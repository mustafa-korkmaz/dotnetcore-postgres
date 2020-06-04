
using AutoMapper;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Dto.DtoBase, Dal.Entities.EntityBase>();
            CreateMap< Dal.Entities.EntityBase, Dto.DtoBase>();


            CreateMap< Dal.Entities.Identity.ApplicationUser, Dto.ApplicationUser>();
            CreateMap<Dto.ApplicationUser, Dal.Entities.Identity.ApplicationUser>();

            CreateMap<Dto.Post, Dal.Entities.Post>();
            CreateMap< Dal.Entities.Post, Dto.Post>();


            CreateMap<Dto.Blog, Dal.Entities.Blog>();
            CreateMap< Dal.Entities.Blog, Dto.Blog>();
        }
    }
}