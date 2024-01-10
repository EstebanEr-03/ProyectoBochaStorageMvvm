namespace BochaStoreProyecto.Maui.Views.Marca;

using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.ViewModels.MarcaVM;
using Marca = BochaStoreProyecto.Maui.Models.Marca;

public partial class DetailsMarca : ContentPage
{
    private APIService _APIService;
    private DetailsMarcaVM _viewModel;
    private Marca marcaTraido;

    public DetailsMarca(APIService apiservice,Marca marca)
	{
		InitializeComponent();
        marcaTraido = marca;
        _APIService = apiservice;
        _viewModel = new DetailsMarcaVM(_APIService, marca);
        BindingContext = _viewModel;
    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new NuevaMarca(_APIService, _viewModel._marcaTraido));
    }
}