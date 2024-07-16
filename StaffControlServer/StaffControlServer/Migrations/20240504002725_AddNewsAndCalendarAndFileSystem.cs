using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffControlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsAndCalendarAndFileSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a349f34-d14d-4b9a-b0f2-6041ac649dee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("803a1481-c298-4c65-aed6-35137f3546bc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8415c123-5def-4dca-9f29-3977c72a1daf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b8b9c5d0-4ce7-4b9a-8ba7-7d4a9bce941a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d8a288eb-4535-405a-a893-95ef318169c2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5af71f4-774e-4e5c-9a70-e782144a43c0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f73ad29e-8d5c-4a4b-a542-088022d25c63"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("89272620-ce0b-4d3f-96cf-561b0cc62ce6"), new Guid("88748af0-f54f-48cc-b76b-bf01c93fac38") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5fab8805-b02d-4cd8-9b87-4561825adb68"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7a1f1013-1184-4212-a47f-8ea0d9599c57"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("86f5586e-d7d5-4706-aeb7-7731f086e461"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89272620-ce0b-4d3f-96cf-561b0cc62ce6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca4e0b77-28b6-4b50-b9ce-5641861aded1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88748af0-f54f-48cc-b76b-bf01c93fac38"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98af3f9d-fc1c-4ce7-b31d-65b3e5bcd945"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("932fefa4-3f40-4b58-8f5a-bc9f831be411"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("cdd1484c-6106-4f2a-a9a2-4f3d51cabc7d"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("fd21c817-730e-4712-a194-f11967f91427"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a189754-abe5-4751-abbe-7d61b56587ae"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4026fb09-5408-41a1-ae15-1c8b349aab52"));

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    FileExtension = table.Column<string>(type: "text", nullable: false),
                    NewsId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileSystem_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
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
                name: "IX_AspNetUsers_FileId",
                table: "AspNetUsers",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileSystem_NewsId",
                table: "FileSystem",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FileSystem_FileId",
                table: "AspNetUsers",
                column: "FileId",
                principalTable: "FileSystem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FileSystem_FileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "FileSystem");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FileId",
                table: "AspNetUsers");

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
                name: "FileId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("2a189754-abe5-4751-abbe-7d61b56587ae"), null, null, "Генеральный директор", "ГЕНЕРАЛЬНЫЙ ДИРЕКТОР", null },
                    { new Guid("89272620-ce0b-4d3f-96cf-561b0cc62ce6"), null, null, "Системный администратор", "СИСТЕМНЫЙ АДМИНИСТРАТОР", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LocationId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentUserId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("88748af0-f54f-48cc-b76b-bf01c93fac38"), 0, "25e65e2b-4666-4deb-9efd-6ffa4c94372a", "admin@admin.admin", false, "Admin", "Admin", null, false, null, "ADMIN@ADMIN.ADMIN", "ADMIN", null, "AQAAAAIAAYagAAAAEKTQzFSpt+6fKrpdFdt4InTd/5Nsl4qNQgHjNEeaD9nqcFQKKCOBTE0hfKLL2dsbYA==", null, false, null, "141873f7-fdc0-4547-8e62-499ecfb0188a", false, "admin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[,]
                {
                    { new Guid("4026fb09-5408-41a1-ae15-1c8b349aab52"), new DateTime(2024, 4, 30, 15, 37, 46, 963, DateTimeKind.Utc).AddTicks(9714), "Отдел разработки" },
                    { new Guid("932fefa4-3f40-4b58-8f5a-bc9f831be411"), new DateTime(2024, 4, 30, 15, 37, 46, 963, DateTimeKind.Utc).AddTicks(9715), "Отдел продаж" },
                    { new Guid("cdd1484c-6106-4f2a-a9a2-4f3d51cabc7d"), new DateTime(2024, 4, 30, 15, 37, 46, 963, DateTimeKind.Utc).AddTicks(9716), "Отдел финансов" },
                    { new Guid("fd21c817-730e-4712-a194-f11967f91427"), new DateTime(2024, 4, 30, 15, 37, 46, 963, DateTimeKind.Utc).AddTicks(9711), "Отдел маркетинга" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("5fab8805-b02d-4cd8-9b87-4561825adb68"), null, new Guid("932fefa4-3f40-4b58-8f5a-bc9f831be411"), "Руководитель отдела продаж", "РУКОВОДИТЕЛЬ ОТДЕЛА ПРОДАЖ", new Guid("2a189754-abe5-4751-abbe-7d61b56587ae") },
                    { new Guid("7a1f1013-1184-4212-a47f-8ea0d9599c57"), null, new Guid("cdd1484c-6106-4f2a-a9a2-4f3d51cabc7d"), "Руководитель отдела финансов", "РУКОВОДИТЕЛЬ ОТДЕЛА ФИНАНСОВ", new Guid("2a189754-abe5-4751-abbe-7d61b56587ae") },
                    { new Guid("98af3f9d-fc1c-4ce7-b31d-65b3e5bcd945"), null, new Guid("4026fb09-5408-41a1-ae15-1c8b349aab52"), "Руководитель отдела разработки", "РУКОВОДИТЕЛЬ ОТДЕЛА РАЗРАБОТКИ", new Guid("2a189754-abe5-4751-abbe-7d61b56587ae") },
                    { new Guid("ca4e0b77-28b6-4b50-b9ce-5641861aded1"), null, new Guid("fd21c817-730e-4712-a194-f11967f91427"), "Руководитель отдела маркеткинга", "РУКОВОДИТЕЛЬ ОТДЕЛА МАРКЕТКИНГА", new Guid("2a189754-abe5-4751-abbe-7d61b56587ae") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("89272620-ce0b-4d3f-96cf-561b0cc62ce6"), new Guid("88748af0-f54f-48cc-b76b-bf01c93fac38") });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "DepartmentId", "Name", "NormalizedName", "ParentRoleId" },
                values: new object[,]
                {
                    { new Guid("803a1481-c298-4c65-aed6-35137f3546bc"), null, new Guid("fd21c817-730e-4712-a194-f11967f91427"), "Менеджер по маркетингу", "МЕНЕДЖЕР ПО МАРКЕТИНГУ", new Guid("ca4e0b77-28b6-4b50-b9ce-5641861aded1") },
                    { new Guid("8415c123-5def-4dca-9f29-3977c72a1daf"), null, new Guid("932fefa4-3f40-4b58-8f5a-bc9f831be411"), "Менеджер по продажам", "МЕНЕДЖЕР ПО ПРОДАЖАМ", new Guid("5fab8805-b02d-4cd8-9b87-4561825adb68") },
                    { new Guid("86f5586e-d7d5-4706-aeb7-7731f086e461"), null, new Guid("4026fb09-5408-41a1-ae15-1c8b349aab52"), "Менеджер проекта", "МЕНЕДЖЕР ПРОЕКТА", new Guid("98af3f9d-fc1c-4ce7-b31d-65b3e5bcd945") },
                    { new Guid("b8b9c5d0-4ce7-4b9a-8ba7-7d4a9bce941a"), null, new Guid("932fefa4-3f40-4b58-8f5a-bc9f831be411"), "Консультант-продавец", "КОНСУЛЬТАНТ-ПРОДАВЕЦ", new Guid("5fab8805-b02d-4cd8-9b87-4561825adb68") },
                    { new Guid("d8a288eb-4535-405a-a893-95ef318169c2"), null, new Guid("cdd1484c-6106-4f2a-a9a2-4f3d51cabc7d"), "Бухгалтер", "БУХГАЛТЕР", new Guid("7a1f1013-1184-4212-a47f-8ea0d9599c57") },
                    { new Guid("f73ad29e-8d5c-4a4b-a542-088022d25c63"), null, new Guid("fd21c817-730e-4712-a194-f11967f91427"), "Менеджер по продвижению", "МЕНЕДЖЕР ПО ПРОДВИЖЕНИЮ", new Guid("ca4e0b77-28b6-4b50-b9ce-5641861aded1") },
                    { new Guid("4a349f34-d14d-4b9a-b0f2-6041ac649dee"), null, new Guid("4026fb09-5408-41a1-ae15-1c8b349aab52"), "Разработчик", "РАЗРАБОТЧИК", new Guid("86f5586e-d7d5-4706-aeb7-7731f086e461") },
                    { new Guid("f5af71f4-774e-4e5c-9a70-e782144a43c0"), null, new Guid("4026fb09-5408-41a1-ae15-1c8b349aab52"), "Тестировщик", "ТЕСТИРОВЩИК", new Guid("86f5586e-d7d5-4706-aeb7-7731f086e461") }
                });
        }
    }
}
