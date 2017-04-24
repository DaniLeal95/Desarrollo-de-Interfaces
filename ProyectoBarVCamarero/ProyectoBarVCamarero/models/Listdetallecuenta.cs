using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
   public class Listdetallecuenta
    {
        #region Properties
        private Producto producto;
        private int cantidad;



        #endregion
        #region Builders
        public Listdetallecuenta(Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

        public Listdetallecuenta()
        {

        }
        #endregion
        #region Getters&Setters

        public Producto Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }
        #endregion
    }
}
