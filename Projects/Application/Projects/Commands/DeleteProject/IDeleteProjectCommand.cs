using NUCA.Projects.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUCA.Projects.Application.Projects.Commands.DeleteProject
{
   public interface IDeleteProjectCommand
    {
        Task Execute(long id);
    }
}
