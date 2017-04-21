using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ProgramaClinica
{
    [Serializable]
    class Usuario
    {
        #region Atributos y Propiedades

        private String _Nombre;
        private String _Password;
        private int _Numero;

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
        public int Numero
        {
            get { return this._Numero; }
            set { this._Numero = value; }
        }

        #endregion                       
        

        #region Constructor

        public Usuario()
        {

        }

        public Usuario(String nombre, String password, int numero)
        {
            this.Nombre = nombre;
            this.Password = password;
            this.Numero = numero;
        }

        public Usuario(Usuario obj)
        {
            this.Nombre = obj.Nombre;
            this.Password = obj.Password;
            this.Numero = obj.Numero;
        }

        #endregion
    }
}
