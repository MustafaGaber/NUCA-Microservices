namespace NUCA.Projects.Application.Settings.Ledgers.Models
{
    public class GetLedgerModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required string? Code { get; init; }
        public required long? ParentId { get; init; }
        public required string? ParentFullPath { get; init; }
    }
}
