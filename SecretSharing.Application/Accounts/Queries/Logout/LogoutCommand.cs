using MediatR;

namespace SecretSharing.Application.Accounts.Queries.Logout
{
    public sealed record LogoutCommand : IRequest<Unit>;
}
