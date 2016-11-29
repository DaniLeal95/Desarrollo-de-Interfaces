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

namespace Binding2.ViewModels
{
    public class clsMainPageVM:INotifyPropertyChanged
    {
        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _lista;
        public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _eliminarCommand;
        private DelegateCommand _buscarCommand;
        private String textoaBuscar;

        public clsMainPageVM()
        {
           lista = new clsListado().list;
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
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
                OnPropertyChanged("personaSeleccionada");

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
                OnPropertyChanged("_lista");
                
            }
        }
        #endregion
        #region funciones

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

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

        private void EliminarCommand_Executed()
        {
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
            
           INotifyPropertyChanged("lista");
        }
        #endregion
    }
}
