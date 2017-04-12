using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    class Diagnostico
    {
        #region Atributos y Propiedades

        private String _Descripcion;
        private enum TipoDiagnostico
        {
            Alta, Leve, Grave, MuyGrave
        }
        private Tratamiento _Tratamiento;

        public String Descripcion 
        {
            get { return this._Descripcion; }
            set { this._Descripcion = value; }
        }        

        public Tratamiento Tratamiento
        {
            get { return this._Tratamiento; }
            set { this._Tratamiento = value; }
        }

        #endregion


        #region Métodos

        public void EsAlta()
        {

        }

        public Object LeeEnum(String tipoDiagnostico)
        {
            String[] opcionesDisponibles = Enum.GetNames(typeof(TipoDiagnostico));
            String tipoDiagnosticoIntroducido;

            opcionesDisponibles[3].Insert(0, "Muy Grave");

            while (true)
            {
                if (Enum.IsDefined(typeof(TipoDiagnostico), tipoDiagnostico))
                {
                    for (int i = 0; i < opcionesDisponibles.Length; i++)
                    {
                        Console.WriteLine(opcionesDisponibles[i]);
                    }

                    Console.WriteLine("\n Introduce el tipo de Diagnóstico: ");
                    tipoDiagnosticoIntroducido = Console.ReadLine();
                }
                else
                {
                    return (TipoDiagnostico)Enum.Parse(typeof(TipoDiagnostico), tipoDiagnostico);
                }
            }                      
        }

        #endregion


        #region Constructores

        public Diagnostico()
        {

        }

        public Diagnostico(String descripcion, String tipoDiagnostico, Tratamiento tratamiento)       
        {
            this.Descripcion = descripcion;
            LeeEnum(tipoDiagnostico);
            this.Tratamiento = new Tratamiento(tratamiento);
        }

        public Diagnostico(Diagnostico obj)
        {
            this.Descripcion = obj.Descripcion;            
            this.Tratamiento = obj.Tratamiento;
        }

        #endregion
    }
}
