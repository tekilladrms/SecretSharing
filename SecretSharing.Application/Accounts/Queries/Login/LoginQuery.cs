using MediatR;
using SecretSharing.Application.DTO;

namespace SecretSharing.Application.Accounts.Queries.Login
{
    public sealed record LoginQuery(string Email, string Password) : IRequest<UserDTO>;
}
