using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Settlements.Commands
{
    public class EditWithholdingModel
    {
        public string Name { get; init; }
        public double Value { get; init; }
        public WithholdingType Type { get; init; }
    }
}
