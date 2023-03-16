using AMS.API.Repositories.Blocks;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class UpdateBlock
    {
        public class Command : IRequest
        {
            public Command(Block block)
            {
              Block = block;
            }

            public Block Block { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IBlockRepository BlockRepository;

            public Handler(IBlockRepository blockRepository)
            {
                this.BlockRepository = blockRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await BlockRepository.UpdateBlock(message.Block);

            }
        }
    }
}
