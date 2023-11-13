using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Companies
{
    public class Company : Entity<long>
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string Fax { get; private set; }
        public string CommercialRegister { get; private set; }
        public string TaxCard { get; private set; }
        public string ElectronicInvoice { get; private set; }
        public bool CommercialIndustrialTaxFree { get; private set; }
        protected Company() { }
        public Company(string name, string address, string phone, string fax, string commercialRegister, string taxCard, string electronicInvoice, bool commercialIndustrialTaxFree)
        {
            Name = Guard.Against.NullOrEmpty(name);
            Address = address;
            Phone = phone;
            Fax = fax;
            CommercialRegister = commercialRegister;
            TaxCard = taxCard;
            ElectronicInvoice = electronicInvoice;
            CommercialIndustrialTaxFree = commercialIndustrialTaxFree;
        }

        public void Update(string name, string address, string phone, string fax, string commercialRegister, string taxCard, string electronicInvoice, bool commercialIndustrialTaxFree)
        {
            Name = Guard.Against.NullOrEmpty(name);
            Address = address;
            Phone = phone;
            Fax = fax;
            CommercialRegister = commercialRegister;
            TaxCard = taxCard;
            ElectronicInvoice = electronicInvoice;
            CommercialIndustrialTaxFree = commercialIndustrialTaxFree;
        }
    }
}
