using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Privilege : Entity
    {
        public long ProjectId { get; private set; }
        public string UserId { get; private set; }
        public PrivilegeType Type { get; private set; }
        public string? DepartmentId { get; private set; }

        public Privilege(long projectId, string userId, PrivilegeType type, string? departmentId)
        {
            if (!Enum.IsDefined(typeof(PrivilegeType), type))
            {
                throw new ArgumentException();
            }
            if (departmentId != null && type != PrivilegeType.Execution)
            {
                throw new ArgumentException();
            }
            ProjectId = Guard.Against.NegativeOrZero(projectId);
            UserId = Guard.Against.NullOrEmpty(userId);
            Type = type;
            DepartmentId = departmentId;
        }

        public void Update(string userId)
        {
            UserId = Guard.Against.NullOrEmpty(userId);
        }
    }

    public enum PrivilegeType
    {
        Projects = 10,
        ProjectsManager = 20,
        Execution = 30,
        ExecutionManager = 40,
        TechnicalOffice = 50,
        TechnicalOfficeManager = 60,
        Revision = 70,
        RevisionManager = 80,
        Accounting = 90,
        AccountingManager = 100,
        GeneralFinanceManager = 110,
        Assistant = 120,
        DeputyHead = 130,
    }

}
