using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Boqs.Queries.GetBoq;
using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.CreateTable
{
    public interface ICreateTableCommand
    {
        Task<BoqModel> Execute(long boqId, CreateTableModel table);
    }
}
