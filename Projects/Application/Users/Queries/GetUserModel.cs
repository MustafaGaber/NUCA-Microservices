namespace NUCA.Projects.Application.Users.Queries
{
    public class GetUserModel
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public List<DepartmentModel> Departments { get; init; }
    }

    public class DepartmentModel
    {
        public long Id { get; init; }
        public string Name { get; init; }

    }
}
