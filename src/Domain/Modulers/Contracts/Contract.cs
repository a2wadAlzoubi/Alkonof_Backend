using System.ComponentModel.DataAnnotations;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Contracts.Enum;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using Alkonof_Backend.Domain.Modulers.Contracts.Events;

namespace Alkonof_Backend.Domain.Entities.Contracts;

public class Contract : BaseAuditableEntity
{
    private Contract()
    {
        
    }
    private Contract(Guid id ,DateTimeOffset starteddate,DateTimeOffset endedDate, string pathImage, ProjectType type , ContractStatus status, Guid projectId)
    {
        Id = id;
        StartedDate = starteddate;
        EndedDate = endedDate;
        PathImage = pathImage;
        ProjectType = type;
        Status = status;
        ProjectId = projectId;
    }

    
    [Required]
    public DateTimeOffset StartedDate {  get; private set; }
    public DateTimeOffset? EndedDate {  get; private set; }
    [Required]
    public string PathImage {  get; private set; } = string.Empty;
    [Required]
    public ProjectType ProjectType { get; private set; } = ProjectType.Non;
    [Required]
    public ContractStatus Status { get; set; } = ContractStatus.Non;

    //Relatinal
    public Booking? Booking { get; private set; }
    public Project? Project { get; private set; }
    public Guid? ProjectId { get; private set; }
   
    public static Contract CreateContract(DateTimeOffset starteddate, DateTimeOffset endedDate, string pathImage, ProjectType type, ContractStatus status , Guid projectId)
    {
        Guid id = Guid.NewGuid();
        var contract = new Contract(id, starteddate, endedDate, pathImage, type,status , projectId);

        contract.AddDomainEvent(new ChangedProjectTypeEvent(id, type));
        contract.AddDomainEvent(new ChangedContractStatusEvent(id, status));
        return contract;
    }
    public void UpdateContract(Guid id , DateTimeOffset starteddate, DateTimeOffset endedDate, string pathImage, ProjectType type, ContractStatus status , Guid projectId)
    {
        bool IsU1 = false;
        bool IsU2 = false;
        StartedDate = starteddate;
        EndedDate = endedDate;
        PathImage = pathImage;
        ProjectId = projectId;
        if(ProjectType != type)
        {
            ProjectType = type;
            IsU1 = true;
        }
        if(Status != status)
        {
            Status = status;
            IsU2 = true;
        }
        if(IsU1)
            AddDomainEvent(new ChangedProjectTypeEvent(id, type));

        if(IsU2)
            AddDomainEvent(new ChangedContractStatusEvent(id, status));

    }
    public void ChangeContractStatus(Guid id ,ContractStatus status)
    {
        Status = status;
        AddDomainEvent(new ChangedContractStatusEvent(id, status));
    }
    public void ChangeProjectType(Guid id ,ProjectType type)
    {
        ProjectType = type;
        AddDomainEvent(new ChangedProjectTypeEvent(id , type));
    }
}
