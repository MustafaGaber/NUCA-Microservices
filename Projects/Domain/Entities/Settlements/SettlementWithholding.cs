using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Settlements
{
    public class SettlementWithholding : Entity
    {
        public string Name { get; private set; }
        public double Value { get; private set; }
        public WithholdingType Type { get; private set; }
        public bool FromStatement { get; private set; }

        protected SettlementWithholding() { }
        public SettlementWithholding(string name, double value, WithholdingType type, bool fromStatement)
        {
            if (!Enum.IsDefined(typeof(WithholdingType), type))
            {
                throw new ArgumentException("Invalid settlement withholding type");
            }
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Value = value;
            Type = type;
            FromStatement = fromStatement;
        }

        public void Update(string name, double value, WithholdingType type)
        {
            if (FromStatement)
            {
                throw new InvalidOperationException();
            }
            if (!Enum.IsDefined(typeof(WithholdingType), type))
            {
                throw new ArgumentException("Invalid settlement withholding type");
            }
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Value = value;
            Type = type;
        }
    }

}
