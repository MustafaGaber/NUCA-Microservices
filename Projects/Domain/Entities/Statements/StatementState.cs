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
        Adjusted = 70,
        Paid = 80,
    }
}
