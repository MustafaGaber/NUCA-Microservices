using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Companies.Queries
{
    public class GetCompanyModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required CompanyType Type { get; init; }
        public required string? Address { get; init; }
        public required string? Phone { get; init; }
        public required string? Fax { get; init; }
        public required string? CommercialRegister { get; init; }
        public required string? TaxCard { get; init; }
        public required string? ElectronicInvoice { get; init; }
        public required bool CommercialIndustrialTaxFree { get; init; }
    }
}
