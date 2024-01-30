namespace NUCA.Projects.Application.Settings.CostCenters.Commands.DeleteCostCenter
{
    public interface IDeleteCostCenterCommand
    {
        Task Execute(int id);
    }
}
