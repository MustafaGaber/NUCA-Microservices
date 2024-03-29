﻿using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Interfaces.Persistence
{
    public interface ITaxAuthorityRepository : IRepository<TaxAuthority>
    {
        public Task<bool> TaxAuthorityHasProjects(long id);
    }
}
