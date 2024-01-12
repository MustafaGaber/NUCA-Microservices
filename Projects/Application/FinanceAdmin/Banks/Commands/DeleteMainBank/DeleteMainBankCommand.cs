using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteMainBank
{
    public class DeleteMainBankCommand : IDeleteMainBankCommand
    {
        private readonly IBankRepository _repository;
        public DeleteMainBankCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(long id)
        {
            bool hasProjects = await _repository.MainBankHasProjects(id);
            if (hasProjects)
            {
                throw new InvalidOperationException("Main Bank has projects");
            }
            bool hasBranches = await _repository.MainBankHasBranches(id);
            if (hasBranches)
            {
                throw new InvalidOperationException("Main Bank has branches");
            }
            await _repository.Delete(id);
        }
    }
}
