﻿using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Data.Settings
{
    public class LedgerRepository : Repository<Ledger>, ILedgerRepository
    {
        public LedgerRepository(ProjectsDatabaseContext database) : base(database)
        {
        }
    }
}
