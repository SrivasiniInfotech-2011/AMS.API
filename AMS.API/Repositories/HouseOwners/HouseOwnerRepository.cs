using AMS.Models.Constants;
using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Linq;


namespace AMS.API.Repositories.HouseOwners
{
    public class HouseOwnerRepository : IHouseOwnerRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public HouseOwnerRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// De-Activate and houseowner.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeActivateHouseOwner(int id)
        {
            await this.sqlConnection.ExecuteAsync(SqlCommandConstants.DEACTIVATE_HOUSE_OWNER, new { HouseOwnerId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All HouseOwners.
        /// </summary>
        /// <returns></returns>
        public async Task<List<HouseOwner>> GetAllHouseOwners()
        {
            var lstHouseOwners = await this.sqlConnection.QueryAsync<HouseOwner>(SqlCommandConstants.GET_ALL_HOUSE_OWNERS).ConfigureAwait(false);
            return lstHouseOwners.ToList();
        }

        /// <summary>
        /// Get HouseOwner By and Field.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<HouseOwner> GetHouseOwnerByAnyField(Func<HouseOwner, bool> expression)
        {
            var lstHouseOwners = await this.sqlConnection.QueryAsync<HouseOwner>(SqlCommandConstants.GET_HOUSE_OWNERS).ConfigureAwait(false);
            return lstHouseOwners.FirstOrDefault(expression);
        }

        /// <summary>
        /// Get HouseOwner By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HouseOwner> GetHouseOwnerById(int id)
        {
            return await this.sqlConnection.QueryFirstAsync<HouseOwner>(SqlCommandConstants.GET_HOUSE_OWNERS, new { HouseOwnerId = id }).ConfigureAwait(false);
        }

        public Task<HouseOwner> GetHouseOwnerById(object HouseOwnerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new HouseOwner Record.
        /// </summary>
        /// <param name="houseowner"></param>
        /// <returns></returns>
        public async Task<HouseOwner> InsertHouseOwner(HouseOwner houseowner)
        {
            try
            {
                this.sqlConnection.Open();
                
                var cmd = this.sqlConnection.CreateCommand();
                cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_HOUSE_OWNER_DETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@House_Owner_Name", houseowner.HouseOwnerName));
                cmd.Parameters.Add(new SqlParameter("@House_Owner_Id_Proof", houseowner.HouseOwnerIdProof));
                cmd.Parameters.Add(new SqlParameter("@House_Owner_Address", houseowner.HouseOwnerAddress));
                cmd.Parameters.Add(new SqlParameter("@House_Owner_Email", houseowner.HouseOwnerEmail));
                cmd.Parameters.Add(new SqlParameter("@House_Owner_Mobile", houseowner.HouseOwnerMobile));
                cmd.Parameters.Add(new SqlParameter("@House_Owner_House_Id", houseowner.HouseOwnerHouseID));
                cmd.Parameters.Add(new SqlParameter("@House_Owner_IsActive", houseowner.IsActive));
                cmd.Parameters.Add(new SqlParameter("@Block_Id", houseowner.BlockID));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Id", houseowner.ApartmentID));
                cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

                var outParam = new SqlParameter("@Output_House_Owner_Id", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();

                int newHouseOwnerId = Convert.ToInt32(cmd.Parameters["@Output_House_Owner_Id"].Value);
                houseowner.HouseOwnerId = newHouseOwnerId;

                this.sqlConnection.Close();

                return houseowner;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update the HouseOwner Record.
        /// </summary>
        /// <param name="houseowner"></param>
        /// <returns></returns>
        public async Task<HouseOwner> UpdateHouseOwner(HouseOwner houseowner)
        {
            this.sqlConnection.Open();
            var cmd = this.sqlConnection.CreateCommand();
            cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_HOUSE_OWNER_DETAILS;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_Id", houseowner.HouseOwnerId));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_Name", houseowner.HouseOwnerName));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_Id_Proof", houseowner.HouseOwnerIdProof));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_Address", houseowner.HouseOwnerAddress));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_Email", houseowner.HouseOwnerEmail));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_Mobile", houseowner.HouseOwnerMobile));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_House_Id", houseowner.HouseOwnerHouseID));
            cmd.Parameters.Add(new SqlParameter("@House_Owner_IsActive", houseowner.IsActive));
            cmd.Parameters.Add(new SqlParameter("@Block_Id", houseowner.BlockID));
            cmd.Parameters.Add(new SqlParameter("@Apartment_Id", houseowner.ApartmentID));
            cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

            var outParam = new SqlParameter("@Output_House_Owner_Id", System.Data.SqlDbType.Int);
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            await cmd.ExecuteNonQueryAsync();

            this.sqlConnection.Close();

            return houseowner;
        }
    }
}
