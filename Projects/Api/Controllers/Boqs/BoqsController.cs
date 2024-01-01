using Microsoft.AspNetCore.Mvc;
using NUCA.Projects.Api.Controllers.Core;
using NUCA.Projects.Application.Boqs.Commands.ApproveBoq;
using NUCA.Projects.Application.Boqs.Commands.CreateBoq;
using NUCA.Projects.Application.Boqs.Commands.CreateItem;
using NUCA.Projects.Application.Boqs.Commands.CreateSection;
using NUCA.Projects.Application.Boqs.Commands.CreateTable;
using NUCA.Projects.Application.Boqs.Commands.DeleteItem;
using NUCA.Projects.Application.Boqs.Commands.DeleteSection;
using NUCA.Projects.Application.Boqs.Commands.DeleteTable;
using NUCA.Projects.Application.Boqs.Commands.UpdateBoq;
using NUCA.Projects.Application.Boqs.Commands.UpdateItem;
using NUCA.Projects.Application.Boqs.Commands.UpdateSection;
using NUCA.Projects.Application.Boqs.Commands.UpdateTable;
using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Boqs.Queries.GetBoq;
using NUCA.Projects.Application.Projects.Queries.Models;

namespace NUCA.Projects.Api.Controllers.Boqs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoqsController : BaseController
    {
        private readonly IGetProjectBoqQuery _getProjectBoqQuery;
        private readonly ICreateBoqCommand _createBoqCommand;
        private readonly IUpdateBoqCommand _updateBoqCommand;
        private readonly ICreateTableCommand _createTableCommand;
        private readonly IUpdateTableCommand _updateTableCommand;
        private readonly IDeleteTableCommand _deleteTableCommand;
        private readonly ICreateSectionCommand _createSectionCommand;
        private readonly IUpdateSectionCommand _updateSectionCommand;
        private readonly IDeleteSectionCommand _deleteSectionCommand;
        private readonly ICreateItemCommand _createItemCommand;
        private readonly IUpdateItemCommand _updateItemCommand;
        private readonly IDeleteItemCommand _deleteItemCommand;
        private readonly IApproveBoqCommand _approveBoqCommand;

        public BoqsController(IGetProjectBoqQuery getBoqQuery, ICreateBoqCommand createBoqCommand, IUpdateBoqCommand updateBoqCommand,
            ICreateTableCommand createTableCommand, IUpdateTableCommand updateTableCommand, IDeleteTableCommand deleteTableCommand,
            ICreateSectionCommand createSectionCommand, IUpdateSectionCommand updateSectionCommand, IDeleteSectionCommand deleteSectionCommand,
            ICreateItemCommand createItemCommand, IUpdateItemCommand updateItemCommand, IDeleteItemCommand deleteItemCommand, IApproveBoqCommand approveBoqCommand)
        {
            _getProjectBoqQuery = getBoqQuery;
            _createBoqCommand = createBoqCommand;
            _updateBoqCommand = updateBoqCommand;
            _createTableCommand = createTableCommand;
            _updateTableCommand = updateTableCommand;
            _deleteTableCommand = deleteTableCommand;
            _createSectionCommand = createSectionCommand;
            _updateSectionCommand = updateSectionCommand;
            _deleteSectionCommand = deleteSectionCommand;
            _createItemCommand = createItemCommand;
            _updateItemCommand = updateItemCommand;
            _deleteItemCommand = deleteItemCommand;
            _approveBoqCommand = approveBoqCommand;
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> Get(long projectId)
        {
            BoqModel? boq = await _getProjectBoqQuery.Execute(projectId);
            return Ok(boq);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateBoq(long id, [FromBody] CreateBoqModel model)
        {
            BoqModel boq = await _createBoqCommand.Execute(id, model);
            return Ok(boq);
        }

        [HttpPut("{id}/Approve")]
        public async Task<IActionResult> Approve(long id)
        {
            BoqModel boq = await _approveBoqCommand.Execute(id, User);
            return Ok(boq);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoq(long id, [FromBody] UpdateBoqModel model)
        {
            BoqModel boq = await _updateBoqCommand.Execute(id, model);
            return Ok(boq);
        }

        [HttpPost("{id}/Table")]
        public async Task<IActionResult> CreateTable(long id, [FromBody] CreateTableModel table)
        {
            BoqModel boq = await _createTableCommand.Execute(id, table);
            return Ok(boq);
        }

        [HttpPut("{id}/Table/{tableId}")]
        public async Task<IActionResult> UpdateTable(long id, long tableId, [FromBody] UpdateTableModel table)
        {
            BoqModel boq = await _updateTableCommand.Execute(id, tableId, table);
            return Ok(boq);
        }

        [HttpDelete("{id}/Table/{tableId}")]
        public async Task<IActionResult> DeleteTable(long id, long tableId)
        {
            BoqModel boq = await _deleteTableCommand.Execute(id, tableId);
            return Ok(boq);
        }

        [HttpPost("{id}/Section/{tableId}")]
        public async Task<IActionResult> createSection(long id, long tableId, [FromBody] CreateSectionModel section)
        {
            BoqModel boq = await _createSectionCommand.Execute(id, tableId, section);
            return Ok(boq);
        }

        [HttpPut("{id}/Section/{tableId}/{sectionId}")]
        public async Task<IActionResult> UpdateSection(long id, long tableId, long sectionId, [FromBody] UpdateSectionModel section)
        {
            BoqModel boq = await _updateSectionCommand.Execute(id, tableId, sectionId, section);
            return Ok(boq);
        }

        [HttpDelete("{id}/Section/{tableId}/{sectionId}")]
        public async Task<IActionResult> DeleteSection(long id, long tableId, long sectionId)
        {
            BoqModel boq = await _deleteSectionCommand.Execute(id, tableId, sectionId);
            return Ok(boq);
        }

        [HttpPost("{id}/Item/{tableId}/{sectionId}")]
        public async Task<IActionResult> CreateItem(long id, long tableId, long sectionId, [FromBody] CreateItemModel item)
        {
            BoqModel boq = await _createItemCommand.Execute(id, tableId, sectionId, item);
            return Ok(boq);
        }

        [HttpPut("{id}/Item/{tableId}/{sectionId}/{itemId}")]
        public async Task<IActionResult> UpdateItem(long id, long tableId, long sectionId, long itemId, [FromBody] UpdateItemModel item)
        {
            BoqModel boq = await _updateItemCommand.Execute(id, tableId, sectionId, itemId, item);
            return Ok(boq);
        }

        [HttpDelete("{id}/Item/{tableId}/{sectionId}/{itemId}")]
        public async Task<IActionResult> DeleteItem(long id, long tableId, long sectionId, long itemId)
        {
            BoqModel boq = await _deleteItemCommand.Execute(id, tableId, sectionId, itemId);
            return Ok(boq);
        }
    }
}
