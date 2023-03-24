using AMS.API.Areas.Billing.Repositories;
using AMS.API.Repositories.Apartments;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Commands
{
    public class CreateCompany
    {
        public class Command : IRequest<Company>
        {
            public Command(Company company)
            {
                Company = company;
            }

            public Company Company { get; }

        }

        public class Handler : IRequestHandler<Command, Company>
        {
            private readonly ICompanyRepository companyRepository;

            public Handler(ICompanyRepository repository)
            {
                companyRepository = repository;
            }

            public async Task<Company> Handle(Command message, CancellationToken cancellationToken)
            {
                return await companyRepository.InsertCompany(message.Company);

            }
        }
    }
}
