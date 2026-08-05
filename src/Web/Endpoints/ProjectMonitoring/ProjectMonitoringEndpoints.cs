using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangePriorityTask;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangeStageStatus;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateStage;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateStageImage;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateTask;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveStage;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveStageImage;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveTask;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.SetStageProgress;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateStage;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateStageImage;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateTask;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetProjectById;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetProjectByCustomerIdWithRelaited;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetResponsiblesByProjectId;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetReportByReportType;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStageById;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStageImagesByStageId;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesByProjectId;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesById;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetStagesByPriorityId;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetTasksById;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetTasksByStageId;
using Alkonof_Backend.Web.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Web.Endpoints.ProjectMonitoring;

public class ProjectMonitoringEndpoints : IEndpointGroup
{
    public static void Map(RouteGroupBuilder group)
    {
        group.WithTags("ProjectMonitoring");

        // Stage Commands
        group.MapPost("/stages", CreateStage)
            .WithName(nameof(CreateStage))
            .WithSummary("Create a new stage.");

        group.MapPut("/stages/{id:guid}", UpdateStage)
            .WithName(nameof(UpdateStage))
            .WithSummary("Update an existing stage.");

        group.MapDelete("/stages/{id:guid}", RemoveStage)
            .WithName(nameof(RemoveStage))
            .WithSummary("Remove a stage.");

        group.MapPatch("/stages/{id:guid}/status", ChangeStageStatus)
            .WithName(nameof(ChangeStageStatus))
            .WithSummary("Change stage status.");

        group.MapPatch("/stages/{id:guid}/progress", SetStageProgress)
            .WithName(nameof(SetStageProgress))
            .WithSummary("Set stage progress.");

        // StageImage Commands
        group.MapPost("/stage-images", CreateStageImage)
            .WithName(nameof(CreateStageImage))
            .WithSummary("Create a new stage image.");

        group.MapPut("/stage-images/{id:guid}", UpdateStageImage)
            .WithName(nameof(UpdateStageImage))
            .WithSummary("Update an existing stage image.");

        group.MapDelete("/stage-images/{id:guid}", RemoveStageImage)
            .WithName(nameof(RemoveStageImage))
            .WithSummary("Remove a stage image.");

        // Task Commands
        group.MapPost("/tasks", CreateTask)
            .WithName(nameof(CreateTask))
            .WithSummary("Create a new task.");

        group.MapPut("/tasks/{id:guid}", UpdateTask)
            .WithName(nameof(UpdateTask))
            .WithSummary("Update an existing task.");

        group.MapDelete("/tasks/{id:guid}", RemoveTask)
            .WithName(nameof(RemoveTask))
            .WithSummary("Remove a task.");

        group.MapPatch("/tasks/{id:guid}/priority", ChangePriorityTask)
            .WithName(nameof(ChangePriorityTask))
            .WithSummary("Change task priority.");

        // Queries
        group.MapGet("/projects/{id:guid}", GetProjectById)
            .WithName(nameof(GetProjectById))
            .WithSummary("Get a project by ID.");

        group.MapGet("/stages/{id:guid}", GetStageById)
            .WithName(nameof(GetStageById))
            .WithSummary("Get a stage by ID.");

        group.MapGet("/projects/{projectId:guid}/stages", GetStagesByProjectId)
            .WithName(nameof(GetStagesByProjectId))
            .WithSummary("Get all stages for a project.");

        group.MapGet("/projects/{projectId:guid}/responsibles", GetResponsiblesByProjectId)
            .WithName(nameof(GetResponsiblesByProjectId))
            .WithSummary("Get all responsibles for a project.");

        group.MapGet("/reports/{reportType}", GetReportByReportType)
            .WithName(nameof(GetReportByReportType))
            .WithSummary("Get reports by type.");

        group.MapGet("/stages-by-id/{id:guid}", GetStagesById)
            .WithName(nameof(GetStagesById))
            .WithSummary("Get stage by ID.");

        group.MapGet("/stages/priority/{priority}", GetStagesByPriorityId)
            .WithName(nameof(GetStagesByPriorityId))
            .WithSummary("Get tasks by priority.");

        group.MapGet("/stages/{stageId:guid}/tasks", GetTasksByStageId)
            .WithName(nameof(GetTasksByStageId))
            .WithSummary("Get all tasks for a stage.");

        group.MapGet("/tasks/{id:guid}", GetTasksById)
            .WithName(nameof(GetTasksById))
            .WithSummary("Get a task by ID.");

        group.MapGet("/stages/{stageId:guid}/images", GetStageImagesByStageId)
            .WithName(nameof(GetStageImagesByStageId))
            .WithSummary("Get all images for a stage.");

        group.MapGet("/customers/{customerId:guid}/projects", GetProjectByCustomerIdWithRelaited)
            .WithName(nameof(GetProjectByCustomerIdWithRelaited))
            .WithSummary("Get projects by customer ID with relations.");
    }

    // Stage Handlers
    private static async Task<Results<Ok<Guid>, BadRequest<string>>> CreateStage(ISender sender, CreateStageDto dto)
    {
        var id = await sender.Send(new CreateStageCommand(dto));
        return TypedResults.Ok(id);
    }

    private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdateStage(ISender sender, Guid id, UpdateStageDto dto)
    {
        await sender.Send(new UpdateStageCommand(dto));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> RemoveStage(ISender sender, Guid id)
    {
        await sender.Send(new RemoveStageCommand(id));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> ChangeStageStatus(ISender sender, Guid id, ChangeStageStatusDto dto)
    {
        await sender.Send(new ChangeStageStatusCommand(dto));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> SetStageProgress(ISender sender, Guid id, SetStageProgressDto dto)
    {
        await sender.Send(new SetStageProgressCommand(dto));
        return TypedResults.Ok();
    }

    // StageImage Handlers
    private static async Task<Results<Ok<Guid>, BadRequest<string>>> CreateStageImage(ISender sender, CreateStageImageDto dto)
    {
        var id = await sender.Send(new CreateStageImageCommand(dto));
        return TypedResults.Ok(id);
    }

    private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdateStageImage(ISender sender, Guid id, UpdateStageImageDto dto)
    {
        await sender.Send(new UpdateStageImageCommand(dto));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> RemoveStageImage(ISender sender, Guid id)
    {
        await sender.Send(new RemoveStageImageCommand(id));
        return TypedResults.Ok();
    }

    // Task Handlers
    private static async Task<Results<Ok<Guid>, BadRequest<string>>> CreateTask(ISender sender, CreateTaskDto dto)
    {
        var id = await sender.Send(new CreateTaskCommand(dto));
        return TypedResults.Ok(id);
    }

    private static async Task<Results<Ok, NotFound, BadRequest<string>>> UpdateTask(ISender sender, Guid id, UpdateTaskDto dto)
    {
        await sender.Send(new UpdateTaskCommand(dto));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> RemoveTask(ISender sender, Guid id)
    {
        await sender.Send(new RemoveTaskCommand(id));
        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> ChangePriorityTask(ISender sender, Guid id, ChangePriorityTaskDto dto)
    {
        await sender.Send(new ChangePriorityTaskCommand(dto));
        return TypedResults.Ok();
    }

    // Query Handlers
    private static async Task<Results<Ok<ProjectDto>, NotFound>> GetProjectById(ISender sender, Guid id)
    {
        var project = await sender.Send(new GetProjectByIdQuery(id));
        return project == null ? TypedResults.NotFound() : TypedResults.Ok(project);
    }

    private static async Task<Results<Ok<StageDto>, NotFound>> GetStageById(ISender sender, Guid id)
    {
        var stage = await sender.Send(new GetStageByIdQuery(id));
        return stage == null ? TypedResults.NotFound() : TypedResults.Ok(stage);
    }

    private static async Task<Ok<List<StageDto>>> GetStagesByProjectId(ISender sender, Guid projectId)
    {
        var stages = await sender.Send(new GetStagesByProjectIdQuery(projectId));
        return TypedResults.Ok(stages);
    }

    private static async Task<Ok<List<ProjectStaffDto>>> GetResponsiblesByProjectId(ISender sender, Guid projectId)
    {
        var responsibles = await sender.Send(new GetResponsiblesByProjectIdQuery(projectId));
        return TypedResults.Ok(responsibles);
    }

    private static async Task<Ok<List<ProjectReportDto>>> GetReportByReportType(ISender sender, string reportType)
    {
        var reports = await sender.Send(new GetReportByReportTypeQuery(reportType));
        return TypedResults.Ok(reports);
    }

    private static async Task<Results<Ok<StageDto>, NotFound>> GetStagesById(ISender sender, Guid id)
    {
        var stage = await sender.Send(new GetStagesByIdQuery(id));
        return stage == null ? TypedResults.NotFound() : TypedResults.Ok(stage);
    }

    private static async Task<Ok<List<TaskDto>>> GetStagesByPriorityId(ISender sender, int priority)
    {
        var tasks = await sender.Send(new GetStagesByPriorityIdQuery((PriorityLevel)priority));
        return TypedResults.Ok(tasks);
    }

    private static async Task<Ok<List<TaskDto>>> GetTasksByStageId(ISender sender, Guid stageId)
    {
        var tasks = await sender.Send(new GetTasksByStageIdQuery(stageId));
        return TypedResults.Ok(tasks);
    }

    private static async Task<Results<Ok<TaskDto>, NotFound>> GetTasksById(ISender sender, Guid id)
    {
        var task = await sender.Send(new GetTasksByIdQuery(id));
        return task == null ? TypedResults.NotFound() : TypedResults.Ok(task);
    }

    private static async Task<Ok<List<StageImageDto>>> GetStageImagesByStageId(ISender sender, Guid stageId)
    {
        var images = await sender.Send(new GetStageImagesByStageIdQuery(stageId));
        return TypedResults.Ok(images);
    }

    private static async Task<Ok<List<ProjectWithRelationsDto>>> GetProjectByCustomerIdWithRelaited(ISender sender, Guid customerId)
    {
        var projects = await sender.Send(new GetProjectByCustomerIdWithRelaitedQuery(customerId));
        return TypedResults.Ok(projects);
    }
}
