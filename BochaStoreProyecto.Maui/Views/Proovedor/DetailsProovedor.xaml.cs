namespace BochaStoreProyecto.Maui.Views.Proovedor;

using CommunityToolkit.Maui.Core;
using BochaStoreProyecto.Maui.Services;
using Proovedor = BochaStoreProyecto.Maui.Models.Proovedor;
using BochaStoreProyecto.Maui.ViewModels.ProovedorViewModel;

public partial class DetailsProovedor : ContentPage
{
    private DetailsProovedorVM _viewModel;
    private APIService _APIService;
    private Proovedor _proovedorTraido;

    public DetailsProovedor(APIService apiservice,Proovedor proovedor)
	{   
		InitializeComponent();
        _proovedorTraido=proovedor;
        _APIService = apiservice;
        _viewModel = new DetailsProovedorVM(_APIService, proovedor);
        BindingContext = _viewModel;
    }
    private async void Editar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProovedor(_APIService, _viewModel._proovedorTraido)
        {
            BindingContext = _proovedorTraido,
        });
    }
}