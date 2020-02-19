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

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        private ApiResponse<IEnumerable<BlogViewModel>> GetBlogs()
        {
            var apiResp = new ApiResponse<IEnumerable<BlogViewModel>>
            {
                ResponseCode = ResponseCode.Fail
            };

            var resp = _blogBusiness.SearchBlogs("google.com");

            apiResp.ResponseData = resp.Select(p => new BlogViewModel
            {
                Id = p.Id,
                Url = p.Url
            });

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }

    }
}