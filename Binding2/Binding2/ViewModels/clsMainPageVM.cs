using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Binding2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml;
using _13_DataContext.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace Binding2.ViewModels
{
    public class clsMainPageVM:clsVMBase
    {
        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _lista;
        
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _buscarCommand;
        private String textoaBuscar;

        public clsMainPageVM()
        {
            //lista = new clsListado().list;
            //Llamamos a un metodo asíncrono
            rellenaLista();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
        }

        private async void rellenaLista()
        {
            clsListado olistados = new clsListado();
            lista = await olistados.getPersonas();
            NotifyPropertyChanged("lista");
        }

        #region getters&setters
        public clsPersona  personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }

            set
            {
                _personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");

            }
        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                
                return _eliminarCommand;
            }

        
        }

        public DelegateCommand buscarCommand
        {
            get
            {
                _buscarCommand = new DelegateCommand(buscarCommand_Executed);
                return _buscarCommand;
            }
        }

        public ObservableCollection<clsPersona> lista
        {
            get
            {
                return this._lista;
            }
            set
            {
                this._lista = value;
                NotifyPropertyChanged("lista");
                
            }
        }
        #endregion
        #region funciones

 

        public void btnborrar_Click(Object sender, RoutedEventArgs e)
        {
            lista.Remove(_personaSeleccionada);
        }

        private bool EliminarCommand_CanExecuted()
        {
            bool sePuedeBorrar = false;

            if (_personaSeleccionada != null){ sePuedeBorrar = true; }
            return sePuedeBorrar;
        }

        /*  private bool BuscarCommand_CanExecuted()
          {

          }*/

        private async void EliminarCommand_Executed()
        {
            HttpStatusCode respuesta;
            ContentDialog dialogo = new ContentDialog();
            dialogo.Title = "Eliminar";
            dialogo.Content = "¿Estña seguro de que sea borrar?";
            dialogo.PrimaryButtonText = "Cancelar";
            dialogo.SecondaryButtonText = "Aceptar";

            ContentDialogResult resultado = await dialogo.ShowAsync();

            if(resultado == ContentDialogResult.Secondary)
            {
                try { }
                catch (Exception) { }
            }
            lista.Remove(_personaSeleccionada);
            personaSeleccionada = null;
        }


        public void buscarCommand_Executed()
        {
            if (!String.IsNullOrEmpty(textoaBuscar))
            {
                var listarFiltrada = from p in _lista where p.nombre.StartsWith(textoaBuscar) select p;
                lista = new ObservableCollection<clsPersona>(listarFiltrada);
            }
            else
            {
                lista = new ObservableCollection<clsPersona>(lista);
            }
            
           NotifyPropertyChanged("lista");
        }
        #endregion
    }
}
