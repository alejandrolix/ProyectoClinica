using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProgramaClinica
{
    [Serializable]
    class Clinica
    {
        #region Atributos y Propiedades

        private String _Direccion;
        private String _Nombre;
        private String _Telefono;
        private List<Medico> _Medicos;
        private List<Enfermero> _Enfermeros;
        private List<Habitacion> _Habitaciones;

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
            set
            {
                Regex patron = new Regex(@"^[0-9]{9}$");
                Boolean repetirTelefono = true;

                while (repetirTelefono)
                {
                    if (patron.IsMatch(value))
                    {
                        repetirTelefono = false;
                        this._Telefono = value;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error, el nº de teléfono ha de tener 9 dígitos.");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
            }
        }

        public List<Medico> Medicos
        {
            get { return this._Medicos; }
            set { this._Medicos = value; }
        }

        public List<Enfermero> Enfermeros
        {
            get { return this._Enfermeros; }
            set { this._Enfermeros = value; }
        }

        public List<Habitacion> Habitaciones
        {
            get { return this._Habitaciones; }
            set { this._Habitaciones = value; }
        }

        #endregion


        #region Métodos

        public void AnnadirMedico()
        {
            Boolean repetirNombre = true, repetirApellidos = true, repetirDni = true, repetirEspecialidad = true;
            String nombreIntroducido, apellidosIntroducidos, dniIntroducido, especialidadIntroducida;

            Console.Clear();

            while (repetirNombre)
            {
                Console.Write("Introduce el nombre: ");
                nombreIntroducido = Console.ReadLine();

                if (nombreIntroducido == "")
                {
                    Console.Clear();

                    Console.WriteLine("Error, tienes que introducir un nombre.");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
                else
                {
                    repetirNombre = false;

                    while (repetirApellidos)
                    {
                        Console.Clear();

                        Console.Write("Introduce los apellidos: ");
                        apellidosIntroducidos = Console.ReadLine();

                        if (apellidosIntroducidos == "")
                        {
                            Console.Clear();

                            Console.WriteLine("Error, tienes que introducir unos apellidos.");
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        else
                        {
                            repetirApellidos = false;

                            while (repetirDni)
                            {
                                Console.Clear();

                                Console.Write("Introduce el D.N.I.: ");
                                dniIntroducido = Console.ReadLine();

                                if (dniIntroducido == "")
                                {
                                    Console.Clear();

                                    Console.WriteLine("Error, tienes que introducir un D.N.I.");
                                    System.Threading.Thread.Sleep(5000);
                                    Console.Clear();
                                }
                                else
                                {
                                    repetirDni = false;

                                    while (repetirEspecialidad)
	                                {
	                                    Console.Clear();

                                        Console.Write("Introduce la especialidad: ");
                                        especialidadIntroducida = Console.ReadLine();

                                        if (especialidadIntroducida == "")
                                        {
                                            Console.Clear();

                                            Console.WriteLine("Error, tienes que introducir una especialidad.");
                                            System.Threading.Thread.Sleep(5000);
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            repetirEspecialidad = false;
                                            this.Medicos.Add(new Medico(nombreIntroducido, apellidosIntroducidos, dniIntroducido, especialidadIntroducida));
                                        }
	                                }                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AnnadirEnfermero()
        {
            Boolean repetirNombre = true, repetirApellidos = true, repetirDni = true;
            String nombreIntroducido, apellidosIntroducidos, dniIntroducido;

            Console.Clear();

            while (repetirNombre)
            {
                Console.Write("Introduce el nombre: ");
                nombreIntroducido = Console.ReadLine();

                if (nombreIntroducido == "")
                {
                    Console.Clear();

                    Console.WriteLine("Error, tienes que introducir un nombre.");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
                else
                {
                    repetirNombre = false;

                    while (repetirApellidos)
                    {
                        Console.Clear();

                        Console.Write("Introduce los apellidos: ");
                        apellidosIntroducidos = Console.ReadLine();

                        if (apellidosIntroducidos == "")
                        {
                            Console.Clear();

                            Console.WriteLine("Error, tienes que introducir unos apellidos.");
                            System.Threading.Thread.Sleep(5000);
                            Console.Clear();
                        }
                        else
                        {
                            repetirApellidos = false;

                            while (repetirDni)
                            {
                                Console.Clear();

                                Console.Write("Introduce el D.N.I.: ");
                                dniIntroducido = Console.ReadLine();

                                if (dniIntroducido == "")
                                {
                                    Console.Clear();

                                    Console.WriteLine("Error, tienes que introducir un D.N.I.");
                                    System.Threading.Thread.Sleep(5000);
                                    Console.Clear();
                                }
                                else
                                {
                                    repetirDni = false;
                                    this.Enfermeros.Add(new Enfermero(nombreIntroducido, apellidosIntroducidos, dniIntroducido));
                                }
                            }
                        }
                    }
                }
            }
        }

        public void BorrarMedico()
        {
            Boolean repetirDni = true, romperBucle = true;
            String dniIntroducido;

            Console.Clear();

            while (repetirDni)
            {
                Console.Write("Introduce el D.N.I.: ");
                dniIntroducido = Console.ReadLine();

                if (dniIntroducido == "")
                {
                    Console.Clear();

                    Console.WriteLine("Error, tienes que introducir un D.N.I.");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
                else
                {
                    repetirDni = false;

                    for (int i = 0; i < this.Medicos.Count && romperBucle; i++)
                    {
                        if (this.Medicos[i].DNI == dniIntroducido)
                        {
                            romperBucle = false;
                            this.Medicos.Remove(this.Medicos[i]);

                            Console.Clear();
                            Console.WriteLine("Médico Eliminado.");
                            System.Threading.Thread.Sleep(4000);
                        }
                    }
                }
            }
        }

        public void BorrarEnfermero()
        {
            Boolean repetirDni = true, romperBucle = true;
            String dniIntroducido;

            Console.Clear();

            while (repetirDni)
            {
                Console.Write("Introduce el D.N.I.: ");
                dniIntroducido = Console.ReadLine();

                if (dniIntroducido == "")
                {
                    Console.Clear();

                    Console.WriteLine("Error, tienes que introducir un D.N.I.");
                    System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                }
                else
                {
                    repetirDni = false;

                    for (int i = 0; i < this.Enfermeros.Count && romperBucle; i++)
                    {
                        if (this.Enfermeros[i].DNI == dniIntroducido)
                        {
                            romperBucle = false;
                            this.Enfermeros.Remove(this.Enfermeros[i]);

                            Console.Clear();
                            Console.WriteLine("Enfermero Eliminado.");
                            System.Threading.Thread.Sleep(4000);
                        }
                    }
                }
            }
        }

        public void BuscarHabitacion()
        {

        }

        public Medico BuscarMedico(Paciente paciente)
        {
            for (int i = 0; i < this.Medicos.Count; i++)
            {
                if (this.Medicos[i].DNI == paciente.NSIP)
                {
                    return this.Medicos[i];
                }
            }
            return null;
        }

        public Boolean AsignarHabitacion(Habitacion habitacion)
        {
            for (int i = 0; i < this.Habitaciones.Count; i++)
            {
                if (this.Habitaciones[i].Ocupada == false && this.Habitaciones[i].Especialidad == habitacion.Especialidad)
                {
                    return true;
                }
            }
            return false;
        }

        public void AsignarMedico()
        {
            int primerValor = this.Medicos[0].CargaPacientes();

            for (int i = 0; i < this.Medicos.Count; i++)
            {
                if (primerValor < this.Medicos[i].CargaPacientes())
                {
                    // Implementar.
                }

                for (int j = 0; j < this.Medicos.Count; j++)
                {
                    if (this.Medicos[i].CargaPacientes() == this.Medicos[j].CargaPacientes() && i != j)
                    {
                        if ((this.Medicos[i].Nombre.Length < this.Medicos[j].Nombre.Length) && (this.Medicos[i].Apellidos.Length < this.Medicos[j].Apellidos.Length) && (i != j))
                        {
                            // Implementar.
                        }
                    }
                }
            }
        }

        /* public List<Paciente> PacientesListosParaAlta()
        {
            List<Paciente> listaPacientesCurados = new List<Paciente>();

            for (int i = 0; i < this.Medicos.Count; i++)
            {
                listaPacientesCurados.Add(this.Medicos[i].CargaPacientes());
            }
        } */

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

            this.Medicos = new List<Medico>();
            this.Enfermeros = new List<Enfermero>();
            this.Habitaciones = new List<Habitacion>();
        }

        public Clinica(Clinica obj)
        {
            this.Direccion = obj.Direccion;
            this.Nombre = obj.Nombre;
            this.Telefono = obj.Telefono;
            this.Medicos = obj.Medicos;
            this.Enfermeros = obj.Enfermeros;
            this.Habitaciones = obj.Habitaciones;
        }

        #endregion
    }
}
