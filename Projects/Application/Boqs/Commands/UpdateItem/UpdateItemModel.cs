using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateItem
{
    public class UpdateItemModel
    {
        public string Index { get; init; }
        public string Content { get; init; }
        public string Unit { get; init; }
        public double Quantity { get; init; }
        public double UnitPrice { get; init; }
    }
}
