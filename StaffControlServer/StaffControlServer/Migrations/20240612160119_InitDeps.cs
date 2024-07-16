using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffControlServer.Migrations
{
    /// <inheritdoc />
    public partial class InitDeps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("07dc2060-a6f6-4ebf-8ce5-1ab153550a97"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("24dd6a17-b0b6-4166-88fc-def8d09bd3fa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33a5c564-2cce-40e7-96a8-e82db77feb69"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("492a2c48-ad06-4cb1-9591-ef631fa85252"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("575db12e-5808-4277-9f33-12e615b7727e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3071af5-2a91-440f-8414-1f6795ed83ce"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e195b50e-40b5-4d5a-b564-d61055c7f794"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cedeec66-2594-4a0a-a8b5-d52acfc9fb96"), new Guid("1d2351af-e8f1-4974-b776-829d47139bab") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("971708f1-9220-44c8-81f0-8f8c82f52564"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98117452-a7de-4049-bc2a-23d6a7c7aaf7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb366210-1e62-431a-bef0-5c4408d7b041"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdaa34de-39f8-49e1-926f-4a7b56d3fac5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cedeec66-2594-4a0a-a8b5-d52acfc9fb96"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d2351af-e8f1-4974-b776-829d47139bab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8454a2a-eac8-4f46-9cca-b2c60c9ce1a0"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("057c2651-ebec-455e-8c5b-a1b0541e4184"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("3b12d79b-74e4-4b14-9032-5d41b08bcf90"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a99f1722-ecf8-45bb-a049-f3c64449f304"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("130c2cdb-ffce-4cf7-87c7-43e68202308b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("f79f1e85-ced4-4a4b-8f13-9f29bb48a90a"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentUserId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorCode", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1a3a0afa-64c7-4fc1-b95e-1b9794048007"), 0, "9f91b4d7-ec64-40d6-be98-f8afe09c48b9", "admin@admin.admin", false, null, "Admin", "Admin", false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", null, "AQAAAAIAAYagAAAAEGc0ZmYZXHVkbxWKQpPt5nitIwrbfJe0fav1H99daSMCUD92fDuKU1dVZWk6XtFmpQ==", null, false, "d50ba99b-f008-4d62-a861-dc0d94f49395", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[,]
                {
                    { new Guid("0759e194-a97d-4578-b8cc-e6ae9c3c1200"), new DateTime(2024, 6, 12, 16, 1, 17, 743, DateTimeKind.Utc).AddTicks(4585), "Отдел продаж" },
                    { new Guid("2a2a17b9-ed7f-4d4b-bfd2-47837ee4cef0"), new DateTime(2024, 6, 12, 16, 1, 17, 743, DateTimeKind.Utc).AddTicks(4583), "Отдел маркетинга" },
                    { new Guid("69a0f599-ef26-4170-bf62-45d8deb3a88e"), new DateTime(2024, 6, 12, 16, 1, 17, 743, DateTimeKind.Utc).AddTicks(4585), "Отдел финансов" },
                    { new Guid("a87cf267-908f-48ff-960b-cc635865d4f3"), new DateTime(2024, 6, 12, 16, 1, 17, 743, DateTimeKind.Utc).AddTicks(4583), "Отдел разработки" },
                    { new Guid("dd075121-8a6d-4212-a30f-a18dbe577b87"), new DateTime(2024, 6, 12, 16, 1, 17, 743, DateTimeKind.Utc).AddTicks(4579), "CEO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("6c1f0db7-a1f1-4a30-a3dd-2f87341ed105"), null, new Guid("dd075121-8a6d-4212-a30f-a18dbe577b87"), "Системный администратор", "СИСТЕМНЫЙ АДМИНИСТРАТОР", null },
                    { new Guid("8ca34e7b-facc-4af7-9d8c-9015357ef197"), null, new Guid("dd075121-8a6d-4212-a30f-a18dbe577b87"), "Генеральный директор", "ГЕНЕРАЛЬНЫЙ ДИРЕКТОР", null },
                    { new Guid("693c0570-ad70-4e65-a0a2-ee2fcc33dcb7"), null, new Guid("2a2a17b9-ed7f-4d4b-bfd2-47837ee4cef0"), "Руководитель отдела маркеткинга", "РУКОВОДИТЕЛЬ ОТДЕЛА МАРКЕТКИНГА", new Guid("8ca34e7b-facc-4af7-9d8c-9015357ef197") },
                    { new Guid("6b5d7ea3-b1c5-4c01-8af6-f612f6e04f52"), null, new Guid("a87cf267-908f-48ff-960b-cc635865d4f3"), "Руководитель отдела разработки", "РУКОВОДИТЕЛЬ ОТДЕЛА РАЗРАБОТКИ", new Guid("8ca34e7b-facc-4af7-9d8c-9015357ef197") },
                    { new Guid("bfa3dec1-8f35-48b0-939b-c7224a208311"), null, new Guid("0759e194-a97d-4578-b8cc-e6ae9c3c1200"), "Руководитель отдела продаж", "РУКОВОДИТЕЛЬ ОТДЕЛА ПРОДАЖ", new Guid("8ca34e7b-facc-4af7-9d8c-9015357ef197") },
                    { new Guid("dd310d94-265b-4121-8fd3-22ad139da96e"), null, new Guid("69a0f599-ef26-4170-bf62-45d8deb3a88e"), "Руководитель отдела финансов", "РУКОВОДИТЕЛЬ ОТДЕЛА ФИНАНСОВ", new Guid("8ca34e7b-facc-4af7-9d8c-9015357ef197") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("6c1f0db7-a1f1-4a30-a3dd-2f87341ed105"), new Guid("1a3a0afa-64c7-4fc1-b95e-1b9794048007") });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("345f5305-ae37-4c91-9dd3-ff5cd3634724"), null, new Guid("69a0f599-ef26-4170-bf62-45d8deb3a88e"), "Бухгалтер", "БУХГАЛТЕР", new Guid("dd310d94-265b-4121-8fd3-22ad139da96e") },
                    { new Guid("74efe83d-951f-44f6-bf59-31db51d8d1ed"), null, new Guid("0759e194-a97d-4578-b8cc-e6ae9c3c1200"), "Менеджер по продажам", "МЕНЕДЖЕР ПО ПРОДАЖАМ", new Guid("bfa3dec1-8f35-48b0-939b-c7224a208311") },
                    { new Guid("7d172ed8-5518-4c5e-81ef-da1a3eeff6d6"), null, new Guid("a87cf267-908f-48ff-960b-cc635865d4f3"), "Менеджер проекта", "МЕНЕДЖЕР ПРОЕКТА", new Guid("6b5d7ea3-b1c5-4c01-8af6-f612f6e04f52") },
                    { new Guid("92c41728-be93-4a85-933f-09f42d156693"), null, new Guid("2a2a17b9-ed7f-4d4b-bfd2-47837ee4cef0"), "Менеджер по маркетингу", "МЕНЕДЖЕР ПО МАРКЕТИНГУ", new Guid("693c0570-ad70-4e65-a0a2-ee2fcc33dcb7") },
                    { new Guid("e73692b5-b5a7-46fa-969e-c9fd4019f8bd"), null, new Guid("2a2a17b9-ed7f-4d4b-bfd2-47837ee4cef0"), "Менеджер по продвижению", "МЕНЕДЖЕР ПО ПРОДВИЖЕНИЮ", new Guid("693c0570-ad70-4e65-a0a2-ee2fcc33dcb7") },
                    { new Guid("edd4b53b-4bf0-4654-bd5f-344f1df29ced"), null, new Guid("0759e194-a97d-4578-b8cc-e6ae9c3c1200"), "Консультант-продавец", "КОНСУЛЬТАНТ-ПРОДАВЕЦ", new Guid("bfa3dec1-8f35-48b0-939b-c7224a208311") },
                    { new Guid("b72b2c1b-e144-4d13-8e3f-dc9ecb479b13"), null, new Guid("a87cf267-908f-48ff-960b-cc635865d4f3"), "Разработчик", "РАЗРАБОТЧИК", new Guid("7d172ed8-5518-4c5e-81ef-da1a3eeff6d6") },
                    { new Guid("e1135ff8-892e-4fc7-9395-33109e041819"), null, new Guid("a87cf267-908f-48ff-960b-cc635865d4f3"), "Тестировщик", "ТЕСТИРОВЩИК", new Guid("7d172ed8-5518-4c5e-81ef-da1a3eeff6d6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("345f5305-ae37-4c91-9dd3-ff5cd3634724"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74efe83d-951f-44f6-bf59-31db51d8d1ed"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("92c41728-be93-4a85-933f-09f42d156693"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b72b2c1b-e144-4d13-8e3f-dc9ecb479b13"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1135ff8-892e-4fc7-9395-33109e041819"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e73692b5-b5a7-46fa-969e-c9fd4019f8bd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edd4b53b-4bf0-4654-bd5f-344f1df29ced"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6c1f0db7-a1f1-4a30-a3dd-2f87341ed105"), new Guid("1a3a0afa-64c7-4fc1-b95e-1b9794048007") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("693c0570-ad70-4e65-a0a2-ee2fcc33dcb7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c1f0db7-a1f1-4a30-a3dd-2f87341ed105"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d172ed8-5518-4c5e-81ef-da1a3eeff6d6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bfa3dec1-8f35-48b0-939b-c7224a208311"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd310d94-265b-4121-8fd3-22ad139da96e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a3a0afa-64c7-4fc1-b95e-1b9794048007"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b5d7ea3-b1c5-4c01-8af6-f612f6e04f52"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("0759e194-a97d-4578-b8cc-e6ae9c3c1200"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2a2a17b9-ed7f-4d4b-bfd2-47837ee4cef0"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("69a0f599-ef26-4170-bf62-45d8deb3a88e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ca34e7b-facc-4af7-9d8c-9015357ef197"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a87cf267-908f-48ff-960b-cc635865d4f3"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("dd075121-8a6d-4212-a30f-a18dbe577b87"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("130c2cdb-ffce-4cf7-87c7-43e68202308b"), null, null, "Генеральный директор", "ГЕНЕРАЛЬНЫЙ ДИРЕКТОР", null },
                    { new Guid("cedeec66-2594-4a0a-a8b5-d52acfc9fb96"), null, null, "Системный администратор", "СИСТЕМНЫЙ АДМИНИСТРАТОР", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentUserId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorCode", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1d2351af-e8f1-4974-b776-829d47139bab"), 0, "b96860ac-b4ff-408d-a4d6-eedabf2d05f8", "admin@admin.admin", false, null, "Admin", "Admin", false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", null, "AQAAAAIAAYagAAAAEEcOm1V4yvUjBcm6VANFKIatqUSrSaDR2NiJxzJaVD8vzU62W0HPLlka6rJ+NnMUBw==", null, false, "a2264ee8-114d-4b2b-9886-609589bc9f8e", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[,]
                {
                    { new Guid("057c2651-ebec-455e-8c5b-a1b0541e4184"), new DateTime(2024, 6, 12, 10, 35, 44, 786, DateTimeKind.Utc).AddTicks(915), "Отдел финансов" },
                    { new Guid("3b12d79b-74e4-4b14-9032-5d41b08bcf90"), new DateTime(2024, 6, 12, 10, 35, 44, 786, DateTimeKind.Utc).AddTicks(915), "Отдел продаж" },
                    { new Guid("a99f1722-ecf8-45bb-a049-f3c64449f304"), new DateTime(2024, 6, 12, 10, 35, 44, 786, DateTimeKind.Utc).AddTicks(911), "Отдел маркетинга" },
                    { new Guid("f79f1e85-ced4-4a4b-8f13-9f29bb48a90a"), new DateTime(2024, 6, 12, 10, 35, 44, 786, DateTimeKind.Utc).AddTicks(914), "Отдел разработки" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("971708f1-9220-44c8-81f0-8f8c82f52564"), null, new Guid("057c2651-ebec-455e-8c5b-a1b0541e4184"), "Руководитель отдела финансов", "РУКОВОДИТЕЛЬ ОТДЕЛА ФИНАНСОВ", new Guid("130c2cdb-ffce-4cf7-87c7-43e68202308b") },
                    { new Guid("a8454a2a-eac8-4f46-9cca-b2c60c9ce1a0"), null, new Guid("f79f1e85-ced4-4a4b-8f13-9f29bb48a90a"), "Руководитель отдела разработки", "РУКОВОДИТЕЛЬ ОТДЕЛА РАЗРАБОТКИ", new Guid("130c2cdb-ffce-4cf7-87c7-43e68202308b") },
                    { new Guid("cb366210-1e62-431a-bef0-5c4408d7b041"), null, new Guid("3b12d79b-74e4-4b14-9032-5d41b08bcf90"), "Руководитель отдела продаж", "РУКОВОДИТЕЛЬ ОТДЕЛА ПРОДАЖ", new Guid("130c2cdb-ffce-4cf7-87c7-43e68202308b") },
                    { new Guid("cdaa34de-39f8-49e1-926f-4a7b56d3fac5"), null, new Guid("a99f1722-ecf8-45bb-a049-f3c64449f304"), "Руководитель отдела маркеткинга", "РУКОВОДИТЕЛЬ ОТДЕЛА МАРКЕТКИНГА", new Guid("130c2cdb-ffce-4cf7-87c7-43e68202308b") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cedeec66-2594-4a0a-a8b5-d52acfc9fb96"), new Guid("1d2351af-e8f1-4974-b776-829d47139bab") });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("07dc2060-a6f6-4ebf-8ce5-1ab153550a97"), null, new Guid("a99f1722-ecf8-45bb-a049-f3c64449f304"), "Менеджер по продвижению", "МЕНЕДЖЕР ПО ПРОДВИЖЕНИЮ", new Guid("cdaa34de-39f8-49e1-926f-4a7b56d3fac5") },
                    { new Guid("24dd6a17-b0b6-4166-88fc-def8d09bd3fa"), null, new Guid("057c2651-ebec-455e-8c5b-a1b0541e4184"), "Бухгалтер", "БУХГАЛТЕР", new Guid("971708f1-9220-44c8-81f0-8f8c82f52564") },
                    { new Guid("33a5c564-2cce-40e7-96a8-e82db77feb69"), null, new Guid("3b12d79b-74e4-4b14-9032-5d41b08bcf90"), "Консультант-продавец", "КОНСУЛЬТАНТ-ПРОДАВЕЦ", new Guid("cb366210-1e62-431a-bef0-5c4408d7b041") },
                    { new Guid("492a2c48-ad06-4cb1-9591-ef631fa85252"), null, new Guid("a99f1722-ecf8-45bb-a049-f3c64449f304"), "Менеджер по маркетингу", "МЕНЕДЖЕР ПО МАРКЕТИНГУ", new Guid("cdaa34de-39f8-49e1-926f-4a7b56d3fac5") },
                    { new Guid("98117452-a7de-4049-bc2a-23d6a7c7aaf7"), null, new Guid("f79f1e85-ced4-4a4b-8f13-9f29bb48a90a"), "Менеджер проекта", "МЕНЕДЖЕР ПРОЕКТА", new Guid("a8454a2a-eac8-4f46-9cca-b2c60c9ce1a0") },
                    { new Guid("e195b50e-40b5-4d5a-b564-d61055c7f794"), null, new Guid("3b12d79b-74e4-4b14-9032-5d41b08bcf90"), "Менеджер по продажам", "МЕНЕДЖЕР ПО ПРОДАЖАМ", new Guid("cb366210-1e62-431a-bef0-5c4408d7b041") },
                    { new Guid("575db12e-5808-4277-9f33-12e615b7727e"), null, new Guid("f79f1e85-ced4-4a4b-8f13-9f29bb48a90a"), "Тестировщик", "ТЕСТИРОВЩИК", new Guid("98117452-a7de-4049-bc2a-23d6a7c7aaf7") },
                    { new Guid("a3071af5-2a91-440f-8414-1f6795ed83ce"), null, new Guid("f79f1e85-ced4-4a4b-8f13-9f29bb48a90a"), "Разработчик", "РАЗРАБОТЧИК", new Guid("98117452-a7de-4049-bc2a-23d6a7c7aaf7") }
                });
        }
    }
}
