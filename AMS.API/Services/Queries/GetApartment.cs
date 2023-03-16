using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetApartment
    {
        public class Query : IRequest<Apartment>
        {
            public int ApartmentId { get; set; }
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
                return await apartmentRepository.GetApartmentById(request.ApartmentId);
            }
        }
    }
}
