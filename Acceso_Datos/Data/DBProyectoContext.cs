using Microsoft.EntityFrameworkCore;
using Entidades.Models;

namespace Acceso_Datos.Data
{
    public class DBProyectoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DBProyectoContext() { }

        public DBProyectoContext(DbContextOptions<DBProyectoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "server=Localhost;database=DBProyectoCapas;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}
