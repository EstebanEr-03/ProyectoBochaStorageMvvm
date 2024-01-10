using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.Views;
using BochaStoreProyecto.Maui.Views.Producto;
using BochaStoreProyecto.Maui.Views.Proovedor;

namespace BochaStoreProyecto.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService apiservice = new APIService();

            var flyoutPage = new FlyoutPageT(apiservice);
            //flyoutPage.Detail = new NavigationPage(new ProductoPage(apiservice)); // Define la página principal aquí

            MainPage =new NavigationPage(new ProductoPage(apiservice));
           // MainPage = flyoutPage;

            //MainPage = new FlyoutPageT(apiservice);
            //MainPage = new NavigationPage(new LoginPage(apiservice));
            //MainPage = new NavigationPage(new ProovedorPage(apiservice));
        }
    }
}
