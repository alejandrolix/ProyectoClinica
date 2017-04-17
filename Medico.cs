using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
    class Medico : Profesional
    {
        #region Atributo y Propiedad

        private enum EnumEspecialidad
        {
            Alergología, AnestesiologíayReanimación, Cardiología, Dermatología, Endocrinología, Gastroenterología, Geriatría, Ginecología, HematologíaYHemoterapia, HidrologíaMedica, Infectología, MedicinaAeroespacial, MedicinaDelDeporte, MedicinaDelTrabajo, MedicinaDeUrgencias, MedicinaFamiliarYComunitaria, MedicinaFísicaYRehabilitación, MedicinaIntensiva, MedicinaInterna, MedicinaLegalYForense, MedicinaPaliativa, MedicinaPreventivaYSaludPública, Nefrología, Neonatología, Neumología, Neurología, Nutriología, ObstetriciaespecialidadMédicaYObstetriciamatronería, Oftalmología, OncologíaMédica, OncologíaRadioterápica, Pediatría, Psiquiatría, Rehabilitación, Reumatología, ToxicologíaYUrología
        }
        private String _Especialidad;

        public String Especialidad
        {
            get { return Enum.GetName(typeof(EnumEspecialidad), this._Especialidad); }
            set { this._Especialidad = value; }
        }

        #endregion


        #region Métodos

        public void Diagnosticar()
        {
            String nispIntroducido, descripcionIntroducida, tipoDiagnIntroducido, tratamientoIntroducido;
            Char letraIntroducida;
            Boolean repetirNISP = true, repetirDescripcion = true, repetirTipoDiagn = true, repetirTratamiento = true, repetirLetraIntroducida = true;

            while (repetirNISP)
            {
                Console.Clear();
                Console.Write("Introduce el N.I.S.P. del paciente: ");
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

                    while (repetirDescripcion)
                    {
                        Console.Clear();
                        Console.Write("Introduce la descripción del diagnóstico: ");
                        descripcionIntroducida = Console.ReadLine();

                        if (descripcionIntroducida == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error, tienes que introducir una descripción.");
                            System.Threading.Thread.Sleep(4000);
                        }
                        else
                        {
                            repetirDescripcion = false;

                            while (repetirTipoDiagn)
                            {
                                Console.Clear();
                                Console.Write("Introduce el tipo de diagnóstico: ");
                                tipoDiagnIntroducido = Console.ReadLine();

                                if (tipoDiagnIntroducido == "")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Error, tienes que introducir un tipo de diagnóstico.");
                                    System.Threading.Thread.Sleep(4000);
                                }
                                else
                                {
                                    repetirTipoDiagn = false;
                                    this.Pacientes[this.Pacientes.Count - 1].Diagnosticos.Add(new Diagnostico(descripcionIntroducida, tipoDiagnIntroducido, new Tratamiento()));                                    

                                    Console.Clear();
                                    Console.WriteLine("Diagnóstico Añadido. \n");

                                    while (repetirLetraIntroducida)
                                    {
                                        Console.Write("Pulsa la tecla 'a' para añadir un tratamiento al diagnóstico: ");
                                        letraIntroducida = Char.Parse(Console.ReadLine());

                                        if (char.IsUpper(letraIntroducida))
                                        {
                                            letraIntroducida = char.ToLower(letraIntroducida);
                                        }

                                        if (letraIntroducida == 'a')
                                        {
                                            repetirLetraIntroducida = false;

                                            while (repetirTratamiento)
                                            {
                                                Console.Clear();
                                                Console.Write("Introduce el tratamiento: ");
                                                tratamientoIntroducido = Console.ReadLine();

                                                if (tratamientoIntroducido == "")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Error, tienes que introducir un tratamiento.");
                                                    System.Threading.Thread.Sleep(4000);
                                                }
                                                else
                                                {
                                                    repetirTratamiento = false;

                                                    this.Pacientes[this.Pacientes.Count - 1].Diagnosticos[this.Pacientes[this.Pacientes.Count - 1].Diagnosticos.Count - 1].Descripcion = descripcionIntroducida;
                                                    this.Pacientes[this.Pacientes.Count - 1].Diagnosticos[this.Pacientes[this.Pacientes.Count - 1].Diagnosticos.Count - 1].TipoDiagnostico = tipoDiagnIntroducido;
                                                    this.Pacientes[this.Pacientes.Count - 1].Diagnosticos[this.Pacientes[this.Pacientes.Count - 1].Diagnosticos.Count - 1].Tratamiento = new Tratamiento(descripcionIntroducida);                                                    

                                                    if (this.Pacientes[this.Pacientes.Count - 1].Diagnosticos.Count > 2)
                                                    {
                                                        this.Pacientes[this.Pacientes.Count - 1].Diagnosticos.Sort();
                                                    }

                                                    Console.Clear();
                                                    Console.WriteLine("Tratamiento añadido al paciente.");
                                                    System.Threading.Thread.Sleep(4000);

                                                    Console.Clear();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Error, tienes que introducir la letra 'a'.");
                                            System.Threading.Thread.Sleep(4000);

                                            Console.Clear();
                                        }
                                    }

                                    if (this.Pacientes.Count > 2)
                                    {
                                        this.Pacientes.Sort();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Tratar(Paciente paciente)
        {
            String tratamientoIntroducido;            
            Boolean repetirTratamiento = true;

            for (int i = 0; i < this.Pacientes.Count; i++)
            {
                if (this.Pacientes[i].NSIP == paciente.NSIP)
                {
                    while (repetirTratamiento)
                    {
                        Console.Clear();
                        Console.Write("Introduce el tratamiento: ");
                        tratamientoIntroducido = Console.ReadLine();

                        if (tratamientoIntroducido == "")
                        {
                            Console.Clear();
                            Console.WriteLine("Error, tienes que introducir un tratamiento.");
                            System.Threading.Thread.Sleep(4000);
                        }
                        else
                        {
                            repetirTratamiento = false;
                            this.Pacientes[i].Diagnosticos[this.Pacientes[i].Diagnosticos.Count - 1].Tratar(tratamientoIntroducido);

                            Console.Clear();
                            Console.WriteLine("Tratamiento Añadido");                            
                            System.Threading.Thread.Sleep(4000);

                            Console.Clear();
                        }
                    }
                }
            }
        }

        public List<Paciente> PacientesListosParaAlta()
        {
            List<Paciente> listaPacientesCurados = new List<Paciente>();

            for (int i = 0; i < this.Pacientes.Count; i++)
            {
                if (this.Pacientes[i].EstaCurado == true)
                {
                    listaPacientesCurados.Add(this.Pacientes[i]);
                }
            }
            return listaPacientesCurados;
        }

        public Object LeeEnum(String especialidad)
        {
            String[] opcionesDisponibles = Enum.GetNames(typeof(EnumEspecialidad));
            String especialidadIntroducida;

            opcionesDisponibles[1].Insert(0, "Anestesiología y Reanimación"); opcionesDisponibles[8].Insert(0, "Hematología y Hemoterapia");
            opcionesDisponibles[11].Insert(0, "Medicina Aeroespacial"); opcionesDisponibles[12].Insert(0, "Medicina del Deporte");
            opcionesDisponibles[13].Insert(0, "Medicina del Trabajo"); opcionesDisponibles[14].Insert(0, "Medicina de Urgencias");
            opcionesDisponibles[15].Insert(0, "Medicina Familiar y Comunitaria"); opcionesDisponibles[16].Insert(0, "Medicina Física y Rehabilitación");
            opcionesDisponibles[17].Insert(0, "Medicina Intensiva"); opcionesDisponibles[18].Insert(0, "Medicina Interna");
            opcionesDisponibles[19].Insert(0, "Medicina Legal y Forense"); opcionesDisponibles[20].Insert(0, "Medicina Paliativa");
            opcionesDisponibles[21].Insert(0, "Medicina Preventiva y Salud Pública"); opcionesDisponibles[27].Insert(0, "Obstetricia (especialidad Médica) y Obstetricia (matronería)");
            opcionesDisponibles[30].Insert(0, "Oncología Radioterápica"); opcionesDisponibles[35].Insert(0, "Toxicología y Urología");

            while (true)
            {
                if (!Enum.IsDefined(typeof(EnumEspecialidad), especialidad))
                {
                    for (int i = 0; i < opcionesDisponibles.Length; i++)
                    {
                        Console.WriteLine(opcionesDisponibles[i]);
                    }

                    Console.WriteLine("Introduce la especialidad: ");
                    especialidadIntroducida = Console.ReadLine();
                }
                else
                {
                    this.Especialidad = Enum.GetName(typeof(EnumEspecialidad), especialidad);
                    return (EnumEspecialidad)Enum.Parse(typeof(EnumEspecialidad), especialidad);
                }
            }
        }

        #endregion


        #region Constructores

        public Medico()
            : base()
        {

        }

        public Medico(String nombre, String apellidos, String dni, String especialidad)
            : base(nombre, apellidos, dni)
        {
            LeeEnum(especialidad);
        }

        public Medico(Medico obj)
            : base(obj)
        {

        }

        #endregion
    }
}
