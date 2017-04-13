using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaClinica
{
    [Serializable]
    class Diagnostico
    {
        #region Atributos y Propiedades

        private String _Descripcion;
        private enum EnumTipoDiagnostico
        {
            Alta, Leve, Grave, MuyGrave
        }
        private String _TipoDiagnostico;
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

        public String TipoDiagnostico
        {
            get { return this._TipoDiagnostico; }
            set { this._TipoDiagnostico = value; }
        }

        #endregion


        #region Métodos

        public Boolean EsAlta()
        {
            if (this.TipoDiagnostico == "Alta")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Tratar()
        {
            this.Tratamiento = new Tratamiento();
        }

        public Object LeeEnum(String tipoDiagnostico)
        {
            String[] opcionesDisponibles = Enum.GetNames(typeof(EnumTipoDiagnostico));
            String tipoDiagnosticoIntroducido;

            opcionesDisponibles[3].Insert(0, "Muy Grave");

            while (true)
            {
                if (Enum.IsDefined(typeof(EnumTipoDiagnostico), tipoDiagnostico))
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
                    this.TipoDiagnostico = Enum.GetName(typeof(EnumTipoDiagnostico), tipoDiagnostico);
                    return (EnumTipoDiagnostico)Enum.Parse(typeof(EnumTipoDiagnostico), tipoDiagnostico);
                }
            }                      
        }

        public override string ToString()
        {
            return String.Format("Datos Diagnóstico \n Descripción: {0} \n Tipo de Diagnóstico: {1} \n Tratamiento: {2}", this.Descripcion, this.TipoDiagnostico, this.Tratamiento);
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
