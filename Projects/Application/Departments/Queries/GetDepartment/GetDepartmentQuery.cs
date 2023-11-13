using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Departments;

namespace NUCA.Projects.Application.Departments.Queries.GetDepartment
{
    public class GetDepartmentQuery : IGetDepartmentQuery
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentQuery(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDepartmentModel?> Execute(int id)
        {
            var department = await _repository.Get(id);
            return department != null ? new GetDepartmentModel
            {
                Id = department.Id,
                Name = department.Name,
            } : null;
        }

    }
}
