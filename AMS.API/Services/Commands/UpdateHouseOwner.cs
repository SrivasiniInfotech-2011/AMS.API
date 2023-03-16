using AMS.API.Repositories.HouseOwners;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class UpdateHouseOwner
    {
        public class Command : IRequest
        {
            public Command(HouseOwner houseowner)
            {
                HouseOwner = houseowner;
            }

            public HouseOwner HouseOwner { get; }

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
                await HouseOwnerRepository.UpdateHouseOwner(message.HouseOwner);

            }
        }
    }
}
