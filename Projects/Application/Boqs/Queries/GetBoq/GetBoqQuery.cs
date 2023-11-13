using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Boqs.Queries.GetBoq
{
    public class GetBoqQuery : IGetBoqQuery
    {
        private readonly IBoqRepository _repository;
        public GetBoqQuery(IBoqRepository repository)
        {
            _repository = repository;
        }
        public async Task<BoqModel?> Execute(long id)
        {
            var boq = await _repository.Get(id);
            return boq != null ? new BoqModel(boq) : null;
        }
    }
}
