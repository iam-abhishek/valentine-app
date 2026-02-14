
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace myvapp.Data
{
    public class LoveDbContextFactory : IDesignTimeDbContextFactory<LoveDbContext>
    {
        public LoveDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LoveDbContext>();
            optionsBuilder.UseSqlite("Data Source=love.db");

            return new LoveDbContext(optionsBuilder.Options);
        }
    }
}

