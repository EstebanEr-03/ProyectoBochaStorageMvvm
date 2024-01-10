using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.Views.Producto;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PropertyChanged;

namespace BochaStoreProyecto.Maui.ViewModels.ProductoViewModel
{
    [AddINotifyPropertyChangedInterface]

    public partial class ProductoPageViewModel: ObservableObject
    {
        public ObservableCollection<Producto> Products { get; set; }
        public Producto selectedProduct { get; set; }

        public readonly APIService _APIService;
        public Producto productoNull = null;

        public ProductoPageViewModel()
        {

        }
        public ProductoPageViewModel(APIService apiservice)
        {
            _APIService = apiservice;
            Products = new ObservableCollection<Producto>();
        }

        [RelayCommand]

        public async void traerProductos()
        {
            var ListaProducts = await _APIService.GetProductos();
            foreach (var producto in ListaProducts)
            {
                 Products.Add(producto);
            }
        }
        public ICommand ClickNuevoProducto =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProducto(_APIService, productoNull));
            });
        public ICommand NavigateToDetailsCommand => new Command(async () =>
        {
            if (selectedProduct != null)
            {
                var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);
                await toast.Show();

                await App.Current.MainPage.Navigation.PushAsync(new DetailsProducto(_APIService, selectedProduct)
                {
                    BindingContext = selectedProduct,
                });

                // Limpia la selección después de la navegación
                selectedProduct = null;
            }
        });
    }
}
