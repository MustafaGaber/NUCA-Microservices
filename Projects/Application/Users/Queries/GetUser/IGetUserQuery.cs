
namespace NUCA.Projects.Application.Users.Queries.GetUser
{
    public interface IGetUserQuery
    {
        Task<GetUserModel?> Execute(long id);
    }
}
