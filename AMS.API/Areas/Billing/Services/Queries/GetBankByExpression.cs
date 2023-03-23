using AMS.API.Areas.Billing.Repositories;
using AMS.Models.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Queries
{
    public class GetBankByExpression
    {
        public class Query : IRequest<Bank>
        {
            public Func<Bank, bool> BankExpression;
            public Query(Func<Bank, bool> expression)
            {
                BankExpression = expression;
            }
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
                var bankList= await bankRepository.GetAllBanks();
                return bankList.FirstOrDefault(request.BankExpression);
            }
        }
    }
}
