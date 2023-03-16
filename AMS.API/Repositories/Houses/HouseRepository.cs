using AMS.Models.Constants;
using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Linq;


namespace AMS.API.Repositories.Houses
{
    public class HouseRepository : IHouseRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public HouseRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// De-Activate and house.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeActivateHouse(int id)
        {
            await this.sqlConnection.ExecuteAsync(SqlCommandConstants.DEACTIVATE_HOUSE, new { HouseId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All Houses.
        /// </summary>
        /// <returns></returns>
        public async Task<List<House>> GetAllHouses()
        {
            var lstHouses = await this.sqlConnection.QueryAsync<House>(SqlCommandConstants.GET_ALL_HOUSES).ConfigureAwait(false);
            return lstHouses.ToList();
        }

        /// <summary>
        /// Get House By and Field.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<List<House>> GetHouseByAnyField(Func<House, bool> expression)
        {
            var lstHouses = await this.sqlConnection.QueryAsync<House>(SqlCommandConstants.GET_ALL_HOUSES).ConfigureAwait(false);
            return lstHouses.Where(expression).ToList();
        }

        /// <summary>
        /// Get House By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<House> GetHouseById(int id)
        {
            return await this.sqlConnection.QueryFirstAsync<House>(SqlCommandConstants.GET_HOUSES, new { HouseId = id }).ConfigureAwait(false);
        }

        public Task<House> GetHouseById(object houseId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new House Record.
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public async Task<House> InsertHouse(House house)
        {
            try
            {
                this.sqlConnection.Open();
                
                var cmd = this.sqlConnection.CreateCommand();
                cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_HOUSE_DETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@Block_Id", house.BlockId));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Id", house.ApartmentId));
                cmd.Parameters.Add(new SqlParameter("@House_Number", house.HouseNumber));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Id", house.ApartmentId));
                cmd.Parameters.Add(new SqlParameter("@Block_Id", house.BlockId));
                cmd.Parameters.Add(new SqlParameter("@House_IsActive", house.IsActive));
                cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

                var outParam = new SqlParameter("@Output_House_Id", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();

                int newHouseId = Convert.ToInt32(cmd.Parameters["@Output_House_Id"].Value);
                house.HouseId = newHouseId;

                this.sqlConnection.Close();

                return house;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update the House Record.
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public async Task<House> UpdateHouse(House house)
        {
            this.sqlConnection.Open();
            var cmd = this.sqlConnection.CreateCommand();
            cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_HOUSE_DETAILS;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlCommandConstants.Mode.MODIFY));
            cmd.Parameters.Add(new SqlParameter("@House_ID", house.HouseId));
            cmd.Parameters.Add(new SqlParameter("@Block_Id", house.BlockId));
            cmd.Parameters.Add(new SqlParameter("@Apartment_Id", house.ApartmentId));
            cmd.Parameters.Add(new SqlParameter("@House_Number", house.HouseNumber));
            cmd.Parameters.Add(new SqlParameter("@House_IsActive", house.IsActive));
            cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

            var outParam = new SqlParameter("@Output_House_Id", System.Data.SqlDbType.Int);
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            await cmd.ExecuteNonQueryAsync();

            this.sqlConnection.Close();

            return house;
        }
    }
}
