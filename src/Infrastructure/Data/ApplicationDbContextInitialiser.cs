using Alkonof_Backend.Domain.Constants;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Bookings.Enum;
using Alkonof_Backend.Domain.Entities.Complains;
using Alkonof_Backend.Domain.Entities.Complains.Enum;
using Alkonof_Backend.Domain.Entities.Contracts;
using Alkonof_Backend.Domain.Entities.Contracts.Enum;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Identity.Enum;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Entities.Meetings.Enum;
using Alkonof_Backend.Domain.Entities.Notifications;
using Alkonof_Backend.Domain.Entities.Notifications.Enum;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;
using Alkonof_Backend.Domain.Entities.Schedualing;
using Alkonof_Backend.Domain.Enums;
using Alkonof_Backend.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Alkonof_Backend.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();

    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            //await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            
            await TrySeedAsync();

            //await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {

        // Fetch required users and services once
        var admin = await _context.User.FirstOrDefaultAsync(u => u.Role == UserRole.Admin);
        var responsible = await _context.User.FirstOrDefaultAsync(u => u.Role == UserRole.Responsible);
        var customer1 = await _context.User.FirstOrDefaultAsync(u => u.Role == UserRole.Customer);
        var customer2 = await _context.User.Skip(1).FirstOrDefaultAsync(u => u.Role == UserRole.Customer);
        var customer3 = await _context.User.Skip(2).FirstOrDefaultAsync(u => u.Role == UserRole.Customer);


        if (!_context.Service.Any())
        {
            _context.Service.Add(Service.Create(
                "Service 1",
                "Description for service 1",
                ServiceType.Informaticse
            ));
            _context.Service.Add(Service.Create(
                "Service 2",
                "Description for service 2",
                ServiceType.Civial
            ));
            _context.Service.Add(Service.Create(
                "Service 3",
                "Description for service 3",
                ServiceType.Decor
            ));
            await _context.SaveChangesAsync();
        }
        var decorService = await _context.Service.FirstOrDefaultAsync(s => s.ServiceType == ServiceType.Decor);
        var civilService = await _context.Service.FirstOrDefaultAsync(s => s.ServiceType == ServiceType.Civial);
        var informaticseService = await _context.Service.FirstOrDefaultAsync(s => s.ServiceType == ServiceType.Informaticse);
        
        if (admin == null || responsible == null || customer1 == null || customer2 == null || customer3 == null || decorService == null || civilService == null || informaticseService == null)
        {
            _logger.LogError("Seeding failed: Not all required base users or services were found.");
            return;
        }

        // Seed Bookings
        if (!_context.Booking.Any())
        {
            // Scenario 1: New Booking in Review
            var orderBooking1 = OrderBooking.CreateOrderBooking(customer1.Id, decorService.Id);
            _context.OrderBooking.Add(orderBooking1);
            var booking1 = Booking.CreateBooking("New Interior Design Consultation",
                customer1.Id,
                responsible.Id,
                DateTimeOffset.Now,
                Decision.Pending,
                Decision.Pending,
                BookingStatus.InReviewCustomer
                );
            _context.Booking.Add(booking1);

            // Scenario 2: Confirmed Booking
            var orderBooking2 = OrderBooking.CreateOrderBooking(customer2.Id, civilService.Id);
            _context.OrderBooking.Add(orderBooking2);

            var booking2 = Booking.CreateBooking("Civil Works Initial Meeting",
                customer2.Id,
                responsible.Id,
                DateTimeOffset.Now,
                Decision.Approved,
                Decision.Approved,
                BookingStatus.Confirmed);
            _context.Booking.Add(booking2);

            // Scenario 5: Cancelled Booking
            var orderBooking3 = OrderBooking.CreateOrderBooking(customer3.Id, informaticseService.Id);
            _context.OrderBooking.Add(orderBooking3);

            var booking3 = Booking.CreateBooking("Cancelled IT Consultation",
                customer3.Id,
                responsible.Id,
                DateTimeOffset.Now,
                Decision.Rejected,
                Decision.Approved,
                BookingStatus.Cancelled);
            _context.Booking.Add(booking3);

            await _context.SaveChangesAsync();
        }

        // Seed Meetings
        if (!_context.Meeting.Any())
        {
            var confirmedBooking = await _context.Booking.FirstOrDefaultAsync(b => b.Title == "Civil Works Initial Meeting");
            if (confirmedBooking != null)
            {
                // Scenario 2 (cont.): Successful Meeting
                var meeting1 = Meeting.CreateMeeting(
                    "Discuss Civil Works",
                    "Project Kick-off",
                    1,
                    MeetingStatus.Completed,
                    MeetingUserStatus.Attended,
                    MeetingUserStatus.Attended,
                    MeetingOutCome.NeededAnotherMeeting);
                _context.Meeting.Add(meeting1);

                var meeting2 = Meeting.CreateMeeting(
                    "Discuss Civil Works",
                    "Project Kick-off",
                    1,
                    MeetingStatus.Completed,
                    MeetingUserStatus.Attended,
                    MeetingUserStatus.Attended,
                    MeetingOutCome.AgreementReched);

                _context.Meeting.Add(meeting2);

                var prepareMeeting1 = PrepareMeeting.CreatePrepareMeeting(
                    "Alkonof Office, Riyadh",
                    DateTimeOffset.Now.AddDays(-10),
                    DateTimeOffset.Now.AddDays(-10).AddHours(1),
                    confirmedBooking.Id,
                    meeting1.Id);
                var prepareMeeting2 = PrepareMeeting.CreatePrepareMeeting(
                    "Alkonof Office, Riyadh",
                    DateTimeOffset.Now.AddDays(-1),
                    DateTimeOffset.Now.AddDays(-1).AddHours(1),
                    confirmedBooking.Id,
                    meeting2.Id);

                _context.PrepareMeeting.Add(prepareMeeting1);
                _context.PrepareMeeting.Add(prepareMeeting2);
                await _context.SaveChangesAsync();
            }
        }

        // Seed Projects, Contracts, and Staff
        if (!_context.Project.Any())
        {
            // Scenario 3: Project In Progress
            var projectInProgress = Project.CreateProject("Riyadh Villa Construction", "Full construction of a 4-bedroom villa.", "Riyadh", null, 40, ProjectStatus.InProgress);
            _context.Project.Add(projectInProgress);
            
            // Scenario 4: Completed Project
            var projectCompleted = Project.CreateProject("Jeddah Office IT Setup", "Full IT infrastructure setup for a new office.", "Jeddah", null, 100, ProjectStatus.Completed);
            _context.Project.Add(projectCompleted);
            await _context.SaveChangesAsync();

            // Contracts
            var confirmedBooking = await _context.Booking.FirstOrDefaultAsync(b => b.Title == "Civil Works Initial Meeting");
            var contractInProgress = Contract.CreateContract(DateTimeOffset.Now.AddDays(-9), DateTimeOffset.Now.AddMonths(12), "riyadh_villa_contract.pdf", ProjectType.Field, ContractStatus.OnWorking, projectInProgress.Id);
            _context.Contract.Add(contractInProgress);
            if (confirmedBooking != null)
            {
                confirmedBooking.GetType().GetProperty("ContractId")?.SetValue(confirmedBooking, contractInProgress.Id);
            }
            var contractCompleted = Contract.CreateContract(DateTimeOffset.Now.AddMonths(-8), DateTimeOffset.Now.AddMonths(-2), "jeddah_it_contract.pdf", ProjectType.Advisory, ContractStatus.Archeved, projectCompleted.Id);
            _context.Contract.Add(contractCompleted);

            // Project Staff
            var projectStaff = ProjectStaff.CreateProjectStaff(projectInProgress.Id, responsible.Id);
            _context.ProjectStaff.Add(projectStaff);

            await _context.SaveChangesAsync();
        }

        // Seed Stages, Tasks, and Images
        if (!_context.Stage.Any())
        {
            var projectInProgress = await _context.Project.FirstOrDefaultAsync(p => p.Description == "Riyadh Villa Construction");
            var projectCompleted = await _context.Project.FirstOrDefaultAsync(p => p.Description == "Jeddah Office IT Setup");

            if (projectInProgress != null && projectCompleted != null)
            {
                // Scenario 3 (cont.): Stages for In-Progress Project
                var stageFoundation = Stage.CreateStage("Foundation Works", "Excavation and foundation laying.", 25, DateTimeOffset.Now.AddDays(-8), DateTimeOffset.Now.AddMonths(1), projectInProgress.Id, StageStatus.Completed);
                var stageStructure = Stage.CreateStage("Structural Framework", "Building the main structure.", 50, DateTimeOffset.Now.AddMonths(1), DateTimeOffset.Now.AddMonths(3), projectInProgress.Id, StageStatus.InProgress);
                _context.Stage.AddRange(stageFoundation, stageStructure);

                // Scenario 4 (cont.): Stage for Completed Project
                var stageNetwork = Stage.CreateStage("Network & Cabling", "All network infrastructure.", 100, DateTimeOffset.Now.AddMonths(-7), DateTimeOffset.Now.AddMonths(-6), projectCompleted.Id, StageStatus.Completed);
                _context.Stage.Add(stageNetwork);
                await _context.SaveChangesAsync();

                // Tasks and Images
                _context.TaskTabel.Add(TaskTabel.CreateTask("Erect steel columns", "Install main steel frame.", DateTimeOffset.Now.AddMonths(1), DateTimeOffset.Now.AddMonths(2), 20, stageStructure.Id, PriorityLevel.High));
                _context.StageImage.Add(StageImage.CreateStageImage("foundation.jpg", "/images/foundation.jpg", "Foundation complete.", stageFoundation.Id));
                await _context.SaveChangesAsync();
            }
        }

        // Seed Complaints and Resolutions
        if (!_context.Complain.Any())
        {
            var completedProject = await _context.Project.FirstOrDefaultAsync(p => p.Description == "Jeddah Office IT Setup");

            // Scenario 1 (cont.): New Complaint
            var complainNew = Complain.Create(ComplainStatus.UnReaded, "Delayed Response", ReferenceType.Booking, "No one has contacted me about my booking.", customer1.Id);
            _context.Complain.Add(complainNew);

            // Scenario 4 (cont.): Resolved Complaint
            if (completedProject != null)
            {
                var complainResolved = Complain.Create(ComplainStatus.Resolved, "Wrong Server Specs", ReferenceType.Project,
                    "The installed server does not match the specs.", customer1.Id);
                _context.Complain.Add(complainResolved);
                await _context.SaveChangesAsync();

                _context.Resolution.Add(Resolution.Create(complainResolved.Id, "Server was replaced with the correct model. Customer confirmed satisfaction."));
                await _context.SaveChangesAsync();
            }
        }

        // Seed Notifications
        if (!_context.Notification.Any())
        {
            var newComplain = await _context.Complain.FirstOrDefaultAsync(c => c.Subject == "Delayed Response");
            if (newComplain != null)
            {
                // Scenario 1 (cont.): Notification for New Complaint
                var template = new NotificationTemplet(Guid.NewGuid(), "New Complaint Received", "A new complaint has been filed by a customer.", true, ReferenceType.Complain, newComplain.Id);
                _context.NotificationTemplet.Add(template);
                var notification = Notification.Create(admin.Id, template.Id, NotificationStatus.unRead, ReferenceType.Complain, newComplain.Id, false);
                _context.Notification.Add(notification);
                await _context.SaveChangesAsync();
            }
        }

        // Seed Project Reports
        if (!_context.ProjectReport.Any())
        {
            var projectInProgress = await _context.Project.FirstOrDefaultAsync(p => p.Description == "Riyadh Villa Construction");
            var projectCompleted = await _context.Project.FirstOrDefaultAsync(p => p.Description == "Jeddah Office IT Setup");

            if (projectInProgress != null)
                _context.ProjectReport.Add(ProjectReport.CreateProjectReport(projectInProgress.Id, ReportType.Weekly, "Week 4 Progress", "Foundation completed. Structural work beginning."));
            
            if (projectCompleted != null)
                _context.ProjectReport.Add(ProjectReport.CreateProjectReport(projectCompleted.Id, ReportType.General, "Project Completion Report", "Project delivered successfully and signed off by client."));
            
            await _context.SaveChangesAsync();
        }

        // Seed TimeTable
        if (!_context.TimeTable.Any())
        {
            // Scenario 5 (cont.): Staff Scheduling
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 8, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 9, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 10, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 11, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 12, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 13, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 14, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 15, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Friday, 16, false, responsible.Id));
            // ..
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 8, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 9, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 10, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 11, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 12, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 13, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 14, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 15, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Saturday, 16, false, responsible.Id));
            // ..
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 8, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 9, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 10, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 11, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 12, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 13, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 14, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 15, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Sunday, 16, false, responsible.Id));
            // ..
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 8, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 9, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 10, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 11, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 12, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 13, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 14, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 15, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Monday, 16, false, responsible.Id));
            // ..
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 8, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 9, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 10, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 11, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 12, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 13, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 14, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 15, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Tuesday, 16, false, responsible.Id));
            // ..
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 8, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 9, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 10, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 11, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 12, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 13, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 14, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 15, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Wednesday, 16, false, responsible.Id));
            // ..
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 8, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 9, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 10, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 11, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 12, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 13, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 14, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 15, false, responsible.Id));
            _context.TimeTable.Add(TimeTable.CreateSchedual(DayOfWeek.Thursday, 16, false, responsible.Id));
            // ..


            await _context.SaveChangesAsync();
        }
    }
}
