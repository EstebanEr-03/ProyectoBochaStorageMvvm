namespace BochaStoreProyecto.Maui.Views.Producto;

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using BochaStoreProyecto.Maui.Services;
using System.Collections.ObjectModel;

using Producto = BochaStoreProyecto.Maui.Models.Producto;
using BochaStoreProyecto.Maui.ViewModels.ProductoViewModel;

public partial class ProductoPage : ContentPage
{
    //ObservableCollection<Producto> products;
    private readonly APIService _APIService;
    private ProductoPageViewModel _viewModel;

    public ProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _viewModel = new ProductoPageViewModel(apiservice);
        BindingContext = _viewModel;
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Products.Clear();
        _viewModel.traerProductos();
        /*string username = "BOCHASTORE";
        Username.Text = username;
        List<Producto> ListaProducts = await _APIService.GetProductos();
        products = new ObservableCollection<Producto>(ListaProducts);
        listaProductos.ItemsSource = products;*/

    }

    /*private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevoProducto(_APIService));

        //await Navigation.PushAsync(new NuevoProducto());
    }*/

    private async void OnClickShowDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Producto producto)
        {
            var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);
            await toast.Show();

            await App.Current.MainPage.Navigation.PushAsync(new DetailsProducto(_APIService, producto));
        }

        ((ListView)sender).SelectedItem = null; // Deselecciona el elemento después de la navegación
    }
}