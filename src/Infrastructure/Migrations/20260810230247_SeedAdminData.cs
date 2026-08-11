using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Complain");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Complain");

            migrationBuilder.AddColumn<Guid>(
                name: "ComplintId",
                table: "Resolution",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "PermissionGrop",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "OperationPermission", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("035215cd-def9-4eb1-8154-b90440e03ed0"), null, null, null, null, 11, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("07da9005-8c5a-42a0-a77a-76ef8c54b8dd"), null, null, null, null, 2, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("0b256676-95f2-4502-9ec0-7575e0596096"), null, null, null, null, 7, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("3769dbf1-ffff-4254-833a-21a5e9aaa9a1"), null, null, null, null, 10, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("3bce99f3-e328-4f75-bb78-9aeaa763fdc7"), null, null, null, null, 2, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("45486488-cbfb-445b-910a-b7a33ab9e082"), null, null, null, null, 7, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("47ea4e1a-7f7d-4db2-a43d-d4236d83efea"), null, null, null, null, 1, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("58dd6e2b-1c3d-42f0-b0e4-7442c4f290cc"), null, null, null, null, 10, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("64a3390b-9b6f-416c-946b-7c52feee6fa1"), null, null, null, null, 0, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("70110e97-aa5c-439b-8472-d0f0cfe1292a"), null, null, null, null, 0, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("78f4ffc1-9e2b-4823-ba27-4322cd874237"), null, null, null, null, 9, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("8b4068a0-5514-4e85-9fcf-fca958c852a9"), null, null, null, null, 1, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("8cd2e626-b4c3-4199-85b1-4c449c9270a2"), null, null, null, null, 5, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("9194218c-9520-4645-b54a-bd580a261024"), null, null, null, null, 6, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("93880cce-62a7-4fc3-b661-df8d2bef8e08"), null, null, null, null, 0, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("9cf6bbae-f4b5-4463-a71b-f6092d7bd08d"), null, null, null, null, 3, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("b2e56dc2-ebcd-4b72-8b60-cf6b18f6f25c"), null, null, null, null, 2, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("c5c0fb57-e57d-480e-aba3-d1735d724bf0"), null, null, null, null, 4, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("e3e358e2-2046-450c-b624-afaf5c73f593"), null, null, null, null, 8, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("e5827b2b-b78c-4c53-9c92-fcde058aeb62"), null, null, null, null, 3, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("fa8d3781-b92a-4e81-904e-90db754eb6ba"), null, null, null, null, 3, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("fd2da7fd-ceac-4285-9f72-3f9c807f9363"), null, null, null, null, 1, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Number", "Password", "PermissionId", "Role" },
                values: new object[] { new Guid("caf312c6-681b-44b4-9637-1c7e60ef7032"), null, null, "awad@gmail.com", false, null, null, "Awad", "0986174521", "E9230CF95C159AD83A0E7AFAF1A23B0496A5C59FB2D2ACF7D9077A5C0EEE2713", new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5"), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("035215cd-def9-4eb1-8154-b90440e03ed0"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("07da9005-8c5a-42a0-a77a-76ef8c54b8dd"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("0b256676-95f2-4502-9ec0-7575e0596096"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("3769dbf1-ffff-4254-833a-21a5e9aaa9a1"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("3bce99f3-e328-4f75-bb78-9aeaa763fdc7"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("45486488-cbfb-445b-910a-b7a33ab9e082"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("47ea4e1a-7f7d-4db2-a43d-d4236d83efea"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("58dd6e2b-1c3d-42f0-b0e4-7442c4f290cc"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("64a3390b-9b6f-416c-946b-7c52feee6fa1"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("70110e97-aa5c-439b-8472-d0f0cfe1292a"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("78f4ffc1-9e2b-4823-ba27-4322cd874237"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("8b4068a0-5514-4e85-9fcf-fca958c852a9"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("8cd2e626-b4c3-4199-85b1-4c449c9270a2"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("9194218c-9520-4645-b54a-bd580a261024"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("93880cce-62a7-4fc3-b661-df8d2bef8e08"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("9cf6bbae-f4b5-4463-a71b-f6092d7bd08d"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("b2e56dc2-ebcd-4b72-8b60-cf6b18f6f25c"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c5c0fb57-e57d-480e-aba3-d1735d724bf0"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("e3e358e2-2046-450c-b624-afaf5c73f593"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("e5827b2b-b78c-4c53-9c92-fcde058aeb62"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("fa8d3781-b92a-4e81-904e-90db754eb6ba"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("fd2da7fd-ceac-4285-9f72-3f9c807f9363"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("caf312c6-681b-44b4-9637-1c7e60ef7032"));

            migrationBuilder.DropColumn(
                name: "ComplintId",
                table: "Resolution");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Complain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Complain",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
