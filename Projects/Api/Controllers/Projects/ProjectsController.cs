﻿using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Projects.Commands.ApproveProject;
using NUCA.Projects.Application.Projects.Commands.CreateProject;
using NUCA.Projects.Application.Projects.Commands.DeleteProject;
using NUCA.Projects.Application.Projects.Commands.UpdateLedgers;
using NUCA.Projects.Application.Projects.Commands.UpdatePrivileges;
using NUCA.Projects.Application.Projects.Commands.UpdateProject;
using NUCA.Projects.Application.Projects.Models;
using NUCA.Projects.Application.Projects.Queries.GetProject;
using NUCA.Projects.Application.Projects.Queries.GetProjectLedgers;
using NUCA.Projects.Application.Projects.Queries.GetProjectName;
using NUCA.Projects.Application.Projects.Queries.GetProjects;
using NUCA.Projects.Application.Projects.Queries.GetProjectsWithStatements;
using NUCA.Projects.Application.Projects.Queries.GetProjectWithBoqData;
using NUCA.Projects.Application.Projects.Queries.GetProjectWithPrivileges;
using NUCA.Projects.Application.Projects.Queries.GetUserProjects;
using NUCA.Projects.Domain.Entities.Projects;
using System.Security.Claims;

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
        private readonly IGetProjectWithBoqDataQuery _getProjectWithBoqDataQuery;
        private readonly IGetProjectWithLedgersQuery _getProjectWithLedgersQuery;
        private readonly ICreateProjectCommand _createCommand;
        private readonly IUpdateProjectCommand _updateCommand;
        private readonly IDeleteProjectCommand _deleteCommand;
        private readonly IUpdatePrivilegesCommand _updatePrivilegesCommand;
        private readonly IApproveProjectCommand _approveProjectCommand;
        private readonly IUpdateLedgersCommand _updateLedgersCommand;
        public ProjectsController(IGetUserProjectsQuery listQuery, IGetProjectQuery detailQuery, IGetProjectWithStatementsQuery getProjectWithStatementsQuery, ICreateProjectCommand createCommand, IUpdateProjectCommand updateCommand, IDeleteProjectCommand deleteCommand, IGetProjectNameQuery getNameQuery, IGetProjectWithPrivilegesQuery getProjectWithPrivilegesQuery, IUpdatePrivilegesCommand updatePrivilegesCommand, IApproveProjectCommand approveProjectCommand, IGetProjectWithBoqDataQuery getProjectWithBoqDataQuery, IUpdateLedgersCommand updateLedgersCommand, IGetProjectWithLedgersQuery getProjectLedgersQuery)
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
            _approveProjectCommand = approveProjectCommand;
            _getProjectWithBoqDataQuery = getProjectWithBoqDataQuery;
            _updateLedgersCommand = updateLedgersCommand;
            _getProjectWithLedgersQuery = getProjectLedgersQuery;
        }

        // [Authorize(Policy = "ExecutionUser")]
        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            List<UserProject> projects = await _listQuery.Execute(User);
            return Ok(projects);
        }

        [HttpGet("WithStatements")]
        public async Task<IActionResult> GetProjectsWithStatements()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            List<ProjectWithStatementsModel> projects = await _getProjectWithStatementsQuery.Execute(userId);
            return Ok(projects);
        }

        [HttpGet("{id}/Name")]
        public async Task<IActionResult> GetName(long id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            string name = await _getNameQuery.Execute(id);
            return Ok(name);
        }

        [HttpGet("{id}/BoqData")]
        public async Task<IActionResult> GeProjectWithBoqData(long id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            ProjectWithBoqData project = await _getProjectWithBoqDataQuery.Execute(id);
            return Ok(project);
        }

        //[Authorize(Policy = "Admin")]
        [HttpGet("{id}/WithPrivileges")]
        public async Task<IActionResult> GetProjectWithPrivilegess(long id)
        {
            ProjectWithPrivilegesModel project = await _getProjectWithPrivilegesQuery.Execute(id);
            return Ok(project);
        }

        [HttpGet("{id}/WithLedgers")]
        public async Task<IActionResult> GetProjectWithLedgers(long id)
        {
            GetProjectWithLedgersModel project = await _getProjectWithLedgersQuery.Execute(id, User);
            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            GetProjectModel project = await _detailQuery.Execute(id, User);
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

        [HttpPut("{id}/Approve")]
        public async Task<IActionResult> Approve(long id)
        {
            GetProjectModel project = await _approveProjectCommand.Execute(id, User);
            return Ok(project);
        }

        [HttpPut("{id}/Privileges")]
        public async Task<IActionResult> UpdatePrivileges(long id, [FromBody] UpdatePrivilegesModel model)
        {
            await _updatePrivilegesCommand.Execute(id, model);
            return Ok();
        }

        [HttpPut("{id}/Ledgers")]
        public async Task<IActionResult> UpdateLedgers(long id, [FromBody] UpdateLedgersModel model)
        {
            GetProjectWithLedgersModel project = await _updateLedgersCommand.Execute(id, model, User);
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }
    }
}
