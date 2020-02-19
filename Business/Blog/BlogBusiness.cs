﻿using System.Collections.Generic;
using AutoMapper;
using Dal;
using Dal.Blog;
using Dal.Repositories.Blog;
using Microsoft.Extensions.Logging;
//using Services.Logging;

namespace Business.Blog
{
    public class BlogBusiness : IBlogBusiness
    {
        private readonly UnitOfWork _uow;
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BlogBusiness> _logger;

        public BlogBusiness(BlogDbContext context, ILogger<BlogBusiness> logger, IMapper mapper)
        {
            _uow = new UnitOfWork(context);
            _repository = _uow.Repository<BlogRepository, Dal.Models.Blog>();
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<Dto.Blog> SearchBlogs(string url)
        {
            var blogs = _repository.SearchBlogs(url);

            var dtos = _mapper.Map<IEnumerable<Dal.Models.Blog>, IEnumerable<Dto.Blog>>(blogs);

            return dtos;
        }

        public Dto.Blog Get(int id)
        {
            var blog = _repository.GetById(id);

            var dto = _mapper.Map<Dal.Models.Blog, Dto.Blog>(blog);

            return dto;
        }
    }
}