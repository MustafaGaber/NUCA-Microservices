﻿using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.FinanceAdmin;

namespace NUCA.Projects.Data.FinanceAdmin
{
    public class CostCenterRepository : Repository<CostCenter>, ICostCenterRepository
    {
        public CostCenterRepository(ProjectsDatabaseContext database) : base(database){ }

        public async Task<bool> CostCenterHasProjects(long id)
        {
            int count = await database.Projects
                .Include(p => p.CostCenter)
                .Where(p => p.CostCenter != null && p.CostCenter.Id == id)
                .CountAsync();
            return count > 0;
        }
    }
}
