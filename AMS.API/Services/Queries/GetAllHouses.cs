using AMS.API.Repositories.Houses;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetAllHouses
    {
        public class Query : IRequest<List<House>>
        {
            public int? HouseId { get; }
            public Query(int? houseId=null)
            {
                HouseId = houseId;
            }
        }

        public class Handler : IRequestHandler<Query, List<House>>
        {
            private readonly IHouseRepository houseRepository;

            public Handler(IHouseRepository repository)
            {
                houseRepository = repository;
            }
            public async Task<List<House>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await houseRepository.GetAllHouses();
            }
        }
    }
}
