using NUCA.Projects.Domain.Entities.Adjustments;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Adjustments.Commands
{
    public class EditWithholdingModel
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public WithholdingType Type { get; set; }
    }
}
