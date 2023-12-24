namespace NUCA.Projects.Domain.Entities.Projects
{
    public class PrivilegeModel
    {
        public long Id { get; init; }
        public Guid UserId { get; init; }
        public PrivilegeType Type { get; init; }
        public Guid? DepartmentId { get; init; }
    }
}