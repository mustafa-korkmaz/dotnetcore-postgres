using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Common;
using Common.Response;
using Dal.Models;
using Dto;
using System.Linq;
using Dal.Blog;
using Dal.Repositories;
using Microsoft.Extensions.Logging;

namespace Business
{
    /// <summary>
    /// Abstract class for basic create, update, delete and get operations.
    /// </summary>
    /// <typeparam name="TEntity">TEntity is db entity.</typeparam>
    /// <typeparam name="TDto">TDto is data transfer object.</typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public abstract class CrudBusiness<TRepository, TEntity, TDto> : ICrudBusiness<TEntity, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
        where TRepository : IRepository<TEntity>
    {
        protected readonly UnitOfWork Uow;
        protected readonly TRepository Repository;
        protected readonly IMapper Mapper;
        protected readonly ILogger Logger;

        /// <summary>
        /// to avoid IDOR attacks checks userId of entity and the given dto are the same or not
        /// </summary>
        protected bool ValidateEntityOwner;

        protected CrudBusiness(BlogDbContext context, ILogger logger, IMapper mapper)
        {
            Uow = new UnitOfWork(context);
            Repository = Uow.Repository<TRepository, TEntity>();
            Logger = logger;
            Mapper = mapper;
        }

        public virtual void Add(TDto dto)
        {
            var entity = Mapper.Map<TDto, TEntity>(dto);

            Repository.Insert(entity);

            Uow.Save();

            dto.Id = entity.Id;
        }

        public virtual void AddRange(IEnumerable<TDto> dtoList)
        {
            var entities = Mapper.Map<IEnumerable<TDto>, IEnumerable<TEntity>>(dtoList);

            Repository.InsertRange(entities);

            Uow.Save();
        }

        public virtual DataResponse<int> Edit(TDto dto)
        {
            var businessResp = new DataResponse<int>
            {
                Type = ResponseType.Fail
            };

            var entity = Repository.GetById(dto.Id);

            if (entity == null)
            {
                businessResp.Code = ErrorMessage.RecordNotFound;
                return businessResp;
            }

            var type = typeof(TEntity);

            var entityProperties = type.GetProperties();

            if (ValidateEntityOwner)
            {
                //client wants to check for an IDOR attack
                var userIdPropExists = entityProperties.Any(p => p.Name == "UserId");

                if (userIdPropExists)
                {
                    PropertyInfo entityProperty = typeof(TEntity).GetProperty("UserId");
                    PropertyInfo dtoProperty = typeof(TDto).GetProperty("UserId");

                    var entityUserId = entityProperty.GetValue(entity).ToString();
                    var dtoUserId = dtoProperty.GetValue(dto).ToString();

                    if (!entityUserId.Equals(dtoUserId))
                    {
                        businessResp.Code = ErrorMessage.NotAuthorized;
                        return businessResp;
                    }
                }
            }

            foreach (PropertyInfo entityProperty in entityProperties)
            {
                //Only modify settable properties. Do not change CreatedAt property.
                if (entityProperty.CanWrite && entityProperty.Name != "CreatedAt")
                {
                    PropertyInfo dtoProperty = typeof(TDto).GetProperty(entityProperty.Name); //POCO obj must have same prop as model

                    var value = dtoProperty.GetValue(dto); //get new value of entity from dto object

                    entityProperty.SetValue(entity, value, null); //set new value of entity
                }
            }

            Repository.Update(entity);

            var affectedRows = Uow.Save();

            businessResp.Data = affectedRows;
            businessResp.Type = ResponseType.Success;
            return businessResp;
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(id);

            Uow.Save();

            var type = typeof(TEntity);

            //log db record deletion as an info
            Logger.LogInformation(string.Format("'{0}' entity has been hard-deleted.", type.ToString()));
        }

        public virtual void Delete(TEntity entity)
        {
            Repository.Delete(entity);

            Uow.Save();

            var type = typeof(TEntity);

            //log db record deletion as an info
            var args = new TEntity[1];
            args[0] = entity;
            Logger.LogInformation(string.Format("'{0}' entity has been deleted.", type.ToString()), args);
        }

        public virtual void SoftDelete(int id)
        {
            var entity = Repository.GetById(id);

            bool updated = false;

            if (entity == null)
            {
                return;
            }

            var type = typeof(TEntity);

            var entityProperties = type.GetProperties();

            foreach (PropertyInfo entityProperty in entityProperties)
            {
                //Only modify IsDeleted property. Do not change others
                if (entityProperty.CanWrite && entityProperty.Name == "IsDeleted")
                {
                    entityProperty.SetValue(entity, true, null); //soft deletion

                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                Repository.Update(entity);
                Uow.Save();
            }

            //log db record modification as an info
            Logger.LogInformation(string.Format("'{0}' entity with ID: {1} has been modified.", type, id));
        }


        public virtual DataResponse<TDto> Get(int id)
        {
            var businessResp = new DataResponse<TDto>
            {
                Type = ResponseType.Fail
            };

            var entity = Repository.GetById(id);

            if (entity == null)
            {
                businessResp.Code = ErrorMessage.RecordNotFound;
                return businessResp;
            }

            var dto = Mapper.Map<TEntity, TDto>(entity);

            businessResp.Type = ResponseType.Success;
            businessResp.Data = dto;

            return businessResp;
        }

        public virtual DataResponse<IEnumerable<TDto>> GetAll()
        {
            var businessResp = new DataResponse<IEnumerable<TDto>>
            {
                Type = ResponseType.Fail
            };

            var entities = Repository.GetAll();

            if (!entities.Any())
            {
                businessResp.Code = ErrorMessage.RecordNotFound;
                return businessResp;
            }

            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);

            businessResp.Type = ResponseType.Success;
            businessResp.Data = dtos;

            return businessResp;
        }
    }
}
