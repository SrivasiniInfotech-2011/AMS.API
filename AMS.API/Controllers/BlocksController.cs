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
    public class BlocksController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For BlocksController
        /// </summary>
        /// <param name="mediator"></param>
        public BlocksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Blocks.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllBlocks")]
        public async Task<IActionResult> GetAllBlocks()
        {
            var blocks = await mediator.Send(new GetAllBlocks.Query());
            return Ok(blocks);
        }

        /// <summary>
        /// Get Block By Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBlockById")]
        public async Task<IActionResult> GetBlockById([FromQuery] GetBlock.Query query)
        {
            var block = await mediator.Send(query);

            return Ok(block);
        }

        /// <summary>
        /// Create an Block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateBlock")]
        public async Task<IActionResult> CreateBlock([FromBody] Block block)
        {
           var newBlock = await mediator.Send(new CreateBlock.Command(block));

            return Ok(newBlock);
        }

        /// <summary>
        /// Update an Block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateBlock")]
        public async Task<IActionResult> UpdateBlock([FromBody] Block block)
        {
            await mediator.Send(new UpdateBlock.Command(block));

            return Ok("Success");
        }

        /// <summary>
        /// DeActivte an Block.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeactivateBlock")]
        public async Task<IActionResult> DeactivateBlock([FromQuery] int id)
        {
            await mediator.Send(new DeActivateBlock.Command(id));

            return Ok("Success");
        }

        /// <summary>
        /// Get Block By Apartment Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBlockByApartmentId")]
        public async Task<IActionResult> GetBlockByApartmentId([FromQuery] int apartmentId)
        {
            var query = new GetBlockByExpression.Query(s => s.ApartmentId == apartmentId);
            var blocks = await mediator.Send(query);
            return Ok(blocks);
        }
    }
}