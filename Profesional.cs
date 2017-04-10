using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clínica
{
    class Profesional
    {
        #region Atributos

        protected String Nombre;
        protected String Apellidos;
        protected String DNI;

        #endregion


        #region Métodos

        public void AnnadirPaciente()
        {

        }

        public void QuitarPaciente()
        {

        }

        public void CargaPaciente()
        {

        }

        public void MostrarNumPacientesAsignados()
        {

        }

        #endregion


        #region Constructores

        public Profesional()
        {

        }

        public Profesional(String nombre, String apellidos, String dni)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.DNI = dni;
        }

        public Profesional(Profesional obj)
        {
            this.Nombre = obj.Nombre;
            this.Apellidos = obj.Apellidos;
            this.DNI = obj.DNI;
        }

        #endregion
    }
}
