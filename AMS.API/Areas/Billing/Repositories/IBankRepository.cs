using AMS.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Repositories
{
    public interface IBankRepository
    {
        /// <summary>
        /// Get All Banks For Listing.
        /// </summary>
        /// <returns></returns>
        Task<List<Bank>> GetAllBanks();

        /// <summary>
        /// Get Bank By Bank Id.
        /// </summary>
        /// <returns></returns>
        Task<Bank> GetBankById(int BankId);

        /// <summary>
        /// Insert a new Bank.
        /// </summary>
        /// <param name="bank"></param>
        /// <returns>Bank Object With The Latest Id.</returns>
        Task<Bank> InsertBank(Bank bank);

        /// <summary>
        /// Updates a Bank.
        /// </summary>
        /// <param name="bank">Update the User Details.</param>
        /// <returns></returns>
        Task<Bank> UpdateBank(Bank bank);

        /// <summary>
        /// DeActivates a Bank.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyId"></param>
        Task DeActivateBank(int bankId, int companyId);
    }
}
