using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Models
{
    public class PrintStatementModel
    {
        public Statement Statement { get; set; }
        public Project Project { get; set; }
    }
}
