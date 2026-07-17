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
        BokingStatus status,
        string title,
        string location,
        DateTimeOffset expiredAt,
        Decision customerAnser,
        Decision responsiplAnser,
        Guid? contractId,
        Guid customerId,
        Guid responsibalId)
    {
        this.Id = id;
        this.Status = status;
        this.Title = title;
        this.Location = location;
        this.ExpiredAt = expiredAt;
        this.CustomerAnser = customerAnser;
        this.ResponsiplAnser = responsiplAnser;
        this.ContractId = contractId;
        this.CustomerId = customerId;
        this.ResponsibalId = responsibalId;
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
    public Decision CustomerAnser {  get; private set; }
    [Required]
    public Decision ResponsiplAnser {  get; private set; }


    //relationals
    public Contract? Contract { get; private set; }
    public Guid? ContractId { get; private set; }
    public User? Customer { get; private set; }
    [Required]
    public Guid CustomerId { get; private set; }
    public User? Responsibal { get; private set; }
    [Required]
    public Guid ResponsibalId { get; private set; }
    public List<PrepareMeeting> PrepareMeetings { get; private set; } = new List<PrepareMeeting>();




}
