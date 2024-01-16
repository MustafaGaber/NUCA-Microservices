namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithBoqData
{
    public interface IGetProjectWithBoqDataQuery
    {
        Task<ProjectWithBoqData> Execute(long id);
    }
}
