using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Companies.Queries
{
   public class GetCompanyModel
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public string Phone { get; init; }
        public string Fax { get; init; }
        public string CommercialRegister { get; init; }
        public string TaxCard { get; init; }
        public string ElectronicInvoice { get; init; }
        public bool CommercialIndustrialTaxFree { get; init; }
    }
}
