using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Contracts.Enum;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;

namespace Alkonof_Backend.Domain.Entities.Contracts;

public class Contract : BaseAuditableEntity
{
    private Contract()
    {
        
    }
    private Contract(Guid id ,DateTimeOffset date, string pathImage, ProjectType type, Guid projectId)
    {
        Id = id;
        Date = date;
        PathImage = pathImage;
        Type = type;
        ProjectId = projectId;
    }

    public DateTimeOffset Date {  get; private set; }
    public string PathImage {  get; private set; } = string.Empty;
    public ProjectType Type { get; private set; } = ProjectType.Non;
    public ContractStatus Status { get; set; } = ContractStatus.Non;

    //Relatinal
    public Booking? Booking { get; private set; }
    public Project? Project { get; private set; }
    public Guid? ProjectId { get; private set; }
   

}
