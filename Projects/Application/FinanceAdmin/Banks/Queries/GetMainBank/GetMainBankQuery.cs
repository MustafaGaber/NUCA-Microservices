using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBank
{
    public class GetMainBankQuery : IGetMainBankQuery
    {
        private readonly IBankRepository _repository;

        public GetMainBankQuery(IBankRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMainBankModel?> Execute(int id)
        {
            var mainBank = await _repository.Get(id);
            return mainBank != null ? new GetMainBankModel
            {
                Id = mainBank.Id,
                Name = mainBank.Name,
                ValueAddedTaxPercent = mainBank.ValueAddedTaxPercent,
            } : null;
        }

    }
}
