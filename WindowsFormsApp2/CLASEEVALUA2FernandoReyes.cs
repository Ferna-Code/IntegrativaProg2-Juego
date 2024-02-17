using System;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
   
    class CLASEEVALUA2FernandoReyes
    {
        
        private DateTime fecha = DateTime.Now;
        private string rut;
      
        private DateTime InicioSecion;
        private string accion;
        private DateTime accionF;
        private DateTime FinSesion;
        private string FinSecionTxt;
        public CLASEEVALUA2FernandoReyes()
        {

            this.rut = "11111111-1";
            this.InicioSecion = fecha;
            this.FinSesion = fecha;
            this.accion = "NULL";
            this.accionF = fecha;
            
        }

        public CLASEEVALUA2FernandoReyes(string rut, DateTime iniciosecion, DateTime finsecion, string accion, DateTime accionf)
        {
            DateTime fecha = DateTime.MinValue;
            this.rut = rut;
            this.InicioSecion = iniciosecion;
            this.accion = accion;
            this.accionF = accionf;
            this.FinSesion = finsecion;
           
        }

        
        //public string GetSetRana
        //{
        //    get { return salioRana; }
        //    set { this.salioRana = value; }
        //}
        //public string GetSetOlla
        //{
        //    get { return salioOlla; }
        //    set { this.salioOlla = value; }
        //}
        public DateTime GetSetFin
        {
            get { return FinSesion; }
            set { this.FinSesion = value; }
        }
        public string GetSetTxt
        {
            get { return FinSecionTxt; }
            set { this.FinSecionTxt = value; }
        }
        public string GetSetRut
        {
            get { return rut; }
            set { this.rut = value; }
        }

        public DateTime GetSetInicio
        {
            get { return InicioSecion; }
            set { this.InicioSecion = value; }
        }
        public string GetSetAccion
        {
            get { return accion; }
            set { this.accion = value; }
        }
        public DateTime GetSeAccionF
        {
            get { return accionF; }
            set { this.accionF = value; }
        }
    }
}
