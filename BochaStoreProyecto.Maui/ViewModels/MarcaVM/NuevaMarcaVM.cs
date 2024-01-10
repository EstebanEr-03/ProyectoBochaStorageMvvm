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

    public class NuevaMarcaVM
    {

        public Marca _marca{ get; set; }//solo para crear

        // Define las variables locales que se utilizan en el código
        public string IdMarca { get; set; }
        public string NombreMarca { get; set; }

        private readonly APIService _APIService;
        public NuevaMarcaVM(APIService apiService)
        {
            _APIService = apiService;


        }
        public NuevaMarcaVM(APIService apiService, Marca marcaLLevo)
        {
            _APIService = apiService;
            _marca = marcaLLevo;
            NombreMarca = marcaLLevo.nombreMarca;
            //cargar 
        }



        public ICommand GuardarMarcaCommand => new Command(async () =>
        {
            if (_marca == null)
            {
                Marca marca = new Marca
                {
                    idMarca = 0,
                    nombreMarca = NombreMarca
                };

                await _APIService.PostMarca(marca);
            }
            else
            {
                _marca.nombreMarca = NombreMarca;

                await _APIService.PutMarca(_marca.idMarca, _marca);
            }

            await Application.Current.MainPage.Navigation.PopAsync();
        });
    }
}
