using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductosAPI.Modelos
{
    [Table("productos")]
    public class Productos
    {
        [Key]
        public int id_prod { set; get; }
        public string nombre_prod { set; get; }
        public string descripcion_prod { set; get; }
        public double precio_prod { set; get; }

    }
}
