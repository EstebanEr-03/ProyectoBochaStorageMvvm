using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BochaStoreProyecto.Maui.ViewModels.MarcaVM
{
    [AddINotifyPropertyChangedInterface]

    internal class DetailsMarcaVM
    {
        public readonly APIService _APIService;
        public Marca _marcaTraido { get; set; }
        public DetailsMarcaVM(APIService apiService, Marca marcaTraido)
        {
            _APIService = apiService;
            _marcaTraido = marcaTraido;
        }

        public ICommand ClickBorrarMarca =>
            new Command(async () =>
            {
                if (_APIService != null && _marcaTraido != null)
                {
                    await _APIService.DeleteMarca(_marcaTraido.idMarca);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
    }
}
