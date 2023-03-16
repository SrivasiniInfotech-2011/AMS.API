using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AMS.API.Repositories.HouseOwners
{
    /// <summary>
    /// Repository for HouseOwners.
    /// </summary>
    public interface IHouseOwnerRepository
    {
        /// <summary>
        /// Get All HouseOwners.
        /// </summary>
        /// <returns>List Of HouseOwners.</returns>
        Task<List<HouseOwner>> GetAllHouseOwners();

        /// <summary>
        /// Get HouseOwners By Id.
        /// </summary>
        /// <param name="id">Get HouseOwners By Id.</param>
        /// <returns></returns>
        Task<HouseOwner> GetHouseOwnerById(int id);
        Task<HouseOwner> GetHouseOwnerById(object HouseOwnerId);

        /// <summary>
        /// Get HouseOwner By Any Field.
        /// </summary>
        /// <param name="">HouseOwner</param>
        /// <returns></returns>
        Task<HouseOwner> GetHouseOwnerByAnyField(Func<HouseOwner, bool> expression);

        /// <summary>
        /// Insert an HouseOwner.
        /// </summary>
        /// <param name="houseowner"></param>
        /// <returns>HouseOwners Object With The Latest Id.</returns>
        Task<HouseOwner> InsertHouseOwner(HouseOwner HouseOwner);

        /// <summary>
        /// Updates an HouseOwner.
        /// </summary>
        /// <param name="HouseOwner">Update the HouseOwners.</param>
        /// <returns></returns>
        Task<HouseOwner> UpdateHouseOwner(HouseOwner HouseOwner);

        /// <summary>
        /// DeActivates and HouseOwner.
        /// </summary>
        /// <param name="id"></param>
        Task DeActivateHouseOwner(int id);
    }
}
