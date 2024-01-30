using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Settings.Banks.Queries.GetMainBankBranches
{
    public class GetMainBankBranchesQuery : IGetMainBankBranchesQuery
    {
        private readonly IBankRepository _repository;

        public GetMainBankBranchesQuery(IBankRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetBankBranchModel>> Execute(long id)
        {
            return _repository.GetMainBankBranches(id);
        }
    }
}
