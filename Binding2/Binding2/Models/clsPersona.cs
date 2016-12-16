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
        private DateTime? _fechaNac { get; set; }
        private String _telefono { get; set; }
        private String _direccion;

        public event PropertyChangedEventHandler PropertyChanged;

        //constructores
        public clsPersona(String nombre, String apellido, DateTime fechaNac, String telefono, String direccion)
        {

            this._nombre = nombre;
            this._apellido = apellido;
            this._fechaNac = fechaNac;
            this._telefono = telefono;
            this._direccion = direccion; 
           
        }

        public clsPersona()
        {
            this._nombre = null;
            this._apellido = null;
            this._fechaNac = null;
            this._telefono = null;
            this._direccion = null; 
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

        public DateTime? fechaNac
        {
            get
            {
                return this._fechaNac;
            }
            set
            {
                this._fechaNac = value;
                OnPropertyChanged("fechaNac");
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

        public String direccion
        {
            get
            {
                return this._direccion;
            }
            set
            {
                this._direccion = value;
                OnPropertyChanged("direccion");
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
