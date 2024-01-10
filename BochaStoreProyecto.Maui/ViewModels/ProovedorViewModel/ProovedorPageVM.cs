using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.Views.Proovedor;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BochaStoreProyecto.Maui.ViewModels.MarcaViewModel
{
    [AddINotifyPropertyChangedInterface]

    public partial class ProovedorPageVM : ObservableObject
    {
        public ObservableCollection<Proovedor> proovedores { get; set; }
        public Proovedor selectedProovedor { get; set; }

        public readonly APIService _APIService;
        public Proovedor proveedorNull = null;

        public ProovedorPageVM()
        {

        }
        public ProovedorPageVM(APIService apiservice)
        {
            _APIService = apiservice;
            proovedores = new ObservableCollection<Proovedor>();
        }

        [RelayCommand]

        public async void traerProovedores()
        {
            var listaProveedores = await _APIService.GetProovedor();
            foreach (var producto in listaProveedores)
            {
                proovedores.Add(producto);
            }
        }
        public ICommand ClickNuevoProovedor =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevoProovedor(_APIService, proveedorNull));
            });
        public ICommand NavigateToDetailsCommand => new Command(async () =>
        {
            if (selectedProovedor != null)
            {
                var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver proovedor", ToastDuration.Short, 14);
                await toast.Show();

                await App.Current.MainPage.Navigation.PushAsync(new DetailsProovedor(_APIService, selectedProovedor)
                {
                    BindingContext = selectedProovedor,
                });

                // Limpia la selección después de la navegación
                selectedProovedor = null;
            }
        });
    }
}
