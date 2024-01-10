using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BochaStoreProyecto.Maui.ViewModels.ProductoViewModel
{
    [AddINotifyPropertyChangedInterface]
    
    public class DetailsProductoViewModel
    {
        private readonly APIService _APIService;
        public Producto _productoTraido { get; set; }
        public DetailsProductoViewModel(APIService apiService,Producto productoTraido)
        {
            _productoTraido = productoTraido;
            _APIService = apiService;

        }

        public ICommand ClickBorrarProducto=>
        new Command(async () =>
        {
            var idProductoBorrar = _productoTraido.idProducto;
            await _APIService.DeleteProducto(_productoTraido.idProducto);
            await App.Current.MainPage.Navigation.PopAsync();

        });

        public ICommand EditarProducto=>
        new Command(async () =>
        {
            var idProductoBorrar = _productoTraido.idProducto;
            await _APIService.DeleteProducto(idProductoBorrar);
            await App.Current.MainPage.Navigation.PopAsync();

        });
    }
}
