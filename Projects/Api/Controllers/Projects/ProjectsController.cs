using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Projects.Commands;
using NUCA.Projects.Application.Projects.Commands.CreateProject;
using NUCA.Projects.Application.Projects.Commands.DeleteProject;
using NUCA.Projects.Application.Projects.Commands.UpdatePrivileges;
using NUCA.Projects.Application.Projects.Commands.UpdateProject;
using NUCA.Projects.Application.Projects.Queries.GetProject;
using NUCA.Projects.Application.Projects.Queries.GetProjectName;
using NUCA.Projects.Application.Projects.Queries.GetProjects;
using NUCA.Projects.Application.Projects.Queries.GetProjectsWithStatements;
using NUCA.Projects.Application.Projects.Queries.GetProjectWithPrivileges;
using NUCA.Projects.Application.Projects.Queries.GetUserProjects;
using NUCA.Projects.Application.Projects.Queries.Models;
using NUCA.Projects.Domain.Entities.Projects;

namespace NUCA.Projects.Api.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        private readonly IGetUserProjectsQuery _listQuery;
        private readonly IGetProjectQuery _detailQuery;
        private readonly IGetProjectWithStatementsQuery _getProjectWithStatementsQuery;
        private readonly IGetProjectNameQuery _getNameQuery;
        private readonly IGetProjectWithPrivilegesQuery _getProjectWithPrivilegesQuery;
        private readonly ICreateProjectCommand _createCommand;
        private readonly IUpdateProjectCommand _updateCommand;
        private readonly IDeleteProjectCommand _deleteCommand;
        private readonly IUpdatePrivilegesCommand _updatePrivilegesCommand;
        public ProjectsController(IGetUserProjectsQuery listQuery, IGetProjectQuery detailQuery, IGetProjectWithStatementsQuery getProjectWithStatementsQuery, ICreateProjectCommand createCommand, IUpdateProjectCommand updateCommand, IDeleteProjectCommand deleteCommand, IGetProjectNameQuery getNameQuery, IGetProjectWithPrivilegesQuery getProjectWithPrivilegesQuery, IUpdatePrivilegesCommand updatePrivilegesCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _getProjectWithStatementsQuery = getProjectWithStatementsQuery;
            _getNameQuery = getNameQuery;
            _getProjectWithPrivilegesQuery = getProjectWithPrivilegesQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _updatePrivilegesCommand = updatePrivilegesCommand;
        }

        // [Authorize(Policy = "ExecutionUser")]
        [HttpGet("UserProjects")]
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User;
            List<UserProject> projects = await _listQuery.Execute();
            return Ok(projects);
        }

        [HttpGet("WithStatements")]
        public async Task<IActionResult> GetProjectsWithStatements()
        {
            List<ProjectWithStatementsModel> projects = await _getProjectWithStatementsQuery.Execute();
            return Ok(projects);
        }

        [HttpGet("{id}/Name")]
        public async Task<IActionResult> GetName(long id)
        {
            string name = await _getNameQuery.Execute(id);
            return Ok(name);
        }

        [HttpGet("{id}/WithPrivileges")]
        public async Task<IActionResult> GetProjectWithPrivilegess(long id)
        {
            ProjectWithPrivilegesModel project = await _getProjectWithPrivilegesQuery.Execute(id);
            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            GetProjectModel project = await _detailQuery.Execute(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectModel project)
        {
            Project? result = await _createCommand.Execute(project);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ProjectModel project)
        {
            await _updateCommand.Execute(id, project);
            return Ok();
        }

        [HttpPut("{id}/Privileges")]
        public async Task<IActionResult> UpdatePrivileges(long id, [FromBody] UpdatePrivilegesModel model)
        {
            await _updatePrivilegesCommand.Execute(id, model);
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
