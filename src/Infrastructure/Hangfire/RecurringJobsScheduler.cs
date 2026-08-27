using Alkonof_Backend.Application.Modulers.Bookings.Book.Commands.AutoApproveResponsibleBookings;
using Alkonof_Backend.Application.Modulers.Scheduling.Commands.RestartTimeTable;
using Alkonof_Backend.Domain.Entities.Bookings;
using Hangfire;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Alkonof_Backend.Infrastructure.Hangfire;

public static class RecurringJobsScheduler
{
    public static void ScheduleJobs(IServiceProvider services)
    {
        var recurringJobManager = services.GetRequiredService<IRecurringJobManager>();

        // Schedule the job to restart the timetable every Friday.

        recurringJobManager.AddOrUpdate<ISender>(
        "restart-timetable-job",
        sender => sender.Send(new RestartTimeTableCommand()),
        "0 0 * * 5",
        new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.Utc
        });

        // Schedule the job to check for overdue bookings every 5 minutes.
        recurringJobManager.AddOrUpdate<ISender>(
            "escalate-overdue-bookings-job",
            sender => sender.Send(new AutoApproveResponsibleBookingsCommand()),
            "*/5 * * * *"); // Runs every 5 minutes
    }
}
