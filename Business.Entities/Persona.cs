using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona: BusinessEntity
    {
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _telefono;
        private DateTime _fechaNac;
        private string _email;
        private int _legajo;
        private int _tipoPersona;
        private int _IDPlan;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string EMail { get { return _email; } set { _email = value; } }
        public DateTime FechaNac { get { return _fechaNac; } set { _fechaNac = value; } }
        public int Legajo { get { return _legajo; } set { _legajo = value; } }
        public int TipoPersona { get { return _tipoPersona; } set { _tipoPersona = value; } }
        public int IDPlan { get { return _IDPlan; } set { _IDPlan = value; } }

    }
}
