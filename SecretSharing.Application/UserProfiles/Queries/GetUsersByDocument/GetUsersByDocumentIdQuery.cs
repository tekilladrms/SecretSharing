using MediatR;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SecretSharing.Application.UserProfiles.Queries.GetUsersByDocument
{
    public sealed record GetUsersByDocumentIdQuery(Guid DocumentId) : IRequest<IReadOnlyCollection<UserProfileDto>>;
    
}
