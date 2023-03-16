using AMS.API.Repositories.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class DeActivateUser
    {
        public class Command : IRequest
        {
            public Command(int userId)
            {
                UserId = userId;
            }

            public int UserId { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IUserRepository UserRepository;

            public Handler(IUserRepository userRepository)
            {
                this.UserRepository = userRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await UserRepository.DeActivateUser(message.UserId);

            }
        }
    }
}
