using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Services
{
    public interface ICurrentUserService
    {
        int? UserId { get; }

        bool IsAuthenticated { get; }
    }
}
