using AMS.API.Repositories;
using AMS.Models.Constants;
using AMS.Models.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Repositories
{
    public class BankRepository : IBankRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public BankRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// DeActivates a Bank.
        /// </summary>
        /// <param name="bankId"></param>
        public async Task DeActivateBank(int bankId, int companyId)
        {
            await this.sqlConnection.ExecuteAsync(SqlCommandConstants.BMS_ADD_EDIT_DELETE_BANKDETAILS, new { CMP_ID = companyId, BANK_ID = bankId }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All Banks For Listing.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bank>> GetAllBanks()
        {
            var lst = await this.sqlConnection.QueryAsync<Bank>(SqlCommandConstants.BMS_FETCH_BANKDETAILS).ConfigureAwait(false);
            return lst.ToList();
        }

        /// <summary>
        /// Get Bank By Bank Id.
        /// </summary>
        /// <returns></returns>
        public async Task<Bank> GetBankById(int bankId)
        {
            return await this.sqlConnection.QueryFirstAsync<Bank>(SqlCommandConstants.BMS_FETCH_BANKDETAILS, new { BANK_ID = bankId }).ConfigureAwait(false);
        }

        /// <summary>
        /// Insert a new Bank.
        /// </summary>
        /// <param name="bank"></param>
        /// <returns>Bank Object With The Latest Id.</returns>
        public async Task<Bank> InsertBank(Bank bank)
        {
            this.sqlConnection.Open();
            var transaction = this.sqlConnection.BeginTransaction();
            try
            {


                var cmd = this.sqlConnection.CreateCommand();
                cmd.Transaction=transaction;
                cmd.CommandText = SqlCommandConstants.BMS_ADD_EDIT_DELETE_BANKDETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MODE", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@CMPID", 1));
                cmd.Parameters.Add(new SqlParameter("@BANK_CODE", bank.BankCode));
                cmd.Parameters.Add(new SqlParameter("@BANK_NAME", bank.BankName));
                cmd.Parameters.Add(new SqlParameter("@MICR_CODE", bank.MicrCode));
                cmd.Parameters.Add(new SqlParameter("@IFSC_CODE", bank.IFSCCode));
                cmd.Parameters.Add(new SqlParameter("@BRANCH_NAME", bank.BranchName));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_ADD1", bank.BranchAddressLine1));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_ADD2", bank.BranchAddressLine2));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_CITY", bank.BranchAddressCity));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_PINCODE", bank.BranchAddressPinCode));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_COUNTRY", bank.BranchAddressCountry));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_PHONE", bank.BranchAddressPhone));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_MOB", bank.BranchAddressMobile));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_EMAIL", bank.BranchEmail));
                cmd.Parameters.Add(new SqlParameter("@ACTIVE", 1));
                cmd.Parameters.Add(new SqlParameter("@AID", bank.CreatedBy));

                var outParam = new SqlParameter("@NEWBANKID", System.Data.SqlDbType.Int);
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();
                transaction.Commit();

                int bankId = Convert.ToInt32(cmd.Parameters["@NEWBANKID"].Value);
                bank.BankId = bankId;



                return bank;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <summary>
        /// Updates a Bank.
        /// </summary>
        /// <param name="bank">Update the User Details.</param>
        /// <returns></returns>
        public async Task<Bank> UpdateBank(Bank bank)
        {
            this.sqlConnection.Open();
            var transaction = this.sqlConnection.BeginTransaction();
            try
            {


                var cmd = this.sqlConnection.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = SqlCommandConstants.BMS_ADD_EDIT_DELETE_BANKDETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MODE", (int)SqlCommandConstants.Mode.MODIFY));
                cmd.Parameters.Add(new SqlParameter("@CMPID", 1));
                cmd.Parameters.Add(new SqlParameter("@BANK_ID", bank.BankId));
                cmd.Parameters.Add(new SqlParameter("@BANK_CODE", bank.BankCode));
                cmd.Parameters.Add(new SqlParameter("@BANK_NAME", bank.BankName));
                cmd.Parameters.Add(new SqlParameter("@MICR_CODE", bank.MicrCode));
                cmd.Parameters.Add(new SqlParameter("@IFSC_CODE", bank.IFSCCode));
                cmd.Parameters.Add(new SqlParameter("@BRANCH_NAME", bank.BranchName));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_ADD1", bank.BranchAddressLine1));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_ADD2", bank.BranchAddressLine2));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_CITY", bank.BranchAddressCity));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_PINCODE", bank.BranchAddressPinCode));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_COUNTRY", bank.BranchAddressCountry));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_PHONE", bank.BranchAddressPhone));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_MOB", bank.BranchAddressMobile));
                cmd.Parameters.Add(new SqlParameter("@BANK_BRANCH_EMAIL", bank.BranchEmail));
                cmd.Parameters.Add(new SqlParameter("@ACTIVE", 1));
                cmd.Parameters.Add(new SqlParameter("@MID", bank.CreatedBy));

                var outParam = new SqlParameter("@NEWBANKID", System.Data.SqlDbType.Int);
                outParam.Value = 0;
                outParam.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();
                transaction.Commit();

                int bankId = Convert.ToInt32(cmd.Parameters["@NEWBANKID"].Value);
                bank.BankId = bankId;



                return bank;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
