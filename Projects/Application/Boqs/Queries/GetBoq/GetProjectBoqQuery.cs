using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Boqs.Queries.GetBoq
{
    public class GetProjectBoqQuery : IGetProjectBoqQuery
    {
        private readonly IBoqRepository _repository;
        public GetProjectBoqQuery(IBoqRepository repository)
        {
            _repository = repository;
        }
        public async Task<BoqModel?> Execute(long projectId)
        {
            var boq = await _repository.GetByProjectId(projectId);
            return boq != null ? new BoqModel(boq) : null;
        }
    }
}
