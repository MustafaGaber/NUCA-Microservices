using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Companies.Queries
{
   public class GetCompanyModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string CommercialRegister { get; set; }
        public string TaxCard { get; set; }
        public string ElectronicInvoice { get; set; }
        public bool CommercialIndustrialTaxFree { get; set; }
    }
}
