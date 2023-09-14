using Api_Productos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Productos_Catalogo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }

}
