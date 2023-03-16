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
    public class HousesController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For HousesController
        /// </summary>
        /// <param name="mediator"></param>
        public HousesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Houses.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllHouses")]
        public async Task<IActionResult> GetAllHouses()
        {
            var houses = await mediator.Send(new GetAllHouses.Query());

            return Ok(houses);
        }

        /// <summary>
        /// Get House By Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHouseById")]
        public async Task<IActionResult> GetHouseById([FromQuery] GetHouse.Query query)
        {
            var house = await mediator.Send(query);

            return Ok(house);
        }

        /// <summary>
        /// Create an House.
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateHouse")]
        public async Task<IActionResult> CreateHouse([FromBody] House house)
        {
            var newHouse = await mediator.Send(new CreateHouse.Command(house));

            return Ok(newHouse);
        }

        /// <summary>
        /// Update an House.
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateHouse")]
        public async Task<IActionResult> UpdateHouse([FromBody] House house)
        {
            await mediator.Send(new UpdateHouse.Command(house));

            return Ok("Success");
        }

        /// <summary>
        /// DeActivte an House.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeactivateHouse")]
        public async Task<IActionResult> DeactivateHouse([FromQuery] int id)
        {
            await mediator.Send(new DeActivateHouse.Command(id));

            return Ok("Success");
        }

        /// <summary>
        /// Get All Houses By Apartment and Block.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHousesByBlockandApartment")]
        public async Task<IActionResult> GetHousesByBlockandApartment([FromQuery] int apartmentId, int blockId)
        {
            var query = new GetHouseByExpression.Query(s => s.ApartmentId == apartmentId && s.BlockId == blockId);
            var houses = await mediator.Send(query);

            return Ok(houses);
        }
    }
}