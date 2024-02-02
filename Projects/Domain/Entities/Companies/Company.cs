using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Domain.Entities.Settings;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Companies
{
    public class Company : Entity
    {
        public string Name { get; private set; }
        public CompanyType Type { get; private set; }
        public string? Address { get; private set; }
        public string? Phone { get; private set; }
        public string? Fax { get; private set; }
        public string? CommercialRegister { get; private set; }
        public string? TaxCard { get; private set; }
        public string? TaxFile { get; private set; }
        public string? ElectronicInvoice { get; private set; }
        public bool CommercialIndustrialTaxFree { get; private set; }
        public TaxAuthority? TaxAuthority { get; private set; }
        public virtual IReadOnlyList<Project> Projects { get; private set; }
        public long? TaxAuthorityId { get; private set; }
        protected Company() { }
        public Company(string name, CompanyType type, string address, string phone, string fax, string commercialRegister, string taxCard, string taxFile, string electronicInvoice, bool commercialIndustrialTaxFree, TaxAuthority? taxAuthority)
        {
            Update(
                name: name,
                type: type,
                address: address,
                phone: phone,
                fax: fax,
                commercialRegister: commercialRegister,
                taxCard: taxCard,
                taxFile: taxFile,
                electronicInvoice: electronicInvoice,
                commercialIndustrialTaxFree: commercialIndustrialTaxFree,
                taxAuthority: taxAuthority
            );
        }

        public void Update(string name, CompanyType type, string address, string phone, string fax, string commercialRegister, string taxCard, string taxFile, string electronicInvoice, bool commercialIndustrialTaxFree, TaxAuthority? taxAuthority)
        {
            Name = Guard.Against.NullOrEmpty(name);
            Type = Guard.Against.EnumOutOfRange(type);
            Address = address;
            Phone = phone;
            Fax = fax;
            CommercialRegister = commercialRegister;
            TaxCard = taxCard;
            TaxFile = taxFile;
            ElectronicInvoice = electronicInvoice;
            CommercialIndustrialTaxFree = commercialIndustrialTaxFree;
            TaxAuthority = taxAuthority;
        }
    }
}
