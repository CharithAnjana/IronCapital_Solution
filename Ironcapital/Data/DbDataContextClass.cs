using Ironcapital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ironcapital.Data
{
    public class DbDataContextClass : DbContext
    {
        public DbDataContextClass(DbContextOptions<DbDataContextClass> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyNowClass>()
                .HasOne(p => p.TokenClass)
                .WithMany(b => b.BuyNowClasses);
        }

        public DbSet<TokenClass> Token { get; set; }

        public DbSet<BuyNowClass> BuyNow { get; set; }


    }
}
