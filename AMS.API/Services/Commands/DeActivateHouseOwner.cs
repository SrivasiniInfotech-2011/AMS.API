using AMS.API.Repositories.HouseOwners;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class DeActivateHouseOwner
    {
        public class Command : IRequest
        {
            public Command(int houseownerId)
            {
                HouseOwnerId = houseownerId;
            }

            public int HouseOwnerId { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IHouseOwnerRepository HouseOwnerRepository;

            public Handler(IHouseOwnerRepository houseownerRepository)
            {
                this.HouseOwnerRepository = houseownerRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await HouseOwnerRepository.DeActivateHouseOwner(message.HouseOwnerId);

            }
        }
    }
}
