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
        public string TableName { get; init; }
        public int Count { get; init; }
        public double PriceChangePercent { get; init; }
        public BoqTableType Type { get; init; }
    }
}
