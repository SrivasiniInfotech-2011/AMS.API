using AMS.API.Areas.Billing.Repositories;
using AMS.Models.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Areas.Billing.Services.Queries
{
    public class GetCompanyByExpression
    {
        public class Query : IRequest<Company>
        {
            public Func<Company, bool> CompanyExpression;
            public Query(Func<Company, bool> expression)
            {
                CompanyExpression = expression;
            }
        }

        public class Handler : IRequestHandler<Query, Company>
        {
            private readonly ICompanyRepository companyRepository;

            public Handler(ICompanyRepository repository)
            {
                companyRepository = repository;
            }
            public async Task<Company> Handle(Query request, CancellationToken cancellationToken)
            {
                var companyList= await companyRepository.GetAllCompanys();
                return companyList.FirstOrDefault(request.CompanyExpression);
            }
        }
    }
}
