using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_PermissionGrop_PermissionGropId",
                table: "UserPermission");

            migrationBuilder.DropIndex(
                name: "IX_UserPermission_PermissionGropId",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "PermissionGropId",
                table: "UserPermission");

            migrationBuilder.CreateTable(
                name: "ProjectReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectReport_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReport_StageId",
                table: "ProjectReport",
                column: "StageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectReport");

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionGropId",
                table: "UserPermission",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionGropId",
                table: "UserPermission",
                column: "PermissionGropId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_PermissionGrop_PermissionGropId",
                table: "UserPermission",
                column: "PermissionGropId",
                principalTable: "PermissionGrop",
                principalColumn: "Id");
        }
    }
}
