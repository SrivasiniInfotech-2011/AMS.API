using AMS.API.Repositories.Users;
using AMS.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AMS.API.Services.Commands
{
    public class UpdateUser
    {
        public class Command : IRequest
        {
            public Command(User user)
            {
                User = user;
            }

            public User User { get; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IUserRepository UserRepository;

            public Handler(IUserRepository UserRepository)
            {
                this.UserRepository = UserRepository;
            }

            public async Task Handle(Command message, CancellationToken cancellationToken)
            {
                await UserRepository.UpdateUser(message.User);

            }
        }
    }
}
