using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _Binding2.Models
{

  public class clsPersona:INotifyPropertyChanged
    {
        //propiedades y Getters/Setters
        private String _nombre { get; set; }
        private String _apellido { get; set; }
        private DateTime? _fNac { get; set; }
        private String _telefono { get; set; }
        private String _detalles;

        public event PropertyChangedEventHandler PropertyChanged;

        //constructores
        public clsPersona(String nombre, String apellido, DateTime fNac,String telefono, String detalles)
        {

            this._nombre = nombre;
            this._apellido = apellido;
            this._fNac = fNac;
            this._telefono = telefono;
            this._detalles = detalles; 
           
        }

        public clsPersona()
        {
            this._nombre = null;
            this._apellido = null;
            this._fNac = null;
            this._telefono = null;
            this._detalles = null; 
        }

        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                this._nombre = value;
                OnPropertyChanged("nombre");
            }
        }

        public String apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                this._apellido = value;
                OnPropertyChanged("apellido");
            }
        }

        public DateTime? fNac
        {
            get
            {
                return this._fNac;
            }
            set
            {
                this._fNac = value;
                OnPropertyChanged("Fnac");
            }
        }

        public String telefono
        {
            get
            {
                return this._telefono;
            }
            set
            {
                this._telefono = value;
                OnPropertyChanged("telefono");
            }
        }

        public String detalles
        {
            get
            {
                return this._detalles;
            }
            set
            {
                this._detalles = detalles;
                OnPropertyChanged("detalles");
            }
        }


        override
        public String ToString()
        {
            return ("Nombre: "+this.nombre+" , Apellidos: "+this.apellido);
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
