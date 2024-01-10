﻿using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochaStoreProyecto.Maui.Models
{
    [AddINotifyPropertyChangedInterface]

    public class Marca
    {
        public int idMarca { get; set; }
        public string nombreMarca { get; set; }
    }
}
