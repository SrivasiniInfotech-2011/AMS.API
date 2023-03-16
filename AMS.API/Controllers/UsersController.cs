using AMS.API.Services.Commands;
using AMS.API.Services.Queries;
using AMS.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For ApartmentsController
        /// </summary>
        /// <param name="mediator"></param>
        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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
        [HttpPost]
        [Route("GetUserByUserNameAndPassword")]
        public async Task<IActionResult> GetUserById(LoginRequest loginRequest)
        {
            var query = new GetUserByUserNameAndPassword.Query(loginRequest.UserName, loginRequest.Password);
            var user = await mediator.Send(query);
            var userToken = await IdentityServer4Client.LoginAsync(loginRequest.UserName, loginRequest.Password);
            return Ok(new {User= user ,Token=userToken.AccessToken});


        }

        /// <summary>
        /// Create an User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateApartment([FromBody] User user)
        {
           var newUser= await mediator.Send(new CreateUser.Command(user));

            return Ok(newUser);
        }

        /// <summary>
        /// Update a User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateApartment(int id,[FromBody] User user)
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
        [HttpDelete]
        [Route("DeactivateUser/{id}")]
        public async Task<IActionResult> DeactivateUser([FromQuery] int id)
        {
            await mediator.Send(new DeActivateUser.Command(id));

            return Ok("Success");
        }
    }
}