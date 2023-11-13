using System.Collections.Generic;

namespace NUCA.Projects.Application.Users.Queries.GetUsers
{
    public interface IGetUsersQuery
    {
        Task<List<GetUserModel>> Execute();
    }
}
