namespace BochaStoreProyecto.Maui.Views.Marca;

using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.ViewModels.MarcaVM;
using BochaStoreProyecto.Maui.ViewModels.ProductoViewModel;
using Marca = BochaStoreProyecto.Maui.Models.Marca;

public partial class NuevaMarca : ContentPage
{

    private readonly APIService _APIService;
    private NuevaMarcaVM _viewModel;


    public NuevaMarca(APIService apiservice, Marca MarcaSiExiste)
	{
        if (MarcaSiExiste == null)
        {
            InitializeComponent();
            _APIService = apiservice;
            _viewModel = new NuevaMarcaVM(apiservice);
            BindingContext = _viewModel;
        }
        else
        {
            InitializeComponent();
            _APIService = apiservice;
            _viewModel = new NuevaMarcaVM(apiservice, MarcaSiExiste);
            BindingContext = _viewModel;
        }

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var ProductoDelViewModel = _viewModel._marca;
        if (ProductoDelViewModel != null)
        {
            EntryNombre.Text = ProductoDelViewModel.nombreMarca;
        }
    }
}