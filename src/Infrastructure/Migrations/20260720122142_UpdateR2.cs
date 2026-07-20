using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateR2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReport_Stage_StageId",
                table: "ProjectReport");

            migrationBuilder.RenameColumn(
                name: "StageId",
                table: "ProjectReport",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectReport_StageId",
                table: "ProjectReport",
                newName: "IX_ProjectReport_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReport_Project_ProjectId",
                table: "ProjectReport",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReport_Project_ProjectId",
                table: "ProjectReport");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectReport",
                newName: "StageId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectReport_ProjectId",
                table: "ProjectReport",
                newName: "IX_ProjectReport_StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReport_Stage_StageId",
                table: "ProjectReport",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
