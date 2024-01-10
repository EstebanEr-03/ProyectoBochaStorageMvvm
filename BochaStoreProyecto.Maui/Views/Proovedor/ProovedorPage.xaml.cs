namespace BochaStoreProyecto.Maui.Views.Proovedor;

using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.ViewModels.MarcaViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using Proovedor = BochaStoreProyecto.Maui.Models.Proovedor;

public partial class ProovedorPage : ContentPage
{
    private ProovedorPageVM _viewModel;
    private readonly APIService _APIService;

    public ProovedorPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
        _viewModel = new ProovedorPageVM(apiservice);
        BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.proovedores.Clear();
        _viewModel.traerProovedores();

    }

    /*private async void OnClickNuevoProveedor(object sender, EventArgs e)
    {
        var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevoProovedor(_APIService));
    }*/

    private async void OnClickShowDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Proovedor proovedor)
        {
            var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver proovedor", ToastDuration.Short, 14);
            await toast.Show();

            await App.Current.MainPage.Navigation.PushAsync(new DetailsProovedor(_APIService, proovedor));
        }

        ((ListView)sender).SelectedItem = null; // Deselecciona el elemento después de la navegación
    }
}