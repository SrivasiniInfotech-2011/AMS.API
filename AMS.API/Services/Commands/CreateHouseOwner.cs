using AMS.API.Repositories.HouseOwners;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class CreateHouseOwner
    {
        public class Command : IRequest<HouseOwner>
        {
            public Command(HouseOwner houseowner)
            {
                HouseOwner = houseowner;
            }

            public HouseOwner HouseOwner { get; }

        }

        public class Handler : IRequestHandler<Command, HouseOwner>
        {
            private readonly IHouseOwnerRepository HouseOwnerRepository;

            public Handler(IHouseOwnerRepository houseownerRepository)
            {
                this.HouseOwnerRepository = houseownerRepository;
            }

            public async Task<HouseOwner> Handle(Command message, CancellationToken cancellationToken)
            {
                return await HouseOwnerRepository.InsertHouseOwner(message.HouseOwner);

            }
        }
    }
}
