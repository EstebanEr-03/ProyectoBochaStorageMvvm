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

    public class NuevoProovedorVM
    {
        public Proovedor _proovedor { get; set; }//solo para crear

        // Define las variables locales que se utilizan en el código
        public string IdProovedor { get; set; }
        public string NombreProovedor { get; set; }
        public string DuracionContrato { get; set; }
        public string PrecioImportacion { get; set; }

        private readonly APIService _APIService;
        public NuevoProovedorVM(APIService apiService)
        {
            _APIService = apiService;


        }
        public NuevoProovedorVM(APIService apiService, Proovedor proovedorLLevo)
        {
            _APIService = apiService;
            _proovedor = proovedorLLevo;
            NombreProovedor = proovedorLLevo.nombreProovedor;
            DuracionContrato = proovedorLLevo.duracionContrato.ToString();
            PrecioImportacion = proovedorLLevo.precioImportacion.ToString();
            //cargar 
        }



        public ICommand GuardarProovedorCommand => new Command(async () =>
        {
            if (_proovedor == null)
            {
                Proovedor proovedor = new Proovedor
                {
                    idProovedor = 0,
                    nombreProovedor = NombreProovedor,
                    duracionContrato = int.Parse(DuracionContrato),
                    precioImportacion = double.Parse(PrecioImportacion)
                };

                await _APIService.PostProovedor(proovedor);
            }
            else
            {
                _proovedor.nombreProovedor = NombreProovedor;
                _proovedor.duracionContrato = int.Parse(DuracionContrato);
                _proovedor.precioImportacion = double.Parse(PrecioImportacion);

                await _APIService.PutProovedor(_proovedor.idProovedor, _proovedor);
            }

            await Application.Current.MainPage.Navigation.PopAsync();
        });
    }
}
