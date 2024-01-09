using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.FinanceAdmin.MainBanks.Commands.DeleteMainBank
{
    public class DeleteMainBankCommand : IDeleteMainBankCommand
    {
        private readonly IBankRepository _repository;
        public DeleteMainBankCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(int id)
        {
            bool hasProjects = await _repository.MainBankHasProjects(id);
            if (!hasProjects)
            {
                await _repository.Delete(id);
            }
            else
            {
                throw new InvalidOperationException("MainBank has projects");
            }
        }
    }
}
