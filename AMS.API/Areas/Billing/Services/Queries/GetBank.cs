using AMS.API.Areas.Billing.Repositories;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Queries
{
    public class GetBank
    {
        public class Query : IRequest<Bank>
        {
            public int? BankId { get; }
        }

        public class Handler : IRequestHandler<Query, Bank>
        {
            private readonly IBankRepository bankRepository;

            public Handler(IBankRepository repository)
            {
                bankRepository = repository;
            }
            public async Task<Bank> Handle(Query request, CancellationToken cancellationToken)
            {
                return await bankRepository.GetBankById(request.BankId.GetValueOrDefault());
            }
        }
    }
}
