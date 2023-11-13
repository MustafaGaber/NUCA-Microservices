using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class WithholdingModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public WithholdingType Type { get; set; }

    }
}
