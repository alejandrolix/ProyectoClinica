using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
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

        public override string ToString()
        {
            return String.Format("Datos Tratamiento \n Descripción: {1} \n", this.Descripcion);
        }

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
