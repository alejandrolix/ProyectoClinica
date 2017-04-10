using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clínica
{
    class Tratamiento
    {
        #region Atributo y Propiedad

        private String _Descripcion;

        public String Descripcion
        {
            get { return this._Descripcion; }
            set { this._Descripcion = value; }
        }

        #endregion


        #region Métodos

        #endregion


        #region Constructores

        public Tratamiento()
        {
            
        }

        public Tratamiento(String descripcion)
        {
            this.Descripcion = descripcion;
        }

        public Tratamiento(Tratamiento obj)
        {
            this.Descripcion = obj.Descripcion;
        }

        #endregion
    }
}
