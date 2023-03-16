using AMS.API.Repositories.Houses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class DeActivateHouse
    {
        public class Command : IRequest
        {
            public Command(int houseId)
            {
                HouseId = houseId;
            }

            public int HouseId { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IHouseRepository HouseRepository;

            public Handler(IHouseRepository houseRepository)
            {
                this.HouseRepository = houseRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await HouseRepository.DeActivateHouse(message.HouseId);

            }
        }
    }
}
