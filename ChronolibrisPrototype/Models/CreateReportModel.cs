namespace ChronolibrisWeb.Models
{
    public record CreateReportModel(long TargetId, long TargetTypeId, 
        long ReasonTypeId, string Description);

}
