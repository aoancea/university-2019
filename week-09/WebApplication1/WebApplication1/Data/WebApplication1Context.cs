using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }

        public DbSet<Models.Value> Values { get; set; }

        public DbSet<Models.Duckbill> Duckbills { get; set; }

        public DbSet<Models.DuckbillFriend> DuckbillFriends { get; set; }
    }
}