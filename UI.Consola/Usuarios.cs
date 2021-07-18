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
                        ListadoGeneral();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Agregar();
                        break;
                    case 4:
                        Modificar();
                        break;
                    case 5:
                        Eliminar();
                        break;
                    case 6:
                        op = 6;
                        break;
                    default:
                        Console.WriteLine("Yo por ahi no paso");
                        break;
                }
                Console.WriteLine("1–Listado General\n2– Consulta\n3– Agregar\n4 - Modificar\n5 - Eliminar\n6 - Salir  ");
                op = int.Parse(Console.ReadLine());
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
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese email: ");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese habilitacion de usuario (1-Si / otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("Mensaje: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }
        public void Agregar()
        {

            Usuario usuario = new Usuario();

            Console.Clear();

            Console.WriteLine("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese clave: ");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese email: ");
            usuario.EMail = Console.ReadLine();
            Console.WriteLine("Ingrese habilitacion de usuario (1-Si / otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);

            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);

        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a eliminar");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La id ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }






    }
}
