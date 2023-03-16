using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AMS.API.Repositories.Houses
{
    /// <summary>
    /// Repository for House.
    /// </summary>
    public interface IHouseRepository
    {
        /// <summary>
        /// Get All Houses.
        /// </summary>
        /// <returns>List Of House.</returns>
        Task<List<House>> GetAllHouses();

        /// <summary>
        /// Get House By Id.
        /// </summary>
        /// <param name="id">Get House By Id.</param>
        /// <returns></returns>
        Task<House> GetHouseById(int id);

        /// <summary>
        /// Get House By Any Field.
        /// </summary>
        /// <param name="">House</param>
        /// <returns></returns>
        Task<List<House>> GetHouseByAnyField(Func<House, bool> expression);

        /// <summary>
        /// Insert an House.
        /// </summary>
        /// <param name="house"></param>
        /// <returns>House Object With The Latest Id.</returns>
        Task<House> InsertHouse(House house);

        /// <summary>
        /// Updates an House.
        /// </summary>
        /// <param name="House">Update the House Details.</param>
        /// <returns></returns>
        Task<House> UpdateHouse(House House);

        /// <summary>
        /// DeActivates and House.
        /// </summary>
        /// <param name="id"></param>
        Task DeActivateHouse(int id);
    }
}
