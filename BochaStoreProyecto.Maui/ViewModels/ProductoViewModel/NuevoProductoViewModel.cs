    using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace BochaStoreProyecto.Maui.ViewModels.ProductoViewModel
{
    [AddINotifyPropertyChangedInterface]

    public class NuevoProductoViewModel 
    {
        public Producto _producto { get; set; }//solo para crear
                                                
        // Define las variables locales que se utilizan en el código
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }
        public string IdProovedor { get; set; }
        public string IdMarca { get; set; }
        public string FechaCreacion { get; set; }


        private readonly APIService _APIService;
        public NuevoProductoViewModel(APIService apiService)
        {
            _APIService = apiService;

            
        }
        public NuevoProductoViewModel(APIService apiService,Producto productoLLevo)
        {
            _APIService = apiService;
            _producto = productoLLevo;
            NombreProducto = productoLLevo.nombreProducto;
            DescripcionProducto = productoLLevo.descripcionProducto;
            Precio = productoLLevo.precio.ToString();
            Stock = productoLLevo.stock.ToString();
            IdProovedor = productoLLevo.idProovedor.ToString();
            IdMarca = productoLLevo.idMarca.ToString();
            FechaCreacion= DateTime.Now.ToString();
            //cargar 
        }



        public ICommand GuardarProductoCommand => new Command(async () =>
        {
            if (_producto == null)
            {
                Producto producto = new Producto
                {
                    idProducto = 0,
                    nombreProducto = NombreProducto,
                    descripcionProducto = DescripcionProducto,
                    precio = double.Parse(Precio),
                    stock = int.Parse(Stock),
                    idProovedor = int.Parse(IdProovedor),
                    idMarca = int.Parse(IdMarca),
                    fechaCreacion = DateTime.Now
                };

                await _APIService.PostProducto(producto);
            }
            else
            {
                _producto.nombreProducto = NombreProducto;
                _producto.descripcionProducto = DescripcionProducto;
                _producto.precio = double.Parse(Precio);
                _producto.stock = int.Parse(Stock);
                _producto.idProovedor = int.Parse(IdProovedor);
                _producto.idMarca = int.Parse(IdMarca);
                _producto.fechaCreacion = DateTime.Now;

                await _APIService.PutProducto(_producto.idProducto, _producto);
            }

            await Application.Current.MainPage.Navigation.PopAsync();
        });
    }

}
