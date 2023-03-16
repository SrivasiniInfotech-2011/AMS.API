using AMS.Models.Constants;
using AMS.Models.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public UserRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// Deactivates a User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeActivateUser(int id)
        {
            await this.sqlConnection.ExecuteAsync(SqlCommandConstants.DEACTIVATE_USER, new { UserId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUsers()
        {
            var lstUsers = await this.sqlConnection.QueryAsync<User>(SqlCommandConstants.GET_ALL_USERS).ConfigureAwait(false);
            return lstUsers.ToList();
        }

        /// <summary>
        /// Get User By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(int id)
        {
            return await this.sqlConnection.QueryFirstAsync<User>(SqlCommandConstants.GET_USER_BY_ID, new { UserId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get User By UserName and Password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> GetUserByUserNameAndPassword(string userName, string password)
        {
            try
            {
                return await this.sqlConnection.QueryFirstOrDefaultAsync<User>(SqlCommandConstants.GET_USER_BY_USERNAME_AND_PASSWORD, new { UserName = userName, UserPassword = password }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Create a new User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> InsertUser(User user)
        {
            try
            {
                this.sqlConnection.Open();

                var cmd = this.sqlConnection.CreateCommand();
                cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_USER_DETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@User_First_Name", user.UserFirstName));
                cmd.Parameters.Add(new SqlParameter("@User_Last_Name", user.UserLastName));
                cmd.Parameters.Add(new SqlParameter("@User_User_Name", user.UserUserName));
                cmd.Parameters.Add(new SqlParameter("@User_Password", user.UserPassword));
                cmd.Parameters.Add(new SqlParameter("@User_Doj", user.UserDoj));
                cmd.Parameters.Add(new SqlParameter("@User_Dob", user.UserDob));
                cmd.Parameters.Add(new SqlParameter("@User_CreatorOrModifier_Id", user.CreatedBy));

                var outParam = new SqlParameter("@Output_User_Id", System.Data.SqlDbType.Int);
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();

                int newUserId = Convert.ToInt32(cmd.Parameters["@Output_User_Id"].Value);
                user.UserId = newUserId;

                this.sqlConnection.Close();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updated User Details.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateUser(User user)
        {
            try
            {
                this.sqlConnection.Open();

                var cmd = this.sqlConnection.CreateCommand();
                cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_USER_DETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@User_Id", user.UserId));
                cmd.Parameters.Add(new SqlParameter("@User_First_Name", user.UserFirstName));
                cmd.Parameters.Add(new SqlParameter("@User_Last_Name", user.UserLastName));
                cmd.Parameters.Add(new SqlParameter("@User_User_Name", user.UserUserName));
                cmd.Parameters.Add(new SqlParameter("@User_Password", user.UserPassword));
                cmd.Parameters.Add(new SqlParameter("@User_Doj", user.UserDoj));
                cmd.Parameters.Add(new SqlParameter("@User_Dob", user.UserDob));
                cmd.Parameters.Add(new SqlParameter("@User_CreatorOrModifier_Id", user.CreatedBy));

                var outParam = new SqlParameter("@Output_User_Id", System.Data.SqlDbType.Int);
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();

                int newUserId = Convert.ToInt32(cmd.Parameters["@Output_User_Id"].Value);
                user.UserId = newUserId;

                this.sqlConnection.Close();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
