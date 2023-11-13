using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface IBoqRepository : IRepository<Boq, long>
    {
    }
}
