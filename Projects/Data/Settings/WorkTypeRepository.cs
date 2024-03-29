﻿using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Data.Settings
{
    public class WorkTypeRepository : Repository<WorkType>, IWorkTypeRepository
    {
        public WorkTypeRepository(ProjectsDatabaseContext database)
          : base(database) { }

        public async Task<bool> WorkTypeHasProjects(int id)
        {
            int count = await database.Projects.Include(p => p.WorkType).Where(p => p.WorkType.Id == id).CountAsync();
            // Todo: boq items;
            return count > 0;
        }

    }
}
