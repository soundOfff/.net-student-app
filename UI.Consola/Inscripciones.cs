using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Inscripciones
    {

        private InscripcionLogic _incripcionNegocio;

        public InscripcionLogic InscripcionNegocio { get { return _incripcionNegocio; } set { _incripcionNegocio = value; } }


        public Inscripciones()
        {
            _incripcionNegocio = new InscripcionLogic();
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
            foreach (Inscripcion insc in InscripcionNegocio.GetAll())
            {
                MostrarDatos(insc);
            }
        }

        public void MostrarDatos(Inscripcion insc)
        {
            Console.WriteLine("Inscripcion: {0}", insc.ID);
            Console.WriteLine("\t\tID Alumno: {0}", insc.IdAlumno);
            Console.WriteLine("\t\tID Curso: {0}", insc.IdCurso);
            Console.WriteLine("\t\tCondicion de Alumno: {0}", insc.Condicion);
            Console.WriteLine("\t\tNota: {0}", insc.Nota);
            Console.WriteLine();
        }

        public void Consultar()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Ingresa el ID de la inscripcion a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(InscripcionNegocio.GetOne(ID));
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
                Inscripcion inscripcion = InscripcionNegocio.GetOne(ID);
                Console.WriteLine("Ingrese ID alumno: ");
                inscripcion.IdAlumno = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese ID curos: ");
                inscripcion.IdCurso = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese Condicion Aluno: ");
                inscripcion.Condicion = Console.ReadLine();
                Console.WriteLine("Ingrese Nota Alumno: ");
                inscripcion.Nota = int.Parse(Console.ReadLine());
                inscripcion.State = BusinessEntity.States.Modified;
                InscripcionNegocio.Save(inscripcion);
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

            Inscripcion inscripcion = new Inscripcion();

            Console.Clear();

            Console.WriteLine("Ingrese id_Alumno: ");
            inscripcion.IdAlumno = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese IdCurso: ");
            inscripcion.IdCurso = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Condicion Alumno: ");
            inscripcion.Condicion = Console.ReadLine();
            Console.WriteLine("Ingrese Nota Alumno: ");
            inscripcion.Nota = int.Parse(Console.ReadLine());
            inscripcion.State = BusinessEntity.States.New;
            InscripcionNegocio.Save(inscripcion);

            Console.WriteLine();
            Console.WriteLine("ID: {0}", inscripcion.ID);

        }


        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID de inscripcion a eliminar");
                int ID = int.Parse(Console.ReadLine());
                InscripcionNegocio.Delete(ID);
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
