﻿using NUCA.Projects.Application.Settings.Banks.Queries;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Settings;

namespace NUCA.Projects.Application.Settings.Banks.Commands.CreateMainBank
{
    public class CreateMainBankCommand : ICreateMainBankCommand
    {
        private readonly IBankRepository _repository;
        public CreateMainBankCommand(IBankRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetMainBankModel> Execute(MainBankModel model)
        {
            var mainBank = await _repository.Add(new MainBank(model.Name));
            return new GetMainBankModel {
                Id = mainBank.Id,
                Name = mainBank.Name,
            };
        }

    }
}
