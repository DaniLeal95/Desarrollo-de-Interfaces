using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;


using System.Globalization;
using Windows.UI.ViewManagement;

namespace ProyectoBarVCamarero.viewModel
{
    public class clsMainPageVM : clsVMBase 
    {
        private bool _progressring;
        /*private DelegateCommand _guardarCommand;
        private DelegateCommand _addCommand;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _buscarCommand;*/

        public String textoaBuscar { get; set; }

        public clsMainPageVM()
        {
            progessring = true;
            //Llamamos a un metodo asíncrono
        /*    rellenaLista();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
            _guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecuted);
            _addCommand = new DelegateCommand(addCommand_Executed);*/
            
        }

        #region getters&setters
        public bool progessring
        {
            get
            {
                return this._progressring;
            }
            set
            {
                this._progressring = value;
                NotifyPropertyChanged("progessring");
            }
        }

      /*
        public DelegateCommand guardarCommand
        {
           get
            {

            //    return _guardarCommand;
            }


        }

        public DelegateCommand addCommand
        {
            get
            {

              //  return _addCommand;
            }
        }
        public DelegateCommand EliminarCommand
        {
            get
            {
                
                //return _eliminarCommand;
            }

        
        }

        public DelegateCommand buscarCommand
        {
           get
            {
               // _buscarCommand = new DelegateCommand(buscarCommand_Executed);
              //  return _buscarCommand;
            }
        }*/
        #endregion
        #region funciones

        /// <summary>
        ///  Metodo para comprobar si puede ejecutarse el comando De eliminar
        /// </summary>
        /// <returns></returns>
        private bool EliminarCommand_CanExecuted()
        {
            bool sePuedeBorrar = false;

           //TODO : MODIFICAR
            return sePuedeBorrar;
        }

        /// <summary>
        /// Metodo para eliminar a una persona
        /// </summary>
        private async void EliminarCommand_Executed()
        {
            
            ContentDialog dialogo = new ContentDialog();
            dialogo.Title = "Eliminar";
            dialogo.Content = "¿Está seguro de que sea borrar?";
            dialogo.PrimaryButtonText = "Cancelar";
            dialogo.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await dialogo.ShowAsync();

           

        }

        private bool GuardarCommand_CanExecuted()
        {
            bool sePuedeGuardar = false;

            return sePuedeGuardar;
        }

       /* private async void GuardarCommand_Executed()
        {
            
        }*/

        private void addCommand_Executed()
        {
            
            
            //TODO : HACER
        }

        /*private async void rellenaLista()
        {
            
        }

        public async void buscarCommand_Executed()
        {
            
        }*/



        #endregion
    }
}
