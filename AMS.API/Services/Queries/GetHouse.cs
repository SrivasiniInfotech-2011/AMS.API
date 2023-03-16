using AMS.API.Repositories.Houses;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetHouse
    {
        public class Query : IRequest<House>
        {
            public int HouseId { get; set; }
        }

        public class Handler : IRequestHandler<Query, House>
        {
            private readonly IHouseRepository houseRepository;

            public Handler(IHouseRepository repository)
            {
                houseRepository = repository;
            }
            public async Task<House> Handle(Query request, CancellationToken cancellationToken)
            {
                return await houseRepository.GetHouseById(request.HouseId);
            }

        }
    }
}
