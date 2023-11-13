namespace NUCA.Projects.Application.Statements.Queries.GetProjectStatements
{
    public interface IGetProjectStatementsQuery
    {
        public Task<List<ProjectStatement>> Execute(long projectId);
    }
}
