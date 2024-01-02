using Microsoft.EntityFrameworkCore;
using NUCA.Projects.Data;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Application.Projects.Commands.UpdatePrivileges
{
    public class UpdatePrivilegesCommand : IUpdatePrivilegesCommand
    {
        private ProjectsDatabaseContext _dbContext;

        public UpdatePrivilegesCommand(ProjectsDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(long projectId, UpdatePrivilegesModel model)
        {
            var privileges = await _dbContext.Set<Privilege>()
                                    .Where(p => p.ProjectId == projectId)
                                    .ToListAsync();
            _dbContext.RemoveRange(privileges.Where(privilege => !model.Privileges.Any(p => p.Type == privilege.Type && p.DepartmentId == privilege.DepartmentId)));
            _dbContext.RemoveRange(privileges.Where(privilege => model.Privileges.Any(p => p.Type == privilege.Type && p.DepartmentId == privilege.DepartmentId && p.UserId == null)));
            model.Privileges.Where(p => p.UserId != null).ToList().ForEach(p =>
            {
                Privilege? privilege = privileges.Find(_p => _p.Type == p.Type && p.DepartmentId == _p.DepartmentId);
                if (privilege != null)
                {
                    privilege.Update(p.UserId!);
                }
            });
            _dbContext.AddRange(
              model.Privileges
                   .Where(p => p.UserId != null)
                   .Where(p => !privileges.Any(_p => p.Type == _p.Type && p.DepartmentId == _p.DepartmentId))
                   .Select(p => new Privilege(projectId, p.UserId!, p.Type, p.DepartmentId)));
            await _dbContext.SaveChangesAsync();
        }
    }
}
