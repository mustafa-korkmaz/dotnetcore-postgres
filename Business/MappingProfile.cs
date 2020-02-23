﻿
using System.Collections.Generic;

namespace Business
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects

            CreateMap<Dal.Models.Identity.ApplicationUser, Dto.User.ApplicationUser>();
            CreateMap<Dto.User.ApplicationUser, Dal.Models.Identity.ApplicationUser>();

            CreateMap<Dto.Post, Dal.Models.Post>();
            CreateMap<Dal.Models.Post, Dto.Post>();
            //CreateMap<IEnumerable<Dto.Post>, IEnumerable<Dal.Models.Post>>();
            //CreateMap<IEnumerable<Dal.Models.Post>, IEnumerable<Dto.Post>>();

            CreateMap<Dto.Blog, Dal.Models.Blog>();
            CreateMap<Dal.Models.Blog, Dto.Blog>();
            //CreateMap<IEnumerable<Dto.Blog>, IEnumerable<Dal.Models.Blog>>();
            //CreateMap<IEnumerable<Dal.Models.Blog>, IEnumerable<Dto.Blog>>();
        }
    }
}