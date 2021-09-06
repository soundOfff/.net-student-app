using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario: BusinessEntity
    {
        private string _nombre;
        private string _apellido;
        private string _password;
        private string _nombreUsuario;
        private string _email;
        private bool _habilitado;
        private int _IDpersona;
        private byte[] _imagen;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Clave { get { return _password; } set { _password = value; } }
        public string NombreUsuario { get { return _nombreUsuario; } set { _nombreUsuario = value; } }
        public string EMail { get { return _email; } set { _email = value; } }
        public bool Habilitado { get { return _habilitado; } set { _habilitado = value; } }
        public int IDpersona { get { return _IDpersona; } set { _IDpersona = value; } }
        public byte[] Imagen { get { return _imagen; } set { _imagen = value; } }


    }
}
