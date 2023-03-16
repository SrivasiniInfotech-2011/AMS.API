using AMS.API.Repositories.Blocks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class DeActivateBlock
    {
        public class Command : IRequest
        {
            public Command(int blockId)
            {
                BlockId = blockId;
            }

            public int BlockId { get; }

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
                await BlockRepository.DeActivateBlock(message.BlockId);

            }
        }
    }
}
