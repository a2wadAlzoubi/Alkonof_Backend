using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Entities.Contracts;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Modulers.Bookings.Events.BookingStatusWorkflow;
using Alkonof_Backend.Domain.Modulers.Bookings.Events.CustomerBooking;
using Alkonof_Backend.Domain.Modulers.Bookings.Events.ResponsibleBooking;

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
        BookingStatus status = BookingStatus.UnCreated,
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




    public BookingStatus Status { get; private set; } = BookingStatus.UnCreated;
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
        BookingStatus status = BookingStatus.UnCreated,
        Guid? contractId = null
        )
    {
        var booking = new Booking(
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

        booking.AddDomainEvent(new CreateBookingEvent(booking.Id , customerId , responsibleId , expiredAt));
        return booking;
    }
    public void UpdateBooking(
        string title,
        string location,
        DateTimeOffset expiredAt,
        Guid customerId,
        Guid responsibleId,
        Decision customerAnser = Decision.Pending,
        Decision responsiplAnser = Decision.Pending,
        BookingStatus status = BookingStatus.UnCreated,
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
    public void AssignResposibleAnswer(Decision decision , Guid bookingId , Guid responsibleId)
    {
        ResponsibleAnswer = decision;
        AddDomainEvent(new AssignResponsibleAnswerEvent(bookingId , responsibleId , decision));
    }
    public void AssignCustomerAnswer(Decision decision , Guid bookingId, Guid customerId)
    {
        ResponsibleAnswer = decision;
        AddDomainEvent(new AssignCustomerAnswerEvent(bookingId,customerId , decision));
    }

    // Booking Status
    public void CancellBooking(Guid bookingId)
    {
        Status = BookingStatus.Cancelled;
        AddDomainEvent(new CancellBookingEvent(bookingId));

    }
    public void ExpireBooking(Guid bookingId)
    {
        Status = BookingStatus.Expired;
        AddDomainEvent(new ExpiredBookingEvent(bookingId));

    }
    public void ConfirmeBookingStatus(Guid bookingId , Guid customerId , Guid responsibleId)
    {
        Status = BookingStatus.Confirmed;
        AddDomainEvent(new ConfirmBookingEvent(bookingId , customerId , responsibleId));

    }
    public void DelayBookingStatus(Guid bookingId)
    {
        Status = BookingStatus.Delaied;
        AddDomainEvent(new DelayBookingEvent(bookingId));
    }
    public void InReviewResponsibleBookingStatus(Guid bookingId , Guid responsibleId)
    {
        Status = BookingStatus.InReviewResponsible;
        AddDomainEvent(new InReviewResponsibleBookingEvent(bookingId , responsibleId));
    }
    public void InReviewCustomerBookingStatus(Guid bookingId , Guid customerId)
    {
        Status = BookingStatus.InReviewCustomer;
        AddDomainEvent(new InReviewCustomerBookingEvent(bookingId , customerId));
    }
    
    // Customer Answer
    public void  CustomerApproveAnswer(Guid bookingId , Guid customerId)
    {
        ResponsibleAnswer = Decision.Approved;
        AddDomainEvent(new CustomerApproveEvent(bookingId , customerId));
    }
    public void  CustomerRejectAnswer(Guid bookingId, Guid customerId)
    {
        ResponsibleAnswer = Decision.Rejected;
        AddDomainEvent(new CustomerRejectEvent(bookingId,customerId));
    }
    public void  CustomerDelayAnswer(Guid bookingId, Guid customerId)
    {
        ResponsibleAnswer = Decision.Delay;
        AddDomainEvent(new CustomerDelayEvent(bookingId,customerId));
    }
    public void  CustomerPendingAnswer(Guid bookingId, Guid customerId)
    {
        ResponsibleAnswer = Decision.Pending;
        AddDomainEvent(new CustomerPendingEvent(bookingId, customerId));
    }

    //Responsible Answer
    public void  ResponsibleApproveAnswer(Guid bookingId, Guid responsibleId)
    {
        ResponsibleAnswer = Decision.Approved;
        AddDomainEvent(new ResponsibleApproveEvent(bookingId,responsibleId));
    }
    public void ResponsibleRejectAnswer(Guid bookingId, Guid responsibleId)
    {
        ResponsibleAnswer = Decision.Rejected;
        AddDomainEvent(new ResponsibleRejectEvent(bookingId, responsibleId));
    }
    public void ResponsibleDelayAnswer(Guid bookingId, Guid responsibleId)
    {
        ResponsibleAnswer = Decision.Delay;
        AddDomainEvent(new ResponsibleDelayEvent(bookingId , responsibleId));
    }
    public void ResponsiblePendingAnswer(Guid bookingId, Guid responsibleId)
    {
        ResponsibleAnswer = Decision.Pending;
        AddDomainEvent(new ResponsiblePendingEvent(bookingId, responsibleId));
    }
    
    

}


