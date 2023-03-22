using AMS.API.Areas.Billing.Repositories;
using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Commands
{
    public class UpdateBank
    {
        public class Command : IRequest
        {
            public Command(Bank bank)
            {
                Bank = bank;
            }

            public Bank Bank { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IBankRepository BankRepository;

            public Handler(IBankRepository bankRepository)
            {
                this.BankRepository = bankRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await BankRepository.UpdateBank(message.Bank);

            }
        }
    }
}
