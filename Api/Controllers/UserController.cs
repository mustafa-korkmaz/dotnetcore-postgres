﻿using System;
using System.Threading.Tasks;
using BoilerplateDotnetCorePostgres.ViewModels.User;
using Common;
using Common.Response;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace BoilerplateDotnetCorePostgres.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ApiControllerBase
    {
        private readonly ISecurity _security;

        public UserController(ISecurity security)
        {
            _security = security;
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken([FromBody]TokenRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrorResponse(ModelState));
            }

            var resp = await GetTokenResponse(model);

            if (resp.Type != ResponseType.Success)
            {
                return BadRequest(resp);
            }

            return Ok(resp);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrorResponse(ModelState));
            }

            var resp = await RegisterUser(model);

            if (resp.Type != ResponseType.Success)
            {
                return BadRequest(resp);
            }

            return Ok(resp);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = await GetUser();

            if (resp.Type != ResponseType.Success)
            {
                return BadRequest(resp);
            }

            return Ok(resp);
        }

        private async Task<ApiResponse<TokenViewModel>> GetTokenResponse(TokenRequestViewModel model)
        {
            var apiResp = new ApiResponse<TokenViewModel>
            {
                Type = ResponseType.Fail
            };

            var applicationUser = new ApplicationUser
            {
                Email = model.EmailOrUsername,
                UserName = model.EmailOrUsername
            };

            var securityResp = await _security.GetToken(applicationUser, model.Password);

            if (securityResp.Type != ResponseType.Success)
            {
                apiResp.ErrorCode = securityResp.ErrorCode;
                return apiResp;
            }

            var viewModel = new TokenViewModel
            {
                Username = applicationUser.UserName,
                AccessToken = securityResp.Data,
                Email = applicationUser.Email,
                NameSurname = applicationUser.NameSurname,
                Id = applicationUser.Id.ToString()
            };

            apiResp.Data = viewModel;
            apiResp.Type = ResponseType.Success;

            return apiResp;
        }

        /// <summary>
        /// returns user info by identity manager
        /// </summary>
        /// <returns></returns>
        private async Task<ApiResponse<UserViewModel>> GetUser()
        {
            var user = await _security.GetUser(User);

            return new ApiResponse<UserViewModel>
            {
                Type = ResponseType.Success,
                Data = new UserViewModel
                {
                    Id = user.Id.ToString(),
                    CreatedAt = user.CreatedAt,
                    Email = user.Email,
                    NameSurname = user.NameSurname,
                    Username = user.UserName,
                    EmailConfirmed = user.EmailConfirmed
                }
            };
        }

        /// <summary>
        /// creates new user
        /// </summary>
        /// <param name="model"></param>
        private async Task<ApiResponse> RegisterUser(RegisterRequestViewModel model)
        {
            var apiResp = new ApiResponse
            {
                Type = ResponseType.Fail
            };

            var applicationUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                NameSurname = model.NameSurname,
                UserName = model.Username,
                EmailConfirmed = true,
                CreatedAt = Utility.GetTurkeyCurrentDateTime()
            };

            var registerResp = await _security.Register(applicationUser, model.Password);

            if (registerResp.Type != ResponseType.Success)
            {
                apiResp.ErrorCode = registerResp.ErrorCode;
                return apiResp;
            }

            apiResp.Type = ResponseType.Success;
            return apiResp;
        }

    }
}