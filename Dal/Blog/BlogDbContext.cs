using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dal.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Dal.Blog
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim<string>,
        ApplicationUserRole<string>, ApplicationUserLogin<string>, ApplicationRoleClaim<string>, ApplicationUserToken<string>>
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
            //todo: add query execution logging
        }

        public DbSet<Models.Blog> Blogs { get; set; }

        public DbSet<Models.Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            #region identity user modifications

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.Id)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.ConcurrencyStamp)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.Email)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.NormalizedEmail)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.NormalizedUserName)
                .HasColumnType("varchar(30)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.PasswordHash)
                .HasColumnType("varchar(8000)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.PhoneNumber)
                .HasColumnType("varchar(12)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.SecurityStamp)
                .HasColumnType("varchar(8000)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.UserName)
                .HasColumnType("varchar(30)");

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.NameSurname)
                .HasColumnType("varchar(100)");

            #endregion identity user modifications

            #region role modifications

            modelBuilder.Entity<ApplicationRole>()
                .Property(p => p.Id)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationRole>()
                .Property(p => p.ConcurrencyStamp)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationRole>()
                .Property(p => p.Name)
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<ApplicationRole>()
                .Property(p => p.NormalizedName)
                .HasColumnType("varchar(20)");


            #endregion role modifications

            #region user role modifications

            modelBuilder.Entity<ApplicationUserRole<string>>()
                .Property(p => p.UserId)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationUserRole<string>>()
                .Property(p => p.RoleId)
                .HasColumnType("varchar(128)");


            #endregion user role modifications

            #region user login modifications

            modelBuilder.Entity<ApplicationUserLogin<string>>()
                .Property(p => p.LoginProvider)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationUserLogin<string>>()
                .Property(p => p.ProviderKey)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationUserLogin<string>>()
                .Property(p => p.ProviderDisplayName)
                .HasColumnType("varchar(128)");


            #endregion user login modifications

            #region user token modifications

            modelBuilder.Entity<ApplicationUserToken<string>>()
                .Property(p => p.LoginProvider)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationUserToken<string>>()
                .Property(p => p.Name)
                .HasColumnType("varchar(128)");

            modelBuilder.Entity<ApplicationUserToken<string>>()
                .Property(p => p.Value)
                .HasColumnType("varchar(500)");

            #endregion user token modifications

            #region user claim modifications

            modelBuilder.Entity<ApplicationUserClaim<string>>()
                .Property(p => p.ClaimType)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<ApplicationUserClaim<string>>()
                .Property(p => p.ClaimValue)
                .HasColumnType("varchar(50)");

            #endregion user claim modifications

            #region role claim modifications

            modelBuilder.Entity<ApplicationRoleClaim<string>>()
                .Property(p => p.ClaimType)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<ApplicationRoleClaim<string>>()
                .Property(p => p.ClaimValue)
                .HasColumnType("varchar(50)");

            #endregion role claim modifications

            //#region dbo.userLogs

            //modelBuilder.Entity<UserLog>()
            //    .HasIndex(b => b.UserId)
            //    .HasName("IX_UserId");

            //#endregion #dbo.userLogs

            //avoid nvarchar (use varchar)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                   .Where(t => t.ClrType != typeof(ApplicationUser)
                    && t.ClrType != typeof(ApplicationUserLogin<string>)
                    && t.ClrType != typeof(ApplicationUserRole<string>)
                    && t.ClrType != typeof(ApplicationUserClaim<string>)
                    && t.ClrType != typeof(ApplicationRoleClaim<string>)
                    && t.ClrType != typeof(ApplicationUserToken<string>)
                    && t.ClrType != typeof(ApplicationRole))
                   .SelectMany(t => t.GetProperties())
                   .Where(p => p.ClrType == typeof(string)))
            {
                var length = property.GetMaxLength();

                property.SetColumnType(length == null ? "varchar(max)" : string.Format("varchar({0})", length));
            }

        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                                 || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                                 || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        private static void LogQuery(string sql)
        {
            // This text is always added, making the file longer over time  if it is not deleted.
            using (StreamWriter sw = File.AppendText(@"C:\\logs\\BlogDbQueryLogs.sql"))
            {
                sw.WriteLine(sql);
            }
        }
    }
}
