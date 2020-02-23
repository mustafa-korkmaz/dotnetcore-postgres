using System.Threading.Tasks;
using BoilerplateDotnetCorePostgres.Models.User;
using BoilerplateDotnetCorePostgres.ViewModels.User;
using Common;
using Common.Response;
using Dto.User;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace BoilerplateDotnetCorePostgres.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        private readonly ISecurity _security;

        public UserController(ISecurity security)
        {
            _security = security;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody]TokenModel model)
        {
            var resp = await GetTokenResponse(model);

            if (resp.Type != ResponseType.Success)
            {
                return BadRequest(resp);
            }

            return Ok(resp);
        }


        private async Task<ApiResponse<TokenViewModel>> GetTokenResponse(TokenModel request)
        {
            var apiResp = new ApiResponse<TokenViewModel>
            {
                Type = ResponseType.Fail
            };

            var applicationUser = new ApplicationUser
            {
                Email = request.EmailOrUsername,
                UserName = request.EmailOrUsername
            };

            var securityResp = await _security.GetToken(applicationUser, request.Password);

            if (securityResp.Type != ResponseType.Success)
            {
                apiResp.ErrorCode = securityResp.ErrorCode;
                return apiResp;
            }

            var model = new TokenViewModel
            {
                Username = applicationUser.UserName,
                AccessToken = securityResp.Data,
                Email = applicationUser.Email,
                NameSurname = applicationUser.NameSurname,
                Id = applicationUser.Id
            };

            apiResp.Data = model;
            apiResp.Type = ResponseType.Success;

            return apiResp;
        }

    }
}