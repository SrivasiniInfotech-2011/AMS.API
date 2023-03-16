using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.API.Repositories.Apartments
{
    /// <summary>
    /// Repository for Apartment.
    /// </summary>
    public interface IApartmentRepository
    {
        /// <summary>
        /// Get All Apartments.
        /// </summary>
        /// <returns>List Of Apartment.</returns>
        Task<List<Apartment>> GetAllApartments();

        /// <summary>
        /// Get Apartment By Id.
        /// </summary>
        /// <param name="id">Get Apartment By Id.</param>
        /// <returns></returns>
        Task<Apartment> GetApartmentById(int id);

        /// <summary>
        /// Get Apartment By Any Field.
        /// </summary>
        /// <param name="">Apartment</param>
        /// <returns></returns>
        Task<Apartment> GetApartmentByAnyField(Func<Apartment, bool> expression);

        /// <summary>
        /// Insert an Apartment.
        /// </summary>
        /// <param name="apartment"></param>
        /// <returns>Apartment Object With The Latest Id.</returns>
        Task<Apartment> InsertApartment(Apartment apartment);

        /// <summary>
        /// Updates an Apartment.
        /// </summary>
        /// <param name="apartment">Update the Apartment Details.</param>
        /// <returns></returns>
        Task<Apartment> UpdateApartment(Apartment apartment);

        /// <summary>
        /// DeActivates and Apartment.
        /// </summary>
        /// <param name="id"></param>
        Task DeActivateApartment(int id);
    }
}
