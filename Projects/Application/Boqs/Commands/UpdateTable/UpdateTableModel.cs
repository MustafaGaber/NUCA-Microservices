using NUCA.Projects.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Projects.Application.Boqs.Commands.UpdateTable
{
    public class UpdateTableModel
    {
        public string TableName { get; set; }
        public int Count { get; set; }
        public double PriceChangePercent { get; set; }
        public BoqTableType Type { get; set; }
    }
}
