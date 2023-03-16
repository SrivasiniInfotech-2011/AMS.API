using AMS.API.Repositories.Blocks;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class CreateBlock
    {
        public class Command : IRequest<Block>
        {
            public Command(Block block)
            {
               Block = block;
            }

            public Block Block { get; }

        }

        public class Handler : IRequestHandler<Command,Block>
        {
            private readonly IBlockRepository BlockRepository;

            public Handler(IBlockRepository blockRepository)
            {
                this.BlockRepository = blockRepository;
            }

            public async Task<Block> Handle(Command message, CancellationToken cancellationToken)
            {
                return await BlockRepository.InsertBlock(message.Block);

            }
        }
    }
}
