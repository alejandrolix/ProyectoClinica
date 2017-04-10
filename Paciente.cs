using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clínica
{
    class Paciente
    {
        #region Atributos y Propiedades

        private String _SIP;
        private String _Nombre;
        private String _Apellidos;
        private String _Sexo;
        private DateTime _FechaNacimiento;
        private ushort _Edad;
        private List<Diagnostico> _Diagnosticos;

        public String SIP
        {
            get { return this._SIP; }
            set { this._SIP = value; }
        }

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

        public String Sexo
        {
            get { return this._Sexo; }
            set { this._Sexo = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return this._FechaNacimiento; }
            set { this._FechaNacimiento = value; }
        }

        public ushort Edad
        {
            get { return this._Edad; }
            set { this._Edad = value; }
        }

        public List<Diagnostico> Diagnosticos
        {
            get { return this._Diagnosticos; }
            set { this._Diagnosticos = value; }
        }

        #endregion


        #region Métodos

        public void MostrarUltimoDiagnostico()
        {

        }

        public void DarAlta()
        {

        }

        #endregion


        #region Constructores

        public Paciente()
        {

        }

        public Paciente(String sip, String nombre, String apellidos, String sexo, DateTime fechaNacimiento, ushort edad, List<Diagnostico> diagnosticos)
        {
            this.SIP = sip;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
            this.Diagnosticos = new List<Diagnostico>();
        }

        public Paciente(Paciente obj)
        {
            this.SIP = obj.SIP;
            this.Nombre = obj.Nombre;
            this.Apellidos = obj.Apellidos;
            this.Sexo = obj.Sexo;
            this.FechaNacimiento = obj.FechaNacimiento;
            this.Edad = obj.Edad;
            this.Diagnosticos = new List<Diagnostico>();
        }

        #endregion
    }
}
