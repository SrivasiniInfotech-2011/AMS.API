using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetAllApartments
    {
        public class Query : IRequest<List<Apartment>>
        {
            public int? ApartmentId { get; }
            public Query(int? apartmentId=null)
            {
                ApartmentId = apartmentId;
            }
        }

        public class Handler : IRequestHandler<Query, List<Apartment>>
        {
            private readonly IApartmentRepository apartmentRepository;

            public Handler(IApartmentRepository repository)
            {
                apartmentRepository = repository;
            }
            public async Task<List<Apartment>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await apartmentRepository.GetAllApartments();
            }
        }
    }
}
