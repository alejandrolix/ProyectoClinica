using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
    class Habitacion
    {
        #region Atributos y Propiedades

        private int _Numero;
        private Boolean _Ocupada;
        private enum EnumEspecialidad
        {
            Alergología, AnestesiologíayReanimación, Cardiología, Dermatología, Endocrinología, Gastroenterología, Geriatría, Ginecología, HematologíaYHemoterapia, HidrologíaMedica, Infectología, MedicinaAeroespacial, MedicinaDelDeporte, MedicinaDelTrabajo, MedicinaDeUrgencias, MedicinaFamiliarYComunitaria, MedicinaFísicaYRehabilitación, MedicinaIntensiva, MedicinaInterna, MedicinaLegalYForense, MedicinaPaliativa, MedicinaPreventivaYSaludPública, Nefrología, Neonatología, Neumología, Neurología, Nutriología, ObstetriciaespecialidadMédicaYObstetriciamatronería, Oftalmología, OncologíaMédica, OncologíaRadioterápica, Pediatría, Psiquiatría, Rehabilitación, Reumatología, ToxicologíaYUrología
        }
        private String _Especialidad;        

        public int Numero
        {
            get { return this._Numero; }
            set { this._Numero = value; }
        }

        public Boolean Ocupada
        {
            get { return this._Ocupada; }
            set { this._Ocupada = value; }
        }

        public String Especialidad
        {
            get { return this._Especialidad; }
            set { this._Especialidad = value; }
        }

        #endregion


        #region Métodos

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
                    this.Especialidad = (String)Enum.Parse(typeof(EnumEspecialidad), especialidad);
                    return (EnumEspecialidad)Enum.Parse(typeof(EnumEspecialidad), especialidad);
                }
            }
        }

        public void IngresarPaciente()
        {
            this._Ocupada = true;
        }

        public void QuitarPaciente()
        {
            this._Ocupada = false;
        }

        public void BorrarHabitacion(Habitacion habitacion)
        {
            habitacion = null;
        }

        public void AnnadirHabitacion()
        {
            String especialidadIntroducida;            

            Console.WriteLine("Introduce una especialidad: ");
            especialidadIntroducida = Console.ReadLine();

            LeeEnum(especialidadIntroducida);

            Habitacion habitacion = new Habitacion(this.Numero++, false, especialidadIntroducida);
        }

        public void MostrarEspecialidad(Habitacion habitacion)
        {
            Console.Clear();
            Console.WriteLine("Especialidad: " + habitacion.Especialidad);            
        }

        public void CambiarEspecialidad(Habitacion habitacion)
        {
            String especialidadIntroducida;

            if (this.Numero == habitacion.Numero && this.Ocupada == habitacion.Ocupada)
            {
                Console.Clear();
                Console.Write("Introduce la nueva especialidad: ");
                especialidadIntroducida = Console.ReadLine();

                LeeEnum(especialidadIntroducida);

                Console.Clear();
                Console.WriteLine("Especialidad cambiada.");
                System.Threading.Thread.Sleep(4000);

                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error, no se ha podido cambiar la especialidad.");
                System.Threading.Thread.Sleep(4000);

                Console.Clear();
            }
        }

        #endregion


        #region Constructores

        public Habitacion()
        {

        }

        public Habitacion(int numero, Boolean ocupada, String especialidad)
        {
            this.Numero = numero;
            this._Ocupada = ocupada;
            LeeEnum(especialidad);
        }

        public Habitacion(Habitacion obj)
        {
            this.Numero = obj.Numero;
            this._Ocupada = obj._Ocupada;
        }

        #endregion
    }
}
