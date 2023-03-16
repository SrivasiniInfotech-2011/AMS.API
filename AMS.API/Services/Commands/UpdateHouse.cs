using AMS.API.Repositories.Houses;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class UpdateHouse
    {
        public class Command : IRequest
        {
            public Command(House house)
            {
              House = house;
            }

            public House House { get; }

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
                await HouseRepository.UpdateHouse(message.House);

            }
        }
    }
}
