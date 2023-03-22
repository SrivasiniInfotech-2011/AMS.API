using AMS.API.Areas.Billing.Repositories;
using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Commands
{
    public class CreateBank
    {
        public class Command : IRequest<Bank>
        {
            public Command(Bank bank)
            {
                Bank = bank;
            }

            public Bank Bank { get; }

        }

        public class Handler : IRequestHandler<Command, Bank>
        {
            private readonly IBankRepository bankRepository;

            public Handler(IBankRepository repository)
            {
                bankRepository = repository;
            }

            public async Task<Bank> Handle(Command message, CancellationToken cancellationToken)
            {
                return await bankRepository.InsertBank(message.Bank);

            }
        }
    }
}
