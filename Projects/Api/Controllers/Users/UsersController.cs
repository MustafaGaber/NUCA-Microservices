using NUCA.Projects.Application.Users.Commands;
using NUCA.Projects.Application.Users.Commands.CreateUser;
using NUCA.Projects.Application.Users.Commands.DeleteUser;
using NUCA.Projects.Application.Users.Commands.UpdateUser;
using NUCA.Projects.Application.Users.Queries;
using NUCA.Projects.Application.Users.Queries.GetUser;
using NUCA.Projects.Application.Users.Queries.GetUsers;
using NUCA.Projects.Domain.Entities.Users;
using NUCA.Projects.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;


namespace NUCA.Projects.Api.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IGetUsersQuery _listQuery;
        private readonly IGetUserQuery _detailQuery;
        private readonly ICreateUserCommand _createCommand;
        private readonly IUpdateUserCommand _updateCommand;
        private readonly IDeleteUserCommand _deleteCommand;

        public UsersController(IGetUsersQuery listQuery, IGetUserQuery detailQuery, ICreateUserCommand createCommand, IUpdateUserCommand updateCommand, IDeleteUserCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }
         
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<GetUserModel> users = await _listQuery.Execute();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            GetUserModel? user = await _detailQuery.Execute((long)id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel user)
        {
           User result = await _createCommand.Execute(user);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UserModel user)
        {
            await _updateCommand.Execute(id, user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }
    }
}
