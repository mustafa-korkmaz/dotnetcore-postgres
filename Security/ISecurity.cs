﻿using System.Security.Claims;
using Common.Response;
using Dto;
using System.Threading.Tasks;

namespace Security
{
    public interface ISecurity
    {
        /// <summary>
        /// Checks for user by username or email. Sets user info and returns a valid token
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<DataResponse<string>> GetToken(ApplicationUser userDto, string password);
    
        /// <summary>
        /// Creates user and sets user info
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ResponseBase> Register(ApplicationUser userDto, string password);

        /// <summary>
        /// resets user's password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<ResponseBase> ResetPassword(string userId, string password);

        /// <summary>
        /// changes user password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        Task<ResponseBase> ChangePassword(string email, string newPassword);

        /// <summary>
        /// returns current user info by user id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetUser(ClaimsPrincipal user);
    }
}
