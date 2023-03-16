using AMS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AMS.API.Repositories.Blocks
{
    /// <summary>
    /// Repository for Block.
    /// </summary>
    public interface IBlockRepository
    {
        /// <summary>
        /// Get All Blocks.
        /// </summary>
        /// <returns>List Of Block.</returns>
        Task<List<Block>> GetAllBlocks();

        /// <summary>
        /// Get Block By Id.
        /// </summary>
        /// <param name="id">Get Block By Id.</param>
        /// <returns></returns>
        Task<Block> GetBlockById(int id);

        /// <summary>
        /// Get Block By Any Field.
        /// </summary>
        /// <param name="">Block</param>
        /// <returns></returns>
        Task<List<Block>> GetBlockByAnyField(Func<Block, bool> expression);

        /// <summary>
        /// Insert an Block.
        /// </summary>
        /// <param name="block"></param>
        /// <returns>Block Object With The Latest Id.</returns>
        Task<Block> InsertBlock(Block block);

        /// <summary>
        /// Updates an Block.
        /// </summary>
        /// <param name="Block">Update the Block Details.</param>
        /// <returns></returns>
        Task<Block> UpdateBlock(Block Block);

        /// <summary>
        /// DeActivates and Block.
        /// </summary>
        /// <param name="id"></param>
        Task DeActivateBlock(int id);
    }
}
