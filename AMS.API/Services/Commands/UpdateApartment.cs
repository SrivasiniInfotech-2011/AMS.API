using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class UpdateApartment
    {
        public class Command : IRequest
        {
            public Command(Apartment apartment)
            {
                Apartment = apartment;
            }

            public Apartment Apartment { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IApartmentRepository ApartmentRepository;

            public Handler(IApartmentRepository apartmentRepository)
            {
                this.ApartmentRepository = apartmentRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await ApartmentRepository.UpdateApartment(message.Apartment);

            }
        }
    }
}
