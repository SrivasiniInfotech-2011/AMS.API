using AMS.API.Repositories.HouseOwners;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetHouseOwner
    {
        public class Query : IRequest<HouseOwner>
        {
            public int HouseOwnerId { get; set; }
        }

        public class Handler : IRequestHandler<Query, HouseOwner>
        {
            private readonly IHouseOwnerRepository houseownersRepository;

            public Handler(IHouseOwnerRepository repository)
            {
                houseownersRepository = repository;
            }
            public async Task<HouseOwner> Handle(Query request, CancellationToken cancellationToken)
            {
                return await houseownersRepository.GetHouseOwnerById(request.HouseOwnerId);
            }
        }
    }
}
