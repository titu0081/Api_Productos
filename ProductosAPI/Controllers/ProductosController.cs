using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosAPI.Contexto;
using ProductosAPI.Modelos;

namespace ProductosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbContexto _context;

        public ProductosController(DbContexto context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProducto()
        {
          if (_context.Producto == null)
          {
              return NotFound();
          }
            return await _context.Producto.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
          if (_context.Producto == null)
          {
              return NotFound();
          }
            var productos = await _context.Producto.FindAsync(id);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, Productos productos)
        {
            if (id != productos.id_prod)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
          if (_context.Producto == null)
          {
              return Problem("Entity set 'DbContexto.Producto'  is null.");
          }
            _context.Producto.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductos", new { id = productos.id_prod }, productos);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            if (_context.Producto == null)
            {
                return NotFound();
            }
            var productos = await _context.Producto.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(productos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosExists(int id)
        {
            return (_context.Producto?.Any(e => e.id_prod == id)).GetValueOrDefault();
        }
    }
}
