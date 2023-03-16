using AMS.API.Repositories.Houses;
using AMS.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetHouseByExpression
    {
        public class Query : IRequest<List<House>>
        {
            public Func<House, bool> HouseExpressiom;
            public Query(Func<House, bool> expression)
            {
                HouseExpressiom = expression;
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
                return await houseRepository.GetHouseByAnyField(request.HouseExpressiom);
            }
        }
    }
}
