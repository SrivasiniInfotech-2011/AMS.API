using AMS.API.Repositories.Blocks;
using AMS.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetBlockByExpression
    {
        public class Query : IRequest<List<Block>>
        {
            public Func<Block, bool> BlockExpressiom;
            public Query(Func<Block, bool> expression)
            {
                BlockExpressiom = expression;
            }
        }

        public class Handler : IRequestHandler<Query, List<Block>>
        {
            private readonly IBlockRepository blockRepository;

            public Handler(IBlockRepository repository)
            {
                blockRepository = repository;
            }
            public async Task<List<Block>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await blockRepository.GetBlockByAnyField(request.BlockExpressiom);
            }
        }
    }
}
