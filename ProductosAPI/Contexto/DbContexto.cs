using Microsoft.EntityFrameworkCore;
using ProductosAPI.Modelos;

namespace ProductosAPI.Contexto
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options)
        : base(options)
        {
        }

        public DbSet<Productos> Producto { get; set; }

    }
}
