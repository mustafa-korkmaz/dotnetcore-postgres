using System.Collections.Generic;
using System.Linq;
using Business.Post;
using Common;
using Common.Response;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Post;

namespace boilerplate_dotnet_core_mysql.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBusiness _postBusiness;

        public PostController(IPostBusiness postBusiness)
        {
            _postBusiness = postBusiness;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var resp = GetPosts();

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        private ApiResponse<IEnumerable<PostViewModel>> GetPosts()
        {
            var apiResp = new ApiResponse<IEnumerable<PostViewModel>>
            {
                ResponseCode = ResponseCode.Fail
            };

            var resp = _postBusiness.SearchPosts("search text");

            apiResp.ResponseData = resp.Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title
            });

            apiResp.ResponseCode = ResponseCode.Success;
            return apiResp;
        }

    }
}