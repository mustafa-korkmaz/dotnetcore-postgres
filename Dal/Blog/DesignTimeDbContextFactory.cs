using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dal.Blog
{
    /// <summary>
    /// for ef migrations and updates
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseNpgsql("Server=drona.db.elephantsql.com;Port=5432;Database=tevebsox;User Id = tevebsox; Password=getD8DW32cQ1edBnc9yKh-palbsz3g-y;CommandTimeout=20;");

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}
