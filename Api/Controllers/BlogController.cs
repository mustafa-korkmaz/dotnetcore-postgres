using System.Collections.Generic;
using System.Linq;
using Business.Blog;
using Common;
using Common.Response;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Blog;

namespace BoilerplateDotnetCorePostgres.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogBusiness _blogBusiness;

        public BlogController(IBlogBusiness blogBusiness)
        {
            _blogBusiness = blogBusiness;
        }


        [HttpGet("all")]
        public IActionResult All()
        {
            var resp = GetBlogs();

            if (resp.Type != ResponseType.Success)
            {
                return BadRequest(resp.Code);
            }

            return Ok(resp);
        }

        private ApiResponse<IEnumerable<BlogViewModel>> GetBlogs()
        {
            var apiResp = new ApiResponse<IEnumerable<BlogViewModel>>
            {
                Type = ResponseType.Fail
            };

            var resp = _blogBusiness.SearchBlogs("google.com");

            apiResp.Data = resp.Select(p => new BlogViewModel
            {
                Id = p.Id,
                Url = p.Url
            });

            apiResp.Type = ResponseType.Success;
            return apiResp;
        }

    }
}