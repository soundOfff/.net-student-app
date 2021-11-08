using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace Data.Database
{
    public class InscripcionAdapter: Adapter
    {
        public List<Inscripcion> GetAll()
        {
            List<Inscripcion> Inscripciones = new List<Inscripcion>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones", SqlConn);
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {

                    // Ver que datos tengo que mostrar
                    Inscripcion ins = new Inscripcion();
                    ins.IdAlumno = (int)drInscripciones["id_alumno"];
                    ins.IdCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];
                    Inscripciones.Add(ins);
                }

                drInscripciones.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de Inscripciones", Ex);
                throw ExcepcionManejada;


            }
            finally
            {
                this.CloseConnection();
            }
            return Inscripciones;


        }

        public ArrayList getAllMateriasInscripcion() {

            ArrayList materiasInscripciones = new ArrayList();

            try
            {

                this.OpenConnection();
                string query = @"SELECT alumnos_inscripciones.id_curso, mat.desc_materia, 
		                        mat.hs_totales, mat.hs_semanales, mat.id_plan, mat.id_materia,
		                        comisiones.desc_comision, alumnos_inscripciones.id_inscripcion 
                                FROM alumnos_inscripciones
                                INNER JOIN cursos
	                                ON cursos.id_curso = alumnos_inscripciones.id_curso
                                INNER JOIN materias mat
	                                ON mat.id_materia = cursos.id_curso
                                INNER JOIN comisiones
	                                ON cursos.id_comision = comisiones.id_comision";
                SqlCommand cmdInscripciones = new SqlCommand(query, SqlConn);
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                while (drInscripciones.Read())
                {
                    materiasInscripciones.Add(new {
                        IDMateria = (int)drInscripciones["id_materia"],
                        DescMateria = (string)drInscripciones["desc_materia"],
                        HsSemanales = (int)drInscripciones["hs_semanales"],
                        HsTotales = (int)drInscripciones["hs_totales"],
                        IDcurso = (int)drInscripciones["id_curso"],
                        IDplan = (int)drInscripciones["id_plan"],
                        DescComision = (string)drInscripciones["desc_comision"],
                        IDinscripcion = (int)drInscripciones["id_inscripcion"]
                    });                
                }
                drInscripciones.Close();
            }
            catch( Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materiasInscripciones;
        }




        public Inscripcion GetOne(int ID)
        {
            Inscripcion ins = new Inscripcion();

            try
            {
                this.OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("SELECT * FROM alumnos_incripciones where id_inscripcion = @id ", SqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();
                if (drInscripciones.Read())
                {
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IdAlumno = (int)drInscripciones["id_alumno"];
                    ins.IdCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];

                }
                drInscripciones.Close();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la inscripcion", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
            return ins;


        }

        public bool getUserAlreadyInscript(int idCurso, int idAlu)
        {
            Inscripcion ins = new Inscripcion();

            try
            {
                this.OpenConnection();
                SqlCommand cmdInscript = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso = @idCurso AND id_alumno = @idAlumno", SqlConn);
                cmdInscript.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                cmdInscript.Parameters.Add("@idAlumno", SqlDbType.Int).Value = idAlu;
                SqlDataReader drInscripciones = cmdInscript.ExecuteReader();
                if (drInscripciones.Read())
                {
                    //MessageBox.Show(Convert.ToString((int)drInscript["id_inscripcion"]));
                    // Ver como hacer para sacar el objeto y usar una variable
                    ins.ID = (int)drInscripciones["id_inscripcion"];
                    ins.IdAlumno = (int)drInscripciones["id_alumno"];
                    ins.IdCurso = (int)drInscripciones["id_curso"];
                    ins.Condicion = (string)drInscripciones["condicion"];
                    ins.Nota = (int)drInscripciones["nota"];

                    //idStr = Convert.ToString((int)drInscript["id_inscripcion"]);
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return ins.ID == 0 ? false : true;
            
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_incripciones where id_inscripcion = @id ", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al elminiar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Inscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }

        protected void Insert(Inscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota) " +
                     "values(@id_alumno, @id_curso, @condicion, @nota) " + 
                     "select @@identity", SqlConn);

                
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Inscripcion", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }


        }

        protected void Update(Inscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Update alumnos_inscripciones SET id_alumno = @id_alumno, " +
                    "id_curso = @id_curso, condicion = @condicion, nota = @nota, " + 
                    "id_inscripcion = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la Inscripcion", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }
        public List<Persona> getAlumnosCurso(int idCurso)
        {
           
            List<Persona> alumnos = new List<Persona>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdInscript = new SqlCommand("SELECT distinct personas.legajo, personas.nombre, personas.apellido FROM alumnos_inscripciones " +
                    "INNER JOIN personas " +
                     "ON personas.id_persona = alumnos_inscripciones.id_alumno " +
                    "WHERE alumnos_inscripciones.id_curso = @idCurso", SqlConn);
                cmdInscript.Parameters.Add("@idCurso", SqlDbType.Int).Value = idCurso;
                SqlDataReader drInscripciones = cmdInscript.ExecuteReader();
                while (drInscripciones.Read())
                {
              
                    
                    Persona alum = new Persona();
                    alum.Legajo = (int)drInscripciones["legajo"];
                    alum.Nombre = (string)drInscripciones["nombre"];
                    alum.Apellido = (string)drInscripciones["apellido"];
                    alumnos.Add(alum);
                   
                }
                drInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la Inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return alumnos;

        }

    }
}
