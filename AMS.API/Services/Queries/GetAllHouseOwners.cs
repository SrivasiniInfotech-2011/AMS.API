using AMS.API.Repositories.HouseOwners;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetAllHouseOwners
    {
        public class Query : IRequest<List<HouseOwner>>
        {
            public int? HouseOwnerId { get; }
            public Query(int? houseownerId = null)
            {
                HouseOwnerId = houseownerId;
            }
        }

        public class Handler : IRequestHandler<Query, List<HouseOwner>>
        {
            private readonly IHouseOwnerRepository houseownerRepository;

            public Handler(IHouseOwnerRepository repository)
            {
                houseownerRepository = repository;
            }
            public async Task<List<HouseOwner>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await houseownerRepository.GetAllHouseOwners();
            }
        }
    }
}
