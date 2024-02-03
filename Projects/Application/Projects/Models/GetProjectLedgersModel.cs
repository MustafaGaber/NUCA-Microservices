namespace NUCA.Projects.Application.Projects.Models
{
    public class GetProjectLedgersModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required LedgerModel? FromLedger { get; init; }
        public required LedgerModel? ToLedger { get; init; }
        public required LedgerModel? AdvancePaymentLedger { get; init; }
    }

    public class LedgerModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required string? Code { get; init; }
        public required long? ParentId { get; init; }
        public required string? ParentFullPath { get; init; }
    }
}
