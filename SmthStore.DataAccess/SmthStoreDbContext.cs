using Microsoft.EntityFrameworkCore;
using SmthStore.DataAccess.Entities;
using System.Security.Cryptography.X509Certificates;

namespace SmthStore.DataAccess
{
    public class SmthStoreDbContext : DbContext
    {
        public SmthStoreDbContext(DbContextOptions<SmthStoreDbContext> options) : base(options) { }

        public DbSet<SmthEntity> SmthEntities { get; set; }
    }
}
