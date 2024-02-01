namespace NUCA.Projects.Application.Settings.TaxAuthorities.Queries
{
    public class GetTaxAuthorityModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required string? Address { get; init; }

    }
}
