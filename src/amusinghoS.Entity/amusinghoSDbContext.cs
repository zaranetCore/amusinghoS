using System;
using System.Collections.Generic;
using System.Text;
using amusinghoS.EntityData.Model;
using amusinghoS.Shared;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;

namespace amusinghoS.EntityData
{
    public class amusinghoSDbContext : DbContext
    {
        #region 构造方法
        public amusinghoSDbContext(DbContextOptions<amusinghoSDbContext> options) : base(options) { }
        public amusinghoSDbContext() { } //非注入构造方式
        #endregion

        public DbSet<amusingHosUser> amusingHosUsers { get; set; }
        public DbSet<amusingArticle> amusingArticles { get; set; }
        public DbSet<amusingArticleDetails> amusingArticleDetails { get; set; }

        public DbSet<amusingArticleComment> amusingArticleComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            base.OnConfiguring(dbContextOptionsBuilder);

            if (!dbContextOptionsBuilder.IsConfigured)
            {
                string connection = DESEncryptHelper.Decrypt(
                        "wHMoKdCHCsMzxDTTN9+KOGSDC4JDdwxpukgfD+OGDS6W10AAz9lZac3QctGhAr+o1KGJbkuCLwdT4DXj/EM6eLnLKeVRATxDh21b0Jumpb8="
                    , "12345678");
                dbContextOptionsBuilder.UseMySql(
                    connectionString: connection);
            }
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
