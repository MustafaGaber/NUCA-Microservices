﻿namespace NUCA.Projects.Application.Projects.Queries.GetProjectsWithStatements
{
    public interface IGetProjectWithStatementsQuery
    {
        Task<List<ProjectWithStatementsModel>> Execute(string userId);
    }
}
