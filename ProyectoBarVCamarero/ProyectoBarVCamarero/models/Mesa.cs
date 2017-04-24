using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
    public class Mesa
    {

        #region Properties

        private int _nummesa;

        private string _codigo;

        private int _disponibilidad;
        #endregion

        #region Builders
        public Mesa(int _nummesa, string _codigo, int _disponibilidad)
        {
            this._nummesa = _nummesa;
            this._codigo = _codigo;
            this._disponibilidad = _disponibilidad;
        }
        public Mesa()
        {
          
        }
        #endregion

        #region Getters&Setters
        public int Nummesa
        {
            get
            {
                return _nummesa;
            }

            set
            {
                _nummesa = value;
            }
        }

        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public int Disponibilidad
        {
            get
            {
                return _disponibilidad;
            }

            set
            {
                _disponibilidad = value;
            }
        } 
        #endregion
    }
}
