using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.CreateItem
{
    public class CreateItemModel
    {
        public string Index { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
