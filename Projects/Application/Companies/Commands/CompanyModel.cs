﻿
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Companies.Commands
{
    public class CompanyModel
    {
        public string Name { get; init; }
        public CompanyType Type { get; init; }
        public string? Address { get; init; }
        public string? Phone { get; init; }
        public string? Fax { get; init; }
        public string? CommercialRegister { get; init; }
        public string? TaxCard { get; init; }
        public string? TaxFile { get; init; }
        public string? ElectronicInvoice { get; init; }
        public bool CommercialIndustrialTaxFree { get; init; }
        public long TaxAuthorityId { get; init; }
    }
}
