using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clínica
{
    class Clinica
    {
        #region Atributos y Propiedades

        private String _Direccion;
        private String _Nombre;
        private String _Telefono;

        public String Direccion
        {
            get { return this._Direccion; }
            set { this._Direccion = value; }
        }

        public String Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }

        public String Telefono
        {
            get { return this._Telefono; }
            set { this._Telefono = value; }
        }

        #endregion


        #region Métodos

        public void AnnadirMedico()
        {

        }

        public void AnnadirEnfermero()
        {

        }

        public void BorrarMedico()
        {

        }

        public void BorrarEnfermero()
        {

        }

        public void BuscarHabitacion(String p1)
        {

        }

        public void BuscarMedico()
        {

        }

        public void AsignarHabitacion()
        {

        }

        public void AsignarMedico()
        {

        }

        public void PacientesListosParaAlta()
        {

        }

        #endregion


        #region Constructores

        public Clinica()
        {

        }

        public Clinica(String direccion, String nombre, String telefono)
        {
            this.Direccion = direccion;
            this.Nombre = nombre;
            this.Telefono = telefono;
        }

        public Clinica(Clinica obj)
        {
            this.Direccion = obj.Direccion;
            this.Nombre = obj.Nombre;
            this.Telefono = obj.Telefono;
        }

        #endregion
    }
}
