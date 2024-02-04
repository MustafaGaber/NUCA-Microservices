using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Settlements;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Settlements.Commands.Submit
{
    public class SubmitCommand : ISubmitCommand
    {
        private readonly ProjectsDatabaseContext _dbContext;
        private readonly ISettlementRepository _settlementRepository;
        public SubmitCommand(ProjectsDatabaseContext dbContext, ISettlementRepository settlementRepository)
        {
            _dbContext = dbContext;
            _settlementRepository = settlementRepository;
        }

        public async Task<GetSettlementModel?> Execute(long settlementId)
        {
            Settlement? settlement = await _dbContext.Settlements.FirstOrDefaultAsync(s => s.Id == settlementId);
            Statement? statement = await _dbContext.Statements.Include(s => s.Withholdings).FirstOrDefaultAsync(s => s.Id == settlementId);
            if (settlement == null || statement == null)
            {
                throw new InvalidOperationException();
            }
            settlement.Submit();
            statement.SetStateAdjusted();
            await _dbContext.SaveChangesAsync();
            GetSettlementModel? settlementModel = await _settlementRepository.GetSettlementModel(settlementId);
            return settlementModel;
        }
    }
}
