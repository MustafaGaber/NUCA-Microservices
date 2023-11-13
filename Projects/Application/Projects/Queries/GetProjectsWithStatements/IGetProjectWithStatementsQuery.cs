namespace NUCA.Projects.Application.Projects.Queries.GetProjectsWithStatements
{
    public interface IGetProjectWithStatementsQuery
    {
        Task<List<ProjectWithStatements>> Execute();
    }
}
