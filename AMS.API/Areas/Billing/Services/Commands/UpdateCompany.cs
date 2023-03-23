using AMS.API.Areas.Billing.Repositories;
using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Commands
{
    public class UpdateCompany
    {
        public class Command : IRequest
        {
            public Command(Company company)
            {
                Company = company;
            }

            public Company Company { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICompanyRepository CompanyRepository;

            public Handler(ICompanyRepository companyRepository)
            {
                this.CompanyRepository = companyRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await CompanyRepository.UpdateCompany(message.Company);

            }
        }
    }
}
