using NUCA.Projects.Domain.Common;

namespace NUCA.Projects.Domain.Entities.Shared
{
    public class Duration : ValueObject<Duration>
    {
        public virtual int Years { get; private set; }
        public virtual int Months { get; private set; }
        public virtual int Days { get; private set; }
        protected Duration() { }
        public Duration(int years, int months, int days)
        {
            Years = years; 
            Months = months;
            Days = days;
        }

        public bool  Empty {
            get { return Years == 0 && Months == 0 && Days == 0;}
        }
        
        protected override bool EqualsCore(Duration other)
        {
            return Years == other.Years 
            && Months == other.Months
            && Days == other.Days;
        }

        protected override int GetHashCodeCore()
        {
            return (Years, Months, Days).GetHashCode();
        }
    }
}
