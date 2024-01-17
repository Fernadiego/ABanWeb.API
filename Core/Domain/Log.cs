
using System;

namespace Core.Domain
{
    public class Log
    {
        public Log(string origen, string descripcion, string mensaje, string exception)
        {
            _Origen = origen;
            _Descripcion = descripcion;
            _Mensaje = mensaje;
            _Exception = exception;
            _Fecha = DateTime.Now;
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Origen;

        public string Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }

        private string _Mensaje;

        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Exception;

        public string Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }

        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
    }
}
