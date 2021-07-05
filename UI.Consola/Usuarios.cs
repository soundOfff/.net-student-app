using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _usuarioNegocio;
        public UsuarioLogic UsuarioNegocio { get { return _usuarioNegocio; } set { _usuarioNegocio = value; } }

        public Usuarios()
        {
            _usuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            Console.WriteLine("1–Listado General\n2– Consulta\n3– Agregar\n4 - Modificar\n5 - Eliminar\n6 - Salir  ");
            int op = int.Parse(Console.ReadLine());
            while (op != 6)
            {
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Case 1");
                        break;
                    case 2:
                        Console.WriteLine("Case 2");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario user in UsuarioNegocio.GetAll())
            {
                MostrarDatos(user);
            }
        }

        public void MostrarDatos(Usuario user)
        {
            Console.WriteLine("Usuario: {0}", user.ID);
            Console.WriteLine("\t\tNombre: {0}", user.Nombre);
            Console.WriteLine("\t\tApellido: {0}", user.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", user.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", user.Clave);
            Console.WriteLine("\t\tEmail: {0}", user.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", user.Habilitado);
            Console.WriteLine();
        }

        public void Consultar()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Ingresa el ID del usuario a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException)
            {
                Console.WriteLine("La id ingresada debe ser un entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("Mensaje: {0}", e.Message);
            }
        }





    }
}
