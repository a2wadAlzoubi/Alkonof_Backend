using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditChange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditChange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutCome = table.Column<int>(type: "int", nullable: false),
                    MeetingNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ResponsibleStatus = table.Column<int>(type: "int", nullable: false),
                    CustomerStatus = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyTemplate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resolution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResolutionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Colour_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGrop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationPermission = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGrop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionGrop_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<int>(type: "int", nullable: true),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectReport_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ActualEndedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    ListId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId1",
                        column: x => x.ListId1,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    ReferenceType = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditChangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditEntity_AuditChange_AuditChangeId",
                        column: x => x.AuditChangeId,
                        principalTable: "AuditChange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditEntity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complain_Resolution_ResolutionId",
                        column: x => x.ResolutionId,
                        principalTable: "Resolution",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Complain_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReferenceType = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TempletId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_NotificationTemplet_TempletId",
                        column: x => x.TempletId,
                        principalTable: "NotificationTemplet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBooking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderBooking_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBooking_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStaff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectStaff_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectStaff_User_ResponsibalId",
                        column: x => x.ResponsibalId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expired = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserSecurityHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    ResponsibleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTable_User_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CustomerAnswer = table.Column<int>(type: "int", nullable: false),
                    ResponsibleAnswer = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StageImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageImage_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskTabel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    StartedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ActualEndedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskTabel_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrepareMeeting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    StartedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepareMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrepareMeeting_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrepareMeeting_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "PermissionType" },
                values: new object[,]
                {
                    { new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5"), null, null, null, null, 0 },
                    { new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a"), null, null, null, null, 2 },
                    { new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b"), null, null, null, null, 1 },
                    { new Guid("a9b8c7d6-e5f4-4b3c-8a7b-6f5e4d3c2b1a"), null, null, null, null, 4 },
                    { new Guid("f4d3e2c1-b0a9-4b8c-9a7b-6f5e4d3c2b1a"), null, null, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Number", "Password", "PermissionId", "Role", "Specialization" },
                values: new object[,]
                {
                    { new Guid("1a7e5c9d-3f21-1596-9c42-7d15e8e36903"), null, null, "ahmad2@gmail.com", false, null, null, "Ahmad2", "0986123456", "E9230CF95C159AD83A0E7AFAF1A23B0496A5C59FB2D2ACF7D9077A5C0EEE2713", null, 2, null },
                    { new Guid("1a7e5c9d-3f21-4b86-7e5c-7d15e8a6b903"), null, null, "ahmad3@gmail.com", false, null, null, "Ahmad3", "0986123456", "E9230CF95C159AD83A0E7AFAF1A23B0496A5C59FB2D2ACF7D9077A5C0EEE2713", null, 2, 0 },
                    { new Guid("1a7e5c9d-3f21-4b86-9c42-7d15e8a6b903"), null, null, "ahmad@gmail.com", false, null, null, "Ahmad", "0986123456", "E9230CF95C159AD83A0E7AFAF1A23B0496A5C59FB2D2ACF7D9077A5C0EEE2713", null, 2, null },
                    { new Guid("5b92d714-8e36-4c1a-a057-29f6b83dc9d5"), null, null, "mohammad@gmail.com", false, null, null, "Mohammad", "0986234567", "E9230CF95C159AD83A0E7AFAF1A23B0496A5C59FB2D2ACF7D9077A5C0EEE2713", null, 1, 5 },
                    { new Guid("e4386f21-7c95-4a03-bd18-52a9e6073f64"), null, null, "omar@gmail.com", false, null, null, "Omar", "0986345678", "E9230CF95C159AD83A0E7AFAF1A23B0496A5C59FB2D2ACF7D9077A5C0EEE2713", null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "PermissionGrop",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "OperationPermission", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("19158457-bf01-41e0-96c2-d7bd560e407b"), null, null, null, null, 11, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("1fc41852-3f7e-4035-ab87-e9c32320ce96"), null, null, null, null, 7, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("205952a9-825c-4bf0-b39d-971a49c8625c"), null, null, null, null, 10, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("25344cb7-444a-40aa-9ead-34078ec3b35c"), null, null, null, null, 3, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("29a80149-bee2-4241-ac74-942711fd1ef0"), null, null, null, null, 5, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("3c33d2f9-3f1d-42b4-bf9f-e6ea8efd4db2"), null, null, null, null, 8, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("47602f3d-ae60-4926-a9fb-46fff9c6f816"), null, null, null, null, 6, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("50229d10-288d-4fbf-8852-873103b4cc03"), null, null, null, null, 1, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("552a1f29-c0d3-4bf1-a692-c19579bff7ed"), null, null, null, null, 2, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("6379ae4b-25bc-4d8c-86f5-aec40dcc3c7f"), null, null, null, null, 7, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("639821a1-59ec-445e-8960-e222d809d36b"), null, null, null, null, 2, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("851ad434-4b2b-4f19-b740-a3e61cebaabb"), null, null, null, null, 0, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("9152ca4c-0249-4379-8bac-d1cc34417400"), null, null, null, null, 0, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("94b669f9-5020-4a4b-9ded-0bc2c1802603"), null, null, null, null, 2, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("984c7dd3-8e51-4c6c-9429-b7695c0f18cb"), null, null, null, null, 3, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("a8bbcfeb-e1f6-4f8f-a705-a4c96bad8dbe"), null, null, null, null, 9, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("c636e38b-e86a-4520-b4b3-25ebe5c6a8d7"), null, null, null, null, 10, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("c683f79e-dd2a-4fe2-bde2-0434966c695f"), null, null, null, null, 1, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("d405c15e-b74d-4bef-bd34-216806ced1d8"), null, null, null, null, 0, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("debc86bd-7c19-42aa-95f9-1476b5e935c6"), null, null, null, null, 3, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("e35f3e48-cb42-432c-808f-ae4d09a01fa4"), null, null, null, null, 1, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("ffbf7ad2-40f3-4e65-a454-bfa20c1174ec"), null, null, null, null, 4, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Number", "Password", "PermissionId", "Role", "Specialization" },
                values: new object[] { new Guid("3bf312c6-681b-44b4-9637-1c7e60e2e932"), null, null, "awad@gmail.com", false, null, null, "Awad", "0986174521", "E9230CF95C159AD83A0E7AFAF1A23B0496A5C59FB2D2ACF7D9077A5C0EEE2713", new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5"), 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_AuditEntity_AuditChangeId",
                table: "AuditEntity",
                column: "AuditChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditEntity_UserId",
                table: "AuditEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ContractId",
                table: "Booking",
                column: "ContractId",
                unique: true,
                filter: "[ContractId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerId",
                table: "Booking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ResponsibleId",
                table: "Booking",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId1",
                table: "Booking",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Complain_CustomerId",
                table: "Complain",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Complain_ResolutionId",
                table: "Complain",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ProjectId",
                table: "Contract",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_TempletId",
                table: "Notification",
                column: "TempletId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooking_CustomerId",
                table: "OrderBooking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooking_ServiceId",
                table: "OrderBooking",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGrop_PermissionId",
                table: "PermissionGrop",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepareMeeting_BookingId",
                table: "PrepareMeeting",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepareMeeting_MeetingId",
                table: "PrepareMeeting",
                column: "MeetingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReport_ProjectId",
                table: "ProjectReport",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStaff_ProjectId",
                table: "ProjectStaff",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStaff_ResponsibalId",
                table: "ProjectStaff",
                column: "ResponsibalId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_ProjectId",
                table: "Stage",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StageImage_StageId",
                table: "StageImage",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTabel_StageId",
                table: "TaskTabel",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_ResponsibleId",
                table: "TimeTable",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId1",
                table: "TodoItems",
                column: "ListId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_PermissionId",
                table: "User",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditEntity");

            migrationBuilder.DropTable(
                name: "Complain");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OrderBooking");

            migrationBuilder.DropTable(
                name: "PermissionGrop");

            migrationBuilder.DropTable(
                name: "PrepareMeeting");

            migrationBuilder.DropTable(
                name: "ProjectReport");

            migrationBuilder.DropTable(
                name: "ProjectStaff");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "StageImage");

            migrationBuilder.DropTable(
                name: "TaskTabel");

            migrationBuilder.DropTable(
                name: "TimeTable");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "AuditChange");

            migrationBuilder.DropTable(
                name: "Resolution");

            migrationBuilder.DropTable(
                name: "NotificationTemplet");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Permission");
        }
    }
}
