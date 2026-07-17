using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "LastModified", "LastModifiedBy", "Name", "Number", "Password", "Role", "Status" },
                values: new object[] { new Guid("caf312c6-681b-44b4-9637-1c7e60ef7032"), null, null, "aa@gmail.com", null, null, "Awad", "0368146785", "Aaaa 11111", 2, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("caf312c6-681b-44b4-9637-1c7e60ef7032"));
        }
    }
}
