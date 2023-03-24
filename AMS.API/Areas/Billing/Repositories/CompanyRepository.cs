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
    public class CompanyRepository : ICompanyRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public CompanyRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// DeActivates a Company.
        /// </summary>
        /// <param name="companyId"></param>
        public async Task DeActivateCompany(int companyId)
        {
            this.sqlConnection.Open();
            var transaction = this.sqlConnection.BeginTransaction();
            try
            {
                var cmd = this.sqlConnection.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = SqlCommandConstants.BMS_ADD_EDIT_DELETE_COMPANYDETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MODE", (int)SqlCommandConstants.Mode.DELETE));
                cmd.Parameters.Add(new SqlParameter("@CMPID", companyId));
                var outCompanyCodeParam = new SqlParameter("@NEW_COMPANY_CODE", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outCompanyCodeParam);

                var outResultParam = new SqlParameter("@RESULT", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outResultParam);

                var outMessageParam = new SqlParameter("@MESSAGE", System.Data.SqlDbType.VarChar)
                {
                    Value = string.Empty,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outMessageParam);

                await cmd.ExecuteNonQueryAsync();
                transaction.Commit();

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
        /// Get All Companys For Listing.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Company>> GetAllCompanys()
        {
            var lst = await this.sqlConnection.QueryAsync<Company>(SqlCommandConstants.BMS_FETCH_COMPANYDETAILS).ConfigureAwait(false);
            return lst.ToList();
        }

        /// <summary>
        /// Get Company By Company Id.
        /// </summary>
        /// <returns></returns>
        public async Task<Company> GetCompanyById(int companyId)
        {
            return await this.sqlConnection.QueryFirstAsync<Company>(SqlCommandConstants.BMS_FETCH_COMPANYDETAILS, new { COMPANY_ID = companyId }).ConfigureAwait(false);
        }

        /// <summary>
        /// Insert a new Company.
        /// </summary>
        /// <param name="company"></param>
        /// <returns>Company Object With The Latest Id.</returns>
        public async Task<Company> InsertCompany(Company company)
        {
            this.sqlConnection.Open();
            var transaction = this.sqlConnection.BeginTransaction();
            try
            {


                var cmd = this.sqlConnection.CreateCommand();
                cmd.Transaction=transaction;
                cmd.CommandText = SqlCommandConstants.BMS_ADD_EDIT_DELETE_COMPANYDETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MODE", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@CMPNAME", company.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@CMPALIASNAME", company.CompanyAliasName));
                cmd.Parameters.Add(new SqlParameter("@CMPLOGO", company.CompanyLogo));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1", company.CompanyAddress1));
                cmd.Parameters.Add(new SqlParameter("@CMPADD2", company.CompanyAddress2));
                cmd.Parameters.Add(new SqlParameter("@CMPCITY", company.CompanyCity));
                cmd.Parameters.Add(new SqlParameter("@CMPPINCODE", company.CompanyPinCode));
                cmd.Parameters.Add(new SqlParameter("@CMPCOUNTRY", company.CompanyCountry));
                cmd.Parameters.Add(new SqlParameter("@CMPEMAIL", company.CompanyEmail));
                cmd.Parameters.Add(new SqlParameter("@CMPPHONE", company.CompanyPhone));
                cmd.Parameters.Add(new SqlParameter("@CMPMOBPHONE", company.CompanyMphone));
                cmd.Parameters.Add(new SqlParameter("@CMPFAX", company.CompanyFax));
                cmd.Parameters.Add(new SqlParameter("@CMPTINNO", company.CompanyTINNO));
                cmd.Parameters.Add(new SqlParameter("@CMPTNGSTNO", company.CompanyTINGSTNo));
                cmd.Parameters.Add(new SqlParameter("@CMPPANNO", company.CompanyPANNo));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKNAME", company.CompanyBankName));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKBRANCH", company.CompanyBankBranch));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKACCNO", company.CompanyBankAccountNo));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKIFSCODE", company.CompanyBankIFSCCode));
                cmd.Parameters.Add(new SqlParameter("@CMPFNAME", company.CompanyFontName));
                cmd.Parameters.Add(new SqlParameter("@CMPFSIZE", company.CompanyFontSize));
                cmd.Parameters.Add(new SqlParameter("@CMPFSTYLE", company.CompanyFontStyle));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1FNAME", company.CompanyAddress1FontName));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1FSIZE", company.CompanyAddress1FontSize));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1FSTYLE", company.CompanyAddress1FontStyle));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRNAME", company.CompanyCurrencyName));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRCODE", company.CompanyCurrencyCode));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRSYM", company.CompanyCurrencySymbol));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRPAISE", company.CompanyCurrencyPaise));
                cmd.Parameters.Add(new SqlParameter("@CMPCURREXCHNG", company.CompanyCurrencyExchange));
                cmd.Parameters.Add(new SqlParameter("@ACTIVE", 1));
                cmd.Parameters.Add(new SqlParameter("@AID", company.CreatedBy));
                cmd.Parameters.Add(new SqlParameter("@CMPPRFX", company.CompanyPrefix));
                cmd.Parameters.Add(new SqlParameter("@CMPSTARTDATE", company.CompanyStartDate));

                var outCompanyCodeParam = new SqlParameter("@NEW_COMPANY_CODE", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outCompanyCodeParam);

                var outResultParam = new SqlParameter("@RESULT", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outResultParam);

                var outMessageParam = new SqlParameter("@MESSAGE", System.Data.SqlDbType.VarChar)
                {
                    Value = string.Empty,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outMessageParam);

                await cmd.ExecuteNonQueryAsync();
                transaction.Commit();

                int companyId = Convert.ToInt32(cmd.Parameters["@NEW_COMPANY_CODE"].Value);
                company.CompanyId = companyId;

                return company;
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
        /// Updates a Company.
        /// </summary>
        /// <param name="company">Update the User Details.</param>
        /// <returns></returns>
        public async Task<Company> UpdateCompany(Company company)
        {
            this.sqlConnection.Open();
            var transaction = this.sqlConnection.BeginTransaction();
            try
            {


                var cmd = this.sqlConnection.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = SqlCommandConstants.BMS_ADD_EDIT_DELETE_COMPANYDETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MODE", (int)SqlCommandConstants.Mode.MODIFY));
                cmd.Parameters.Add(new SqlParameter("@CMPID", company.CompanyId));
                cmd.Parameters.Add(new SqlParameter("@CMPNAME", company.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@CMPALIASNAME", company.CompanyAliasName));
                cmd.Parameters.Add(new SqlParameter("@CMPLOGO", company.CompanyLogo));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1", company.CompanyAddress1));
                cmd.Parameters.Add(new SqlParameter("@CMPADD2", company.CompanyAddress2));
                cmd.Parameters.Add(new SqlParameter("@CMPCITY", company.CompanyCity));
                cmd.Parameters.Add(new SqlParameter("@CMPPINCODE", company.CompanyPinCode));
                cmd.Parameters.Add(new SqlParameter("@CMPCOUNTRY", company.CompanyCountry));
                cmd.Parameters.Add(new SqlParameter("@CMPEMAIL", company.CompanyEmail));
                cmd.Parameters.Add(new SqlParameter("@CMPPHONE", company.CompanyPhone));
                cmd.Parameters.Add(new SqlParameter("@CMPMOBPHONE", company.CompanyMphone));
                cmd.Parameters.Add(new SqlParameter("@CMPFAX", company.CompanyFax));
                cmd.Parameters.Add(new SqlParameter("@CMPTINNO", company.CompanyTINNO));
                cmd.Parameters.Add(new SqlParameter("@CMPTNGSTNO", company.CompanyTINGSTNo));
                cmd.Parameters.Add(new SqlParameter("@CMPPANNO", company.CompanyPANNo));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKNAME", company.CompanyBankName));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKBRANCH", company.CompanyBankBranch));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKACCNO", company.CompanyBankAccountNo));
                cmd.Parameters.Add(new SqlParameter("@CMPBANKIFSCODE", company.CompanyBankIFSCCode));
                cmd.Parameters.Add(new SqlParameter("@CMPFNAME", company.CompanyFontName));
                cmd.Parameters.Add(new SqlParameter("@CMPFSIZE", company.CompanyFontSize));
                cmd.Parameters.Add(new SqlParameter("@CMPFSTYLE", company.CompanyFontStyle));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1FNAME", company.CompanyAddress1FontName));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1FSIZE", company.CompanyAddress1FontSize));
                cmd.Parameters.Add(new SqlParameter("@CMPADD1FSTYLE", company.CompanyAddress1FontStyle));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRNAME", company.CompanyCurrencyName));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRCODE", company.CompanyCurrencyCode));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRSYM", company.CompanyCurrencySymbol));
                cmd.Parameters.Add(new SqlParameter("@CMPCURRPAISE", company.CompanyCurrencyPaise));
                cmd.Parameters.Add(new SqlParameter("@CMPCURREXCHNG", company.CompanyCurrencyExchange));
                cmd.Parameters.Add(new SqlParameter("@ACTIVE", 1));
                cmd.Parameters.Add(new SqlParameter("@MID", company.CreatedBy));

                var outCompanyCodeParam = new SqlParameter("@NEW_COMPANY_CODE", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outCompanyCodeParam);

                var outResultParam = new SqlParameter("@RESULT", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outResultParam);

                var outMessageParam = new SqlParameter("@MESSAGE", System.Data.SqlDbType.VarChar)
                {
                    Value = string.Empty,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outMessageParam);

                await cmd.ExecuteNonQueryAsync();
                transaction.Commit();

                int companyId = Convert.ToInt32(cmd.Parameters["@NEW_COMPANY_CODE"].Value);
                company.CompanyId = companyId;

                return company;
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

            // var outParam = new SqlParameter("@NEW_COMPANY_CODE", System.Data.SqlDbType.Int);
            //outParam.Value = 0;
            //outParam.Direction = System.Data.ParameterDirection.Output;
            //cmd.Parameters.Add(outParam);

            //await cmd.ExecuteNonQueryAsync();
            //transaction.Commit();

            //int companyId = Convert.ToInt32(cmd.Parameters["@NEW_COMPANY_CODE"].Value);
            // company.CompanyId = companyId;



            // return company;
            //}
            //catch (Exception)
            //{
            // transaction.Rollback();
            // throw;
            // }
            // finally
            // {
            //     this.sqlConnection.Close();
            //}
        }
    }
}
