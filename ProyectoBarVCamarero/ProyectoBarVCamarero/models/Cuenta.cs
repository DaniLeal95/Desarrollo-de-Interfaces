using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
    public class Cuenta
    {
        #region Properties
        private int idcuenta;
        private int nummesa;
        private IList<Listdetallecuenta> listdetallecuenta;
        private string fecha;
        private double preciofinal;
        private int finalizada;
        #endregion
        #region Builders
        public Cuenta(int idcuenta, int nummesa, IList<Listdetallecuenta> listdetallecuenta, string fecha, double preciofinal, int finalizada)
        {
            this.idcuenta = idcuenta;
            this.nummesa = nummesa;
            this.listdetallecuenta = listdetallecuenta;
            this.fecha = fecha;
            this.preciofinal = preciofinal;
            this.finalizada = finalizada;
        }
        public Cuenta()
        {

        }
        #endregion
        #region Getters&Setters

        public int Idcuenta
        {
            get
            {
                return idcuenta;
            }

            set
            {
                idcuenta = value;
            }
        }

        public int Nummesa
        {
            get
            {
                return nummesa;
            }

            set
            {
                nummesa = value;
            }
        }

        public IList<Listdetallecuenta> Listdetallecuenta
        {
            get
            {
                return listdetallecuenta;
            }

            set
            {
                listdetallecuenta = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public double Preciofinal
        {
            get
            {
                return preciofinal;
            }

            set
            {
                preciofinal = value;
            }
        }

        public int Finalizada
        {
            get
            {
                return finalizada;
            }

            set
            {
                finalizada = value;
            }
        }
        #endregion
    }
}
