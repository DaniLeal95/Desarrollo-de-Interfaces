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
        public ObservableCollection<clsPersona> lista { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private DelegateCommand _eliminarCommand;
        private String textoaBuscar;

        public clsMainPageVM()
        {
           lista = new clsListado().list;
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
                OnPropertyChanged("personaSeleccionada");

            }
        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecuted);
                return _eliminarCommand;
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
            bool sePuedeBorrar = true;
            return sePuedeBorrar;
        }

        private void EliminarCommand_Executed()
        {
            lista.Remove(_personaSeleccionada);
        }
        #endregion
    }
}
