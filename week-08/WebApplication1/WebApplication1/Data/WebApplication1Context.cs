using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public DbSet<Models.Value> Value { get; set; }

        public DbSet<Models.Duckbill> Duckbills { get; set; }

        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }
    }
}