namespace NUCA.Projects.Application.Projects.Queries.GetProjectName
{
    public interface IGetProjectNameQuery
    {
        Task<string> Execute(long Id);
    }
}
