using AMS.API.Repositories.Users;
using AMS.Models.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Queries
{
    public class GetUserByUserNameAndPassword
    {
        public class Query : IRequest<User>
        {
            public string UserName { get; }
            public string Password { get; }
            public Query(string userName,string password)
            {
                UserName = userName;
                Password = password;
            }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly IUserRepository userRepository;

            public Handler(IUserRepository repository)
            {
                userRepository = repository;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                return await userRepository.GetUserByUserNameAndPassword(request.UserName,request.Password);
            }
        }
    }
}
