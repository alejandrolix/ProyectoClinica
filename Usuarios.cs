using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    class Usuarios
    {
        #region Atributos y Propiedades

        private String _Nombre;
        private String _Password;

        public String Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }

        public String Password
        {
            get { return this._Password; }
            set { this._Password = value; }
        }

        #endregion


        #region Métodos        

        #endregion


        #region Constructor

        public Usuarios(String nombre, String password)
        {
            this.Nombre = nombre;
            this.Password = password;
        }

        #endregion
    }
}
