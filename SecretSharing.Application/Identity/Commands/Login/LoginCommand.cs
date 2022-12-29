using Amazon.Runtime.Internal;
using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Users.Commands.Login
{
    public sealed record LoginCommand(string Email, string Password) : IRequest<UserInfoDto>;
}
