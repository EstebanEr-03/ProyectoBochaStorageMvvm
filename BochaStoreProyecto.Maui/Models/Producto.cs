using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace BochaStoreProyecto.Maui.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Producto
    {
        public int idProducto { get; set; }
        public int idProovedor { get; set; }
        public int idMarca { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public DateTime fechaCreacion { get; set; }

    }
}
