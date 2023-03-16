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
    public class HouseOwnerController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For HouseOwnerController
        /// </summary>
        /// <param name="mediator"></param>
        public HouseOwnerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All HouseOwners.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllHouseOwners")]
        public async Task<IActionResult> GetAllHouseOwners()
        {
            var houseowners = await mediator.Send(new GetAllHouseOwners.Query());

            return Ok(houseowners);
        }

        /// <summary>
        /// Get HouseOwner By Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHouseOwnerById")]
        public async Task<IActionResult> GetHouseOwnerById([FromQuery] GetHouseOwner.Query query)
        {
            var houseowner = await mediator.Send(query);

            return Ok(houseowner);
        }

        /// <summary>
        /// Create an HouseOwner.
        /// </summary>
        /// <param name="houseowner"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateHouseOwner")]
        public async Task<IActionResult> CreateHouseOwner([FromBody] HouseOwner houseowner)
        {
           var newHouseOwner = await mediator.Send(new CreateHouseOwner.Command(houseowner));

            return Ok(newHouseOwner);
        }

        /// <summary>
        /// Update an HouseOwner.
        /// </summary>
        /// <param name="houseowner"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateHouseOwner")]
        public async Task<IActionResult> UpdateHouseOwner([FromBody] HouseOwner houseowner)
        {
            await mediator.Send(new UpdateHouseOwner.Command(houseowner));

            return Ok("Success");
        }

        /// <summary>
        /// DeActivte an HouseOwner.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeactivateHouseOwner")]
        public async Task<IActionResult> DeactivateHouseOwner([FromQuery] int id)
        {
            await mediator.Send(new DeActivateHouseOwner.Command(id));

            return Ok("Success");
        }
    }
}