using Microsoft.EntityFrameworkCore;
using Entidades.Models;
//esta parte lo hize
namespace Servicios.Data
{
    public class DBProyectoContext : DbContext
    {
        public DBProyectoContext(DbContextOptions<DBProyectoContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
