using AMS.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Controllers
{
    [Area("Billing")]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For BankController.
        /// </summary>
        /// <param name="mediator"></param>
        public BankController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Banks.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpGet]
        [Route("GetAllBanks")]
        public async Task<IActionResult> GetAllBanks()
        {
            var banks = await mediator.Send(new AMS.API.Areas.Billing.Services.Queries.GetAllBanks.Query());

            return Ok(new Response
            {
                Status = Status.Success,
                Message = JsonConvert.SerializeObject(banks)
            });
        }


        /// <summary>
        /// Create a Bank.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPost]
        [Route("CreateBank")]
        public async Task<IActionResult> CreateBank([FromBody] Bank bank)
        {
            var newBank = await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.CreateBank.Command(bank));

            return Ok(new Response
            {
                Status = Status.Success,
                Message = JsonConvert.SerializeObject(newBank),
                Id=newBank.BankId
            });
        }

        /// <summary>
        /// Update a Bank.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPut]
        [Route("UpdateBank/{id}")]
        public async Task<IActionResult> UpdateBank(int id, [FromBody] Bank bank)
        {
            bank.BankId = id;
            await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.UpdateBank.Command(bank));

            return Ok(new Response
            {
                Status = Status.Success,
                Message = JsonConvert.SerializeObject(bank),
                Id = bank.BankId
            });
        }

        /// <summary>
        /// DeActivate a User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpDelete]
        [Route("DeactivateBank/{id}")]
        public async Task<IActionResult> DeactivateBank([FromQuery] int id)
        {
            await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.DeActivateBank.Command(id));

            return Ok(new Response
            {
                Status = Status.Success,
                Id = id
            });
        }
    }
}
