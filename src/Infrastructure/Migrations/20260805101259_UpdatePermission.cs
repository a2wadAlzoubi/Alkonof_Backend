using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderBooking_BookingType_BookingTypeId",
                table: "OrderBooking");

            migrationBuilder.DropTable(
                name: "BookingType");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PermissionGrop");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PermissionGrop");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Permission");

            migrationBuilder.RenameColumn(
                name: "BookingTypeId",
                table: "OrderBooking",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderBooking_BookingTypeId",
                table: "OrderBooking",
                newName: "IX_OrderBooking_ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "OperationPermission",
                table: "PermissionGrop",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PermissionType",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "PermissionType" },
                values: new object[,]
                {
                    { new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5"), null, null, null, null, 0 },
                    { new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a"), null, null, null, null, 2 },
                    { new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b"), null, null, null, null, 1 },
                    { new Guid("a9b8c7d6-e5f4-4b3c-8a7b-6f5e4d3c2b1a"), null, null, null, null, 4 },
                    { new Guid("d1e2f3a4-b5c6-4b7d-8e9f-6f5e4d3c2b1a"), null, null, null, null, 5 },
                    { new Guid("f4d3e2c1-b0a9-4b8c-9a7b-6f5e4d3c2b1a"), null, null, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "PermissionGrop",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "OperationPermission", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("0705cb83-4823-4e6e-a941-0eb415d3a63e"), null, null, null, null, 11, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("0f300faf-8566-46ff-b133-b6df5fa6b43e"), null, null, null, null, 3, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("1fd63afb-1a6d-4b51-9c05-9fddad3f7fab"), null, null, null, null, 6, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("2d5e23a3-d3c8-4dc0-bb50-348420ad3ec2"), null, null, null, null, 12, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("3ced91e6-7da0-4950-be05-e717b30c3f55"), null, null, null, null, 1, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("3d195dfa-b662-4115-9bad-f57d715e1158"), null, null, null, null, 0, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("46ce4f98-284c-4380-ad9a-b740071fa4e3"), null, null, null, null, 10, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("4bf1213b-6a3c-4a7b-82b3-cc13cc87c042"), null, null, null, null, 7, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("77b92655-b8e3-4907-9d68-84af423d489d"), null, null, null, null, 8, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("c1a2e273-8025-4495-87ae-7636b8876bab"), null, null, null, null, 9, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("c3f1a07a-c3c5-4662-b953-45ffa98643d0"), null, null, null, null, 2, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("c6f4b527-82d6-48c5-ab06-766e05e2e613"), null, null, null, null, 5, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("cf7a60fe-5421-4d05-9580-eddd4fa25be8"), null, null, null, null, 4, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBooking_Service_ServiceId",
                table: "OrderBooking",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderBooking_Service_ServiceId",
                table: "OrderBooking");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("a9b8c7d6-e5f4-4b3c-8a7b-6f5e4d3c2b1a"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4b7d-8e9f-6f5e4d3c2b1a"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f4d3e2c1-b0a9-4b8c-9a7b-6f5e4d3c2b1a"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("0705cb83-4823-4e6e-a941-0eb415d3a63e"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("0f300faf-8566-46ff-b133-b6df5fa6b43e"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("1fd63afb-1a6d-4b51-9c05-9fddad3f7fab"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("2d5e23a3-d3c8-4dc0-bb50-348420ad3ec2"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("3ced91e6-7da0-4950-be05-e717b30c3f55"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("3d195dfa-b662-4115-9bad-f57d715e1158"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("46ce4f98-284c-4380-ad9a-b740071fa4e3"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("4bf1213b-6a3c-4a7b-82b3-cc13cc87c042"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("77b92655-b8e3-4907-9d68-84af423d489d"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c1a2e273-8025-4495-87ae-7636b8876bab"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c3f1a07a-c3c5-4662-b953-45ffa98643d0"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c6f4b527-82d6-48c5-ab06-766e05e2e613"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("cf7a60fe-5421-4d05-9580-eddd4fa25be8"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5"));

            migrationBuilder.DropColumn(
                name: "OperationPermission",
                table: "PermissionGrop");

            migrationBuilder.DropColumn(
                name: "PermissionType",
                table: "Permission");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "OrderBooking",
                newName: "BookingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderBooking_ServiceId",
                table: "OrderBooking",
                newName: "IX_OrderBooking_BookingTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PermissionGrop",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PermissionGrop",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Permission",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Permission",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BookingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderBooking_BookingType_BookingTypeId",
                table: "OrderBooking",
                column: "BookingTypeId",
                principalTable: "BookingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
