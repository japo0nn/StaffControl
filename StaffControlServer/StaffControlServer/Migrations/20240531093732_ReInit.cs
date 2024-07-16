using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffControlServer.Migrations
{
    /// <inheritdoc />
    public partial class ReInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_AspNetUsers_UserId",
                table: "Calendars");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1649bdb7-85e8-4635-9b3c-205bcc3b1cd4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66484195-3f9d-4e5e-b19f-81dd4fb2535e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("69940bb5-d75f-46c3-90df-cb1dd534c7c4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f712bc2-c1c9-4674-87a5-75cdda8b334f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91b19c85-3d7d-473f-af17-ee057a484ed9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab372087-217c-41bd-a0f1-ed0dc92735e7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d774d03e-b70b-46bf-8165-2364acf3c7b1"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a405cfe6-0c33-413d-bbdc-326323ede703"), new Guid("2074158c-720e-439a-ac34-dbfde99aa49a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a0176df-3ed4-4b11-a284-ee53013bc642"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a405cfe6-0c33-413d-bbdc-326323ede703"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b5fa73f6-585d-4b02-912e-7789d4b9e3f7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cfe17a07-0b5a-4437-9982-de62f1a86e7c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d69f420d-aa66-43e5-aae1-892809b5348a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2074158c-720e-439a-ac34-dbfde99aa49a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a27e52ca-d68f-4f54-9f1d-4f88436418f4"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("360d41c2-b342-4b1d-855f-0ebb797dbc2a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("732825ec-9863-4dab-adff-f0d574a99cba"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("f27f5be5-7bb8-47bc-bec1-6a30b691830b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8b7e16c-634d-45f2-ac7b-14e4ab07a591"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("1fe6f671-7547-4c1c-9de4-ba379e885466"));

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Calendars",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwoFactorCode",
                table: "AspNetUsers",
                type: "text",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_AspNetUsers_UserId",
                table: "Calendars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendars_AspNetUsers_UserId",
                table: "Calendars");

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
                name: "TwoFactorCode",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Calendars",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("a405cfe6-0c33-413d-bbdc-326323ede703"), null, null, "Системный администратор", "СИСТЕМНЫЙ АДМИНИСТРАТОР", null },
                    { new Guid("e8b7e16c-634d-45f2-ac7b-14e4ab07a591"), null, null, "Генеральный директор", "ГЕНЕРАЛЬНЫЙ ДИРЕКТОР", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FileId", "FirstName", "LastName", "LocationId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentUserId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2074158c-720e-439a-ac34-dbfde99aa49a"), 0, "8484dfa3-61f5-4f66-a7c8-0d9a4ab4fa45", "admin@admin.admin", false, null, "Admin", "Admin", null, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", null, "AQAAAAIAAYagAAAAEAZ/+vy90WLrzzVEoM1HTdKkZKSuq3PSc+cViLyuG+blWWCK+F6Vb/vBwcuWXg996A==", null, false, null, "b5498cc3-a745-4778-a3d9-5cc0cc2a0cc7", false, "admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[,]
                {
                    { new Guid("1fe6f671-7547-4c1c-9de4-ba379e885466"), new DateTime(2024, 5, 4, 0, 27, 24, 769, DateTimeKind.Utc).AddTicks(7645), "Отдел разработки" },
                    { new Guid("360d41c2-b342-4b1d-855f-0ebb797dbc2a"), new DateTime(2024, 5, 4, 0, 27, 24, 769, DateTimeKind.Utc).AddTicks(7646), "Отдел продаж" },
                    { new Guid("732825ec-9863-4dab-adff-f0d574a99cba"), new DateTime(2024, 5, 4, 0, 27, 24, 769, DateTimeKind.Utc).AddTicks(7647), "Отдел финансов" },
                    { new Guid("f27f5be5-7bb8-47bc-bec1-6a30b691830b"), new DateTime(2024, 5, 4, 0, 27, 24, 769, DateTimeKind.Utc).AddTicks(7641), "Отдел маркетинга" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("9a0176df-3ed4-4b11-a284-ee53013bc642"), null, new Guid("732825ec-9863-4dab-adff-f0d574a99cba"), "Руководитель отдела финансов", "РУКОВОДИТЕЛЬ ОТДЕЛА ФИНАНСОВ", new Guid("e8b7e16c-634d-45f2-ac7b-14e4ab07a591") },
                    { new Guid("a27e52ca-d68f-4f54-9f1d-4f88436418f4"), null, new Guid("1fe6f671-7547-4c1c-9de4-ba379e885466"), "Руководитель отдела разработки", "РУКОВОДИТЕЛЬ ОТДЕЛА РАЗРАБОТКИ", new Guid("e8b7e16c-634d-45f2-ac7b-14e4ab07a591") },
                    { new Guid("b5fa73f6-585d-4b02-912e-7789d4b9e3f7"), null, new Guid("360d41c2-b342-4b1d-855f-0ebb797dbc2a"), "Руководитель отдела продаж", "РУКОВОДИТЕЛЬ ОТДЕЛА ПРОДАЖ", new Guid("e8b7e16c-634d-45f2-ac7b-14e4ab07a591") },
                    { new Guid("cfe17a07-0b5a-4437-9982-de62f1a86e7c"), null, new Guid("f27f5be5-7bb8-47bc-bec1-6a30b691830b"), "Руководитель отдела маркеткинга", "РУКОВОДИТЕЛЬ ОТДЕЛА МАРКЕТКИНГА", new Guid("e8b7e16c-634d-45f2-ac7b-14e4ab07a591") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a405cfe6-0c33-413d-bbdc-326323ede703"), new Guid("2074158c-720e-439a-ac34-dbfde99aa49a") });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("66484195-3f9d-4e5e-b19f-81dd4fb2535e"), null, new Guid("360d41c2-b342-4b1d-855f-0ebb797dbc2a"), "Консультант-продавец", "КОНСУЛЬТАНТ-ПРОДАВЕЦ", new Guid("b5fa73f6-585d-4b02-912e-7789d4b9e3f7") },
                    { new Guid("69940bb5-d75f-46c3-90df-cb1dd534c7c4"), null, new Guid("732825ec-9863-4dab-adff-f0d574a99cba"), "Бухгалтер", "БУХГАЛТЕР", new Guid("9a0176df-3ed4-4b11-a284-ee53013bc642") },
                    { new Guid("8f712bc2-c1c9-4674-87a5-75cdda8b334f"), null, new Guid("f27f5be5-7bb8-47bc-bec1-6a30b691830b"), "Менеджер по продвижению", "МЕНЕДЖЕР ПО ПРОДВИЖЕНИЮ", new Guid("cfe17a07-0b5a-4437-9982-de62f1a86e7c") },
                    { new Guid("91b19c85-3d7d-473f-af17-ee057a484ed9"), null, new Guid("360d41c2-b342-4b1d-855f-0ebb797dbc2a"), "Менеджер по продажам", "МЕНЕДЖЕР ПО ПРОДАЖАМ", new Guid("b5fa73f6-585d-4b02-912e-7789d4b9e3f7") },
                    { new Guid("d69f420d-aa66-43e5-aae1-892809b5348a"), null, new Guid("1fe6f671-7547-4c1c-9de4-ba379e885466"), "Менеджер проекта", "МЕНЕДЖЕР ПРОЕКТА", new Guid("a27e52ca-d68f-4f54-9f1d-4f88436418f4") },
                    { new Guid("d774d03e-b70b-46bf-8165-2364acf3c7b1"), null, new Guid("f27f5be5-7bb8-47bc-bec1-6a30b691830b"), "Менеджер по маркетингу", "МЕНЕДЖЕР ПО МАРКЕТИНГУ", new Guid("cfe17a07-0b5a-4437-9982-de62f1a86e7c") },
                    { new Guid("1649bdb7-85e8-4635-9b3c-205bcc3b1cd4"), null, new Guid("1fe6f671-7547-4c1c-9de4-ba379e885466"), "Разработчик", "РАЗРАБОТЧИК", new Guid("d69f420d-aa66-43e5-aae1-892809b5348a") },
                    { new Guid("ab372087-217c-41bd-a0f1-ed0dc92735e7"), null, new Guid("1fe6f671-7547-4c1c-9de4-ba379e885466"), "Тестировщик", "ТЕСТИРОВЩИК", new Guid("d69f420d-aa66-43e5-aae1-892809b5348a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_AspNetUsers_UserId",
                table: "Calendars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
