using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Application.Settings.Banks.Commands;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Data;

namespace NUCA.Projects.Application.Settings.Banks.Queries.GetBanksAndBranches
{
    public class GetBanksAndBranchesQuery: IGetBanksAndBranchesQuery
    {
        private readonly ProjectsDatabaseContext _database;

        public GetBanksAndBranchesQuery(ProjectsDatabaseContext database)
        {
            _database = database;
        }

        public async Task<GetBanksAndBranchesModel> Execute()
        {
            var mainBanks = await _database.MainBanks.Select(b => new GetMainBankModel
            {
                Id = b.Id,
                Name = b.Name,
            }).ToListAsync();
            var branches = await _database.BankBranches.Select(b => new GetBankBranchModel
            {
                Id = b.Id,
                Name = b.Name,
                MainBankId = b.MainBankId
            }).ToListAsync();
            return new GetBanksAndBranchesModel
            {
                Branches = branches,
                MainBanks = mainBanks
            };
        }
    }
}
