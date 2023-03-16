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
    public class ApartmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For ApartmentsController
        /// </summary>
        /// <param name="mediator"></param>
        public ApartmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Apartments.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllApartments")]
        public async Task<IActionResult> GetAllApartments()
        {
            var apartments = await mediator.Send(new GetAllApartments.Query());
            return Ok(apartments);
        }

        /// <summary>
        /// Get Apartment By Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetApartmentById")]
        public async Task<IActionResult> GetApartmentById([FromQuery] GetApartment.Query query)
        {
            var apartment = await mediator.Send(query);

            return Ok(apartment);
        }

        /// <summary>
        /// Create an Apartment.
        /// </summary>
        /// <param name="apartment"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateApartment")]
        public async Task<IActionResult> CreateApartment([FromBody] Apartment apartment)
        {
           var newApartment= await mediator.Send(new CreateApartment.Command(apartment));

            return Ok(newApartment);
        }

        /// <summary>
        /// Update an Apartment.
        /// </summary>
        /// <param name="apartment"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateApartment")]
        public async Task<IActionResult> UpdateApartment([FromBody] Apartment apartment)
        {
            await mediator.Send(new UpdateApartment.Command(apartment));

            return Ok("Success");
        }

        /// <summary>
        /// DeActivte an Apartment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeactivateApartment")]
        public async Task<IActionResult> DeactivateApartment([FromQuery] int id)
        {
            await mediator.Send(new DeActivateApartment.Command(id));

            return Ok("Success");
        }
    }
}