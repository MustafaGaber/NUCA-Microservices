using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.FinanceAdmin
{
    public class BankBranch: Entity
    {
        public string Name { get; private set; }
        public long MainBankId { get; private set; }

        public MainBank MainBank { get; private set; }
        protected BankBranch() { }

        public BankBranch(string name, MainBank mainBank)
        {
            Name = Guard.Against.NullOrEmpty(name);
            MainBank = mainBank;
            MainBankId = mainBank.Id;
        }

        public void Update(string name)
        {
            Name = Guard.Against.NullOrEmpty(name);
        }
    }
}
