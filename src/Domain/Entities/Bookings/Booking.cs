using System.ComponentModel.DataAnnotations;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Entities.Contracts;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Meetings;

namespace Alkonof_Backend.Domain.Entities.Bookings;

public class Booking : BaseAuditableEntity
{
    private Booking(
        Guid id,
        string title,
        string location,
        DateTimeOffset expiredAt,
        Guid customerId,
        Guid responsibleId,
        Decision customerAnser = Decision.Pending,
        Decision responsiplAnser = Decision.Pending,
        BokingStatus status = BokingStatus.UnCreated,
        Guid? contractId = null
        )
    {
        this.Id = id;
        this.Status = status;
        this.Title = title;
        this.Location = location;
        this.ExpiredAt = expiredAt;
        this.CustomerAnswer = customerAnser;
        this.ResponsibleAnswer = responsiplAnser;
        this.CustomerId = customerId;
        this.ResponsibleId = responsibleId;
        this.ContractId = contractId;
    }

    private Booking()
    {
        
    }




    public BokingStatus Status { get; private set; } = BokingStatus.UnCreated;
    [Required]
    public string Title { get; private set; } = string.Empty;
    [Required]
    public string Location { get; private set; } = string.Empty;    
    public DateTimeOffset ExpiredAt {  get; private set; }
    [Required]
    public Decision CustomerAnswer {  get; private set; } = Decision.Pending;
    [Required]
    public Decision ResponsibleAnswer {  get; private set; } = Decision.Pending;


    //relationals
    public Contract? Contract { get; private set; }
    public Guid? ContractId { get; private set; }
    public User? Customer { get; private set; }
    [Required]
    public Guid CustomerId { get; private set; }
    public User? Responsible { get; private set; }
    [Required]
    public Guid ResponsibleId { get; private set; }
    public List<PrepareMeeting> PrepareMeetings { get; private set; } = new List<PrepareMeeting>();

    public static Booking CreateBooking(
        string title,
        string location,
        DateTimeOffset expiredAt,
        Guid customerId,
        Guid responsibleId,
        Decision customerAnser = Decision.Pending,
        Decision responsiplAnser = Decision.Pending,
        BokingStatus status = BokingStatus.UnCreated,
        Guid? contractId = null
        )
    {
        return new Booking(
        Guid.NewGuid(),
        title,
        location,
        expiredAt,
        customerId,
        responsibleId,
        customerAnser,
        responsiplAnser,
        status,
        contractId);
    }
    public void UpdateBooking(
        string title,
        string location,
        DateTimeOffset expiredAt,
        Guid customerId,
        Guid responsibleId,
        Decision customerAnser = Decision.Pending,
        Decision responsiplAnser = Decision.Pending,
        BokingStatus status = BokingStatus.UnCreated,
        Guid? contractId = null)
    {
        this.Status = status;
        this.Title = title;
        this.Location = location;
        this.ExpiredAt = expiredAt;
        this.CustomerAnswer = customerAnser;
        this.ResponsibleAnswer = responsiplAnser;
        this.CustomerId = customerId;
        this.ResponsibleId = responsibleId;
        this.ContractId = contractId;
    }
    public void AssignResposibleAnswer(Decision decision)
    {
        ResponsibleAnswer = decision;
    }
    public void AssignCustomerAnswer(Decision decision)
    {
        CustomerAnswer = decision;
    }
    
    

}


