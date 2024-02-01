using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class WithholdingModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required double Value { get; init; }
        public required WithholdingType Type { get; init; }

    }
}
