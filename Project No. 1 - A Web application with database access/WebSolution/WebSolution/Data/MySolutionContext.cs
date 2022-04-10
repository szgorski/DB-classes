using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSolution.Models;

namespace WebSolution.Data
{
    public class MySolutionContext : DbContext
    {
        public MySolutionContext (DbContextOptions<MySolutionContext> options)
            : base(options)
        {
        }

        public DbSet<WebSolution.Models.MOVIES> MOVIES { get; set; }
        public DbSet<WebSolution.Models.ORDERS> ORDERS { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MOVIES>().ToTable("MOVIES");
            modelBuilder.Entity<ORDERS>().ToTable("ORDERS");
        }
    }
}
