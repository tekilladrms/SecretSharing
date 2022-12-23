using Amazon.Runtime.Internal;
using MediatR;
using SecretSharing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.UserProfiles.Queries.GetUserProfileById
{
    public sealed record GetUserProfileByIdQuery(Guid UserProfileId) : IRequest<UserProfileDto>;
}
