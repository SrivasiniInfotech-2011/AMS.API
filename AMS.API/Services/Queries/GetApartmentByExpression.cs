using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetApartmentByExpression
    {
        public class Query : IRequest<Apartment>
        {
            public Func<Apartment, bool> ApartmentExpressiom;
            public Query(Func<Apartment, bool> expression)
            {
                ApartmentExpressiom = expression;
            }
        }

        public class Handler : IRequestHandler<Query, Apartment>
        {
            private readonly IApartmentRepository apartmentRepository;

            public Handler(IApartmentRepository repository)
            {
                apartmentRepository = repository;
            }
            public async Task<Apartment> Handle(Query request, CancellationToken cancellationToken)
            {
                return await apartmentRepository.GetApartmentByAnyField(request.ApartmentExpressiom);
            }
        }
    }
}
