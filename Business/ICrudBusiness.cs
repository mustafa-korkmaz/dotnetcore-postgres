
using Common.Response;
using Dal.Models;
using Dto;
using System.Collections.Generic;

namespace Business
{
    public interface ICrudBusiness<in TEntity, TDto>
       where TEntity : EntityBase
       where TDto : DtoBase
    {
        /// <summary>
        /// creates new entity from given dto
        /// </summary>
        /// <param name="dto"></param>
        void Add(TDto dto);

        /// <summary>
        /// creates new entities as bulk insert from given dto list
        /// </summary>
        /// <param name="dtoList"></param>
        void AddRange(IEnumerable<TDto> dtoList);

        /// <summary>
        /// updates given entity and returns affected row count.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>affected row count in db</returns>
        BusinessResponse<int> Edit(TDto dto);

        /// <summary>
        /// hard deletes the given entity.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// hard deletes entity by given id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// soft deletes entity
        /// </summary>
        /// <param name="id"></param>
        void SoftDelete(int id);

        /// <summary>
        /// returns dto object by given id
        /// </summary>
        /// <param name="id"></param>
        BusinessResponse<TDto> Get(int id);

        /// <summary>
        /// returns all dto objects
        /// </summary>
        BusinessResponse<IEnumerable<TDto>> GetAll();
    }
}
