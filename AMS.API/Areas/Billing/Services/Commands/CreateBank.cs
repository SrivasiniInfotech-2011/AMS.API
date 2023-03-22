using AMS.API.Areas.Billing.Repositories;
using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using NLog;

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
            private readonly ILogger<Handler> _logger;
            public Handler(IBankRepository repository, ILogger<Handler> logger)
            {
                bankRepository = repository;
                _logger = logger;
            }

            public async Task<Bank> Handle(Command message, CancellationToken cancellationToken)
            {
                try
                {
                    return await bankRepository.InsertBank(message.Bank);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception occured when trying to Create a New bank. Input param values are: {nameof(message.Bank.BankName)}: {message.Bank.BankName}, error message: {ex?.Message}, stack trace: {ex?.StackTrace}");
                    throw;
                }

            }
        }
    }
}
