using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Examen1Evaluacion
{
    public class MainPageVM : clsVMBase
    {


        private ObservableCollection<Carta> _lista;
        private Carta _cartaSeleccionada;
        private Carta _cartaaux;
        private int parejasencontradas;
        private bool _haganado;
        private bool _clickeable;
        private DelegateCommand _reset;
        private MainPage pagina;

        private DelegateCommand _reiniciar;

        public MainPageVM()
        {
            _reiniciar = new DelegateCommand(ResetCommand_Executed, ResetCommand_CanExecuted);
            _lista = new Listado().list;
            NotifyPropertyChanged("lista");
            parejasencontradas = 0;
            _haganado = false;
            NotifyPropertyChanged("haganado");
            _clickeable = true;
            NotifyPropertyChanged("clickeable");
            
        }

        private bool ResetCommand_CanExecuted()
        {
            return true;
        }

        private void ResetCommand_Executed()
        {
            new MainPageVM();
        }

        #region getters&setters

        public bool clickeable
        {
            get
            {
                return this._clickeable;
            }
            set
            {
                this._clickeable = value;
                NotifyPropertyChanged("clickeable");
            }
        }

        public DelegateCommand reiniciar
        {
            get
            {
                return this._reiniciar;
            }
        }

        public Carta cartaSeleccionada
        {
            get
            {
                return this._cartaSeleccionada;
            }
            set
            {
                
                if (_cartaSeleccionada == null || _cartaSeleccionada!=_cartaaux)
                {
                    this._cartaSeleccionada = value;
                    
                    
                      
                    _cartaSeleccionada.uri = this.cambiaFoto(cartaSeleccionada.nombre);
                        
                    
                   
                    NotifyPropertyChanged("cartaSeleccionada");
                    _cartaaux = _cartaSeleccionada;
                    
                    
                }

                else
                {
                    _cartaSeleccionada = value;

                    if (!(_cartaSeleccionada == _cartaaux) )
                    {
                        _cartaSeleccionada.uri = this.cambiaFoto(cartaSeleccionada.nombre);
                        
                        NotifyPropertyChanged("cartaSeleccionada");

                    }
                    this.retrasasegundo();
                }
            }
        }

     

        public bool haganado
        {
            get
            {
                return this._haganado;
            }
            set
            {
                this._haganado = value;
                NotifyPropertyChanged("haganado");
            }
        }
        public Carta cartaaux
        {
            get
            {
                return this._cartaaux;
            }
            set
            {
                this._cartaaux = value;

            }
        }

        public ObservableCollection<Carta> lista
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

        /// <summary>
        /// Metodo para cambiar la foto de default a la original
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Uri cambiaFoto(String nombre)
        {
            Uri uri = null;

            switch (nombre)
            {
                case "AR-15" :
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/AR-15.jpg", UriKind.Absolute);
                    break;
                case "Ballesta":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Ballesta.jpg", UriKind.Absolute);
                    break;
                case "Colt":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Colt.jpg", UriKind.Absolute);
                    break;
                case "Daryl":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Daryl.jpg", UriKind.Absolute);
                    break;
                case "Katana":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Katana.jpg", UriKind.Absolute);
                    break;
                case "Lucille":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Lucille.jpg", UriKind.Absolute);
                    break;
                case "Martillo":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Martillo.jpg", UriKind.Absolute);
                    break;
                case "Michonne":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Michonne.jpg", UriKind.Absolute);
                    break;
                case "Negan":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Negan.jpg", UriKind.Absolute);
                    break;
                case "Rick":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Rick.jpg", UriKind.Absolute);
                    break;
                case "Sasha":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Sasha.jpg", UriKind.Absolute);
                    break;
                case "Tyreese":
                    uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/Tyreese.jpg", UriKind.Absolute);
                    break;
            }

            return uri;
           
        }


        /// <summary>
        /// Metodo asincrono que retrasa la instruccion siguiente 1 segundo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void retrasasegundo()
        {
            clickeable = false;
            
            await Task.Delay(1000);
            clickeable = true;
            

            if (_cartaaux.id == _cartaSeleccionada.id)
            {
                parejasencontradas++;
            }else
            {
                _cartaSeleccionada.uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute);
                
                NotifyPropertyChanged("cartaSeleccionada");
                
                
                _cartaSeleccionada = _cartaaux;
                _cartaSeleccionada.uri = new Uri("ms-appx://_Examen1Evaluacion/Fotos/logo.png", UriKind.Absolute);
                
                NotifyPropertyChanged("cartaSeleccionada");
                
                _cartaSeleccionada = null;
                _cartaaux = null;
                NotifyPropertyChanged("cartaSeleccionada");
            }

            if (parejasencontradas == 6)
            {
                haganado = true;
               
            }
        }

        /// <summary>
        /// Metodo que comprueba que los ids sean iguales.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public bool iguales(Carta c1,Carta c2)
        {
            bool igual = false;
            if (c1.id == c2.id)
            {
                igual = true;
            }
            return igual;
        }
    }
}
