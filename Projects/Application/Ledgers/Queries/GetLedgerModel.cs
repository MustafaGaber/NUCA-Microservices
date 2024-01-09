namespace NUCA.Projects.Application.Ledgers.Queries
{
    public class GetLedgerModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required int Index { get; init; }
    }
}
