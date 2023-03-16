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
    public class TenantsController : ControllerBase
    {
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor For TenantsController
        /// </summary>
        /// <param name="mediator"></param>
        public TenantsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get All Tenants.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllTenants")]
        public async Task<IActionResult> GetAllTenants()
        {
            var tenants = await mediator.Send(new GetAllTenants.Query());

            return Ok(tenants);
        }

        /// <summary>
        /// Get Tenant By Id.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTenantById")]
        public async Task<IActionResult> GetTenantById([FromQuery] GetTenant.Query query)
        {
            var tenant = await mediator.Send(query);

            return Ok(tenant);
        }

        /// <summary>
        /// Create an Tenant.
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateTenant")]
        public async Task<IActionResult> CreateTenant([FromBody] Tenant tenant)
        {
            var newTenant = await mediator.Send(new CreateTenant.Command(tenant));

            return Ok(newTenant);
        }

        /// <summary>
        /// Update an Tenant.
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateTenant")]
        public async Task<IActionResult> UpdateTennt([FromBody] Tenant tenant)
        {
            await mediator.Send(new UpdateTenant.Command(tenant));

            return Ok("Success");
        }

        /// <summary>
        /// DeActivte an Tenant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeactivateTenant")]
        public async Task<IActionResult> DeactivateTenant([FromQuery] int id)
        {
            await mediator.Send(new DeActivateTenant.Command(id));

            return Ok("Success");
        }
    }
}