using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Data.Projects
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectsDatabaseContext database)
         : base(database) { }

        public async Task<GetProjectWithLedgersModel?> GetProjectWithLedgers(long id)
        {
            GetProjectWithLedgersModel? project = await database.Projects
                .Include(p => p.FromLedger)
                .Include(p => p.ToLedger)
                .Include(p => p.AdvancePaymentLedger)
                .Select(project =>
                new GetProjectWithLedgersModel
                {
                    Id = project.Id,
                    Name = project.Name,
                    FromLedger = project.FromLedger == null ? null : new LedgerModel
                    {
                        Id = project.FromLedger!.Id,
                        Name = project.FromLedger!.Name,
                        Code = project.FromLedger!.Code,
                        ParentId = project.FromLedger!.ParentId,
                        ParentFullPath = project.FromLedger!.ParentFullPath
                    },
                    ToLedger = project.ToLedger == null ? null : new LedgerModel
                    {
                        Id = project.ToLedger!.Id,
                        Name = project.ToLedger!.Name,
                        Code = project.ToLedger!.Code,
                        ParentId = project.ToLedger!.ParentId,
                        ParentFullPath = project.ToLedger!.ParentFullPath
                    },
                    AdvancePaymentLedger = project.AdvancePaymentLedger == null ? null : new LedgerModel
                    {
                        Id = project.AdvancePaymentLedger!.Id,
                        Name = project.AdvancePaymentLedger!.Name,
                        Code = project.AdvancePaymentLedger!.Code,
                        ParentId = project.AdvancePaymentLedger!.ParentId,
                        ParentFullPath = project.AdvancePaymentLedger!.ParentFullPath
                    }
                }).FirstOrDefaultAsync(p => p.Id == id);
            return project;
        }

        public async Task<ProjectWithLedgers> GetProjectLedgers(long id)
        {
            var project = await database.Projects
               .Include(p => p.FromLedger).ThenInclude(l => l.Parent)
               .Include(p => p.ToLedger).ThenInclude(l => l.Parent)
               .Include(p => p.AdvancePaymentLedger).ThenInclude(l => l.Parent)
               .Select(p =>
               new ProjectWithLedgers
               {
                   Id = p.Id,
                   ToLedger = p.ToLedger,
                   FromLedger = p.FromLedger,
                   AdvancePaymentLedger = p.AdvancePaymentLedger,
               })
               .FirstOrDefaultAsync(p => p.Id == id);
            return project;
        }

        override
        public IQueryable<Project> Query =>
            database.Projects
                .Include(p => p.Company)
                .Include(p => p.WorkType)
                .Include(p => p.AwardType)
                .Include(p => p.CostCenter)
                .Include(p => p.Classifications)
                .Include(p => p.MainBank)
                .Include(p => p.BankBranch)
                .Include(p => p.TaxAuthority)
                .Include(p => p.ModifiedEndDates);
        //.Include(p => p.FromLedger)
        //.Include(p => p.ToLedger)
        //.Include(p => p.AdvancePaymentLedger);
    }
}
