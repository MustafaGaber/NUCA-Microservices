using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class Privilege : Entity<long>
    {
        public int DepartmentId { get; private set; }
        public long UserId { get; private set; }

        public Privilege(int departmentId,long userId)
        {
            DepartmentId = Guard.Against.NegativeOrZero(departmentId);
            UserId =  Guard.Against.NegativeOrZero(userId);
        }

        public void Update(long userId)
        {
            UserId = Guard.Against.NegativeOrZero(userId);
        }
    }


}
