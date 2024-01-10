namespace BochaStoreProyecto.Maui.Views.Marca;

using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.ViewModels.MarcaVM;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using Marca = BochaStoreProyecto.Maui.Models.Marca;

public partial class MarcaPage : ContentPage
{
    private readonly APIService _APIService;
    private MarcaPageVM _viewModel;

    public MarcaPage(APIService apiservice)
	{
        InitializeComponent();
        _APIService = apiservice;
        _viewModel = new MarcaPageVM(apiservice);
        BindingContext = _viewModel;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing(); 
        base.OnAppearing();
        _viewModel.Marcas.Clear();
        _viewModel.traerMarcas();
    }
    private async void OnClickShowDetails_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Marca marca)
        {
            var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver marca", ToastDuration.Short, 14);
            await toast.Show();

            await App.Current.MainPage.Navigation.PushAsync(new DetailsMarca(_APIService, marca));
        }

    ((ListView)sender).SelectedItem = null; // Deselecciona el elemento después de la navegación
    }
}