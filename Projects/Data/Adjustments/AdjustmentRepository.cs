using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Adjustments.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data.Shared;
using NUCA.Projects.Domain.Entities.Adjustments;

namespace NUCA.Projects.Data.Adjustments
{
    public class AdjustmentRepository : Repository<Adjustment>, IAdjustmentRepository
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

        public async Task<GetAdjustmentModel?> GetAdjustmentModel(long id)
        {
            var adjustment = await database.Adjustments
                .Where(a => a.Id == id)
                .Include(a => a.Withholdings)
                .Include(a => a.Project).ThenInclude(p => p.Company)
                .Select(a => new GetAdjustmentModel
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
                    AdvancePaymentValue = a.AdvancePaymentValue,
                    CompletionGuaranteeValue = a.CompletionGuaranteeValue,
                    EngineersSyndicateValue = a.EngineersSyndicateValue,
                    ApplicatorsSyndicateValue = a.ApplicatorsSyndicateValue,
                    RegularStampDuty = a.RegularStampDuty,
                    AdditionalStampDuty = a.AdditionalStampDuty,
                    TotalStampDuty = a.TotalStampDuty,
                    CommercialIndustrialTax = a.CommercialIndustrialTax,
                    ValueAddedTaxPercent = a.ValueAddedTaxPercent,
                    ValueAddedTax = a.ValueAddedTax,
                    WasteRemovalInsurance = a.WasteRemovalInsurance,
                    TahyaMisrFundValue = a.TahyaMisrFundValue,
                    ConractStampDuty = a.ConractStampDuty,
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
                    Total = a.Total,
                    Submitted = a.Submitted,
                    IsFirst = false,
                }
               ).FirstOrDefaultAsync();
            return adjustment; //_mapper.Map<GetAdjustmentModel>(adjustment);
        }

        /* public Task<GetAdjustmentModel?> AddWithholding(long id, EditWithholdingModel withholding)
         {
             return database.Adjustments.Include(adjustment => adjustment.Withholdings)
                 .Where(adjustment => adjustment.Id == id)
                 .Join(database.Projects.Include(project => project.Company),
                 adjustment => adjustment.ProjectId,
                 project => project.Id,
                 (adjustment, project) => GetAdjustmentModel.FromAdjustmentAndProject(adjustment, project)
                ).FirstOrDefaultAsync();
         }*/
    }
}
