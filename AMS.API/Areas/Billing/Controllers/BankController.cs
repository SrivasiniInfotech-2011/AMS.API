using AMS.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Controllers
{
    [Area("Billing")]
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        #region [Private ReadOnly Fields]
        private readonly IMediator mediator;
        private readonly ILogger<BankController> _logger;
        #endregion

        #region [Constructor]
        /// <summary>
        /// Constructor For BankController.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public BankController(IMediator mediator, ILogger<BankController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }
        #endregion

        #region [Public Api Methods]
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
            try
            {
                var banks = await mediator.Send(new AMS.API.Areas.Billing.Services.Queries.GetAllBanks.Query());

                return Ok(new Response
                {
                    Status = Status.Success,
                    Message = JsonConvert.SerializeObject(banks)
                });

            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to fetch All Banks. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
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
            try
            {
                var newBank = await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.CreateBank.Command(bank));

                return Ok(new Response
                {
                    Status = Status.Success,
                    Message = JsonConvert.SerializeObject(newBank),
                    Id = newBank.BankId
                });
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to Create a Bank. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
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
            try
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
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to Update a Bank. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
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
        [Route("DeactivateBank/{id}")]
        public async Task<IActionResult> DeactivateBank([FromQuery] int id)
        {
            try
            {
                await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.DeActivateBank.Command(id));

                return Ok(new Response
                {
                    Status = Status.Success,
                    Id = id
                });
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error occured while trying to Dea Active a Bank. error: {ex?.Message}, stack trace: {ex?.StackTrace}");
                throw;
            }
        } 
        #endregion
    }
}
