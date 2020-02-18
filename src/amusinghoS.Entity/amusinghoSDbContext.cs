using System;
using System.Collections.Generic;
using System.Text;
using amusinghoS.EntityData.Model;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

namespace amusinghoS.EntityData
{
    public class amusinghoSDbContext : DbContext
    {
        public DbSet<amusingHosUser> amusingHosUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseMySql(
                connectionString: "server=39.104.53.29;uid=zaranet;pwd=123456;database=amusinghoS");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //You can use Fluent API override your Entity.
            modelBuilder.Entity<amusingHosUser>()
                .HasKey(k => new { k.userId });
            modelBuilder.Entity<amusingHosUser>()
                .Property(p => p.PassWord).HasMaxLength(18);
        }
    }
}
