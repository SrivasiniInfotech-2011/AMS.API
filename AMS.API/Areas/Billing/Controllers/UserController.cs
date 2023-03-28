using AMS.API.Services.Commands;
using AMS.API.Services.Queries;
using AMS.Models.Entities;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Controllers
{

    [Area("Billing")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region [Private ReadOnly Fields]
        private readonly IMediator mediator;
        private readonly ILogger<UserController> _logger;
        #endregion

        #region [Constructor]
        /// <summary>
        /// Constructor For ApartmentsController
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }
        #endregion

        #region [Public Api Methods]

        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var apartments = await mediator.Send(new GetAllUsers.Query());

                return Ok(apartments);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to fetch All Users. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Get User By Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPost]
        [Route("GetUserByUserNameAndPassword")]
        public async Task<IActionResult> GetUserById(LoginRequest loginRequest)
        {
            try
            {
                var query = new GetUserByUserNameAndPassword.Query(loginRequest.UserName, loginRequest.Password);
                var user = await mediator.Send(query);
                var userToken = await IdentityServer4Client.LoginAsync(loginRequest.UserName, loginRequest.Password);
                return Ok(new Response
                {
                    Status = Status.Success,
                    Message = JsonConvert.SerializeObject(new { User = user, Token = userToken.AccessToken, Expiry = userToken.ExpiresIn })
                });
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to getting User By Id. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
        }


        /// <summary>
        /// Create an User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPost]
        [Route("CreateUser")]
        [Authorize]
        public async Task<IActionResult> CreateApartment([FromBody] User user)
        {
            try
            {
                var newUser = await mediator.Send(new CreateUser.Command(user));

                return Ok(newUser);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to Create a User. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Update a User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPut]
        [Route("UpdateUser/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateApartment(int id, [FromBody] User user)
        {
            try
            {
                user.UserId = id;
                await mediator.Send(new UpdateUser.Command(user));

                return Ok("Success");
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to Update a User. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// DeActivate a User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpDelete]
        [Route("DeactivateUser/{id}")]
        [Authorize]
        public async Task<IActionResult> DeactivateUser([FromQuery] int id)
        {
            try
            {
                await mediator.Send(new DeActivateUser.Command(id));

                return Ok("Success");
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to De Activate a User. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Get User By Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(LoginRequest loginRequest)
        {
            try
            {
                TokenResponse userToken = await IdentityServer4Client.LoginAsync(loginRequest.UserName, loginRequest.Password);
                return Ok(new Response
                {
                    Status = Status.Success,
                    Message = JsonConvert.SerializeObject(new {Token = userToken.AccessToken,Expiry=userToken.ExpiresIn })
                });
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to getting Refresh Token. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
        }

        #endregion
    }
}
