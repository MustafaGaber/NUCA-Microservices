namespace NUCA.Projects.Application.Settings.WorkTypes.Queries
{
    public class GetWorkTypeModel
    {
        public required long Id { get; init; }
        public required string Name { get; init; }
        public required double ValueAddedTaxPercent { get; init; }
        public required double CommercialIndustrialTaxPercent { get; init; }
        public required double SelfEmploymentTaxPercent { get; init; }
    }
}
