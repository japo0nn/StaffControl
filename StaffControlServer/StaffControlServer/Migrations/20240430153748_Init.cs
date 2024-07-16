using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffControlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentRoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_AspNetRoles_ParentRoleId",
                        column: x => x.ParentRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetRoles_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_ParentUserId",
                        column: x => x.ParentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ToDoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponsibleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoes_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoes_AspNetUsers_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_DepartmentId",
                table: "AspNetRoles",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_ParentRoleId",
                table: "AspNetRoles",
                column: "ParentRoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParentUserId",
                table: "AspNetUsers",
                column: "ParentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoes_AuthorId",
                table: "ToDoes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoes_ResponsibleId",
                table: "ToDoes",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoes_UserId",
                table: "ToDoes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ToDoes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
