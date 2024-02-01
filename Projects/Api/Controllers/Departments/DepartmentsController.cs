using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Application.Departments.Commands.CreateDepartment;
using NUCA.Projects.Application.Departments.Commands;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Departments.Queries.GetDepartments;
using NUCA.Projects.Application.Departments.Queries.GetDepartment;
using NUCA.Projects.Application.Departments.Commands.UpdateDepartment;
using NUCA.Projects.Application.Departments.Commands.DeleteDepartment;
using NUCA.Projects.Domain.Entities.Departments;
using NUCA.Projects.Application.Departments.Queries;
using NUCA.Projects.Application.Departments.Queries.CanDeleteDepartment;

namespace NUCA.Projects.Api.Controllers.Departments
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController: BaseController
    {
        private readonly IGetDepartmentsQuery _listQuery;
        private readonly IGetDepartmentQuery _detailQuery;
        private readonly ICanDeleteDepartmentQuery _canDeleteQuery;
        private readonly ICreateDepartmentCommand _createCommand;
        private readonly IUpdateDepartmentCommand _updateCommand;
        private readonly IDeleteDepartmentCommand _deleteCommand;

        public DepartmentsController(IGetDepartmentsQuery listQuery, IGetDepartmentQuery detailQuery, ICreateDepartmentCommand createCommand, IUpdateDepartmentCommand updateCommand, IDeleteDepartmentCommand deleteCommand ,ICanDeleteDepartmentQuery canDeleteQuery)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
            _canDeleteQuery = canDeleteQuery;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<GetDepartmentModel> departments = await _listQuery.Execute();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetDepartmentModel department = await _detailQuery.Execute(id);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentModel department)
        {
            Department result = await _createCommand.Execute(department);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentModel department)
        {
            await _updateCommand.Execute(id, department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }

        [HttpGet("{id}/CanDelete")]
        public async Task<IActionResult> CanDelete(string id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }
    }
}