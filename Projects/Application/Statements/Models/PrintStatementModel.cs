using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Models
{
    public class PrintStatementModel
    {
        public required Statement Statement { get; init; }
        public required Project Project { get; init; }
    }
}
