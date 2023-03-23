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
    public class CompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For BankController.
        /// </summary>
        /// <param name="mediator"></param>
        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Companys.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpGet]
        [Route("GetAllCompanys")]
        public async Task<IActionResult> GetAllCompanys()
        {
            var companys = await mediator.Send(new AMS.API.Areas.Billing.Services.Queries.GetAllCompanys.Query());

            return Ok(new Response
            {
                Status = Status.Success,
                Message = JsonConvert.SerializeObject(companys)
            });
        }


        /// <summary>
        /// Create a Company.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPost]
        [Route("CreateCompany")]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            var newCompany = await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.CreateCompany.Command(company));

            return Ok(new Response
            {
                Status = Status.Success,
                Message = JsonConvert.SerializeObject(newCompany),
                Id=newCompany.CompanyId
            });
        }

        /// <summary>
        /// Update a Company.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpPut]
        [Route("UpdateCompany/{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Company company)
        {
            company.CompanyId = id;
            await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.UpdateCompany.Command(company));

            return Ok(new Response
            {
                Status = Status.Success,
                Message = JsonConvert.SerializeObject(company),
                Id = company.CompanyId
            });
        }

        /// <summary>
        /// DeActivate a User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [GroupTag("Billing")]
        [HttpDelete]
        [Route("DeactivateCompany/{id}")]
        public async Task<IActionResult> DeactivateCompany([FromQuery] int id)
        {
            await mediator.Send(new AMS.API.Areas.Billing.Services.Commands.DeActivateCompany.Command(id));

            return Ok(new Response
            {
                Status = Status.Success,
                Id = id
            });
        }
    }
}
