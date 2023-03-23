using AMS.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Repositories
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// Get All Companys For Listing.
        /// </summary>
        /// <returns></returns>
        Task<List<Company>> GetAllCompanys();

        /// <summary>
        /// Get Company By Company Id.
        /// </summary>
        /// <returns></returns>
        Task<Company> GetCompanyById(int CompanyId);

        /// <summary>
        /// Insert a new Company.
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Company Object With The Latest Id.</returns>
        Task<Company> InsertCompany(Company company);

        /// <summary>
        /// Updates a Company.
        /// </summary>
        /// <param name="company">Update the User Details.</param>
        /// <returns></returns>
        Task<Company> UpdateCompany(Company company);

        /// <summary>
        /// DeActivates a Company.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyId"></param>
        Task DeActivateCompany(int companyId);
    }
}
