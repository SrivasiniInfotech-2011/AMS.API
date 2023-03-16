using AMS.Models.Constants;
using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Linq;

namespace AMS.API.Repositories.Apartments
{
    public class ApartmentRepository : IApartmentRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public ApartmentRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// De-Activate and apartment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeActivateApartment(int id)
        {
            await this.sqlConnection.ExecuteAsync(SqlCommandConstants.DEACTIVATE_APARTMENT, new { ApartmentId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All Apartments.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Apartment>> GetAllApartments()
        {
            var lstApartments = await this.sqlConnection.QueryAsync<Apartment>(SqlCommandConstants.GET_ALL_APARTMENTS).ConfigureAwait(false);
            return lstApartments.ToList();
        }

        /// <summary>
        /// Get Apartment By and Field.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<Apartment> GetApartmentByAnyField(Func<Apartment, bool> expression)
        {
            var lstApartments = await this.sqlConnection.QueryAsync<Apartment>(SqlCommandConstants.GET_APARTMENTS).ConfigureAwait(false);
            return lstApartments.FirstOrDefault(expression);
        }

        /// <summary>
        /// Get Apartment By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Apartment> GetApartmentById(int id)
        {
            return await this.sqlConnection.QueryFirstAsync<Apartment>(SqlCommandConstants.GET_APARTMENTS, new { ApartmentId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new Apartment Record.
        /// </summary>
        /// <param name="apartment"></param>
        /// <returns></returns>
        public async Task<Apartment> InsertApartment(Apartment apartment)
        {
            try
            {
                this.sqlConnection.Open();
                
                var cmd = this.sqlConnection.CreateCommand();
                cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_APARTMENT_DETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Address", apartment.ApartmentAddress));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Construction_Date", apartment.ConstructionDate));
                cmd.Parameters.Add(new SqlParameter("@Apartment_IsActive", apartment.IsActive));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Name", apartment.ApartmentName));
                cmd.Parameters.Add(new SqlParameter("@Apartment_RegistrationId", apartment.RegistrationId));
                cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

                var outParam = new SqlParameter("@Output_Apartment_Id", System.Data.SqlDbType.Int);
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();

                int newApartmentId = Convert.ToInt32(cmd.Parameters["@Output_Apartment_Id"].Value);
                apartment.Id = newApartmentId;

                this.sqlConnection.Close();

                return apartment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update the Apartment Record.
        /// </summary>
        /// <param name="apartment"></param>
        /// <returns></returns>
        public async Task<Apartment> UpdateApartment(Apartment apartment)
        {
            this.sqlConnection.Open();
            var cmd = this.sqlConnection.CreateCommand();
            cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_APARTMENT_DETAILS;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlCommandConstants.Mode.MODIFY));
            cmd.Parameters.Add(new SqlParameter("@Apartment_ID", apartment.Id));
            cmd.Parameters.Add(new SqlParameter("@Apartment_Address", apartment.ApartmentAddress));
            cmd.Parameters.Add(new SqlParameter("@Apartment_Construction_Date", apartment.ConstructionDate));
            cmd.Parameters.Add(new SqlParameter("@Apartment_IsActive", apartment.IsActive));
            cmd.Parameters.Add(new SqlParameter("@Apartment_Name", apartment.ApartmentName));
            cmd.Parameters.Add(new SqlParameter("@Apartment_RegistrationId", apartment.RegistrationId));
            cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

            var outParam = new SqlParameter("@Output_Apartment_Id", System.Data.SqlDbType.Int);
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            await cmd.ExecuteNonQueryAsync();

            this.sqlConnection.Close();

            return apartment;
        }
    }
}
