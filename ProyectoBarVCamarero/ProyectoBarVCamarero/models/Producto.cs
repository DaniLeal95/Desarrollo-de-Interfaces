using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBarVCamarero.models
{
    public class Producto
    {
        #region Properties
        
        private int _id;
        
        private String _nombre;
        
        private double _precio;
        
        private int _idcategoria;
        #endregion
        #region Builders
        public Producto()
        {

        }

        public Producto(int _id, string _nombre, double _precio, int _idcategoria)
        {
            this._id = _id;
            this._nombre = _nombre;
            this._precio = _precio;
            this._idcategoria = _idcategoria;
        }



        #endregion
        #region Getters&Setters
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public double Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                _precio = value;
            }
        }

        public int Idcategoria
        {
            get
            {
                return _idcategoria;
            }

            set
            {
                _idcategoria = value;
            }
        }

        #endregion

    }
}
