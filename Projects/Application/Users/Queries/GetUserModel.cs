namespace NUCA.Projects.Application.Users.Queries
{
    public class GetUserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<DepartmentModel> Departments { get; set; }
    }

    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
