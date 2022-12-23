using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Commands.DeleteUserProfile
{
    public sealed record DeleteUserProfileCommand(Guid UserProfileId) : IRequest<Unit>;
}
