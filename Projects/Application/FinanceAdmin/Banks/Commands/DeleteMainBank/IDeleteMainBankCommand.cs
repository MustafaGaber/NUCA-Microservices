﻿namespace NUCA.Projects.Application.FinanceAdmin.Banks.Commands.DeleteMainBank
{
    public interface IDeleteMainBankCommand
    {
        Task Execute(int id);
    }
}