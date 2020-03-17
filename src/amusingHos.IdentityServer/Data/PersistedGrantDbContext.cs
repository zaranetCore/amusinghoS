using amusinghoS.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amusingHos.IdentityServer.Data
{
    public class PersistedGrantDbContext : DbContext
    {
        public PersistedGrantDbContext() 
        {
        
        }
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
        }
    }
}
