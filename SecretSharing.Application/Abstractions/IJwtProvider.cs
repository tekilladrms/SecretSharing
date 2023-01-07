using SecretSharing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.Abstractions
{
    public interface IJwtProvider
    {
        string Generate(ApplicationUser applicationUser);
    }
}
