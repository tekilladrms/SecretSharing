using MediatR;
using SecretSharing.Application.DTO;

namespace SecretSharing.Application.Account.Queries.Login
{
    public sealed record LoginQuery(string Email, string Password) : IRequest<UserDTO>;
}
