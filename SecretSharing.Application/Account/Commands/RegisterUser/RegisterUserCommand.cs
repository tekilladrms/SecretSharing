using MediatR;
using SecretSharing.Application.DTO;

namespace SecretSharing.Application.Account.Commands.RegisterUser
{
    public sealed record RegisterUserCommand(string email, string password) : IRequest<UserDTO>;

}
