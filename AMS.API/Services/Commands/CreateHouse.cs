using AMS.API.Repositories.Houses;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class CreateHouse
    {
        public class Command : IRequest<House>
        {
            public Command(House house)
            {
               House = house;
            }

            public House House { get; }

        }

        public class Handler : IRequestHandler<Command,House>
        {
            private readonly IHouseRepository HouseRepository;

            public Handler(IHouseRepository houseRepository)
            {
                this.HouseRepository = houseRepository;
            }

            public async Task<House> Handle(Command message, CancellationToken cancellationToken)
            {
                return await HouseRepository.InsertHouse(message.House);

            }
        }
    }
}
