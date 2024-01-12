using NUCA.Projects.Application.Interfaces.Persistence;


namespace NUCA.Projects.Application.FinanceAdmin.Banks.Queries.GetMainBanks
{
    public class GetMainBanksQuery : IGetMainBanksQuery
    {

        private readonly IBankRepository _repository;

        public GetMainBanksQuery(IBankRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetMainBankModel>> Execute()
        {
            return _repository.Select(mainBank => new GetMainBankModel
            {
                Id = mainBank.Id,
                Name = mainBank.Name,
            });
        }
    }
}
