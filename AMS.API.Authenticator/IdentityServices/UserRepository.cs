using Dapper;
using System.Data.SqlClient;
using AMS.Models.Constants;
namespace AMS.API.Authenticator.IdentityServices
{
    public class UserRepository : IUserRepository
    {
        #region [Private Fields]
        public readonly string _connectionString = string.Empty; 
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="connectionString"></param>
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region [User Repository Methods]

        /// <summary>
        /// Validate User Credentials.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Returns Validation Result</returns>
        public async Task<bool> ValidateCredentials(string username, string password)
        {
            var user = await FindByUsername(username);
            if (user != null)
            {
                return user.User_Password!.Equals(password);
            }

            return false;
        }

        /// <summary>
        /// Find User By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns User By Id</returns>
        public async Task<User> FindById(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<User>(SqlCommandConstants.GetUserById, new { UserId = id });
            }
        }


        /// <summary>
        /// Find By User Name.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns User By Username</returns>
        public async Task<User> FindByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync<User>(SqlCommandConstants.GetUserByUsernameAndPassword, new { UserName = username });

                #endregion }
            }
        }
    }
}
