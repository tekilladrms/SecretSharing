using Amazon.Runtime.Internal;
using MediatR;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Commands.CreateUserProfile
{
    public sealed record CreateUserProfileCommand() : IRequest<UserProfileDto>;
}
