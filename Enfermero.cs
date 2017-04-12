using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
    class Enfermero : Profesional
    {        
        #region Métodos

        public void MostrarDiagTratamPaciente()
        {

        }

        #endregion


        #region Constructores

        public Enfermero() : base()
        {

        }

        public Enfermero(String nombre, String apellidos, String dni) : base(nombre, apellidos, dni)
        {

        }

        public Enfermero(Enfermero obj) : base(obj)
        {

        }

        #endregion
    }
}
