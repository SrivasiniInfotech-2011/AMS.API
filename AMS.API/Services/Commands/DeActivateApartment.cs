using AMS.API.Repositories.Apartments;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class DeActivateApartment
    {
        public class Command : IRequest
        {
            public Command(int apartmentId)
            {
                ApartmentId = apartmentId;
            }

            public int ApartmentId { get; }

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
                await ApartmentRepository.DeActivateApartment(message.ApartmentId);

            }
        }
    }
}
