
namespace NUCA.Projects.Application.Projects.Commands.UpdatePrivileges
{
    public interface IUpdatePrivilegesCommand
    {
        Task Execute(long projectId, UpdatePrivilegesModel model);

    }
}
