using AMS.API.Areas.Billing.Repositories;
using AMS.API.Repositories.Apartments;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Commands
{
    public class DeActivateCompany
    {
        public class Command : IRequest
        {
            public Command(int companyId)
            {
                CompanyId = companyId;
            }

            public int CompanyId { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICompanyRepository companyRepository;

            public Handler(ICompanyRepository repository)
            {
                companyRepository = repository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await companyRepository.DeActivateCompany(message.CompanyId);

            }
        }
    }
}
