using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Entities.Users;

namespace NUCA.Projects.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly IUserRepository _repository;

        public GetUserQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUserModel?> Execute(long id)
        {
            User? user = await _repository.Get(id);
            return user != null ? new GetUserModel
            {
                Id = user.Id,
                Name = user.Name,
                Departments = user.Departments.Select(d =>
                new DepartmentModel { Id = d.Id, Name = d.Name })
                .ToList()
            } : null;
        }

    }
}
