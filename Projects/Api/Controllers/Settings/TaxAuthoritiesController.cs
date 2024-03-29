﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Settings.TaxAuthorities.Commands;
using NUCA.Projects.Application.Settings.TaxAuthorities.Commands.CreateTaxAuthority;
using NUCA.Projects.Application.Settings.TaxAuthorities.Commands.DeleteTaxAuthority;
using NUCA.Projects.Application.Settings.TaxAuthorities.Commands.UpdateTaxAuthority;
using NUCA.Projects.Application.Settings.TaxAuthorities.Queries.CanDeleteTaxAuthority;
using NUCA.Projects.Application.Settings.TaxAuthorities.Queries.GetTaxAuthorities;
using NUCA.Projects.Application.Settings.TaxAuthorities.Queries.GetTaxAuthority;

namespace NUCA.Projects.Api.Controllers.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxAuthoritiesController : BaseController
    {
        private readonly IGetTaxAuthoritiesQuery _listQuery;
        private readonly IGetTaxAuthorityQuery _detailQuery;
        private readonly ICanDeleteTaxAuthorityQuery _canDeleteQuery;
        private readonly ICreateTaxAuthorityCommand _createCommand;
        private readonly IUpdateTaxAuthorityCommand _updateCommand;
        private readonly IDeleteTaxAuthorityCommand _deleteCommand;

        public TaxAuthoritiesController(IGetTaxAuthoritiesQuery listQuery, IGetTaxAuthorityQuery detailQuery, ICanDeleteTaxAuthorityQuery canDeleteQuery, ICreateTaxAuthorityCommand createCommand, IUpdateTaxAuthorityCommand updateCommand, IDeleteTaxAuthorityCommand deleteCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _canDeleteQuery = canDeleteQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var taxAuthorities = await _listQuery.Execute();
            return Ok(taxAuthorities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var taxAuthority = await _detailQuery.Execute(id);
            return Ok(taxAuthority);
        }

        [HttpGet("{id}/CanDelete")]
        public async Task<IActionResult> CanDelete(int id)
        {
            bool canDelete = await _canDeleteQuery.Execute(id);
            return Ok(canDelete);
        }

        [Authorize("RevisionUser")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaxAuthorityModel TaxAuthority)
        {
            var result = await _createCommand.Execute(TaxAuthority);
            return Ok(result.Id);
        }

        [Authorize("RevisionUser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaxAuthorityModel TaxAuthority)
        {
            await _updateCommand.Execute(id, TaxAuthority);
            return Ok();
        }

        [Authorize("RevisionUser")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteCommand.Execute(id);
            return Ok();
        }
    }
}
