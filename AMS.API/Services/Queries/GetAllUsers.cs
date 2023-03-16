using AMS.API.Repositories.Users;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetAllUsers
    {
        public class Query : IRequest<List<User>>
        {
            public int? UserId { get; }
            public Query(int? userId = null)
            {
                UserId = userId;
            }
        }

        public class Handler : IRequestHandler<Query, List<User>>
        {
            private readonly IUserRepository userRepository;

            public Handler(IUserRepository repository)
            {
                userRepository = repository;
            }
            public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await userRepository.GetAllUsers();
            }
        }
    }
}
