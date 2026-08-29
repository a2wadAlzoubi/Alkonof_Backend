using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alkonof_Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("09c96fcb-e0d1-4d3d-ae5f-95ff861f6df7"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("16dfcd9c-6244-4671-9c1c-ba1285e35e9f"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("44f72a6b-ccfe-4600-b095-53836da1b970"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("4c6bea8b-c93d-4527-8fd3-550e73f4f21c"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("4fda9fa9-88cf-4f46-be10-a8d5ac7fdd52"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("51ce78d1-758d-494c-915f-1019a763ed19"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("5635da7e-424c-414f-b091-085a360a2a07"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("5a352120-cf4e-4983-8422-5570ad82b864"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("5f1cde02-a082-441d-b727-86f64e92b59c"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("649e60c0-fcc8-44c0-af8a-0b6d140cbd63"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("6595cb2b-fb7c-4596-8eb5-096fa0ae9d9c"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("695d0db5-8530-4df3-9601-7f600dd98eaa"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("7b3192f4-f167-4323-8919-79420c8a697d"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("ba0cb569-e7ed-4274-ab10-e1e6400746cc"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("bb215ebd-568b-4fdd-9ddd-2cb3a09ecdd5"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("c170d887-d317-4968-a351-253e1000536b"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("ca7b64f9-9974-4620-bdbb-f770bfc94f2f"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("cb8cf96f-79d2-4f90-b930-d813425cb3f1"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("cd4b109b-be5c-41e2-9c29-347ad2a69c1c"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("dd5552fa-3934-4abc-a779-eee4b1266d3b"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("ecda487f-a9ae-4f97-903a-89261afe4ad7"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("fdcdd1c3-809d-4b45-81fd-e058fb42ab95"));

            migrationBuilder.InsertData(
                table: "PermissionGrop",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "OperationPermission", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("0198fe0d-b5a7-4362-be73-9bc7eae3c651"), null, null, null, null, 2, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("0dd02154-4642-4a31-a594-a08dd1f7f164"), null, null, null, null, 1, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("0e96a3f5-8840-47e5-bb50-720dbbd4fd52"), null, null, null, null, 10, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("0f3add5c-530c-4739-8c62-13c97576a95d"), null, null, null, null, 0, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("1624b49c-0b1f-40e9-a421-26bf66ee9286"), null, null, null, null, 0, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("2828f9e8-4d53-4742-89fd-d694ebf54ed7"), null, null, null, null, 11, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("29fc6e57-19ee-44f2-ba6b-413a6034f95b"), null, null, null, null, 3, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("461df5b5-027f-4422-9a2c-74c56837b0b2"), null, null, null, null, 1, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("555334c3-b5c8-4a57-ab57-cfd45ce98dfc"), null, null, null, null, 10, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("582544f2-02cc-4662-b55d-26b83546b97f"), null, null, null, null, 7, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("61143637-0d5a-4bed-944c-09678dc51da5"), null, null, null, null, 3, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("83c3786f-7da0-46e0-935b-c274a0816e04"), null, null, null, null, 1, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("89b378b5-ecde-4973-a790-df43c72e7df4"), null, null, null, null, 2, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("9b1003a2-6d78-4967-b128-2d41a63882a9"), null, null, null, null, 2, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("a46a707a-6ee6-4cd9-a284-8ebb17290618"), null, null, null, null, 8, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("af0a07bd-49bc-424f-b845-4b5db192e347"), null, null, null, null, 7, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("e0385b68-3fe2-4698-b09b-ae84eb4c2405"), null, null, null, null, 3, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("e1ebc303-6da0-4ba8-b011-987a9e510b24"), null, null, null, null, 6, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("eaf75c95-4721-4819-99dc-fc7ec37a04ff"), null, null, null, null, 0, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("ec30c50f-42ee-4c7e-9726-2e57754e09c5"), null, null, null, null, 4, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("f50a3fbb-1774-4426-ac28-469bd109402a"), null, null, null, null, 5, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("ffe0f977-ded0-4812-988c-59853e33f34b"), null, null, null, null, 9, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1a7e5c9d-3f21-4b86-7e5c-7d15e8a6b903"),
                columns: new[] { "Email", "Name" },
                values: new object[] { "alzoubiawad123@gmail.com", "Kaiser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("0198fe0d-b5a7-4362-be73-9bc7eae3c651"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("0dd02154-4642-4a31-a594-a08dd1f7f164"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("0e96a3f5-8840-47e5-bb50-720dbbd4fd52"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("0f3add5c-530c-4739-8c62-13c97576a95d"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("1624b49c-0b1f-40e9-a421-26bf66ee9286"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("2828f9e8-4d53-4742-89fd-d694ebf54ed7"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("29fc6e57-19ee-44f2-ba6b-413a6034f95b"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("461df5b5-027f-4422-9a2c-74c56837b0b2"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("555334c3-b5c8-4a57-ab57-cfd45ce98dfc"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("582544f2-02cc-4662-b55d-26b83546b97f"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("61143637-0d5a-4bed-944c-09678dc51da5"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("83c3786f-7da0-46e0-935b-c274a0816e04"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("89b378b5-ecde-4973-a790-df43c72e7df4"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("9b1003a2-6d78-4967-b128-2d41a63882a9"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("a46a707a-6ee6-4cd9-a284-8ebb17290618"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("af0a07bd-49bc-424f-b845-4b5db192e347"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("e0385b68-3fe2-4698-b09b-ae84eb4c2405"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("e1ebc303-6da0-4ba8-b011-987a9e510b24"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("eaf75c95-4721-4819-99dc-fc7ec37a04ff"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("ec30c50f-42ee-4c7e-9726-2e57754e09c5"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("f50a3fbb-1774-4426-ac28-469bd109402a"));

            migrationBuilder.DeleteData(
                table: "PermissionGrop",
                keyColumn: "Id",
                keyValue: new Guid("ffe0f977-ded0-4812-988c-59853e33f34b"));

            migrationBuilder.InsertData(
                table: "PermissionGrop",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "OperationPermission", "PermissionId" },
                values: new object[,]
                {
                    { new Guid("09c96fcb-e0d1-4d3d-ae5f-95ff861f6df7"), null, null, null, null, 3, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("16dfcd9c-6244-4671-9c1c-ba1285e35e9f"), null, null, null, null, 2, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("44f72a6b-ccfe-4600-b095-53836da1b970"), null, null, null, null, 3, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("4c6bea8b-c93d-4527-8fd3-550e73f4f21c"), null, null, null, null, 9, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("4fda9fa9-88cf-4f46-be10-a8d5ac7fdd52"), null, null, null, null, 10, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("51ce78d1-758d-494c-915f-1019a763ed19"), null, null, null, null, 11, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("5635da7e-424c-414f-b091-085a360a2a07"), null, null, null, null, 4, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("5a352120-cf4e-4983-8422-5570ad82b864"), null, null, null, null, 0, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("5f1cde02-a082-441d-b727-86f64e92b59c"), null, null, null, null, 6, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("649e60c0-fcc8-44c0-af8a-0b6d140cbd63"), null, null, null, null, 7, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("6595cb2b-fb7c-4596-8eb5-096fa0ae9d9c"), null, null, null, null, 2, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("695d0db5-8530-4df3-9601-7f600dd98eaa"), null, null, null, null, 5, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("7b3192f4-f167-4323-8919-79420c8a697d"), null, null, null, null, 0, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("ba0cb569-e7ed-4274-ab10-e1e6400746cc"), null, null, null, null, 1, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("bb215ebd-568b-4fdd-9ddd-2cb3a09ecdd5"), null, null, null, null, 1, new Guid("3c1b2a9d-4e8f-4b1a-9c8d-6f5e4d3c2b1a") },
                    { new Guid("c170d887-d317-4968-a351-253e1000536b"), null, null, null, null, 10, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("ca7b64f9-9974-4620-bdbb-f770bfc94f2f"), null, null, null, null, 8, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("cb8cf96f-79d2-4f90-b930-d813425cb3f1"), null, null, null, null, 7, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("cd4b109b-be5c-41e2-9c29-347ad2a69c1c"), null, null, null, null, 2, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("dd5552fa-3934-4abc-a779-eee4b1266d3b"), null, null, null, null, 0, new Guid("0a794768-ab8a-4a07-b8a0-424b5e5df9d5") },
                    { new Guid("ecda487f-a9ae-4f97-903a-89261afe4ad7"), null, null, null, null, 1, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") },
                    { new Guid("fdcdd1c3-809d-4b45-81fd-e058fb42ab95"), null, null, null, null, 3, new Guid("8a5c8e6c-4f3b-4b2c-8a7f-8d3e2f5b9a1b") }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1a7e5c9d-3f21-4b86-7e5c-7d15e8a6b903"),
                columns: new[] { "Email", "Name" },
                values: new object[] { "ahmad3@gmail.com", "Ahmad3" });
        }
    }
}
