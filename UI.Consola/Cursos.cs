using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Cursos
    {
        private CursoLogic _cursoNegocio;

        public CursoLogic CursoNegocio { get { return _cursoNegocio; } set { _cursoNegocio = value; } }

        public Cursos()
        {
             _cursoNegocio = new CursoLogic();
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
            foreach(Curso curs in CursoNegocio.GetAll())
            {
                MostrarDatos(curs);
            }
        }

        public void MostrarDatos(Curso curs)
        {
            Console.WriteLine("Inscripcion: {0}", curs.ID);
            Console.WriteLine("\t\tID Alumno: {0}", curs.IdComision);
            Console.WriteLine("\t\tID Curso: {0}", curs.IdMateria);
            Console.WriteLine("\t\tCondicion de Alumno: {0}", curs.AnioCalendario);
            Console.WriteLine("\t\tNota: {0}", curs.Cupo);
            Console.WriteLine();
        }

        public void Consultar()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Ingresa el ID del curso a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(CursoNegocio.GetOne(ID));
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
                Console.WriteLine("Ingrese el ID del curso a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Curso curso = CursoNegocio.GetOne(ID);
                Console.WriteLine("Ingrese ID comision: ");
                curso.IdComision = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese ID materia: ");
                curso.IdMateria = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese anio calendario: ");
                curso.AnioCalendario =int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese cupo: ");
                curso.Cupo = int.Parse(Console.ReadLine());
                curso.State = BusinessEntity.States.Modified;
                CursoNegocio.Save(curso);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
                Console.WriteLine(fe);
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

            Curso curso = new Curso();

            Console.Clear();

            Console.WriteLine("Ingrese id comision: ");
            curso.IdComision = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese id materia: ");
            curso.IdMateria = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese anio calendario: ");
            curso.AnioCalendario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Cupo: ");
            curso.Cupo = int.Parse(Console.ReadLine());
            curso.State = BusinessEntity.States.New;
            CursoNegocio.Save(curso);

            Console.WriteLine();
            Console.WriteLine("ID: {0}", curso.ID);

        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del curso a eliminar");
                int ID = int.Parse(Console.ReadLine());
                CursoNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La id ingresada debe ser un numero entero");
                Console.WriteLine(fe);
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
