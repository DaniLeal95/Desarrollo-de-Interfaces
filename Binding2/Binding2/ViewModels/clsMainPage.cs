using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Binding2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Binding2.ViewModels
{
    public class clsMainPage:INotifyPropertyChanged
    {
        private clsPersona _personaSeleccionada;
        public ObservableCollection<clsPersona> lista { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public clsMainPage()
        {
           lista = new clsListado().list;
        }

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

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
