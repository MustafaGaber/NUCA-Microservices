using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Boqs.Commands.CreateTable
{
    public class CreateTableModel
    {
        public string TableName { get; init; }
        public int Count { get; init; }
        public double PriceChangePercent { get; init; }
        public BoqTableType Type { get; init; }
    }
}
