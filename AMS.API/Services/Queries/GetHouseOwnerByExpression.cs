using AMS.API.Repositories.HouseOwners;
using AMS.Models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetHouseOwnerByExpression
    {
        public class Query : IRequest<HouseOwner>
        {
            public Func<HouseOwner, bool> HouseOwnerExpressiom;
            public Query(Func<HouseOwner, bool> expression)
            {
                HouseOwnerExpressiom = expression;
            }
        }

        public class Handler : IRequestHandler<Query, HouseOwner>
        {
            private readonly IHouseOwnerRepository houseownerRepository;

            public Handler(IHouseOwnerRepository repository)
            {
                houseownerRepository = repository;
            }
            public async Task<HouseOwner> Handle(Query request, CancellationToken cancellationToken)
            {
                return await houseownerRepository.GetHouseOwnerByAnyField(request.HouseOwnerExpressiom);
            }
        }
    }
}
