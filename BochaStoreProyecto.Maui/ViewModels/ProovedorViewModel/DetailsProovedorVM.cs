using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BochaStoreProyecto.Maui.ViewModels.ProovedorViewModel
{
    [AddINotifyPropertyChangedInterface]

    public class DetailsProovedorVM
    {
        public readonly APIService _APIService;
        public Proovedor _proovedorTraido { get; set; }
        public DetailsProovedorVM(APIService apiService, Proovedor proovedorTraido)
        {
            _APIService = apiService;
            _proovedorTraido = proovedorTraido;
        }

        public ICommand ClickBorrarProovedor =>
            new Command(async () =>
            {
                if (_APIService != null && _proovedorTraido != null)
                {
                    await _APIService.DeleteProovedor(_proovedorTraido.idProovedor);
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            });
    }
}
