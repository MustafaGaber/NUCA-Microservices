using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.CreateSection
{
    public interface ICreateSectionCommand
    {
        Task<BoqModel> Execute(long id, long tableId, CreateSectionModel section);
    }
}
