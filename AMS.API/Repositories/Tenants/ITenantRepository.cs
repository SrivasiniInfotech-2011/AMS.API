using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AMS.API.Repositories.Tenants
{
    /// <summary>
    /// Repository for Tenant.
    /// </summary>
    public interface ITenantRepository
    {
        /// <summary>
        /// Get All Tenants.
        /// </summary>
        /// <returns>List Of Tenant.</returns>
        Task<List<Tenant>> GetAllTenants();

        /// <summary>
        /// Get Tenant By Id.
        /// </summary>
        /// <param name="id">Get Tenant By Id.</param>
        /// <returns></returns>
        Task<Tenant> GetTenantById(int id);
        Task<Tenant> GetTenantById(object tenantId);

        /// <summary>
        /// Get Tenant By Any Field.
        /// </summary>
        /// <param name="">Tenant</param>
        /// <returns></returns>
        Task<Tenant> GetTenantByAnyField(Func<Tenant, bool> expression);

        /// <summary>
        /// Insert an Tenant.
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns>Tenant Object With The Latest Id.</returns>
        Task<Tenant> InsertTenant(Tenant tenant);

        /// <summary>
        /// Updates an Tenant.
        /// </summary>
        /// <param name="Tenant">Update the Tenant Details.</param>
        /// <returns></returns>
        Task<Tenant> UpdateTenant(Tenant Tenant);

        /// <summary>
        /// DeActivates and Tenant.
        /// </summary>
        /// <param name="id"></param>
        Task DeActivateTenant(int id);
    }
}
