using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSharing.Application.DTO
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
