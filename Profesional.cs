using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
    class Profesional
    {
        #region Atributos y Propiedades

        protected String _Nombre;
        protected String _Apellidos;
        protected String _DNI;
        protected List<Paciente> _Pacientes;

        public String Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }

        public String Apellidos
        {
            get { return this._Apellidos; }
            set { this._Apellidos = value; }
        }

        public String DNI
        {
            get { return this._DNI; }
            set { this._DNI = value; }
        }

        public List<Paciente> Pacientes
        {
            get { return this._Pacientes; }
            set { this._Pacientes = value; }
        }

        #endregion


        #region Métodos

        public void AnnadirPaciente(Paciente paciente)
        {
            this.Pacientes.Add(paciente);
            Console.Clear();
            Console.WriteLine("Paciente añadido.");

            System.Threading.Thread.Sleep(4000);
        }

        public void QuitarPaciente(Paciente paciente)
        {
            this.Pacientes.Remove(paciente);
            Console.Clear();
            Console.WriteLine("Paciente eliminado.");

            System.Threading.Thread.Sleep(4000);
        }

        public int CargaPacientes()
        {
            return this.Pacientes.Count;
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

            this.Pacientes = new List<Paciente>();
        }

        public Profesional(Profesional obj)
        {
            this.Nombre = obj.Nombre;
            this.Apellidos = obj.Apellidos;
            this.DNI = obj.DNI;

            this.Pacientes = obj.Pacientes;
        }

        #endregion
    }
}
