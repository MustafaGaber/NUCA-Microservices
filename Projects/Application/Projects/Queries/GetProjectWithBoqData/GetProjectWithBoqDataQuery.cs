using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Projects.Queries.GetProjectWithBoqData
{
    public class GetProjectWithBoqDataQuery : IGetProjectWithBoqDataQuery
    {
        private readonly IProjectRepository _repository;

        public GetProjectWithBoqDataQuery(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProjectWithBoqData> Execute(long id)
        {
            ProjectWithBoqData? project = await _repository.SelectOne(p => p.Id == id, p => new ProjectWithBoqData {
                Name = p.Name,
                CostCenterId = p.CostCenterId,
                WorkTypeId = p.WorkTypeId,
                Sovereign = p.Sovereign,
                DepartmentId = p.DepartmentId,
                DepartmentName = p.DepartmentName,
            }) ?? throw new InvalidOperationException();
            return project;
        }
    }
}
