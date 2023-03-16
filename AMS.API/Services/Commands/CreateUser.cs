using AMS.API.Repositories.Users;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class CreateUser
    {
        public class Command : IRequest<User>
        {
            public Command(User user)
            {
                User = user;
            }

            public User User { get; }

        }

        public class Handler : IRequestHandler<Command,User>
        {
            private readonly IUserRepository UserRepository;

            public Handler(IUserRepository userRepository)
            {
                this.UserRepository = userRepository;
            }

            public async Task<User> Handle(Command message, CancellationToken cancellationToken)
            {
                return await UserRepository.InsertUser(message.User);

            }
        }
    }
}
