using Gestion_Destinataire.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Destinataire.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Destinataire> Destinataires { get; set; }
    }

}
