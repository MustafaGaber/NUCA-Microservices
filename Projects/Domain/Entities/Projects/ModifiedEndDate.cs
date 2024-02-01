using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Projects
{
    public class ModifiedEndDate : Entity
    {
        public virtual DateOnly Value { get; private set; }
        protected ModifiedEndDate() { }
        public ModifiedEndDate(DateOnly date)
        {
            Value = date;
        }

        /* protected override bool EqualsCore(ModifiedEndDate other)
         {
             return Value.Day == other.Value.Day
             && Value.Month == other.Value.Month
             && Value.Year == other.Value.Year;
         }

         protected override int GetHashCodeCore()
         {
             return (Value.Day, Value.Month, Value.Year).GetHashCode();
         }*/
    }
}
