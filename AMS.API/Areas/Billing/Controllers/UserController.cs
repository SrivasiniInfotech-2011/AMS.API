using AMS.API.Services.Commands;
using AMS.API.Services.Queries;
using AMS.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Controllers
{
   
    [Area("Billing")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For ApartmentsController
        /// </summary>
        /// <param name="mediator"></param>
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var apartments = await mediator.Send(new GetAllUsers.Query());

            return Ok(apartments);
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
            var query = new GetUserByUserNameAndPassword.Query(loginRequest.UserName, loginRequest.Password);
            var user = await mediator.Send(query);
            var userToken = await IdentityServer4Client.LoginAsync(loginRequest.UserName, loginRequest.Password);
            return Ok(new Response
            {
                Status = Status.Success,
                Message = JsonConvert.SerializeObject(new { User = user, Token = userToken.AccessToken })
            });
        }


        /// <summary>
        /// Create an User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateApartment([FromBody] User user)
        {
            var newUser = await mediator.Send(new CreateUser.Command(user));

            return Ok(newUser);
        }

        /// <summary>
        /// Update a User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateApartment(int id, [FromBody] User user)
        {
            user.UserId = id;
            await mediator.Send(new UpdateUser.Command(user));

            return Ok("Success");
        }

        /// <summary>
        /// DeActivate a User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpDelete]
        [Route("DeactivateUser/{id}")]
        public async Task<IActionResult> DeactivateUser([FromQuery] int id)
        {
            await mediator.Send(new DeActivateUser.Command(id));

            return Ok("Success");
        }
    }
}
