namespace NUCA.Projects.Domain.Entities.Projects
{
    public class PrivilegeModel
    {
        public long Id { get; init; }
        public long UserId { get; init; }
        public int DepartmentId { get; init; }
    }
}