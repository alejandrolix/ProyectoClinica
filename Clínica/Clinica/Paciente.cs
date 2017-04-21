using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
    class Paciente
    {
        #region Atributos y Propiedades

        private String _NSIP;
        private String _Nombre;
        private String _Apellidos;
        private String _Sexo;
        private DateTime _FechaNacimiento;
        private ushort _Edad;
        private List<Diagnostico> _Diagnosticos;
        private Boolean _EstaCurado;
        private Habitacion _Habitacion;

        public String NSIP
        {
            get { return this._NSIP; }
            set { this._NSIP = value; }
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
        public Boolean EstaCurado
        {
            get 
            {                
                for (int i = 0; i < this.Diagnosticos.Count; i++)
                {
                    if (this.Diagnosticos[i].TipoDiagnostico == "Alta")
                    {                                                
                        return true;                        
                    }
                }
                return false;
            }
            set { this._EstaCurado = value; }
        }
        public Habitacion Habitacion
        {
            get { return this._Habitacion; }
            set { this._Habitacion = value; }
        }

        #endregion


        #region Métodos

        // Método que asigna una habitación a un paciente.
        public void IngresarPaciente(Clinica clinica)
        {            
            clinica.AsignarHabitacion(this.Habitacion);
            clinica.AsignarMedico();
        }

        // Método que devuelve "True" si el paciente está dado de alta.
        public Boolean AltaPaciente(Clinica clinica)
        {
            if (this.EstaCurado == false)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < clinica.Medicos.Count; i++)
                {
                    if (this.NSIP == clinica.Medicos[i].Pacientes[i].NSIP)
                    {
                        // clinica.Medicos.Remove(clinica.Medicos[i].QuitarPaciente(clinica.Medicos[i].Pacientes[i]));
                        this.Habitacion.QuitarPaciente();
                        return true;
                    }
                }
                return false;
            }
        }

        // Método que muestra los datos de un paciente.
        public void MostrarDatosPaciente(Paciente paciente)
        {            
            String nispIntroducido;
            Boolean repetirNISP = true;

            while (repetirNISP)
            {
                Console.Clear();
                Console.Write("Introduce el N.S.I.P. del paciente:");
                nispIntroducido = Console.ReadLine();

                if (nispIntroducido == "")
                {
                    Console.Clear();
                    Console.WriteLine("Error, tienes que introducir un N.I.S.P.");
                    System.Threading.Thread.Sleep(4000);
                }
                else
                {                    
                    if (nispIntroducido == paciente.NSIP)
                    {
                        repetirNISP = false;

                        Console.Clear();
                        Console.WriteLine(paciente);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error, no has introducido el número correcto.");
                        System.Threading.Thread.Sleep(5000);

                        Console.Clear();
                    }
                }
            }
        }

        // Método que muestra los diagnósticos de un paciente.
        public void Diagnostico(Paciente paciente)
        {
            int numIntroducido;
            Boolean repetirNum = true, repetirNISP = true;
            String nispIntroducido;            
            
            while (repetirNISP)
            {
                Console.Clear();
                Console.Write("Introduce el N.S.I.P. del paciente:");
                nispIntroducido = Console.ReadLine();

                if (nispIntroducido == "")
                {
                    Console.Clear();
                    Console.WriteLine("Error, tienes que introducir un N.I.S.P.");
                    System.Threading.Thread.Sleep(4000);
                }
                else
                {                    
                    if (nispIntroducido == paciente.NSIP)
                    {                        
                        while (repetirNum)
                        {
                            Console.Clear();
                            Console.Write("1. Mostrar Historial Diagnósticos \n 2. Mostrar Último Diagnóstico \n\n Introduce un número: ");
                            numIntroducido = int.Parse(Console.ReadLine());

                            if (numIntroducido >= 1 && numIntroducido <= 6)
                            {
                                repetirNISP = false;

                                switch (numIntroducido)
                                {
                                    case 1:
                                        #region Código

                                        Console.Clear();

                                        for (int i = 0; i < paciente.Diagnosticos.Count; i++)
                                        {
                                            Console.Write("Diagnóstico: " + (i + 1) + "\n\n");
                                            Console.WriteLine(paciente.Diagnosticos[i] + "\n");
                                        }

                                        #endregion

                                        break;

                                    case 2:

                                        MostrarUltimoDiagnostico();
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error, no has introducido el número correcto.");
                                System.Threading.Thread.Sleep(5000);

                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error, el N.S.I.P. introducido no coincide con ningún paciente.");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
            }            
        }

        // Método que muestra el tratamiento del diagnóstico de un paciente.
        public void Tratamiento(Paciente paciente)
        {            
            Boolean repetirNISP = true;
            String nispIntroducido;

            while (repetirNISP)
            {
                Console.Clear();
                Console.Write("Introduce el N.S.I.P. del paciente:");
                nispIntroducido = Console.ReadLine();

                if (nispIntroducido == "")
                {
                    Console.Clear();
                    Console.WriteLine("Error, tienes que introducir un N.I.S.P.");
                    System.Threading.Thread.Sleep(4000);
                }
                else
                {                    
                    if (nispIntroducido == paciente.NSIP)
                    {
                        repetirNISP = false;
                        for (int i = 0; i < paciente.Diagnosticos.Count; i++)
                        {
                            Console.Write("Trtatamiento: " + (i + 1) + "\n\n");
                            Console.WriteLine(paciente.Diagnosticos[i].Tratamiento + "\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error, el N.S.I.P. introducido no coincide con ningún paciente.");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Datos Paciente \n N.S.I.P.: {0} \n Nombre: {1} \n Apellidos: {2} \n Sexo: {3} \n Fecha Nacimiento: {4} \n Edad: {5} \n Diagnósticos: {6}", this.NSIP, this.Nombre, this.Apellidos, this.Sexo, this.FechaNacimiento.ToString("dd/mm/aaaa"), this.Edad, this.Diagnosticos);
        }

        // Método que muestra el último diagnóstico de un paciente.
        public void MostrarUltimoDiagnostico()
        {
            Console.Clear();
            Console.WriteLine(this.Diagnosticos[this.Diagnosticos.Count - 1] + "\n\n");

            Console.WriteLine("Pulsa cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // Método que da de alta un paciente.
        public void DarAlta()
        {            
            this.Habitacion.IngresarPaciente();
        }

        // Método que muestra la especialidad que tiene un paciente.
        public void EspecialidadPaciente(Habitacion habitacion)
        {
            if (this.Habitacion.Numero == habitacion.Numero)
            {
                Console.Clear();
                Console.WriteLine("Especialidad: " + this.Habitacion.Especialidad + "\n");

                Console.WriteLine("Pulsa una tecla para continuar...");
                Console.ReadKey();

                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error, no se ha podido mostrar la especialidad.");
                System.Threading.Thread.Sleep(4000);

                Console.Clear();
            }
        }

        // Método que busca la habitación en la que está un paciente.
        public void BuscarHabitacion(Paciente paciente)
        {
            String nispIntroducido;
            Boolean repetirNISP = true;

            while (repetirNISP)
            {
                Console.Clear();
                Console.Write("Introduce el N.S.I.P. del paciente:");
                nispIntroducido = Console.ReadLine();

                if (nispIntroducido == "")
                {
                    Console.Clear();
                    Console.WriteLine("Error, tienes que introducir un N.I.S.P.");
                    System.Threading.Thread.Sleep(4000);                    
                }
                else
                {                   
                    if (nispIntroducido == paciente.NSIP)
                    {
                        repetirNISP = false;

                        Console.Clear();
                        Console.WriteLine("Habitación: " + this.Habitacion.Numero + "\n");

                        Console.WriteLine("Pulsa una tecla para continuar...");
                        Console.ReadKey();

                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error, el N.S.I.P. introducido no coincide con ningún paciente.");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
            }
        }

        // Método que busca el médico al que pertenece un paciente.
        public void BuscarMedico(Paciente paciente, Clinica clinica)
        {
            String nispIntroducido;
            Boolean repetirNISP = true;

            while (repetirNISP)
            {
                Console.Clear();
                Console.Write("Introduce el N.S.I.P. del paciente:");
                nispIntroducido = Console.ReadLine();

                if (nispIntroducido == "")
                {
                    Console.Clear();
                    Console.WriteLine("Error, tienes que introducir un N.I.S.P.");
                    System.Threading.Thread.Sleep(4000);
                }
                else
                {
                    repetirNISP = false;

                    for (int i = 0; i < clinica.Medicos.Count; i++)
                    {
                        if (paciente.NSIP == clinica.Medicos[i].Pacientes[i].NSIP)
                        {
                            Console.Clear();
                            Console.WriteLine("Médico/a: " + clinica.Medicos[i].Nombre + " " + clinica.Medicos[i].Apellidos + "\n");

                            Console.WriteLine("Pulsa una tecla para continuar...");
                            Console.ReadKey();

                            Console.Clear();
                        }
                    }
                }
            }
        }

        // Método que da de baja un paciente.
        public void BajaPaciente(Paciente paciente)
        {
            String nispIntroducido;
            Boolean repetirNISP = true;
            Char letraIntroducida;

            while (repetirNISP)
            {
                Console.Clear();
                Console.Write("Introduce el N.S.I.P. del paciente:");
                nispIntroducido = Console.ReadLine();

                if (nispIntroducido == "")
                {
                    Console.Clear();
                    Console.WriteLine("Error, tienes que introducir un N.I.S.P.");
                    System.Threading.Thread.Sleep(4000);
                }
                else
                {
                    repetirNISP = false;

                    Console.WriteLine(this.Diagnosticos[this.Diagnosticos.Count - 1]);

                    if (this.Diagnosticos[this.Diagnosticos.Count - 1].TipoDiagnostico == "Alta")
                    {
                        Console.Write("\n\n Pulsa la tecla 'a' para dar de alta al paciente: ");
                        letraIntroducida = Char.Parse(Console.ReadLine());

                        if (char.IsUpper(letraIntroducida))
                        {
                            letraIntroducida = char.ToLower(letraIntroducida);
                        }

                        Console.Clear();                        
                        paciente.Habitacion.Ocupada = false;
                        paciente = null;

                        Console.WriteLine("Paciente dado de alta.");
                        System.Threading.Thread.Sleep(4000);
                        Console.Clear();
                    }
                }
            }
        }

        #endregion


        #region Constructores

        public Paciente()
        {

        }

        public Paciente(String nSIP, String nombre, String apellidos, String sexo, DateTime fechaNacimiento, ushort edad, List<Diagnostico> diagnosticos)
        {
            this.NSIP = nSIP;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
            this.Edad = edad;
            this.Diagnosticos = new List<Diagnostico>();
            this.Habitacion = new Habitacion();
        }

        public Paciente(Paciente obj)
        {
            this.NSIP = obj.NSIP;
            this.Nombre = obj.Nombre;
            this.Apellidos = obj.Apellidos;
            this.Sexo = obj.Sexo;
            this.FechaNacimiento = obj.FechaNacimiento;
            this.Edad = obj.Edad;
            this.Diagnosticos = new List<Diagnostico>();
            this.Habitacion = obj.Habitacion;
        }

        #endregion
    }
}
