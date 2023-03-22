using AMS.API.Areas.Billing.Repositories;
using AMS.API.Repositories.Apartments;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Commands
{
    public class DeActivateBank
    {
        public class Command : IRequest
        {
            public Command(int bankId)
            {
                BankId = bankId;
            }

            public int BankId { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IBankRepository bankRepository;

            public Handler(IBankRepository repository)
            {
                bankRepository = repository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await bankRepository.DeActivateBank(message.BankId,1);

            }
        }
    }
}
