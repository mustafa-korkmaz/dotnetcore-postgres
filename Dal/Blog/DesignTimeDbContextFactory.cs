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
            optionsBuilder.UseNpgsql("Server=rajje.db.elephantsql.com;Port=5432;Database=czurcuic;User Id = czurcuic; Password=	JkuUawrR34f9bf_Gqp_7CEVWpRAtfIVT;CommandTimeout=20;");

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}
