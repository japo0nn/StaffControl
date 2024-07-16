using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffControlServer.Data;
using System.Reflection.Emit;

namespace StaffControlServer.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Создание начальных ролей

            builder.Entity <ApplicationUserRole>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUserRole>()
                .HasOne(e => e.Role)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            /*builder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(e => e.RoleId)
                .IsRequired();*/

            builder.Entity<ToDo>()
                .HasOne(t => t.Author)
                .WithMany()
                .HasForeignKey(t => t.AuthorId);

            builder.Entity<ToDo>()
                .HasOne(t => t.Responsible)
                .WithMany()
                .HasForeignKey(t => t.ResponsibleId);

            Guid ceoDepId = Guid.NewGuid();
            Guid marketingId = Guid.NewGuid();
            Guid developingId = Guid.NewGuid();
            Guid salesId = Guid.NewGuid();
            Guid financeId = Guid.NewGuid();
            builder.Entity<Department>().HasData(
                new Department { Id = ceoDepId, Name = "CEO" },
                new Department { Id = marketingId, Name = "Отдел маркетинга" },
                new Department { Id = developingId, Name = "Отдел разработки" },
                new Department { Id = salesId, Name = "Отдел продаж" },
                new Department { Id = financeId, Name = "Отдел финансов" }
            );

            // Роли руководителей

            Guid adminRoleId = Guid.NewGuid();
            string adminRoleName = "Системный администратор";
            var adminRole = new Role
            {
                Id = adminRoleId,
                Name = adminRoleName,
                NormalizedName = adminRoleName.ToUpper(),
                DepartmentId = ceoDepId,
            };


            Guid ceoId = Guid.NewGuid();
            string CEO = "Генеральный директор";
            var ceoRole = new Role
            {
                Id = ceoId,
                Name = CEO,
                NormalizedName = CEO.ToUpper(),
                DepartmentId = ceoDepId,
            };

            Guid developerDirectorId = Guid.NewGuid();
            string developerDirector = "Руководитель отдела разработки";
            var developerDirectorRole = new Role
            {
                Id = developerDirectorId,
                Name = developerDirector,
                NormalizedName = developerDirector.ToUpper(),
                DepartmentId = developingId,
                ParentRoleId = ceoId
            };

            Guid marketingDirectorId = Guid.NewGuid();
            string marketingDirector = "Руководитель отдела маркеткинга";
            var marketingDirectorRole = new Role
            {
                Id = marketingDirectorId,
                Name = marketingDirector,
                NormalizedName = marketingDirector.ToUpper(),
                DepartmentId = marketingId,
                ParentRoleId = ceoId
            };

            Guid salesDirectorId = Guid.NewGuid();
            string salesDirector = "Руководитель отдела продаж";
            var salesDirectorRole = new Role
            {
                Id = salesDirectorId,
                Name = salesDirector,
                NormalizedName = salesDirector.ToUpper(),
                DepartmentId = salesId,
                ParentRoleId = ceoId
            };

            Guid financeDirectorId = Guid.NewGuid();
            string financeDirector = "Руководитель отдела финансов";
            var financeDirectorRole = new Role
            {
                Id = financeDirectorId,
                Name = financeDirector,
                NormalizedName = financeDirector.ToUpper(),
                DepartmentId = financeId,
                ParentRoleId = ceoId
            };

            // Роли персонала отдела разработки

            Guid pmId = Guid.NewGuid();
            Guid pmIdentityRoleId = Guid.NewGuid();
            string pm = "Менеджер проекта";
            var pmRole = new Role
            {
                Id = pmId,
                Name = pm,
                NormalizedName = pm.ToUpper(),
                DepartmentId = developingId,
                ParentRoleId = developerDirectorId
            };

            string developer = "Разработчик";
            var developerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = developer,
                NormalizedName = developer.ToUpper(),
                DepartmentId = developingId,
                ParentRoleId = pmId
            };

            string tester = "Тестировщик";
            var testerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = tester,
                NormalizedName = tester.ToUpper(),
                DepartmentId = developingId,
                ParentRoleId = pmId
            };


            // Роли персонала отдела маркетинга

            string marketingManager = "Менеджер по маркетингу";
            var marketingManagerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = marketingManager,
                NormalizedName = marketingManager.ToUpper(),
                DepartmentId = marketingId,
                ParentRoleId = marketingDirectorId
            };

            string promotionManager = "Менеджер по продвижению";
            var promotionManagerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = promotionManager,
                NormalizedName = promotionManager.ToUpper(),
                DepartmentId = marketingId,
                ParentRoleId = marketingDirectorId
            };

            // Роли персонала отдела продаж

            string salesManager = "Менеджер по продажам";
            var salesManagerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = salesManager,
                NormalizedName = salesManager.ToUpper(),
                DepartmentId = salesId,
                ParentRoleId = salesDirectorId
            };

            string salesConsultant = "Консультант-продавец";
            var salesConsultantRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = salesConsultant,
                NormalizedName = salesConsultant.ToUpper(),
                DepartmentId = salesId,
                ParentRoleId = salesDirectorId
            };

            // Роли персонала отдела финансов

            string accountant = "Бухгалтер";
            var accountantRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = accountant,
                NormalizedName = accountant.ToUpper(),
                DepartmentId = financeId,
                ParentRoleId = financeDirectorId
            };

            // Инициализация ролей

            builder.Entity<Role>().HasData(adminRole, ceoRole,
                developerDirectorRole, pmRole, developerRole, testerRole,
                marketingDirectorRole, marketingManagerRole, promotionManagerRole,
                salesDirectorRole, salesManagerRole, salesConsultantRole,
                financeDirectorRole, accountantRole);

            // Инициализация пользователя - Администратор
            var hasher = new PasswordHasher<User>();
            Guid adminUserId = Guid.NewGuid();
            var adminUser = new User()
            {
                Id = adminUserId,
                UserName = "Admin".ToLower(),
                NormalizedUserName = "Admin".ToUpper(),
                Email = "admin@admin.admin",
                NormalizedEmail = "admin@admin.admin".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "beksultanbaizhigit@gmail.com"),
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled = false
            };

            builder.Entity<User>().HasData(adminUser);

            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole { RoleId = adminRoleId, UserId = adminUserId }
                );


        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<ToDo> ToDoes { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<FileSystem> FileSystem { get; set; }

    }
}
