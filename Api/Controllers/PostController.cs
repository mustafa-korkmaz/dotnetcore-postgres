using System.Collections.Generic;
using System.Linq;
using Business.Post;
using Common;
using Common.Response;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels.Post;

namespace BoilerplateDotnetCorePostgres.Controllers
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

            if (resp.Type != ResponseType.Success)
            {
                return BadRequest(resp.Code);
            }

            return Ok(resp);
        }

        private ApiResponse<IEnumerable<PostViewModel>> GetPosts()
        {
            var apiResp = new ApiResponse<IEnumerable<PostViewModel>>
            {
                Type = ResponseType.Fail
            };

            var resp = _postBusiness.SearchPosts("search text");

            apiResp.Data = resp.Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title
            });

            apiResp.Type = ResponseType.Success;
            return apiResp;
        }

    }
}