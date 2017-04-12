using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    class Habitacion
    {
        #region Atributos y Propiedades

        private static int _SiguienteNumero;
        private int _Numero;
        private Boolean _Ocupada;
        private enum Especialidad
        {
            Alergología, AnestesiologíayReanimación, Cardiología, Dermatología, Endocrinología, Gastroenterología, Geriatría, Ginecología, HematologíaYHemoterapia, HidrologíaMedica, Infectología, MedicinaAeroespacial, MedicinaDelDeporte, MedicinaDelTrabajo, MedicinaDeUrgencias, MedicinaFamiliarYComunitaria, MedicinaFísicaYRehabilitación, MedicinaIntensiva, MedicinaInterna, MedicinaLegalYForense, MedicinaPaliativa, MedicinaPreventivaYSaludPública, Nefrología, Neonatología, Neumología, Neurología, Nutriología, ObstetriciaespecialidadMédicaYObstetriciamatronería, Oftalmología, OncologíaMédica, OncologíaRadioterápica, Pediatría, Psiquiatría, Rehabilitación, Reumatología, ToxicologíaYUrología
        }

        public int SiguienteNumero
        {
            get { return Habitacion._SiguienteNumero; }
            set { Habitacion._SiguienteNumero = value; }
        }

        public int Numero
        {
            get { return this._Numero; }
            set { this._Numero = value; }
        }

        public String Ocupada
        {
            get
            {
                if (this._Ocupada == true)
                {
                    return "Ocupada";
                }
                else
                {
                    return "Libre";
                }
            }            
        }

        #endregion


        #region Métodos

        public Object LeeEnum(String especialidad)
        {
            String[] opcionesDisponibles = Enum.GetNames(typeof(Especialidad));
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
                if (!Enum.IsDefined(typeof(Especialidad), especialidad))
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
                    return (Especialidad)Enum.Parse(typeof(Especialidad), especialidad);
                }
            }
        }

        public void IngresarPaciente()
        {

        }

        public void QuitarPaciente()
        {

        }

        public void BorrarHabitacion()
        {

        }

        public void AnnadirHabitacion()
        {

        }

        public void MostrarEspecialidad()
        {

        }

        public void CambiarEspecialidad()
        {

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
