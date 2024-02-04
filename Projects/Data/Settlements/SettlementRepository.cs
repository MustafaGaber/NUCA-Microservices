using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Settlements.Models;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Settlements;

namespace NUCA.Projects.Data.Settlements
{
    public class SettlementRepository : Repository<Settlement>, ISettlementRepository
    {
        public SettlementRepository(ProjectsDatabaseContext database) : base(database)
        {
        }

        public Task<bool> SettlementCreated(long id)
        {
            return database.Settlements.Where(a => a.Id == id).AnyAsync();
        }

        public Task<Settlement?> Get(long id)
        {
            return database.Settlements
                .Include(a => a.Withholdings)
                .Include(a => a.Statement)
                .Include(a => a.Project).ThenInclude(p => p.Company)
                .Include(a => a.Project).ThenInclude(p => p.WorkType)
                .Include(a => a.Project).ThenInclude(p => p.AdvancePaymentDeductions)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<GetSettlementModel?> GetSettlementModel(long id)
        {
            var settlement = await database.Settlements
                .Where(a => a.Id == id)
                .Include(a => a.Withholdings)
                .Include(a => a.Project).ThenInclude(p => p.Company)
                .Select(a => new GetSettlementModel
                {
                    ProjectName = a.Project.Name,
                    CompanyName = a.Project.Company!.Name,
                    WorksDate = a.WorksDate,
                    StatementIndex = a.StatementIndex,
                    TotalWorks = a.TotalWorks,
                    TotalSupplies = a.TotalSupplies,
                    PreviousTotalWorks = a.PreviousTotalWorks,
                    PreviousTotalSupplies = a.PreviousTotalSupplies,
                    CurrentWorks = a.CurrentWorks,
                    CurrentSupplies = a.CurrentSupplies,
                    CurrentWorksAndSupplies = a.CurrentWorksAndSupplies,
                    ServiceTax = a.ServiceTax,
                    AdvancePaymentPercent = a.AdvancePaymentPercent,
                    SupervisionCommission = a.SupervisionCommission,
                    AdvancePaymentValue = a.AdvancePaymentValue,
                    CompletionGuaranteeValue = a.CompletionGuaranteeValue,
                    EngineersSyndicateValue = a.EngineersSyndicateValue,
                    ApplicatorsSyndicateValue = a.ApplicatorsSyndicateValue,
                    RegularStampTax = a.RegularStampTax,
                    AdditionalStampTax = a.AdditionalStampTax,
                    ResourceDevelopmentTax = a.ResourceDevelopmentTax,
                    CommercialIndustrialTax = a.CommercialIndustrialTax,
                    SelfEmploymentTax = a.SelfEmploymentTax,
                    ValueAddedTaxPercent = a.ValueAddedTaxPercent,
                    ValueAddedTax = a.ValueAddedTax,
                    WasteRemovalInsurance = a.WasteRemovalInsurance,
                    TahyaMisrFundValue = a.TahyaMisrFundValue,
                    ConractStampTax = a.ConractStampTax,
                    ContractorsFederationValue = a.ContractorsFederationValue,
                    Withholdings = a.Withholdings.Select(w => new GetWithholdingModel
                    {
                        Id = w.Id,
                        Name = w.Name,
                        Value = w.Value,
                        Type = w.Type,
                        FromStatement = w.FromStatement
                    }).ToList(),
                    TotalDue = a.TotalDue,
                    TotalWithholdings = a.TotalWithholdings,
                    NetAmount = a.NetAmount,
                    Submitted = a.Submitted,
                    IsFirst = false,
                }
               ).FirstOrDefaultAsync();
            return settlement; //_mapper.Map<GetSettlementModel>(settlement);
        }

        /* public Task<GetSettlementModel?> AddWithholding(long id, EditWithholdingModel withholding)
         {
             return database.Settlements.Include(settlement => settlement.Withholdings)
                 .Where(settlement => settlement.Id == id)
                 .Join(database.Projects.Include(project => project.Company),
                 settlement => settlement.ProjectId,
                 project => project.Id,
                 (settlement, project) => GetSettlementModel.FromSettlementAndProject(settlement, project)
                ).FirstOrDefaultAsync();
         }*/
    }
}
