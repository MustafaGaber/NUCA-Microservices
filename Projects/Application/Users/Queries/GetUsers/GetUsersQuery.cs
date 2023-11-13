using NUCA.Projects.Application.Interfaces.Persistence;

namespace NUCA.Projects.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IGetUsersQuery
    {

        private readonly IUserRepository _repository;

        public GetUsersQuery(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetUserModel>> Execute()
        {
            return _repository.Select(user => new GetUserModel
            {
                Id = user.Id,
                Name = user.Name,
                Departments = user.Departments.Select(d =>
                new DepartmentModel { Id = d.Id, Name = d.Name })
                .ToList()
            });
        }
    }
}
