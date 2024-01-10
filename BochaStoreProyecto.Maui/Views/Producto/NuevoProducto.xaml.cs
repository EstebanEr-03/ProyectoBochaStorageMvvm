    namespace BochaStoreProyecto.Maui.Views.Producto;
using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.ViewModels.ProductoViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

using Producto = BochaStoreProyecto.Maui.Models.Producto;

public partial class NuevoProducto : ContentPage
{
    //private Producto _producto;
    private readonly APIService _APIService;
    private NuevoProductoViewModel _viewModel;
    
    public NuevoProducto(APIService apiservice,Producto ProductoSiExiste)
    {
        if (ProductoSiExiste == null)
        {
            InitializeComponent();
            _APIService = apiservice;
            _viewModel = new NuevoProductoViewModel(apiservice);
            BindingContext = _viewModel;
        }
        else
        {
            InitializeComponent();
            _APIService = apiservice;
            _viewModel = new NuevoProductoViewModel(apiservice, ProductoSiExiste);
            BindingContext = _viewModel;
        }
     

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var ProductoDelViewModel = _viewModel._producto;
        if (ProductoDelViewModel != null) {
            EntryNombre.Text = ProductoDelViewModel.nombreProducto;
            EntryDescripcion.Text = ProductoDelViewModel.descripcionProducto;
            EntryPrecio.Text = ProductoDelViewModel.precio.ToString();
            Entrystock.Text = ProductoDelViewModel.stock.ToString();
            EntryidProovedor.Text = ProductoDelViewModel.idProovedor.ToString();
            EntryidMarca.Text = ProductoDelViewModel.idMarca.ToString();
            EntryidMarca.Text = ProductoDelViewModel.idMarca.ToString();
            EntryfechaCreacion.Text= ProductoDelViewModel.fechaCreacion.ToString();
        }
        //setear campos con el producto traido si no es null
    }
}
    /*private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
    {

        if (_producto != null)
        {

            _producto.nombreProducto = EntryNombre.Text;
            _producto.descripcionProducto = EntryDescripcion.Text;
            _producto.precio = double.Parse(EntryPrecio.Text);
            _producto.stock = Int32.Parse(Entrystock.Text);
            _producto.idProovedor = Int32.Parse(EntryidProovedor.Text);
            _producto.idMarca = Int32.Parse(EntryidMarca.Text);
            _producto.fechaCreacion = DateTime.Now;
            await _APIService.PutProducto(_producto.idProducto, _producto);
        }
        else
        {
            int id = Utils.Utils.ProductosList.Count + 1;

            Producto producto = new Producto
            {
                idProducto = 0,
                nombreProducto = EntryNombre.Text,
                descripcionProducto = EntryDescripcion.Text,
                precio = double.Parse(EntryPrecio.Text),
                stock = Int32.Parse(Entrystock.Text),
                idProovedor= Int32.Parse(EntryidProovedor.Text),
                idMarca= Int32.Parse(EntryidMarca.Text),
                fechaCreacion = DateTime.Now
            };
            //Utils.Utils.ProductosList.Add(producto);
            await _APIService.PostProducto(producto);
        }
        await Navigation.PopAsync();
    }*/
