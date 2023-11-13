using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Boqs.Commands.CreateTable
{
    public class CreateTableModel
    {
        public string TableName { get; set; }
        public int Count { get; set; }
        public double PriceChangePercent { get; set; }
        public BoqTableType Type { get; set; }
    }
}
