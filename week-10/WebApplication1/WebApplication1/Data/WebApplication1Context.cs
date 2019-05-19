using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class WebApplication1Context : IdentityDbContext
    {
        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
             : base(options)
        {
        }

        public DbSet<Models.Value> Values { get; set; }

        public DbSet<Models.Duckbill> Duckbills { get; set; }
    }
}
