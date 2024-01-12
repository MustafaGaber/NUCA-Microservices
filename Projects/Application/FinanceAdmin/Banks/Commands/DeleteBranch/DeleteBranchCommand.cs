using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteBranch
{
    public class DeleteBranchCommand: IDeleteBranchCommand
    {
        private readonly IBankRepository _repository;
        public DeleteBranchCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(long id)
        {
            bool hasProjects = await _repository.BranchHasProjects(id);
            if (!hasProjects)
            {
                await _repository.DeleteBranch(id);
            }
            else
            {
                throw new InvalidOperationException("Bank Branch has projects");
            }
        }
    }
}

