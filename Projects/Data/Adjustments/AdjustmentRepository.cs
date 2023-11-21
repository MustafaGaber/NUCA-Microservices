using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Adjustments.Commands.AddWithholding;
using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Data.Adjustments
{
    public class AdjustmentRepository : Repository<Adjustment, long>, IAdjustmentRepository
    {
        public AdjustmentRepository(ProjectsDatabaseContext database) : base(database)
        {
        }

        public Task<bool> AdjustmentCreated(long id)
        {
            return database.Adjustments.Where(a => a.Id == id).AnyAsync();
        }

        public Task<Adjustment?> Get(long id)
        {
            return database.Adjustments
                .Include(a => a.Withholdings)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<AdjustmentModel?> GetAdjustmentModel(long id)
        {
            return database.Adjustments.Include(a => a.Withholdings)
                .Where(a => a.Id == id)
                .Join(database.Projects.Include(p => p.Company),
                a => a.ProjectId,
                p => p.Id,
                (a, p) =>  AdjustmentModel.FromAdjustmentAndProject(a, p)
               ).FirstOrDefaultAsync();
        }

       /* public Task<AdjustmentModel?> AddWithholding(long id, EditWithholdingModel withholding)
        {
            return database.Adjustments.Include(a => a.Withholdings)
                .Where(a => a.Id == id)
                .Join(database.Projects.Include(p => p.Company),
                a => a.ProjectId,
                p => p.Id,
                (a, p) => AdjustmentModel.FromAdjustmentAndProject(a, p)
               ).FirstOrDefaultAsync();
        }*/
    }
}
