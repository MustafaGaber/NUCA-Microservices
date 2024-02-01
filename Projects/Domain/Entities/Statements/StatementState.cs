namespace NUCA.Projects.Domain.Entities.Statements
{
    public enum StatementState
    {
        Execution = 10,
        ReturnedToExecution = 20,
        TechnicalOffice = 30,
        ReturnedToTechnicalOffice = 40,
        Revision = 50,
        RevisionApproved = 60,
        Adjusting = 70,
        Adjusted = 80,
        PartiallyPaid = 90,
        Paid = 100,
    }
}
