using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AMS.API.Areas.Billing.Repositories;

namespace AMS.API.Areas.Billing.Services.Queries
{
    public class GetAllBanks
    {
        public class Query : IRequest<List<Bank>>
        {
            public int? BankId { get; }
            public Query(int? bankId = null)
            {
                BankId = bankId;
            }
        }

        public class Handler : IRequestHandler<Query, List<Bank>>
        {
            private readonly IBankRepository bankRepository;

            public Handler(IBankRepository repository)
            {
                bankRepository = repository;
            }
            public async Task<List<Bank>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await bankRepository.GetAllBanks();
            }
        }
    }
}
