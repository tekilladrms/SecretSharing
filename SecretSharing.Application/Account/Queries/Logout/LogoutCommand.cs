﻿using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Account.Queries.Logout
{
    public sealed record LogoutCommand : IRequest<Unit>;
}