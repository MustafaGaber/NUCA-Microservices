using NUCA.Projects.Application.Companies.Commands;
using NUCA.Projects.Application.Companies.Commands.CreateCompany;
using NUCA.Projects.Application.Companies.Commands.DeleteCompany;
using NUCA.Projects.Application.Companies.Commands.UpdateCompany;
using NUCA.Projects.Application.Companies.Queries.GetCompanies;
using NUCA.Projects.Application.Companies.Queries.GetCompany;
using NUCA.Projects.Api.Controllers.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NUCA.Projects.Api.Controllers.Companies
{
    [Authorize("ProjectsUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        private readonly IGetCompaniesQuery _listQuery;
        private readonly IGetCompanyQuery _detailQuery;
        private readonly ICreateCompanyCommand _createCommand;
        private readonly IUpdateCompanyCommand _updateCommand;
        private readonly IDeleteCompanyCommand _deleteCommand;

        public CompaniesController(IGetCompaniesQuery listQuery, IGetCompanyQuery detailQuery, ICreateCompanyCommand createCommand, IUpdateCompanyCommand updateCommand, IDeleteCompanyCommand deleteCommand)
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
            var companies = await _listQuery.Execute();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var company = await _detailQuery.Execute(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyModel company)
        {
            var result = await _createCommand.Execute(company);
            return Ok(result.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] CompanyModel company)
        {
            await _updateCommand.Execute(id, company);
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
