using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

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
    public string Title { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;    
    public DateTimeOffset ExpiredAt {  get; private set; }
    public Decision CustomerAnser {  get; private set; }
    public Decision ResponsiplAnser {  get; private set; }


    //relationals
    public Contract? Contract { get; private set; }
    public Guid? ContractId { get; private set; }
    public User? Customer { get; private set; }
    public Guid CustomerId { get; private set; }
    public User? Responsibal { get; private set; }
    public Guid ResponsibalId { get; private set; }
    public List<PrepareMeeting> PrepareMeetings { get; private set; } = new List<PrepareMeeting>();

    public enum BokingStatus
    {
        UnCreated=0,
        InReviewCustomer=1,
        InReviewResponsibal=2,
        Confirmed=3,
        Cancelled=4,
        Expired=5,
        Delied=6
    }
    public enum Decision
    {
        Approved=0,
        Rejected=1,
        Pending=2,
        Dely=3
    }

}
