namespace BochaStoreProyecto.Maui.Views.Producto;
using CommunityToolkit.Maui.Core;
using BochaStoreProyecto.Maui.Services;
using Producto = BochaStoreProyecto.Maui.Models.Producto;
using BochaStoreProyecto.Maui.ViewModels.ProductoViewModel;

public partial class DetailsProducto : ContentPage
{
    //private Producto _producto;
    private APIService _APIService;
    private DetailsProductoViewModel _viewModel;
    public Producto productoTraido;


    public DetailsProducto(APIService apiservice,Producto producto)
    {
        InitializeComponent();
        productoTraido = producto;
        _APIService = apiservice;
        _viewModel = new DetailsProductoViewModel(_APIService, producto);
        BindingContext = _viewModel;
    }
    /*private async void Borrar_Clicked(object sender, EventArgs e)
    {
        if (productoTraido != null)
        {
            int idProductoToDelete = productoTraido.idProducto;

            if (await ConfirmDelete())
            {
                await _APIService.DeleteProducto(idProductoToDelete);
                await Navigation.PopAsync();
            }
        }

    }*/
    /*private async Task<bool> ConfirmDelete()
    {
        return await Application.Current.MainPage.DisplayAlert("Confirm Delete", "Are you sure you want to delete this product?", "Yes", "No");
    }*/

    private async void Editar_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new NuevoProducto(_APIService, _viewModel._productoTraido)
        {
            BindingContext = productoTraido,
        });
    }
}