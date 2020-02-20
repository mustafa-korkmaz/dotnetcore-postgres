using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Security.Claims;
using Common;

namespace BoilerplateDotnetCorePostgres.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// return model state errors as a sentence.
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        protected string GetModelStateErrors(ModelStateDictionary dic)
        {
            var list = dic.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            string result = string.Empty;

            for (int i = 1; i <= list.Count(); i++)
            {
                result += list[i - 1];

                if (i < list.Count())
                {
                    result += " ";
                }
            }

            return result.Trim();
        }

        /// <summary>
        /// returns user id from user principal claims.
        /// If not exists returns null
        /// </summary>
        /// <returns></returns>
        protected string GetUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(p => p.Type == "id");

            return userIdClaim?.Value;
        }

        /// <summary>
        /// returns user email from user principal claims.
        /// If not exists returns null
        /// </summary>
        /// <returns></returns>
        protected string GetUserEmail()
        {
            var userIdClaim = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Email);

            return userIdClaim?.Value;
        }

        /// <summary>
        /// returns user name from user principal claims.
        /// If not exists returns null
        /// </summary>
        /// <returns></returns>
        protected string GetUserName()
        {
            var userNameClaim = User.Claims.FirstOrDefault(p => p.Type == "username");

            return userNameClaim?.Value;
        }

        protected string GetChannelType()
        {
            var reqHeaders = HttpContext.Request.Headers;

            var channelTypeStr = reqHeaders[RequestHeader.ChannelType];

            return channelTypeStr.ToString();
        }

        /// <summary>
        /// returns user claims in token
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns></returns>
        protected string GetClaimValue(string claimType)
        {
            var claim = User.Claims.FirstOrDefault(p => p.Type == claimType);
            return claim?.Value;
        }

        /// <summary>
        /// returns request header value for given header key
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        protected string GetHeaderValue(string header)
        {
            var reqHeaders = HttpContext.Request.Headers;

            return reqHeaders[header].ToString();
        }
    }
}