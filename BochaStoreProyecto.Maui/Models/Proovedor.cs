using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochaStoreProyecto.Maui.Models
{
    [AddINotifyPropertyChangedInterface]

    public class Proovedor
    {
        public int idProovedor { get; set; }

        public string nombreProovedor { get; set; }

        public int duracionContrato { get; set; }

        public double precioImportacion { get; set; }
    }
}
