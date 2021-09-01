using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Data.Database
{
    public class InscripcionAdapter: Adapter
    {
        public ArrayList GetAll()
        {
             ArrayList infoExamenes = new ArrayList();

            try
            {       //ins.IdAlumno = (int)drInscripciones["id_alumno"];
                    // ins.IdCurso = (int)drInscripciones["id_curso"];

                string query = @"SELECT materias.desc_materia, alumnos_inscripciones.nota, especialidades.desc_especialidad, planes.desc_plan 
                                FROM alumnos_inscripciones 
                                INNER JOIN cursos 
	                                ON cursos.id_curso = alumnos_inscripciones.id_curso
                                INNER JOIN materias
	                                ON materias.id_materia = cursos.id_materia
                                INNER JOIN planes
	                                ON planes.id_plan = materias.id_plan
                                INNER JOIN especialidades
	                                ON especialidades.id_especialidad = planes.id_especialidad";

                this.OpenConnection();
                SqlCommand cmdExamenes = new SqlCommand(query, SqlConn);
                SqlDataReader drExamenes = cmdExamenes.ExecuteReader();
                while (drExamenes.Read())
                {
                    infoExamenes.Add(new { DescMateria = (string)drExamenes["desc_materia"],
                        Nota = (int)drExamenes["nota"],
                        DescEspecialidad = (string)drExamenes["desc_especialidad"],
                        DescPlan = (string)drExamenes["desc_plan"]
                    });
                }

                drExamenes.Close();
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
            return infoExamenes;


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


    }
}
