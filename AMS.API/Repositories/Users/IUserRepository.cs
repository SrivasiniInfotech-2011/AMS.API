using AMS.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.API.Repositories.Users
{
    /// <summary>
    /// Repository for User.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllUsers();

        /// <summary>
        /// Get User By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Get User By UserName and Password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> GetUserByUserNameAndPassword(string userName, string password);

        /// <summary>
        /// Insert an User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User Object With The Latest Id.</returns>
        Task<User> InsertUser(User user);

        /// <summary>
        /// Updates an User.
        /// </summary>
        /// <param name="user">Update the User Details.</param>
        /// <returns></returns>
        Task<User> UpdateUser(User user);

        /// <summary>
        /// DeActivates a User.
        /// </summary>
        /// <param name="id"></param>
        Task DeActivateUser(int id);
    }
}
