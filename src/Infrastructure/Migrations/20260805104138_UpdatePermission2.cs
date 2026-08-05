using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermission2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4b7d-8e9f-6f5e4d3c2b1a"));

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

            migrationBuilder.InsertData(
                table: "PermissionGrop",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "OperationPermission", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("018bcbbc-72e7-4c13-b3bd-3722ce7b73b0"), null, null, null, null, 10, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("1146ef4a-198d-4d2d-9bd2-37b7b0cfeda9"), null, null, null, null, 9, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("119d020d-2b8a-4548-9372-6b695c8f2109"), null, null, null, null, 0, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("1405431d-4889-4dc6-9030-7adb403bbcd7"), null, null, null, null, 4, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("14d6bdfc-4c47-455d-84da-3488d8f95534"), null, null, null, null, 5, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("1ff0b3b4-6736-46f9-b66a-f4e774102201"), null, null, null, null, 8, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("26e6d8c8-83d6-48e3-8ae9-a3485cb2f619"), null, null, null, null, 1, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("3fbf1e53-be00-47c4-adb7-becedcb1487d"), null, null, null, null, 2, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("47455b92-b0ec-4f5f-8d15-02d3d18b2ba8"), null, null, null, null, 2, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("5c181d55-726f-4ccd-b6b6-7e082d3e4c38"), null, null, null, null, 11, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("5ea92efc-2cad-4515-8de2-989b4c3aed25"), null, null, null, null, 7, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("62c17759-656a-42ec-becf-b1119f23abd1"), null, null, null, null, 10, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("6594b791-f7fb-472d-b4b3-cbcbe30d2077"), null, null, null, null, 6, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("6b9bc37d-66b8-4214-a9d2-17bbdb912d38"), null, null, null, null, 0, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("6ec9847b-2a5f-4c02-b3df-7dfe516bf725"), null, null, null, null, 3, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("7e6679cb-751e-4731-8a74-01f05e3d3d49"), null, null, null, null, 1, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("a8f5f45b-6828-4211-bdf5-2dbfb5fa40dc"), null, null, null, null, 7, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("c04306c1-65fc-43e7-b577-6a544815acf0"), null, null, null, null, 1, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("c29cd45b-adb4-4d35-9942-4f69317f72a4"), null, null, null, null, 3, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("c476b07e-f897-44f5-a95f-6a1fb21469fd"), null, null, null, null, 0, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("e37be2bb-d473-4af7-b8d5-0f40631e780e"), null, null, null, null, 3, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("fc4ad8ea-c558-422d-9079-3e3fb0805d9c"), null, null, null, null, 2, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("018bcbbc-72e7-4c13-b3bd-3722ce7b73b0"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("1146ef4a-198d-4d2d-9bd2-37b7b0cfeda9"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("119d020d-2b8a-4548-9372-6b695c8f2109"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("1405431d-4889-4dc6-9030-7adb403bbcd7"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("14d6bdfc-4c47-455d-84da-3488d8f95534"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("1ff0b3b4-6736-46f9-b66a-f4e774102201"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("26e6d8c8-83d6-48e3-8ae9-a3485cb2f619"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("3fbf1e53-be00-47c4-adb7-becedcb1487d"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("47455b92-b0ec-4f5f-8d15-02d3d18b2ba8"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("5c181d55-726f-4ccd-b6b6-7e082d3e4c38"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("5ea92efc-2cad-4515-8de2-989b4c3aed25"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("62c17759-656a-42ec-becf-b1119f23abd1"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("6594b791-f7fb-472d-b4b3-cbcbe30d2077"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("6b9bc37d-66b8-4214-a9d2-17bbdb912d38"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("6ec9847b-2a5f-4c02-b3df-7dfe516bf725"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("7e6679cb-751e-4731-8a74-01f05e3d3d49"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("a8f5f45b-6828-4211-bdf5-2dbfb5fa40dc"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c04306c1-65fc-43e7-b577-6a544815acf0"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c29cd45b-adb4-4d35-9942-4f69317f72a4"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c476b07e-f897-44f5-a95f-6a1fb21469fd"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("e37be2bb-d473-4af7-b8d5-0f40631e780e"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("fc4ad8ea-c558-422d-9079-3e3fb0805d9c"));

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "PermissionType" },
                values: new object[] { new Guid("d1e2f3a4-b5c6-4b7d-8e9f-6f5e4d3c2b1a"), null, null, null, null, 5 });

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
        }
    }
}
