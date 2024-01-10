using BochaStoreProyecto.Maui.Models;
using BochaStoreProyecto.Maui.Services;
using BochaStoreProyecto.Maui.Views.Marca;
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

namespace BochaStoreProyecto.Maui.ViewModels.MarcaVM
{
    [AddINotifyPropertyChangedInterface]

    public partial class MarcaPageVM: ObservableObject
    {
        public ObservableCollection<Marca> Marcas { get; set; }
        public Marca selectedMarca { get; set; }

        public readonly APIService _APIService;
        public Marca marcaNull = null;

        public MarcaPageVM()
        {

        }
        public MarcaPageVM(APIService apiservice)
        {
            _APIService = apiservice;
            Marcas = new ObservableCollection<Marca>();
        }

        [RelayCommand]

        public async void traerMarcas()
        {
            var ListaMarcas = await _APIService.GetMarca();
            foreach (var marca in ListaMarcas)
            {
                Marcas.Add(marca);
            }
        }
        public ICommand ClickNuevaMarca =>
            new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new NuevaMarca(_APIService, marcaNull));
            });
        public ICommand NavigateToDetailsCommand => new Command(async () =>
        {
            if (selectedMarca != null)
            {
                var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);
                await toast.Show();

                await App.Current.MainPage.Navigation.PushAsync(new DetailsMarca(_APIService, selectedMarca)
                {
                    BindingContext = selectedMarca,
                });

                // Limpia la selección después de la navegación
                selectedMarca = null;
            }
        });
    }
}
