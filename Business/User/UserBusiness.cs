using System;
using AutoMapper;
using Dal;
using Dal.Repositories.User;
using Microsoft.Extensions.Logging;

namespace Business.User
{
    public class UserBusiness : CrudBusiness<IUserRepository, Dal.Entities.Identity.ApplicationUser, Dto.ApplicationUser, Guid>, IUserBusiness
    {
        public UserBusiness(IUnitOfWork uow, ILogger<IUserRepository> logger, IMapper mapper)
            : base(uow, logger, mapper)
        {
        }
    }
}
