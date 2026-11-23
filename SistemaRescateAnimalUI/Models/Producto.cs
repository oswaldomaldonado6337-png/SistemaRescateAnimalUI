
namespace SistemaRescateAnimal.Models
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool EsActivo { get; set; }
    }
}