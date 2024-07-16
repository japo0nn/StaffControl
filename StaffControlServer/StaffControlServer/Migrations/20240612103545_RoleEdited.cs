using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffControlServer.Migrations
{
    /// <inheritdoc />
    public partial class RoleEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("068eeb45-e637-4438-9c24-f146b119d7a2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16e27f3c-5bc7-4032-a920-d924963a610e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2558af9c-967d-4cc0-a3cf-4b7c92c93645"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3567b65f-222d-46ff-8513-1c64a72f0be6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("51a54b3a-bb02-4d39-87ab-93f92700756e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77622901-8917-4f35-987b-f89872f1a36c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eff5acf2-a045-48f2-95a4-adbdcabc1652"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f69976cc-155a-482d-93aa-e61e08c56700"), new Guid("0b7102a9-24e3-48d2-9529-4c4c4c7712e7") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c30d355-ecd2-4acd-90c8-896597835011"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5087591e-c379-462a-aa20-016dd96e2f90"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a98e7ecb-f28d-4151-9cc3-583bf2b6d56d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3adfc09-2204-4d8f-860f-6e213c650541"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f69976cc-155a-482d-93aa-e61e08c56700"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b7102a9-24e3-48d2-9529-4c4c4c7712e7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8328b880-df7e-4663-9b7c-abcf1384218b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("92d28d28-05b3-4afc-9add-7dc03732069c"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("dcc52fcb-2e1a-4f03-b230-d44d7d05eb69"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ee52a5ff-2a27-48e7-a035-04d4ec54b5e4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("459ca162-404a-40d0-81dc-67ce01c72ac8"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("5099d7d9-9f3d-44ec-afba-25a18541d1df"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

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

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("459ca162-404a-40d0-81dc-67ce01c72ac8"), null, null, "Генеральный директор", "ГЕНЕРАЛЬНЫЙ ДИРЕКТОР", null },
                    { new Guid("f69976cc-155a-482d-93aa-e61e08c56700"), null, null, "Системный администратор", "СИСТЕМНЫЙ АДМИНИСТРАТОР", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileId", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentUserId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorCode", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0b7102a9-24e3-48d2-9529-4c4c4c7712e7"), 0, "6d35ba71-bc8e-4f97-a70f-e4d6723abf99", "admin@admin.admin", false, null, "Admin", "Admin", false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", null, "AQAAAAIAAYagAAAAEBcJ1ACjqfFiSziER999GGiXA9ZdWqHin/6DaQVHcyipyhHjyMMmeiuMhQ5u3ju0bA==", null, false, null, "9e5e857f-c59f-4709-89c9-839222a6c4d2", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[,]
                {
                    { new Guid("5099d7d9-9f3d-44ec-afba-25a18541d1df"), new DateTime(2024, 5, 31, 9, 37, 31, 241, DateTimeKind.Utc).AddTicks(6351), "Отдел разработки" },
                    { new Guid("92d28d28-05b3-4afc-9add-7dc03732069c"), new DateTime(2024, 5, 31, 9, 37, 31, 241, DateTimeKind.Utc).AddTicks(6347), "Отдел маркетинга" },
                    { new Guid("dcc52fcb-2e1a-4f03-b230-d44d7d05eb69"), new DateTime(2024, 5, 31, 9, 37, 31, 241, DateTimeKind.Utc).AddTicks(6352), "Отдел продаж" },
                    { new Guid("ee52a5ff-2a27-48e7-a035-04d4ec54b5e4"), new DateTime(2024, 5, 31, 9, 37, 31, 241, DateTimeKind.Utc).AddTicks(6353), "Отдел финансов" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("2c30d355-ecd2-4acd-90c8-896597835011"), null, new Guid("ee52a5ff-2a27-48e7-a035-04d4ec54b5e4"), "Руководитель отдела финансов", "РУКОВОДИТЕЛЬ ОТДЕЛА ФИНАНСОВ", new Guid("459ca162-404a-40d0-81dc-67ce01c72ac8") },
                    { new Guid("8328b880-df7e-4663-9b7c-abcf1384218b"), null, new Guid("5099d7d9-9f3d-44ec-afba-25a18541d1df"), "Руководитель отдела разработки", "РУКОВОДИТЕЛЬ ОТДЕЛА РАЗРАБОТКИ", new Guid("459ca162-404a-40d0-81dc-67ce01c72ac8") },
                    { new Guid("a98e7ecb-f28d-4151-9cc3-583bf2b6d56d"), null, new Guid("dcc52fcb-2e1a-4f03-b230-d44d7d05eb69"), "Руководитель отдела продаж", "РУКОВОДИТЕЛЬ ОТДЕЛА ПРОДАЖ", new Guid("459ca162-404a-40d0-81dc-67ce01c72ac8") },
                    { new Guid("e3adfc09-2204-4d8f-860f-6e213c650541"), null, new Guid("92d28d28-05b3-4afc-9add-7dc03732069c"), "Руководитель отдела маркеткинга", "РУКОВОДИТЕЛЬ ОТДЕЛА МАРКЕТКИНГА", new Guid("459ca162-404a-40d0-81dc-67ce01c72ac8") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f69976cc-155a-482d-93aa-e61e08c56700"), new Guid("0b7102a9-24e3-48d2-9529-4c4c4c7712e7") });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("068eeb45-e637-4438-9c24-f146b119d7a2"), null, new Guid("dcc52fcb-2e1a-4f03-b230-d44d7d05eb69"), "Консультант-продавец", "КОНСУЛЬТАНТ-ПРОДАВЕЦ", new Guid("a98e7ecb-f28d-4151-9cc3-583bf2b6d56d") },
                    { new Guid("16e27f3c-5bc7-4032-a920-d924963a610e"), null, new Guid("dcc52fcb-2e1a-4f03-b230-d44d7d05eb69"), "Менеджер по продажам", "МЕНЕДЖЕР ПО ПРОДАЖАМ", new Guid("a98e7ecb-f28d-4151-9cc3-583bf2b6d56d") },
                    { new Guid("3567b65f-222d-46ff-8513-1c64a72f0be6"), null, new Guid("92d28d28-05b3-4afc-9add-7dc03732069c"), "Менеджер по продвижению", "МЕНЕДЖЕР ПО ПРОДВИЖЕНИЮ", new Guid("e3adfc09-2204-4d8f-860f-6e213c650541") },
                    { new Guid("5087591e-c379-462a-aa20-016dd96e2f90"), null, new Guid("5099d7d9-9f3d-44ec-afba-25a18541d1df"), "Менеджер проекта", "МЕНЕДЖЕР ПРОЕКТА", new Guid("8328b880-df7e-4663-9b7c-abcf1384218b") },
                    { new Guid("51a54b3a-bb02-4d39-87ab-93f92700756e"), null, new Guid("ee52a5ff-2a27-48e7-a035-04d4ec54b5e4"), "Бухгалтер", "БУХГАЛТЕР", new Guid("2c30d355-ecd2-4acd-90c8-896597835011") },
                    { new Guid("eff5acf2-a045-48f2-95a4-adbdcabc1652"), null, new Guid("92d28d28-05b3-4afc-9add-7dc03732069c"), "Менеджер по маркетингу", "МЕНЕДЖЕР ПО МАРКЕТИНГУ", new Guid("e3adfc09-2204-4d8f-860f-6e213c650541") },
                    { new Guid("2558af9c-967d-4cc0-a3cf-4b7c92c93645"), null, new Guid("5099d7d9-9f3d-44ec-afba-25a18541d1df"), "Тестировщик", "ТЕСТИРОВЩИК", new Guid("5087591e-c379-462a-aa20-016dd96e2f90") },
                    { new Guid("77622901-8917-4f35-987b-f89872f1a36c"), null, new Guid("5099d7d9-9f3d-44ec-afba-25a18541d1df"), "Разработчик", "РАЗРАБОТЧИК", new Guid("5087591e-c379-462a-aa20-016dd96e2f90") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }
    }
}
