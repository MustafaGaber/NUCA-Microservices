using NUCA.Projects.Domain.Entities.Statements;

namespace NUCA.Projects.Application.Statements.Models
{
    public class PrintTableModel
    {
        public required StatementTable Table { get; init; }
        public required List<ExternalSuppliesItem> ExternalSuppliesItems { get; init; }

    }
}
