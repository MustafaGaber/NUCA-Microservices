using NUCA.Projects.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IUserRepository: IRepository<User>
    {
    }
}
