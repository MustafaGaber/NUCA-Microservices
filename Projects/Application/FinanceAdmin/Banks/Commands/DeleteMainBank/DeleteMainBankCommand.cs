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
        public async Task Execute(int id)
        {
            bool hasProjects = await _repository.BankHasProjects(id);
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
