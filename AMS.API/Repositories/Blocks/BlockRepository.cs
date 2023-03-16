using AMS.Models.Constants;
using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Linq;


namespace AMS.API.Repositories.Blocks
{
    public class BlockRepository : IBlockRepository
    {
        private IDapperContext _dapperContext;
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dapperContext"></param>
        public BlockRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            sqlConnection = _dapperContext.GetSqlConnection();
        }

        /// <summary>
        /// De-Activate and block.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeActivateBlock(int id)
        {
            await this.sqlConnection.ExecuteAsync(SqlCommandConstants.DEACTIVATE_BLOCK, new { BlockId = id }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All Blocks.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Block>> GetAllBlocks()
        {
            var lstBlocks = await this.sqlConnection.QueryAsync<Block>(SqlCommandConstants.GET_ALL_BLOCKS).ConfigureAwait(false);
            return lstBlocks.ToList();
        }

        /// <summary>
        /// Get Block By and Field.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<List<Block>> GetBlockByAnyField(Func<Block, bool> expression)
        {
            var lstBlocks = await this.sqlConnection.QueryAsync<Block>(SqlCommandConstants.GET_ALL_BLOCKS).ConfigureAwait(false);
            return lstBlocks.Where(expression).ToList();
        }

        /// <summary>
        /// Get Block By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Block> GetBlockById(int id)
        {
            return await this.sqlConnection.QueryFirstAsync<Block>(SqlCommandConstants.GET_BLOCKS, new { BlockId = id }).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new Block Record.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public async Task<Block> InsertBlock(Block block)
        {
            try
            {
                this.sqlConnection.Open();
                
                var cmd = this.sqlConnection.CreateCommand();
                cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_BLOCK_DETAILS;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", (int)SqlCommandConstants.Mode.ADD));
                cmd.Parameters.Add(new SqlParameter("@Apartment_Id", block.ApartmentId));
                cmd.Parameters.Add(new SqlParameter("@Block_Name", block.BlockName));
                cmd.Parameters.Add(new SqlParameter("@Block_IsActive", block.IsActive));
                cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

                var outParam = new SqlParameter("@Output_Block_Id", System.Data.SqlDbType.Int)
                {
                    Value = 0,
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                await cmd.ExecuteNonQueryAsync();

                int newBlockId = Convert.ToInt32(cmd.Parameters["@Output_Block_Id"].Value);
                block.BlockId = newBlockId;

                this.sqlConnection.Close();

                return block;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update the Block Record.
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public async Task<Block> UpdateBlock(Block block)
        {
            this.sqlConnection.Open();
            var cmd = this.sqlConnection.CreateCommand();
            cmd.CommandText = SqlCommandConstants.AMB_SP_UPSERT_BLOCK_DETAILS;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", SqlCommandConstants.Mode.MODIFY));
            cmd.Parameters.Add(new SqlParameter("@Block_ID", block.BlockId));
            cmd.Parameters.Add(new SqlParameter("@Apartment_Id", block.ApartmentId));
            cmd.Parameters.Add(new SqlParameter("@Block_Name", block.BlockName));
            cmd.Parameters.Add(new SqlParameter("@Block_IsActive", block.IsActive));
            cmd.Parameters.Add(new SqlParameter("@User_Id", 1));

            var outParam = new SqlParameter("@Output_Block_Id", System.Data.SqlDbType.Int);
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            await cmd.ExecuteNonQueryAsync();

            this.sqlConnection.Close();

            return block;
        }
    }
}
