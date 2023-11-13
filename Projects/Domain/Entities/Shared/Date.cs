using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Shared
{
    public class Date : ValueObject<Date>
    {
        public virtual DateOnly Value { get; private set; }
        protected Date() { }
        public Date(DateOnly date)
        {
            Value = date;
        }

        protected override bool EqualsCore(Date other)
        {
            return Value.Day == other.Value.Day
            && Value.Month == other.Value.Month
            && Value.Year == other.Value.Year;
        }

        protected override int GetHashCodeCore()
        {
            return (Value.Day, Value.Month, Value.Year).GetHashCode();
        }
    }
}
