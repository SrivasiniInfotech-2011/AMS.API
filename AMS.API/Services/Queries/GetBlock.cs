using AMS.API.Repositories.Blocks;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetBlock
    {
        public class Query : IRequest<Block>
        {
            public int BlockId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Block>
        {
            private readonly IBlockRepository blockRepository;

            public Handler(IBlockRepository repository)
            {
                blockRepository = repository;
            }
            public async Task<Block> Handle(Query request, CancellationToken cancellationToken)
            {
                return await blockRepository.GetBlockById(request.BlockId);
            }
        }
    }
}
