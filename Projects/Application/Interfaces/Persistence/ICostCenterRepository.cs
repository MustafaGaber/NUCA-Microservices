﻿using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface ICostCenterRepository: IRepository<CostCenter>
    {
         Task<bool> CostCenterHasProjects(long id);
         Task<bool> HasChildren(long id);
    }
}
