using AMS.Models.Constants;
using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Linq;


namespace AMS.API.Repositories.Tenants
{
    public class TenantRepository : ITenantRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public TenantRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// De-Activate and tenant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeActivateTenant(int id)
        {
            await this.sqlConnection.ExecuteAsync(SqlCommandConstants.DEACTIVATE_TENANT, new { TenantId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All Tenants.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tenant>> GetAllTenants()
        {
            var lstTenants = await this.sqlConnection.QueryAsync<Tenant>(SqlCommandConstants.GET_ALL_TENANTS).ConfigureAwait(false);
            return lstTenants.ToList();
        }

        /// <summary>
        /// Get Tenant By and Field.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<Tenant> GetTenantByAnyField(Func<Tenant, bool> expression)
        {
            var lstTenants = await this.sqlConnection.QueryAsync<Tenant>(SqlCommandConstants.GET_TENANTS).ConfigureAwait(false);
            return lstTenants.FirstOrDefault(expression);
        }

        /// <summary>
        /// Get Tenant By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Tenant> GetTenantById(int id)
        {
            return await this.sqlConnection.QueryFirstAsync<Tenant>(SqlCommandConstants.GET_TENANTS, new { TenantId = id }).ConfigureAwait(false);
        }

        public Task<Tenant> GetTenantById(object tenantId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new Tenant Record.
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        public async Task<Tenant> InsertTenant(Tenant tenant)
        {
            try
            {
                this.sqlConnection.Open();
                
                var cmd = this.sqlConnection.CreateCommand();
                cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_TENANT_DETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@Tenant_Name", tenant.TenantName));
                cmd.Parameters.Add(new SqlParameter("@Tenant_IsActive", tenant.IsActive));
                cmd.Parameters.Add(new SqlParameter("@Tenant_Id_Proof", tenant.TenantIdProof));
                cmd.Parameters.Add(new SqlParameter("@Tenant_House_Id", tenant.HouseId));
                cmd.Parameters.Add(new SqlParameter("@Block_Id", tenant.BlockId));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Id", tenant.ApartmentId));
                cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

                var outParam = new SqlParameter("@Output_Tenant_Id", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();

                int newTenantId = Convert.ToInt32(cmd.Parameters["@Output_Tenant_Id"].Value);
                tenant.TenantId = newTenantId;

                this.sqlConnection.Close();

                return tenant;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update the Tenant Record.
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        public async Task<Tenant> UpdateTenant(Tenant tenant)
        {
            this.sqlConnection.Open();
            var cmd = this.sqlConnection.CreateCommand();
            cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_TENANT_DETAILS;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlCommandConstants.Mode.MODIFY));
            cmd.Parameters.Add(new SqlParameter("@Tenant_ID", tenant.TenantId));
            cmd.Parameters.Add(new SqlParameter("@Tenant_Name", tenant.TenantName));
            cmd.Parameters.Add(new SqlParameter("@Tenant_IsActive", tenant.IsActive));
            cmd.Parameters.Add(new SqlParameter("@Tenant_Id_Proof", tenant.TenantIdProof));
            cmd.Parameters.Add(new SqlParameter("@Tenant_House_Id", tenant.HouseId));
            cmd.Parameters.Add(new SqlParameter("@Block_Id", tenant.BlockId));
            cmd.Parameters.Add(new SqlParameter("@Apartment_Id", tenant.ApartmentId));
            cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

            var outParam = new SqlParameter("@Output_Tenant_Id", System.Data.SqlDbType.Int);
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            await cmd.ExecuteNonQueryAsync();

            this.sqlConnection.Close();

            return tenant;
        }
    }
}
